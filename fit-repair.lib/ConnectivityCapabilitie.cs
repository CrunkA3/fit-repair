using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitRepair
{
    public enum ConnectivityCapabilitie : uint
    {
        Bluetooth = 0x00000001,
        BluetoothLe = 0x00000002,
        Ant = 0x00000004,
        ActivityUpload = 0x00000008,
        CourseDownload = 0x00000010,
        WorkoutDownload = 0x00000020,
        LiveTrack = 0x00000040,
        WeatherConditions = 0x00000080,
        WeatherAlerts = 0x00000100,
        GpsEphemerisDownload = 0x00000200,
        ExplicitArchive = 0x00000400,
        SetupIncomplete = 0x00000800,
        ContinueSyncAfterSoftwareUpdate = 0x00001000,
        ConnectIqAppDownload = 0x00002000,
        GolfCourseDownload = 0x00004000,
        DeviceInitiatesSync = 0x00008000,
        ConnectIqWatchAppDownload = 0x00010000,
        ConnectIqWidgetDownload = 0x00020000,
        ConnectIqWatchFaceDownload = 0x00040000,
        ConnectIqDataFieldDownload = 0x00080000,
        ConnectIqAppManagment = 0x00100000,
        SwingSensor = 0x00200000,
        SwingSensorRemote = 0x00400000,
        IncidentDetection = 0x00800000,
        AudioPrompts = 0x01000000,
        WifiVerification = 0x02000000,
        TrueUp = 0x04000000,
        FindMyWatch = 0x08000000,
        RemoteManualSync = 0x10000000,
        LiveTrackAutoStart = 0x20000000,
        LiveTrackMessaging = 0x40000000,
        InstantInput = 0x80000000,
        Invalid = 0x00000000,

    }
}
