public class DefinitionMessage
{
    public int Reserved { get; internal set; }
    public Architecture Architecture { get; internal set; }
    public ushort GlobalMessageNumber { get; internal set; }
    public int FieldCount { get; internal set; }
    public int DeveloperFieldCount { get; internal set; }
}