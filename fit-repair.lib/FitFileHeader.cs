public class FitFileHeader
{

    internal FitFileHeader(int headerSize, int protocolVersion, short profileVersion, int dataSize, string dataType, short crc)
    {
        HeaderSize = headerSize;
        ProtocolVersion = protocolVersion;
        ProfileVersion = profileVersion;
        DataSize = dataSize;
        DataType = dataType;
        CRC = crc;
    }

    /// <summary>
    /// Indicates the length of this file header including header size. Minimum size is 12. This may be increased in future to add additional optional information
    /// </summary>
    public int HeaderSize { get; init; }

    public int ProtocolVersion { get; init; }

    public short ProfileVersion { get; init; }

    public int DataSize { get; init; }

    public string DataType { get; init; }

    public short CRC { get; init; }

}