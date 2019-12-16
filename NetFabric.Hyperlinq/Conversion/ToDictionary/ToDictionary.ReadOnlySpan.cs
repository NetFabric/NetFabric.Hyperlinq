using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlySpanExtensions
    {
        [Pure]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this ReadOnlySpan<TSource> source, Selector<TSource, TKey> keySelector)
        {
            if (keySelector is null) Throw.ArgumentNullException(nameof(keySelector));

            return ToDictionary<TSource, TKey>(source, keySelector, EqualityComparer<TKey>.Default, 0, source.Length);
        }

        [Pure]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this ReadOnlySpan<TSource> source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            if (keySelector is null) Throw.ArgumentNullException(nameof(keySelector));

            return ToDictionary<TSource, TKey>(source, keySelector, comparer, 0, source.Length);
        }

        [Pure]
        static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this ReadOnlySpan<TSource> source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer, int skipCount, int takeCount)
        {
            var dictionary = new Dictionary<TKey, TSource>(source.Length, comparer);
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
                dictionary.Add(keySelector(source[index]), source[index]);
            return dictionary;
        }

        [Pure]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this ReadOnlySpan<TSource> source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector)
        {
            if (keySelector is null) Throw.ArgumentNullException(nameof(keySelector));
            if (elementSelector is null) Throw.ArgumentNullException(nameof(elementSelector));

            return ToDictionary<TSource, TKey, TElement>(source, keySelector, elementSelector, EqualityComparer<TKey>.Default, 0, source.Length);
        }

        [Pure]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this ReadOnlySpan<TSource> source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            if (keySelector is null) Throw.ArgumentNullException(nameof(keySelector));
            if (elementSelector is null) Throw.ArgumentNullException(nameof(elementSelector));

            return ToDictionary<TSource, TKey, TElement>(source, keySelector, elementSelector, comparer, 0, source.Length);
        }

        [Pure]
        static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this ReadOnlySpan<TSource> source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer, int skipCount, int takeCount)
        {
            var dictionary = new Dictionary<TKey, TElement>(source.Length, comparer);
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
                dictionary.Add(keySelector(source[index]), elementSelector(source[index]));
            return dictionary;
        }
    }
}

