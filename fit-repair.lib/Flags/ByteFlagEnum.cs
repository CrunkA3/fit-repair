using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitRepair.Flags
{
    public abstract class ByteFlagEnum<T>
    {
        public static readonly SortedList<byte, ByteFlagEnum<T>> Values = new();

        internal ByteFlagEnum(byte value, byte byteIndex, byte byteMask)
        {
            _value = value;
            _byteIndex = byteIndex;
            _byteMask = byteMask;

            Values.Add(value, this);
        }

        internal readonly byte _value;
        internal readonly byte _byteIndex;
        internal readonly byte _byteMask;

        public static implicit operator byte(ByteFlagEnum<T> value) => value._value;
        public static implicit operator ByteFlagEnum<T>(byte value) => Values[value];

        public static ReadOnlyCollection<ByteFlagEnum<T>> ToCollection(byte[] bytes) => ToCollection(bytes.AsSpan());
        public static ReadOnlyCollection<ByteFlagEnum<T>> ToCollection(Span<byte> bytes)
        {
            List<ByteFlagEnum<T>> result = new();

            for (byte i = 0; i < Values.Count; i++)
            {
                var value = Values[i];

                if ((bytes[value._byteIndex] & value._byteMask) == value._byteMask) result.Add(value._value);
            }

            result.TrimExcess();
            return result.AsReadOnly();
        }
    }
}
