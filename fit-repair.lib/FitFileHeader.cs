public class FitFileHeader
{

    internal FitFileHeader(uint headerSize, byte protocolVersion, ushort profileVersion, uint dataSize, string dataType, ushort crc)
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
    public uint HeaderSize { get; init; }

    public byte ProtocolVersion { get; init; }

    public ushort ProfileVersion { get; init; }

    public uint DataSize { get; init; }

    public string DataType { get; init; }

    public ushort CRC { get; init; }

}