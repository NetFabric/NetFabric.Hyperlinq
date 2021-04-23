using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Diagnostics.Tracing.Parsers.Clr;

namespace LinqBenchmarks
{
    static class Utils
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEven(this int value)
            => (value & 0x01) == 0;

        public static IEnumerable<T> Enumerable<T>(int count)
        {
            if (count < 0) 
                throw new ArgumentOutOfRangeException(nameof(count));
            return GetEnumerable(count);

            static IEnumerable<T> GetEnumerable(int count)
            {
                for (var value = 0; value < count; value++)
                    yield return default;
            }
        }
    }
}
