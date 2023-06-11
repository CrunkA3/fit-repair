using System.Collections.Concurrent;

namespace FitRepair;

public class FitParser
{
    private const int HeaderWithCRCSize = 14;

    #region  "Masks"
    private const byte CompressedHeaderMask = 0x80;
    private const byte CompressedTimeMask = 0x1F;
    private const byte CompressedLocalMesgNumMask = 0x60;
    private const byte MesgDefinitionMask = 0x40;
    private const byte DevDataMask = 0x20;
    private const byte LocalMesgNumMask = 0x0F;

    #endregion




    private uint _timeStamp = 0;
    private uint _lastTimeOffset = 0;

    private readonly Stream _stream;

    private readonly ConcurrentDictionary<byte, DefinitionMessage> _definitionMessages = new();
    private readonly List<DataMessage> _dataMessages = new();

    private FitParser(Stream stream)
    {
        _stream = stream;
    }

    public static FitParser Create(Stream stream)
    {
        return new FitParser(stream);
    }

    public async Task<FitFile> Read()
    {
        var header = await ReadHeaderAsync();
        await ReadRecordsAsync();

        return new FitFile(header, _dataMessages);
    }

    private async Task<FitFileHeader> ReadHeaderAsync()
    {
        _stream.Position = 0;

        int size = _stream.ReadByte();
        var buff = new byte[size];
        buff[0] = (byte)size;

        await _stream.ReadAsync(buff, 1, size - 1);
        FitFileHeader header = new(headerSize: buff[0],
                                   protocolVersion: buff[1],
                                   profileVersion: BitConverter.ToUInt16(buff.AsSpan().Slice(2, 2)),
                                   dataSize: BitConverter.ToUInt32(buff.AsSpan().Slice(4, 4)),
                                   dataType: System.Text.ASCIIEncoding.ASCII.GetString(buff.AsSpan().Slice(8, 4)),
                                   crc: (size == HeaderWithCRCSize ? BitConverter.ToUInt16(buff.AsSpan().Slice(12, 2)) : (ushort)0));

        return header;
    }

    private async Task ReadRecordsAsync()
    {
        while (_stream.Position < _stream.Length - 2)
        {
            await ReadRecordAsync();
        }
    }

    private async Task ReadRecordAsync()
    {
        var headerByte = _stream.ReadByte();

        var isCompressedHeader = (headerByte & CompressedHeaderMask) == CompressedHeaderMask;
        var isDeveloper = false;
        var isDefinitionMessage = false;
        byte localMessageType;
        int timeOffset = 0; //offset in seconds


        if (isCompressedHeader)
        {
            timeOffset = headerByte & CompressedTimeMask;
            _timeStamp += (uint)(timeOffset - _lastTimeOffset) & CompressedTimeMask;
            localMessageType = (byte)((headerByte & CompressedLocalMesgNumMask) >> 5);
        }
        else
        {
            isDefinitionMessage = (headerByte & MesgDefinitionMask) == MesgDefinitionMask;
            isDeveloper = (headerByte & DevDataMask) == DevDataMask;

            localMessageType = (byte)(headerByte & LocalMesgNumMask);
        }

        if (isDefinitionMessage)
        {
            await ReadDefinitionMessageAsync(localMessageType, isDeveloper);
        }
        else
        {
            await ReadDataMessageAsync(localMessageType, isCompressedHeader);
        }
    }

    private async Task ReadDefinitionMessageAsync(byte localMessageType, bool isDeveloper)
    {
        var buff = new byte[5];
        await _stream.ReadExactlyAsync(buff, 0, buff.Length);

        var reserved = buff[0];
        var architecture = (Architecture)buff[1];
        var globalMessageNumber = BitConverter.ToUInt16(buff.AsSpan().Slice(2, 2));
        var fieldCount = buff[4];

        var fieldDefinitions = new FieldDefinition[fieldCount];
        for (int i = 0; i < fieldCount; i++)
        {
            var fieldBuff = new byte[3];
            await _stream.ReadExactlyAsync(fieldBuff, 0, fieldBuff.Length);
            fieldDefinitions[i] = new FieldDefinition(number: fieldBuff[0],
                                                     size: fieldBuff[1],
                                                     baseType: fieldBuff[2]);
        }
        //fieldDefinitions = fieldDefinitions.OrderBy(m => m.Number).ToArray();


        var developerFieldCount = 0;
        DeveloperFieldDefinition[]? developerFieldDefinitions = default;
        if (isDeveloper)
        {
            developerFieldCount = _stream.ReadByte();
            developerFieldDefinitions = new DeveloperFieldDefinition[developerFieldCount];

            for (int i = 0; i < developerFieldCount; i++)
            {
                var fieldBuff = new byte[3];
                await _stream.ReadExactlyAsync(fieldBuff, 0, fieldBuff.Length);
                developerFieldDefinitions[i] = new DeveloperFieldDefinition(number: fieldBuff[0],
                                                                            size: fieldBuff[1],
                                                                            developerDataIndex: fieldBuff[2]);
            }
        }

        DefinitionMessage definitionMessage = new(reserved, architecture, globalMessageNumber, fieldCount, developerFieldCount, fieldDefinitions, developerFieldDefinitions);
        Console.WriteLine(definitionMessage.GlobalMessageNumber);

        _definitionMessages.AddOrUpdate(localMessageType, definitionMessage, (k, v) => definitionMessage);
    }

    private async Task ReadDataMessageAsync(byte localMessageType, bool isCompressedHeader)
    {
        if (!_definitionMessages.TryGetValue(localMessageType, out DefinitionMessage? definitionMessage))
            throw new Exception(string.Format("Definition message for message type {0} not found", localMessageType));

        var dataMessage = CreateDataMessage(localMessageType, definitionMessage);

        for (int i = 0; i < definitionMessage.FieldCount; i++)
        {
            var field = definitionMessage.FieldDefinitions[i];
            var buff = new byte[field.Size];
            await _stream.ReadExactlyAsync(buff, 0, buff.Length);
            if (definitionMessage.Architecture == Architecture.BigEndian) buff = buff.Reverse().ToArray();

            dataMessage.AddDataField(new DataField(field, buff));
        }

        if (definitionMessage.DeveloperFieldCount > 0 && definitionMessage.DeveloperFieldDefinitions != null)
        {
            for (int i = 0; i < definitionMessage.DeveloperFieldCount; i++)
            {
                var field = definitionMessage.DeveloperFieldDefinitions[i];
                var buff = new byte[field.Size];
                await _stream.ReadExactlyAsync(buff, 0, buff.Length);
                if (definitionMessage.Architecture == Architecture.BigEndian) buff = buff.Reverse().ToArray();

                dataMessage.AddDeveloperDataField(new DeveloperDataField(field, buff));
            }
        }
        _dataMessages.Add(dataMessage);
    }



    private DataMessage CreateDataMessage(byte localMessageType, DefinitionMessage definitionMessage)
    {
        return (MessageNumber)definitionMessage.GlobalMessageNumber switch
        {
            MessageNumber.FileId => new FileIdMessage(localMessageType),
            _ => new DataMessage(localMessageType),
        };
    }
}
