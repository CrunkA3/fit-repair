using FitRepair.Flags;
using FitRepair.Masks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitRepair
{
    public enum WorkoutCapabilitie : uint
    {
        Interval = 0x00000001,
        Custom = 0x00000002,
        FitnessEquipment = 0x00000004,
        Firstbeat = 0x00000008,
        NewLeaf = 0x00000010,

        /// <summary>
        /// For backwards compatibility. Watch should add missing id fields then clear flag.
        /// </summary>
        Tcx = 0x00000020,

        /// <summary>
        /// Speed source required for workout step.
        /// </summary>
        Speed = 0x00000080,

        /// <summary>
        /// Heart rate source required for workout step.
        /// </summary>
        HeartRate = 0x00000100,

        /// <summary>
        /// Distance source required for workout step.
        /// </summary>
        Distance = 0x00000200,

        /// <summary>
        /// Cadence source required for workout step.
        /// </summary>
        Cadence = 0x00000400,

        /// <summary>
        /// Power source required for workout step.
        /// </summary>
        Power = 0x00000800,

        /// <summary>
        /// Grade source required for workout step.
        /// </summary>
        Grade = 0x00001000,

        /// <summary>
        /// Resistance source required for workout step.
        /// </summary>
        Resistance = 0x00002000,
        Protected = 0x00004000,
        Invalid = 0x00000000,
    }
}
