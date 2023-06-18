using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitRepair.Sports
{
    [Flags]
    internal enum Sport1 : byte
    {
        Tennis = 0x01,
        AmericanFootball = 0x02,
        Training = 0x04,
        Walking = 0x08,
        CrossCountrySkiing = 0x10,
        AlpineSkiing = 0x20,
        Snowboarding = 0x40,
        Rowing = 0x80,
        Invalid = 0x00
    }
}
