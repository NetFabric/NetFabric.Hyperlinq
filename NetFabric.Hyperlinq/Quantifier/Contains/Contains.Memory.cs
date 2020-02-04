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
        public static bool Contains<TSource>(this Memory<TSource> source, TSource value, IEqualityComparer<TSource>? comparer = null)
            => Contains((ReadOnlySpan<TSource>)source.Span, value, comparer);
    }
}

