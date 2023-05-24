namespace fit_repair.lib;

public class FitParser
{
    private readonly Stream _stream;
    private readonly Dictionary<int, DefinitionMessage> _definitionMessages = new();
    private readonly Dictionary<int, DataMessage> _dataMessages = new();

    private FitParser(Stream stream)
    {
        _stream = stream;
    }

    public static FitParser Create(Stream stream)
    {
        return new FitParser(stream);
    }


    public async Task<FitFileHeader> ReadHeaderAsync()
    {
        _stream.Position = 0;

        int size = _stream.ReadByte();
        var buff = new byte[size];
        buff[0] = (byte)size;

        await _stream.ReadAsync(buff, 1, size - 1);
        FitFileHeader header = new(headerSize: buff[0],
                                   protocolVersion: buff[1],
                                   profileVersion: BitConverter.ToInt16(buff.AsSpan().Slice(2, 2)),
                                   dataSize: BitConverter.ToInt32(buff.AsSpan().Slice(4, 4)),
                                   dataType: System.Text.ASCIIEncoding.ASCII.GetString(buff.AsSpan().Slice(8, 4)),
                                   crc: BitConverter.ToInt16(buff.AsSpan().Slice(12, 2)));

        return header;
    }

    public async Task ReadRecordsAsync()
    {
        while (_stream.Position < _stream.Length)
        {
            await ReadRecordAsync();
        }
    }

    private async Task ReadRecordAsync()
    {
        var headerByte = _stream.ReadByte();

        var normalHeader = ((headerByte >> 7) & 1) == 0;
        var isDeveloper = false;
        var isDefinitionMessage = false;
        int localMessageType;
        int timeOffset = 0; //offset in seconds


        if (normalHeader)
        {
            isDefinitionMessage = (headerByte & (1 << 6)) != 0;
            isDeveloper = ((headerByte >> 5) & 1) != 0;

            // 0 = Record
            // 1 = Lap
            localMessageType = (headerByte >> 1) & 1;
        }
        else
        {
            localMessageType = (headerByte >> 1) & 3;
            timeOffset = (headerByte >> 0) & 15;
        }

        if (isDefinitionMessage)
        {
            await ReadDefinitionMessageAsync(localMessageType, isDeveloper);
        }
        else
        {
            await ReadDataMessageAsync(localMessageType);
        }
    }

    private async Task ReadDefinitionMessageAsync(int localMessageType, bool isDeveloper)
    {
        var buff = new byte[5];
        await _stream.ReadExactlyAsync(buff, 0, buff.Length);

        var reserved = buff[0];
        var architecture = (Architecture)buff[1];
        var globalMessageNumber = BitConverter.ToUInt16(buff.AsSpan());
        var fieldCount = buff[4];

        var fieldsBuff = new byte[fieldCount * 3];
        await _stream.ReadExactlyAsync(fieldsBuff, 0, fieldsBuff.Length);

        var fieldDefinition = new FieldDefinition[fieldCount];
        for (int i = 0; i < fieldCount; i++)
        {
            var fieldBuff = new byte[3];
            await _stream.ReadExactlyAsync(fieldBuff, 0, fieldBuff.Length);
            fieldDefinition[i] = new FieldDefinition(number: fieldBuff[0],
                                                     size: fieldBuff[1],
                                                     baseType: fieldBuff[2]);
        }


        var developerFieldCount = 0;
        DeveloperFieldDefinition[]? developerFieldDefinitions = default;
        if (isDeveloper)
        {
            developerFieldCount = _stream.ReadByte();
            developerFieldDefinitions = new DeveloperFieldDefinition[developerFieldCount];

            var devFieldsBuff = new byte[developerFieldCount * 3];
            await _stream.ReadExactlyAsync(devFieldsBuff, 0, devFieldsBuff.Length);

            for (int i = 0; i < developerFieldCount; i++)
            {
                var fieldBuff = new byte[3];
                await _stream.ReadExactlyAsync(fieldBuff, 0, fieldBuff.Length);
                developerFieldDefinitions[i] = new DeveloperFieldDefinition(number: fieldBuff[0],
                                                                            size: fieldBuff[1],
                                                                            developerDataIndex: fieldBuff[2]);
            }
        }

        DefinitionMessage definitionMessage = new(reserved, architecture, globalMessageNumber, fieldCount, developerFieldCount, fieldDefinition, developerFieldDefinitions);
        Console.WriteLine(definitionMessage.GlobalMessageNumber);

        _definitionMessages.Add(localMessageType, definitionMessage);
    }

    private async Task ReadDataMessageAsync(int localMessageType)
    {
        if (!_definitionMessages.TryGetValue(localMessageType, out DefinitionMessage? definitionMessage))
            throw new Exception(string.Format("Definition message for message type {0} not found", localMessageType));

        for (int i = 0; i < definitionMessage.FieldCount; i++)
        {
            var field = definitionMessage.FieldDefinitions[i];
            var buff = new byte[field.Size];
            await _stream.ReadExactlyAsync(buff, 0, buff.Length);
            if (definitionMessage.Architecture == Architecture.BigEndian) buff = buff.Reverse().ToArray();

            //TODO: Save data
        }

        if (definitionMessage.DeveloperFieldCount > 0 && definitionMessage.DeveloperFieldDefinitions != null)
        {
            for (int i = 0; i < definitionMessage.FieldCount; i++)
            {
                var field = definitionMessage.DeveloperFieldDefinitions[i];
                var buff = new byte[field.Size];
                await _stream.ReadExactlyAsync(buff, 0, buff.Length);
                if (definitionMessage.Architecture == Architecture.BigEndian) buff = buff.Reverse().ToArray();

                //TODO: Save data
            }
        }
    }
}
