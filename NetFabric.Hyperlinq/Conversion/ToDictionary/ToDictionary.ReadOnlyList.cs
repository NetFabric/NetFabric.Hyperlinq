using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        
        public static Dictionary<TKey, TSource> ToDictionary<TList, TSource, TKey>(this TList source, NullableSelector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
            where TList : IReadOnlyList<TSource>
        {
            if (keySelector is null) Throw.ArgumentNullException(nameof(keySelector));

            return ToDictionary<TList, TSource, TKey>(source, keySelector, comparer, 0, source.Count);
        }

        
        public static Dictionary<TKey, TElement> ToDictionary<TList, TSource, TKey, TElement>(this TList source, NullableSelector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
            where TList : IReadOnlyList<TSource>
        {
            if (keySelector is null) Throw.ArgumentNullException(nameof(keySelector));
            if (elementSelector is null) Throw.ArgumentNullException(nameof(elementSelector));

            return ToDictionary<TList, TSource, TKey, TElement>(source, keySelector, elementSelector, comparer, 0, source.Count);
        }


        static Dictionary<TKey, TSource> ToDictionary<TList, TSource, TKey>(this TList source, NullableSelector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer, int offset, int count)
            where TList : IReadOnlyList<TSource>
        {
            var dictionary = new Dictionary<TKey, TSource>(source.Count, comparer);
            var end = offset + count;
            for (var index = offset; index < end; index++)
                dictionary.Add(keySelector(source[index]), source[index]);
            return dictionary;
        }


        static Dictionary<TKey, TElement> ToDictionary<TList, TSource, TKey, TElement>(this TList source, NullableSelector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer, int offset, int count)
            where TList : IReadOnlyList<TSource>
        {
            var dictionary = new Dictionary<TKey, TElement>(source.Count, comparer);
            var end = offset + count;
            for (var index = offset; index < end; index++)
                dictionary.Add(keySelector(source[index]), elementSelector(source[index]));
            return dictionary;
        }


        static Dictionary<TKey, TSource> ToDictionary<TList, TSource, TKey>(this TList source, NullableSelector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer, Predicate<TSource> predicate, int offset, int count)
            where TList : IReadOnlyList<TSource>
        {
            var dictionary = new Dictionary<TKey, TSource>(source.Count, comparer);
            var end = offset + count;
            for (var index = offset; index < end; index++)
            {
                if (predicate(source[index]))
                    dictionary.Add(keySelector(source[index]), source[index]);
            }
            return dictionary;
        }


        static Dictionary<TKey, TElement> ToDictionary<TList, TSource, TKey, TElement>(this TList source, NullableSelector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer, Predicate<TSource> predicate, int offset, int count)
            where TList : IReadOnlyList<TSource>
        {
            var dictionary = new Dictionary<TKey, TElement>(source.Count, comparer);
            var end = offset + count;
            for (var index = offset; index < end; index++)
            {
                if (predicate(source[index]))
                    dictionary.Add(keySelector(source[index]), elementSelector(source[index]));
            }
            return dictionary;
        }


        static Dictionary<TKey, TSource> ToDictionary<TList, TSource, TKey>(this TList source, NullableSelector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer, PredicateAt<TSource> predicate, int offset, int count)
            where TList : IReadOnlyList<TSource>
        {
            var dictionary = new Dictionary<TKey, TSource>(source.Count, comparer);
            var end = offset + count;
            for (var index = offset; index < end; index++)
            {
                if (predicate(source[index], index))
                    dictionary.Add(keySelector(source[index]), source[index]);
            }
            return dictionary;
        }


        static Dictionary<TKey, TElement> ToDictionary<TList, TSource, TKey, TElement>(this TList source, NullableSelector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer, PredicateAt<TSource> predicate, int offset, int count)
            where TList : IReadOnlyList<TSource>
        {
            var dictionary = new Dictionary<TKey, TElement>(source.Count, comparer);
            var end = offset + count;
            for (var index = offset; index < end; index++)
            {
                if (predicate(source[index], index))
                    dictionary.Add(keySelector(source[index]), elementSelector(source[index]));
            }
            return dictionary;
        }
    }
}

