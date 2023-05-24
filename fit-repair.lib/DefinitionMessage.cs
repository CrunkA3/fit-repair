public class DefinitionMessage
{
    internal DefinitionMessage(int reserved,
                               Architecture architecture,
                               ushort globalMessageNumber,
                               int fieldCount,
                               int developerFieldCount,
                               FieldDefinition[] fieldDefinitions,
                               DeveloperFieldDefinition[]? developerFieldDefinitions)
    {
        Reserved = reserved;
        Architecture = architecture;
        GlobalMessageNumber = globalMessageNumber;
        FieldCount = fieldCount;
        DeveloperFieldCount = developerFieldCount;
        FieldDefinitions = fieldDefinitions;
        DeveloperFieldDefinitions = developerFieldDefinitions;
    }

    public int Reserved { get; init; }
    public Architecture Architecture { get; init; }
    public ushort GlobalMessageNumber { get; init; }
    public int FieldCount { get; init; }
    public int DeveloperFieldCount { get; init; }


    public FieldDefinition[] FieldDefinitions { get; init; }
    public DeveloperFieldDefinition[]? DeveloperFieldDefinitions { get; init; }
}