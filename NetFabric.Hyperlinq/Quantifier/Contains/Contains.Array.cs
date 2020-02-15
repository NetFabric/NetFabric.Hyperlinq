using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<TSource>(this TSource[] source, TSource value, IEqualityComparer<TSource>? comparer = null)
        {
            if (source.Length != 0)
            {
                if (comparer is null)
                    return System.Array.IndexOf<TSource>(source, value) >= 0;

                for (var index = 0; index < source.Length; index++)
                {
                    if (comparer.Equals(value, source[index]))
                        return true;
                }
            }
            return false;
        }

        [Pure]
        static bool Contains<TSource>(this TSource[] source, TSource value, IEqualityComparer<TSource>? comparer, int skipCount, int takeCount)
        {
            if (takeCount != 0) 
            {
                if (comparer is null)
                    return System.Array.IndexOf<TSource>(source, value, skipCount, takeCount) >= 0;

                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    if (comparer.Equals(value, source[index]))
                        return true;
                }
            }
            return false;
        }
    }
}

