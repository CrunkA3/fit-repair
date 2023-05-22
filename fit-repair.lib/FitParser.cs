namespace fit_repair.lib;

public class FitParser
{
    private Stream _stream;

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
        using BinaryReader reader = new(_stream);

        byte size = reader.ReadByte();
        var buff = new byte[size];
        buff[0] = size;

        await _stream.ReadAsync(buff, 1, size - 1);
        FitFileHeader header = new(buff);

        return header;
    }

}
