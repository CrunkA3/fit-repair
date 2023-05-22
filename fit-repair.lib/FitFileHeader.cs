public class FitFileHeader
{
    private readonly byte[] _data;

    internal FitFileHeader(byte[] data)
    {
        _data = data;
    }


    /// <summary>
    /// Indicates the length of this file header including header size. Minimum size is 12. This may be increased in future to add additional optional information
    /// </summary>
    public int HeaderSize => _data[0];


    public int ProtocolVersion => _data[1];
    public short ProfileVersion => BitConverter.ToInt16(_data.AsSpan().Slice(2, 2));
    public int DataSize => BitConverter.ToInt32(_data.AsSpan().Slice(4, 4));
    public string DataType => System.Text.ASCIIEncoding.ASCII.GetString(_data.AsSpan().Slice(8, 4));
    public short CRC => BitConverter.ToInt16(_data.AsSpan().Slice(12, 2));
}