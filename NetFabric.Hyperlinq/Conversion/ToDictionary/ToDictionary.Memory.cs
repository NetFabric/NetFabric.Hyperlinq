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
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this Memory<TSource> source, Selector<TSource, TKey> keySelector)
            => ToDictionary((ReadOnlySpan<TSource>)source.Span, keySelector);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this Memory<TSource> source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
            => ToDictionary((ReadOnlySpan<TSource>)source.Span, keySelector, comparer);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this Memory<TSource> source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector)
            => ToDictionary((ReadOnlySpan<TSource>)source.Span, keySelector, elementSelector);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this Memory<TSource> source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
            => ToDictionary((ReadOnlySpan<TSource>)source.Span, keySelector, elementSelector, comparer);
    }
}

