using FitRepair.Flags;

namespace FitRepair;

/// <summary>
/// Filed numbers for <see cref="TimestampCorrelationMessage" />
/// </summary>
public sealed class RecordFieldNumber : FieldNumberDefinitions<byte>
{
    public static readonly RecordFieldNumber Timestamp = new(253);
    public static readonly RecordFieldNumber PositionLat = new(0);
    public static readonly RecordFieldNumber PositionLong = new(1);
    public static readonly RecordFieldNumber Altitude = new(2);
    public static readonly RecordFieldNumber HeartRate = new(3);
    public static readonly RecordFieldNumber Cadence = new(4);
    public static readonly RecordFieldNumber Distance = new(5);
    public static readonly RecordFieldNumber Speed = new(6);
    public static readonly RecordFieldNumber Power = new(7);
    public static readonly RecordFieldNumber CompressedSpeedDistance = new(8);
    public static readonly RecordFieldNumber Grade = new(9);
    public static readonly RecordFieldNumber Resistance = new(10);
    public static readonly RecordFieldNumber TimeFromCourse = new(11);
    public static readonly RecordFieldNumber CycleLength = new(12);
    public static readonly RecordFieldNumber Temperature = new(13);
    public static readonly RecordFieldNumber Speed1s = new(17);
    public static readonly RecordFieldNumber Cycles = new(18);
    public static readonly RecordFieldNumber TotalCycles = new(19);
    public static readonly RecordFieldNumber CompressedAccumulatedPower = new(28);
    public static readonly RecordFieldNumber AccumulatedPower = new(29);
    public static readonly RecordFieldNumber LeftRightBalance = new(30);
    public static readonly RecordFieldNumber GpsAccuracy = new(31);
    public static readonly RecordFieldNumber VerticalSpeed = new(32);
    public static readonly RecordFieldNumber Calories = new(33);
    public static readonly RecordFieldNumber VerticalOscillation = new(39);
    public static readonly RecordFieldNumber StanceTimePercent = new(40);
    public static readonly RecordFieldNumber StanceTime = new(41);
    public static readonly RecordFieldNumber ActivityType = new(42);
    public static readonly RecordFieldNumber LeftTorqueEffectiveness = new(43);
    public static readonly RecordFieldNumber RightTorqueEffectiveness = new(44);
    public static readonly RecordFieldNumber LeftPedalSmoothness = new(45);
    public static readonly RecordFieldNumber RightPedalSmoothness = new(46);
    public static readonly RecordFieldNumber CombinedPedalSmoothness = new(47);
    public static readonly RecordFieldNumber Time128 = new(48);
    public static readonly RecordFieldNumber StrokeType = new(49);
    public static readonly RecordFieldNumber Zone = new(50);
    public static readonly RecordFieldNumber BallSpeed = new(51);
    public static readonly RecordFieldNumber Cadence256 = new(52);
    public static readonly RecordFieldNumber FractionalCadence = new(53);
    public static readonly RecordFieldNumber TotalHemoglobinConc = new(54);
    public static readonly RecordFieldNumber TotalHemoglobinConcMin = new(55);
    public static readonly RecordFieldNumber TotalHemoglobinConcMax = new(56);
    public static readonly RecordFieldNumber SaturatedHemoglobinPercent = new(57);
    public static readonly RecordFieldNumber SaturatedHemoglobinPercentMin = new(58);
    public static readonly RecordFieldNumber SaturatedHemoglobinPercentMax = new(59);
    public static readonly RecordFieldNumber DeviceIndex = new(62);
    public static readonly RecordFieldNumber LeftPco = new(67);
    public static readonly RecordFieldNumber RightPco = new(68);
    public static readonly RecordFieldNumber LeftPowerPhase = new(69);
    public static readonly RecordFieldNumber LeftPowerPhasePeak = new(70);
    public static readonly RecordFieldNumber RightPowerPhase = new(71);
    public static readonly RecordFieldNumber RightPowerPhasePeak = new(72);
    public static readonly RecordFieldNumber EnhancedSpeed = new(73);
    public static readonly RecordFieldNumber EnhancedAltitude = new(78);
    public static readonly RecordFieldNumber BatterySoc = new(81);
    public static readonly RecordFieldNumber MotorPower = new(82);
    public static readonly RecordFieldNumber VerticalRatio = new(83);
    public static readonly RecordFieldNumber StanceTimeBalance = new(84);
    public static readonly RecordFieldNumber StepLength = new(85);
    public static readonly RecordFieldNumber AbsolutePressure = new(91);
    public static readonly RecordFieldNumber Depth = new(92);
    public static readonly RecordFieldNumber NextStopDepth = new(93);
    public static readonly RecordFieldNumber NextStopTime = new(94);
    public static readonly RecordFieldNumber TimeToSurface = new(95);
    public static readonly RecordFieldNumber NdlTime = new(96);
    public static readonly RecordFieldNumber CnsLoad = new(97);
    public static readonly RecordFieldNumber N2Load = new(98);
    public static readonly RecordFieldNumber RespirationRate = new(99);
    public static readonly RecordFieldNumber EnhancedRespirationRate = new(108);
    public static readonly RecordFieldNumber Grit = new(114);
    public static readonly RecordFieldNumber Flow = new(115);
    public static readonly RecordFieldNumber EbikeTravelRange = new(117);
    public static readonly RecordFieldNumber EbikeBatteryLevel = new(118);
    public static readonly RecordFieldNumber EbikeAssistMode = new(119);
    public static readonly RecordFieldNumber EbikeAssistLevelPercent = new(120);
    public static readonly RecordFieldNumber AirTimeRemaining = new(123);
    public static readonly RecordFieldNumber PressureSac = new(124);
    public static readonly RecordFieldNumber VolumeSac = new(125);
    public static readonly RecordFieldNumber Rmv = new(126);
    public static readonly RecordFieldNumber AscentRate = new(127);
    public static readonly RecordFieldNumber Po2 = new(129);
    public static readonly RecordFieldNumber CoreTemperature = new(139);


    private RecordFieldNumber(byte value) : base(value) { }

}





public sealed class RecordMessage : DataMessage
{
    internal RecordMessage(int localMessageType) : base(localMessageType) { }


    public DateTime? GetTimestamp() => GetValueOrDefaultDateTime(RecordFieldNumber.Timestamp);
    public short? GetPositionLat() => GetValueOrDefaultShort(RecordFieldNumber.PositionLat);

}