using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
#if SPAN_SUPPORTED
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this TSource[] source, Selector<TSource, TKey> keySelector)
            => ToDictionary((ReadOnlySpan<TSource>)source.AsSpan(), keySelector);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this TSource[] source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
            => ToDictionary((ReadOnlySpan<TSource>)source.AsSpan(), keySelector, comparer);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this TSource[] source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector)
            => ToDictionary((ReadOnlySpan<TSource>)source.AsSpan(), keySelector, elementSelector);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this TSource[] source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer)
            => ToDictionary((ReadOnlySpan<TSource>)source.AsSpan(), keySelector, elementSelector, comparer);
#else
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this TSource[] source, Selector<TSource, TKey> keySelector)
            => ReadOnlyList.ToDictionary(source, keySelector);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this TSource[] source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
            => ReadOnlyList.ToDictionary(source, keySelector, comparer);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this TSource[] source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector)
            => ReadOnlyList.ToDictionary(source, keySelector, elementSelector);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this TSource[] source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer)
            => ReadOnlyList.ToDictionary(source, keySelector, elementSelector, comparer);
#endif
    }
}

