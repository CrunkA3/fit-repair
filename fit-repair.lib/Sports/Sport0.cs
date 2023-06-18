using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitRepair.Sports
{
    [Flags]
    internal enum Sport0 : byte
    {
        Generic = 0x01,
        Running = 0x02,
        Cycling = 0x04,
        Transition = 0x08,
        FitnessEquipment = 0x10,
        Swimming = 0x20,
        Basketball = 0x40,
        Soccer = 0x80,
        Invalid = 0x00
    }
}
