using FitRepair.Sports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FitRepair.Extensions;

internal static class ListExtensions
{
    internal static void AddIf<TList>(this List<TList> list, byte currentValue, byte checkValue, TList addValue)
    {
        if ((currentValue & checkValue) == checkValue) list.Add(addValue);
    }

    internal static void AddIf<TList, TValue>(this List<TList> list, TValue currentValue, TValue checkValue, TList addValue) => list.AddIf((currentValue as byte?) ?? 0x00, (checkValue as byte?) ?? 0x00, addValue);
}






