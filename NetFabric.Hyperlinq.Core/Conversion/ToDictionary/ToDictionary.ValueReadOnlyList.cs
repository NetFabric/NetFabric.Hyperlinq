using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyListExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TKeySelector>(this TEnumerable source, TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            => ValueReadOnlyCollectionExtensions.ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TKeySelector>(source, keySelector, comparer);

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement, TKeySelector, TElementSelector>(this TEnumerable source, TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            where TElementSelector : struct, IFunction<TSource, TElement>
            => ValueReadOnlyCollectionExtensions.ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement, TKeySelector, TElementSelector>(source, keySelector, elementSelector, comparer);
    }
}

