public class DataField
{
    internal DataField(FieldDefinition fieldDefinition, byte[] contentBytes)
    {
        FieldDefinition = fieldDefinition;
        ContentBytes = contentBytes;
    }

    public FieldDefinition FieldDefinition { get; init; }
    public byte[] ContentBytes { get; init; }

    public override string ToString()
    {
        switch (FieldDefinition.BaseType)
        {
            case BaseType.Uint8BaseType: return ContentBytes[0].ToString();
            case BaseType.Uint16BaseType: return BitConverter.ToUInt16(ContentBytes).ToString();
            case BaseType.Uint32BaseType: return BitConverter.ToUInt32(ContentBytes).ToString();
            case BaseType.Uint64BaseType: return BitConverter.ToUInt64(ContentBytes).ToString();

            case BaseType.Uint8ZBaseType: return ContentBytes[0].ToString();
            case BaseType.Uint16ZBaseType: return BitConverter.ToUInt16(ContentBytes).ToString();
            case BaseType.Uint32ZBaseType: return BitConverter.ToUInt32(ContentBytes).ToString();
            case BaseType.Uint64ZBaseType: return BitConverter.ToUInt64(ContentBytes).ToString();

            case BaseType.Sint16BaseType: return BitConverter.ToInt16(ContentBytes).ToString();
            case BaseType.Sint8BaseType: return ((sbyte)ContentBytes[0]).ToString();
            case BaseType.Sint32BaseType: return BitConverter.ToInt32(ContentBytes).ToString();
            case BaseType.Sint64BaseType: return BitConverter.ToInt64(ContentBytes).ToString();

            case BaseType.StringBaseType: return System.Text.Encoding.UTF8.GetString(ContentBytes);

            default: return BitConverter.ToString(ContentBytes);
        }
    }
}