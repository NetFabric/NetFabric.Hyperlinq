using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentDistinctEnumerable<TSource> Distinct<TSource>(this TSource[] source, IEqualityComparer<TSource>? comparer = default)
            => Distinct(new ArraySegment<TSource>(source), comparer);
    }
}

