namespace FitRepair;

/// <summary>
/// Filed numbers for <see cref="FileIdMessage" />
/// </summary>
public sealed class FileIdMessageFieldNumber : FieldNumberDefinitions<byte>
{
    public static readonly FileIdMessageFieldNumber Type = new(0);
    public static readonly FileIdMessageFieldNumber Manufacturer = new(1);
    public static readonly FileIdMessageFieldNumber Product = new(2);
    public static readonly FileIdMessageFieldNumber SerialNumber = new(3);
    public static readonly FileIdMessageFieldNumber TimeCreated = new(4);
    public static readonly FileIdMessageFieldNumber Number = new(5);
    public static readonly FileIdMessageFieldNumber ProductName = new(8);

    private FileIdMessageFieldNumber(byte value) : base(value) { }

}


/// <summary>
/// Product subfiled numbers for <see cref="FileIdMessage" />
/// </summary>
public sealed class FileIdMessageProductSubfieldNumber : FieldNumberDefinitions<ushort>
{
    public static readonly FileIdMessageProductSubfieldNumber FaveroProduct = new(0);
    public static readonly FileIdMessageProductSubfieldNumber GarminProduct = new(1);
    public static readonly FileIdMessageProductSubfieldNumber Subfields = new(2);
    public static readonly FileIdMessageProductSubfieldNumber Active = new(0XFFFE);
    public static readonly FileIdMessageProductSubfieldNumber MainField = new(0XFFFE + 1);

    private FileIdMessageProductSubfieldNumber(ushort value) : base(value) { }

}




public class FileIdMessage : DataMessage
{
    internal FileIdMessage(int localMessageType) : base(localMessageType) { }

    public FileType? GetFileType() => TryGetDataField(FileIdMessageFieldNumber.Type, out DataField dataField) ? (FileType)dataField.ContentBytes[0] : default;

    public ushort? GetManufacturer() => GetValueOrDefaultUshort(FileIdMessageFieldNumber.Manufacturer);
    public ushort? GetProduct() => GetValueOrDefaultUshort(FileIdMessageFieldNumber.Product);

    public ushort? GetFaveroProduct() => throw new NotImplementedException();
    public ushort? GetGarminProduct() => throw new NotImplementedException();

    public uint? GetSerialNumber() => GetValueOrDefaultUint(FileIdMessageFieldNumber.SerialNumber);
    public DateTime? GetTimeCreated() => GetValueOrDefaultDateTime(FileIdMessageFieldNumber.TimeCreated);
    public ushort? GetNumber() => GetValueOrDefaultUshort(FileIdMessageFieldNumber.Number);
    public string? GetProductName() => GetValueOrDefaultString(FileIdMessageFieldNumber.ProductName);


}