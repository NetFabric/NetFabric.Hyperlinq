﻿using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if SPAN_SUPPORTED
        public static Memory<TSource> Take<TSource>(this TSource[] source, int count)
            => Take(source.AsMemory(), count);
#else
        public static ReadOnlyList.SkipTakeEnumerable<TSource[], TSource> Take<TSource>(this TSource[] source, int count)
            => ReadOnlyList.Take<TSource[], TSource>(source, count);
#endif
    }
}
