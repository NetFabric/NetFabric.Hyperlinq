using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        [Pure]
        public static Dictionary<TKey, TSource> ToDictionary<TList, TSource, TKey>(this TList source, Selector<TSource, TKey> keySelector)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (keySelector is null) Throw.ArgumentNullException(nameof(keySelector));

            return ToDictionary<TList, TSource, TKey>(source, keySelector, EqualityComparer<TKey>.Default, 0, source.Count);
        }

        [Pure]
        public static Dictionary<TKey, TSource> ToDictionary<TList, TSource, TKey>(this TList source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (keySelector is null) Throw.ArgumentNullException(nameof(keySelector));

            return ToDictionary<TList, TSource, TKey>(source, keySelector, comparer, 0, source.Count);
        }

        [Pure]
        public static Dictionary<TKey, TElement> ToDictionary<TList, TSource, TKey, TElement>(this TList source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (keySelector is null) Throw.ArgumentNullException(nameof(keySelector));
            if (elementSelector is null) Throw.ArgumentNullException(nameof(elementSelector));

            return ToDictionary<TList, TSource, TKey, TElement>(source, keySelector, elementSelector, EqualityComparer<TKey>.Default, 0, source.Count);
        }

        [Pure]
        public static Dictionary<TKey, TElement> ToDictionary<TList, TSource, TKey, TElement>(this TList source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (keySelector is null) Throw.ArgumentNullException(nameof(keySelector));
            if (elementSelector is null) Throw.ArgumentNullException(nameof(elementSelector));

            return ToDictionary<TList, TSource, TKey, TElement>(source, keySelector, elementSelector, comparer, 0, source.Count);
        }

        [Pure]
        static Dictionary<TKey, TSource> ToDictionary<TList, TSource, TKey>(this TList source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var dictionary = new Dictionary<TKey, TSource>(source.Count, comparer);
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
                dictionary.Add(keySelector(source[index]), source[index]);
            return dictionary;
        }

        [Pure]
        static Dictionary<TKey, TElement> ToDictionary<TList, TSource, TKey, TElement>(this TList source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var dictionary = new Dictionary<TKey, TElement>(source.Count, comparer);
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
                dictionary.Add(keySelector(source[index]), elementSelector(source[index]));
            return dictionary;
        }

        [Pure]
        static Dictionary<TKey, TSource> ToDictionary<TList, TSource, TKey>(this TList source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer, Predicate<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var dictionary = new Dictionary<TKey, TSource>(source.Count, comparer);
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                    dictionary.Add(keySelector(source[index]), source[index]);
            }
            return dictionary;
        }

        [Pure]
        static Dictionary<TKey, TElement> ToDictionary<TList, TSource, TKey, TElement>(this TList source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer, Predicate<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var dictionary = new Dictionary<TKey, TElement>(source.Count, comparer);
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                    dictionary.Add(keySelector(source[index]), elementSelector(source[index]));
            }
            return dictionary;
        }

        [Pure]
        static Dictionary<TKey, TSource> ToDictionary<TList, TSource, TKey>(this TList source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var dictionary = new Dictionary<TKey, TSource>(source.Count, comparer);
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index], index))
                    dictionary.Add(keySelector(source[index]), source[index]);
            }
            return dictionary;
        }

        [Pure]
        static Dictionary<TKey, TElement> ToDictionary<TList, TSource, TKey, TElement>(this TList source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var dictionary = new Dictionary<TKey, TElement>(source.Count, comparer);
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index], index))
                    dictionary.Add(keySelector(source[index]), elementSelector(source[index]));
            }
            return dictionary;
        }
    }
}

