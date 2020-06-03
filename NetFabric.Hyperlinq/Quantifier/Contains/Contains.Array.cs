using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
#if SPAN_SUPPORTED
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<TSource>(this TSource[] source, TSource value, IEqualityComparer<TSource>? comparer = null)
            => Contains((ReadOnlySpan<TSource>)source.AsSpan(), value, comparer);
#else
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<TSource>(this TSource[] source, TSource value, IEqualityComparer<TSource>? comparer = null)
            => ReadOnlyList.Contains(source, value, comparer);
#endif
    }
}

