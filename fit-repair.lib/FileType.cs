namespace FitRepair;

public enum FileType : byte
{
    Device = 1,
    Settings = 2,
    Sport = 3,
    Activity = 4,
    Workout = 5,
    Course = 6,
    Schedules = 7,
    Weight = 9,
    Totals = 10,
    Goals = 11,
    BloodPressure = 14,
    MonitoringA = 15,
    ActivitySummary = 20,
    MonitoringDaily = 28,
    MonitoringB = 32,
    Segment = 34,
    SegmentList = 35,
    ExdConfiguration = 40,
    MfgRangeMin = 0xF7,
    MfgRangeMax = 0xFE,
    Invalid = 0xFF
}