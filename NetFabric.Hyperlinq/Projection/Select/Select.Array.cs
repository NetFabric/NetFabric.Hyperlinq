using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if SPAN_SUPPORTED
        public static MemorySelectEnumerable<TSource, TResult> Select<TSource, TResult>(this TSource[] source, Selector<TSource, TResult> selector)
            => Select(source.AsMemory(), selector);
#else
        public static ReadOnlyList.SelectEnumerable<TSource[], TSource, TResult> Select<TSource, TResult>(this TSource[] source, Selector<TSource, TResult> selector)
            => ReadOnlyList.Select(source, selector);
#endif
    }
}

