using FitRepair.Masks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FitRepair.Flags
{
    public class Sport : ByteFlagEnum<Sport>
    {
        internal Sport(byte value, byte byteIndex, byte byteMask) : base(value, byteIndex, byteMask) { }

        public static readonly Sport Generic = new(0, 0, 0x01);
        public static readonly Sport Running = new(1, 0, 0x02);
        public static readonly Sport Cycling = new(2, 0, 0x04);
        public static readonly Sport Transition = new(3, 0, 0x08);
        public static readonly Sport FitnessEquipment = new(4, 0, 0x10);
        public static readonly Sport Swimming = new(5, 0, 0x20);
        public static readonly Sport Basketball = new(6, 0, 0x40);
        public static readonly Sport Soccer = new(7, 0, 0x80);

        public static readonly Sport Tennis = new(8, 1, 0x01);
        public static readonly Sport AmericanFootball = new(9, 1, 0x02);
        public static readonly Sport Training = new(10, 1, 0x04);
        public static readonly Sport Walking = new(11, 1, 0x08);
        public static readonly Sport CrossCountrySkiing = new(12, 1, 0x10);
        public static readonly Sport AlpineSkiing = new(13, 1, 0x20);
        public static readonly Sport Snowboarding = new(14, 1, 0x40);
        public static readonly Sport Rowing = new(15, 1, 0x80);

        public static readonly Sport Mountaineering = new(16, 2, 0x01);
        public static readonly Sport Hiking = new(17, 2, 0x02);
        public static readonly Sport Multisport = new(18, 2, 0x04);
        public static readonly Sport Paddling = new(19, 2, 0x08);
        public static readonly Sport Flying = new(20, 2, 0x10);
        public static readonly Sport EBiking = new(21, 2, 0x20);
        public static readonly Sport Motorcycling = new(22, 2, 0x40);
        public static readonly Sport Boating = new(23, 2, 0x80);

        public static readonly Sport Driving = new(24, 3, 0x01);
        public static readonly Sport Golf = new(25, 3, 0x02);
        public static readonly Sport HangGliding = new(26, 3, 0x04);
        public static readonly Sport HorsebackRiding = new(27, 3, 0x08);
        public static readonly Sport Hunting = new(28, 3, 0x10);
        public static readonly Sport Fishing = new(29, 3, 0x20);
        public static readonly Sport InlineSkating = new(30, 3, 0x40);
        public static readonly Sport RockClimbing = new(31, 3, 0x80);

        public static readonly Sport Sailing = new(32, 4, 0x01);
        public static readonly Sport IceSkating = new(33, 4, 0x02);
        public static readonly Sport SkyDiving = new(34, 4, 0x04);
        public static readonly Sport Snowshoeing = new(35, 4, 0x08);
        public static readonly Sport Snowmobiling = new(36, 4, 0x10);
        public static readonly Sport StandUpPaddleboarding = new(37, 4, 0x20);
        public static readonly Sport Surfing = new(38, 4, 0x40);
        public static readonly Sport Wakeboarding = new(39, 4, 0x80);

        public static readonly Sport WaterSkiing = new(40, 5, 0x01);
        public static readonly Sport Kayaking = new(41, 5, 0x02);
        public static readonly Sport Rafting = new(42, 5, 0x04);
        public static readonly Sport Windsurfing = new(43, 5, 0x08);
        public static readonly Sport Kitesurfing = new(44, 5, 0x10);
        public static readonly Sport Tactical = new(45, 5, 0x20);
        public static readonly Sport Jumpmaster = new(46, 5, 0x40);
        public static readonly Sport Boxing = new(47, 5, 0x80);

        public static readonly Sport FloorClimbing = new(48, 6, 0x01);
        public static readonly Sport Diving = new(53, 6, 0x02);
        public static readonly Sport Hiit = new(62, 6, 0x04);
        public static readonly Sport Racket = new(64, 6, 0x08);
        public static readonly Sport WaterTubing = new(76, 6, 0x10);
        public static readonly Sport Wakesurfing = new(77, 6, 0x20);


    }
}
