using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitRepair.Sports
{
    [Flags]
    internal enum Sport3 : byte
    {
        Driving = 0x01,
        Golf = 0x02,
        HangGliding = 0x04,
        HorsebackRiding = 0x08,
        Hunting = 0x10,
        Fishing = 0x20,
        InlineSkating = 0x40,
        RockClimbing = 0x80,
        Invalid = 0x00
    }
}
