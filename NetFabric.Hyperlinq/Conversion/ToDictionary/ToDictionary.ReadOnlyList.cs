using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        
        public static Dictionary<TKey, TSource> ToDictionary<TList, TSource, TKey>(this TList source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = null)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (keySelector is null) Throw.ArgumentNullException(nameof(keySelector));

            return ToDictionary<TList, TSource, TKey>(source, keySelector, comparer, 0, source.Count);
        }

        
        public static Dictionary<TKey, TElement> ToDictionary<TList, TSource, TKey, TElement>(this TList source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = null)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (keySelector is null) Throw.ArgumentNullException(nameof(keySelector));
            if (elementSelector is null) Throw.ArgumentNullException(nameof(elementSelector));

            return ToDictionary<TList, TSource, TKey, TElement>(source, keySelector, elementSelector, comparer, 0, source.Count);
        }


        static Dictionary<TKey, TSource> ToDictionary<TList, TSource, TKey>(this TList source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var dictionary = new Dictionary<TKey, TSource>(source.Count, comparer);
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
                dictionary.Add(keySelector(source[index]), source[index]);
            return dictionary;
        }


        static Dictionary<TKey, TElement> ToDictionary<TList, TSource, TKey, TElement>(this TList source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var dictionary = new Dictionary<TKey, TElement>(source.Count, comparer);
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
                dictionary.Add(keySelector(source[index]), elementSelector(source[index]));
            return dictionary;
        }


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

