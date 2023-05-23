namespace fit_repair.lib;

public class FitParser
{
    private readonly Stream _stream;
    private readonly Dictionary<short, DefinitionMessage> _definitionMessages = new();

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
        FitFileHeader header = new(buff);

        return header;
    }

    public async Task ReadRecords()
    {
        while (_stream.Position < _stream.Length)
        {
            await ReadRecord();
        }
    }

    private async Task ReadRecord()
    {
        var headerByte = _stream.ReadByte();

        var normalHeader = (headerByte & (1 << 7)) == 0;
        var isDeveloper = (headerByte & (1 << 5)) != 0;
        bool isDefinitionMessage = false;
        short localMessageType;

        //offset in seconds
        short timeOffset = 0;

        if (normalHeader)
        {
            isDefinitionMessage = (headerByte & (1 << 6)) != 0;

            // 0 = Record
            // 1 = Lap
            localMessageType = Convert.ToInt16(string.Join(null, Enumerable.Range(0, 3).Reverse().Select(m => headerByte & (1 << m))), 2);
        }
        else
        {
            localMessageType = Convert.ToInt16(string.Join(null, Enumerable.Range(5, 6).Reverse().Select(m => headerByte & (1 << m))), 2);
            timeOffset = Convert.ToInt16(string.Join(null, Enumerable.Range(0, 4).Reverse().Select(m => headerByte & (1 << m))), 2);
        }

        if (isDefinitionMessage)
        {
            await ReadDefinitionMessage(localMessageType, isDeveloper);
        }
    }

    private async Task ReadDefinitionMessage(short localMessageType, bool isDeveloper)
    {
        DefinitionMessage definitionMessage = new();
        var buff = new byte[5];
        await _stream.ReadExactlyAsync(buff, 0, buff.Length);

        definitionMessage.Reserved = buff[0];
        definitionMessage.Architecture = (Architecture)buff[1];
        definitionMessage.GlobalMessageNumber = BitConverter.ToUInt16(buff.AsSpan());
        definitionMessage.FieldCount = buff[4];

        var fieldsBuff = new byte[definitionMessage.FieldCount * 3];
        await _stream.ReadExactlyAsync(fieldsBuff, 0, fieldsBuff.Length);

        for (int i = 0; i < definitionMessage.FieldCount; i++)
        {
            var fieldBuff = new byte[3];
            await _stream.ReadExactlyAsync(fieldBuff, 0, fieldBuff.Length);
            //TODO: Read Field Definitions
        }



        if (isDeveloper)
        {
            definitionMessage.DeveloperFieldCount = _stream.ReadByte();
            var devFieldsBuff = new byte[definitionMessage.DeveloperFieldCount * 3];
            await _stream.ReadExactlyAsync(devFieldsBuff, 0, devFieldsBuff.Length);

            for (int i = 0; i < definitionMessage.DeveloperFieldCount; i++)
            {
                var fieldBuff = new byte[3];
                await _stream.ReadExactlyAsync(fieldBuff, 0, fieldBuff.Length);
                //TODO: Read Field Definitions

            }
        }

        Console.WriteLine(definitionMessage.GlobalMessageNumber);

        _definitionMessages.Add(localMessageType, definitionMessage);
    }

}
