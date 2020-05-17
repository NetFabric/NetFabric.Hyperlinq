using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<TSource>(this Span<TSource> source, TSource value, IEqualityComparer<TSource>? comparer = null)
            => Contains((ReadOnlySpan<TSource>)source, value, comparer);
    }
}

