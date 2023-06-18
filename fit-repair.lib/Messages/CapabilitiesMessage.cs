using FitRepair.Sports;

namespace FitRepair;

/// <summary>
/// Filed numbers for <see cref="TimestampCorrelationMessage" />
/// </summary>
public sealed class CapabilitiesFieldNumber : FieldNumberDefinitions<byte>
{
    public static readonly CapabilitiesFieldNumber Languages = new(0);
    public static readonly CapabilitiesFieldNumber Sports = new(1);
    public static readonly CapabilitiesFieldNumber WorkoutsSupported = new(2);
    public static readonly CapabilitiesFieldNumber ConnectivitySupported = new(3);

    private CapabilitiesFieldNumber(byte value) : base(value) { }

}





public sealed class CapabilitiesMessage : DataMessage
{
    internal CapabilitiesMessage(int localMessageType) : base(localMessageType) { }


    public ushort? GetLanguages() => GetValueOrDefaultUshort(CapabilitiesFieldNumber.Languages);
    public IReadOnlyCollection<Sport> GetSports() => GetValueOrDefaultSports(CapabilitiesFieldNumber.Sports);
    public ushort? GetWorkoutsSupported() => GetValueOrDefaultUshort(CapabilitiesFieldNumber.WorkoutsSupported);
    public ushort? GetConnectivitySupported() => GetValueOrDefaultUshort(CapabilitiesFieldNumber.ConnectivitySupported);



}