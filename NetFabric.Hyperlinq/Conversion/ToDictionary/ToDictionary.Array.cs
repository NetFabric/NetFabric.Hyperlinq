using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this TSource[] source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => new ArraySegment<TSource>(source).ToDictionary(keySelector, comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey, TKeySelector>(this TSource[] source, TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey> 
            => new ArraySegment<TSource>(source).ToDictionary(keySelector, comparer);

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this TSource[] source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => new ArraySegment<TSource>(source).ToDictionary(keySelector, elementSelector, comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement, TKeySelector, TElementSelector>(this TSource[] source, TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            where TElementSelector : struct, IFunction<TSource, TElement>
            => new ArraySegment<TSource>(source).ToDictionary<TSource, TKey, TElement, TKeySelector, TElementSelector>(keySelector, elementSelector, comparer);
    }
}

