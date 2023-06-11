namespace FitRepair;

/// <summary>
/// Filed numbers for <see cref="TimestampCorrelationMessage" />
/// </summary>
public sealed class TimestampCorrelationMessageFieldNumber : FieldNumberDefinitions<byte>
{
    public static readonly TimestampCorrelationMessageFieldNumber Timestamp = new(253);
    public static readonly TimestampCorrelationMessageFieldNumber FractionalTimestamp = new(0);
    public static readonly TimestampCorrelationMessageFieldNumber SystemTimestamp = new(1);
    public static readonly TimestampCorrelationMessageFieldNumber FractionalSystemTimestamp = new(2);
    public static readonly TimestampCorrelationMessageFieldNumber LocalTimestamp = new(3);
    public static readonly TimestampCorrelationMessageFieldNumber TimestampMs = new(4);
    public static readonly TimestampCorrelationMessageFieldNumber SystemTimestampMs = new(5);

    private TimestampCorrelationMessageFieldNumber(byte value) : base(value) { }

}





public sealed class TimestampCorrelationMessage : DataMessage
{
    internal TimestampCorrelationMessage(int localMessageType) : base(localMessageType) { }


    public DateTime? GetTimestamp() => GetValueOrDefaultDateTime(TimestampCorrelationMessageFieldNumber.Timestamp);
    public float? GetFractionalTimestamp() => GetValueOrDefaultFloat(TimestampCorrelationMessageFieldNumber.FractionalTimestamp);
    public DateTime? GetSystemTimestamp() => GetValueOrDefaultDateTime(TimestampCorrelationMessageFieldNumber.SystemTimestamp);
    public float? GetFractionalSystemTimestamp() => GetValueOrDefaultFloat(TimestampCorrelationMessageFieldNumber.FractionalSystemTimestamp);
    public uint? GetLocalTimestamp() => GetValueOrDefaultUint(TimestampCorrelationMessageFieldNumber.LocalTimestamp);
    public ushort? GetTimestampMs() => GetValueOrDefaultUshort(TimestampCorrelationMessageFieldNumber.TimestampMs);
    public ushort? GetSystemTimestampMs() => GetValueOrDefaultUshort(TimestampCorrelationMessageFieldNumber.SystemTimestampMs);



}