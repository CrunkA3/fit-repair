using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitRepair.Masks
{
    public class ByteFlag
    {
        public static readonly SortedList<byte, ByteFlag> Values = new();

        internal ByteFlag(byte value)
        {
            _value = value;
            Values.Add(value, this);
        }
        private readonly byte _value;

        public static implicit operator byte(ByteFlag value) => value._value;
        public static implicit operator ByteFlag(byte value) => Values[value];
    }
}
