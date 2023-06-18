using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitRepair.Sports
{
    [Flags]
    internal enum Sport5 : byte
    {
        WaterSkiing = 0x01,
        Kayaking = 0x02,
        Rafting = 0x04,
        Windsurfing = 0x08,
        Kitesurfing = 0x10,
        Tactical = 0x20,
        Jumpmaster = 0x40,
        Boxing = 0x80,
        Invalid = 0x00
    }
}
