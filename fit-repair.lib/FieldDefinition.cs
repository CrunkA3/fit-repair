public class FieldDefinition
{
    internal FieldDefinition(byte number, byte size, byte baseType)
    {
        Number = number;
        Size = size;
        BaseTypeByte = baseType;
    }

    public byte Number { get; private init; }
    public byte Size { get; private init; }
    public byte BaseTypeByte { get; private init; }

    public bool EndianAbility => ((BaseTypeByte >> 7) & 1) == 1;
    public int Reserved => ((BaseTypeByte >> 5) & 3);
    public BaseType BaseType
    {
        get
        {
            var result = (BaseType)(BaseTypeByte & 15);
            return result;
        }
    }
}