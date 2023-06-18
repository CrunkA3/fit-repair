using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitRepair.Sports
{
    [Flags]
    internal enum Sport4 : byte
    {
        Sailing = 0x01,
        IceSkating = 0x02,
        SkyDiving = 0x04,
        Snowshoeing = 0x08,
        Snowmobiling = 0x10,
        StandUpPaddleboarding = 0x20,
        Surfing = 0x40,
        Wakeboarding = 0x80,
        Invalid = 0x00
    }
}
