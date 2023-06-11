namespace FitRepair;

/// <summary>
/// Filed numbers for <see cref="SoftwareMessage" />
/// </summary>
public sealed class SoftwareMessageFieldNumber : FieldNumberDefinitions<byte>
{
    public static readonly SoftwareMessageFieldNumber MessageIndex = new(254);
    public static readonly SoftwareMessageFieldNumber Version = new(3);
    public static readonly SoftwareMessageFieldNumber PartNumber = new(5);

    private SoftwareMessageFieldNumber(byte value) : base(value) { }

}





public sealed class SoftwareMessage : DataMessage
{
    internal SoftwareMessage(int localMessageType) : base(localMessageType) { }


    public ushort? GetMessageIndex() => GetValueOrDefaultUshort(SoftwareMessageFieldNumber.MessageIndex);
    public float? GetVersion() => GetValueOrDefaultFloat(SoftwareMessageFieldNumber.Version);
    public string? GetPartNumber() => GetValueOrDefaultString(SoftwareMessageFieldNumber.PartNumber);



}