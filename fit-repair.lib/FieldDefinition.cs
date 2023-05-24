public class FieldDefinition
{
    internal FieldDefinition(byte number, byte size, byte baseType)
    {
        Number = number;
        Size = size;
        BaseType = baseType;
    }

    public byte Number { get; init; }
    public byte Size { get; init; }
    public byte BaseType { get; init; }

    public bool EndianAbility => ((BaseType >> 7) & 1) == 1;
    public int Reserved => ((BaseType >> 5) & 3);
    public BaseType BaseTypeNumber => (BaseType)(BaseType & 15);
}