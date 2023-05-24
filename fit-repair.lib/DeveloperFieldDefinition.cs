public class DeveloperFieldDefinition
{
    internal DeveloperFieldDefinition(byte number, byte size, byte developerDataIndex)
    {
        Number = number;
        Size = size;
        DeveloperDataIndex = developerDataIndex;
    }

    public byte Number { get; init; }
    public byte Size { get; init; }
    public byte DeveloperDataIndex { get; init; }
}