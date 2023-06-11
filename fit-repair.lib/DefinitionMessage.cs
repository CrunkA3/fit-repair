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

    public int Reserved { get; private init; }
    public Architecture Architecture { get; private init; }
    public ushort GlobalMessageNumber { get; private init; }
    public int FieldCount { get; private init; }
    public int DeveloperFieldCount { get; private init; }


    public FieldDefinition[] FieldDefinitions { get; init; }
    public DeveloperFieldDefinition[]? DeveloperFieldDefinitions { get; private init; }
}