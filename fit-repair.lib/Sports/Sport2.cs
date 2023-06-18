using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitRepair.Sports
{
    [Flags]
    internal enum Sport2 : byte
    {
        Mountaineering = 0x01,
        Hiking = 0x02,
        Multisport = 0x04,
        Paddling = 0x08,
        Flying = 0x10,
        EBiking = 0x20,
        Motorcycling = 0x40,
        Boating = 0x80,
        Invalid = 0x00
    }
}
