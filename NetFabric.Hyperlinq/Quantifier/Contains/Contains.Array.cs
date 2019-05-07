using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static bool Contains<TSource>(this TSource[] source, TSource value)
            => System.Array.IndexOf<TSource>(source, value) >= 0;

        public static bool Contains<TSource>(this TSource[] source, TSource value, IEqualityComparer<TSource> comparer)
        {
            var length = source.Length;
            if (length == 0) return false;

            if (comparer is null)
                return System.Array.IndexOf<TSource>(source, value) >= 0;

            for (var index = 0; index < length; index++)
            {
                if (comparer.Equals(value, source[index]))
                    return true;
            }

            return false;
        }
    }
}

