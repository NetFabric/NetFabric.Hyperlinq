using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
// ReSharper disable HeapView.ObjectAllocation.Evident

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this in ArraySegment<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => source.AsSpan().ToDictionary(keySelector, comparer);

        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey, TKeySelector>(this in ArraySegment<TSource> source, TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            => source.AsSpan().ToDictionary(keySelector, comparer);

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this in ArraySegment<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => source.AsSpan().ToDictionary(keySelector, elementSelector, comparer);

        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement, TKeySelector, TElementSelector>(this in ArraySegment<TSource> source, TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            where TElementSelector : struct, IFunction<TSource, TElement>
            => source.AsSpan().ToDictionary<TSource, TKey, TElement, TKeySelector, TElementSelector>(keySelector, elementSelector, comparer);
    }
}

