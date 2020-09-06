using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        
        public static Dictionary<TKey, TSource> ToDictionary<TList, TSource, TKey>(this TList source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
            where TList : notnull, IReadOnlyList<TSource>
            where TKey : notnull
        {
            if (keySelector is null) Throw.ArgumentNullException(nameof(keySelector));

            return ToDictionary<TList, TSource, TKey>(source, keySelector, comparer, 0, source.Count);
        }

        
        public static Dictionary<TKey, TElement> ToDictionary<TList, TSource, TKey, TElement>(this TList source, Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
            where TList : notnull, IReadOnlyList<TSource>
            where TKey : notnull
        {
            if (keySelector is null) Throw.ArgumentNullException(nameof(keySelector));
            if (elementSelector is null) Throw.ArgumentNullException(nameof(elementSelector));

            return ToDictionary<TList, TSource, TKey, TElement>(source, keySelector, elementSelector, comparer, 0, source.Count);
        }


        static Dictionary<TKey, TSource> ToDictionary<TList, TSource, TKey>(this TList source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            where TKey : notnull
        {
            var dictionary = new Dictionary<TKey, TSource>(source.Count, comparer);
            var end = offset + count - 1;
            for (var index = offset; index <= end; index++)
                dictionary.Add(keySelector(source[index]), source[index]);
            return dictionary;
        }


        static Dictionary<TKey, TElement> ToDictionary<TList, TSource, TKey, TElement>(this TList source, Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            where TKey : notnull
        {
            var dictionary = new Dictionary<TKey, TElement>(source.Count, comparer);
            var end = offset + count - 1;
            for (var index = offset; index <= end; index++)
                dictionary.Add(keySelector(source[index]), elementSelector(source[index])!);
            return dictionary;
        }


        static Dictionary<TKey, TSource> ToDictionary<TList, TSource, TKey, TPredicate>(this TList source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer, TPredicate predicate, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            where TKey : notnull
            where TPredicate : struct, IPredicate<TSource>
        {
            var dictionary = new Dictionary<TKey, TSource>(source.Count, comparer);
            var end = offset + count - 1;
            for (var index = offset; index <= end; index++)
            {
                if (predicate.Invoke(source[index]))
                    dictionary.Add(keySelector(source[index]), source[index]);
            }
            return dictionary;
        }


        static Dictionary<TKey, TElement> ToDictionary<TList, TSource, TKey, TElement, TPredicate>(this TList source, Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer, TPredicate predicate, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            where TKey : notnull
            where TPredicate : struct, IPredicate<TSource>
        {
            var dictionary = new Dictionary<TKey, TElement>(source.Count, comparer);
            var end = offset + count - 1;
            for (var index = offset; index <= end; index++)
            {
                if (predicate.Invoke(source[index]))
                    dictionary.Add(keySelector(source[index]), elementSelector(source[index])!);
            }
            return dictionary;
        }


        static Dictionary<TKey, TSource> ToDictionaryAt<TList, TSource, TKey, TPredicate>(this TList source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer, TPredicate predicate, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            where TKey : notnull
            where TPredicate : struct, IPredicateAt<TSource>
        {
            var dictionary = new Dictionary<TKey, TSource>(source.Count, comparer);
            var end = offset + count - 1;
            for (var index = offset; index <= end; index++)
            {
                if (predicate.Invoke(source[index], index))
                    dictionary.Add(keySelector(source[index]), source[index]);
            }
            return dictionary;
        }


        static Dictionary<TKey, TElement> ToDictionaryAt<TList, TSource, TKey, TElement, TPredicate>(this TList source, Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer, TPredicate predicate, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            where TKey : notnull
            where TPredicate : struct, IPredicateAt<TSource>
        {
            var dictionary = new Dictionary<TKey, TElement>(source.Count, comparer);
            var end = offset + count - 1;
            for (var index = offset; index <= end; index++)
            {
                if (predicate.Invoke(source[index], index))
                    dictionary.Add(keySelector(source[index]), elementSelector(source[index])!);
            }
            return dictionary;
        }
    }
}

