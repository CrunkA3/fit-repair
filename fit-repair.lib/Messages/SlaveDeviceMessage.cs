namespace FitRepair;

/// <summary>
/// Filed numbers for <see cref="TimestampCorrelationMessage" />
/// </summary>
public sealed class SlaveDeviceFieldNumber : FieldNumberDefinitions<byte>
{
    public static readonly SlaveDeviceFieldNumber Manufacturer = new(0);
    public static readonly SlaveDeviceFieldNumber Product = new(1);

    private SlaveDeviceFieldNumber(byte value) : base(value) { }

}





public sealed class SlaveDeviceMessage : DataMessage
{
    internal SlaveDeviceMessage(int localMessageType) : base(localMessageType) { }


    public ushort? GetManufacturer() => GetValueOrDefaultUshort(SlaveDeviceFieldNumber.Manufacturer);
    public ushort? GetProduct() => GetValueOrDefaultUshort(SlaveDeviceFieldNumber.Product);

}