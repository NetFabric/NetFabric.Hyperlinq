using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
                
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this ReadOnlySpan<TSource> source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = null)
            where TKey : notnull
        {
            if (keySelector is null) Throw.ArgumentNullException(nameof(keySelector));

            var dictionary = new Dictionary<TKey, TSource>(source.Length, comparer);
            for (var index = 0; index < source.Length; index++)
                dictionary.Add(keySelector(source[index]), source[index]);
            return dictionary;
        }

        static Dictionary<TKey, TSource> ToDictionary<TSource, TKey, TPredicate>(this ReadOnlySpan<TSource> source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TKey : notnull
            where TPredicate : struct, IPredicate<TSource>
        {
            var dictionary = new Dictionary<TKey, TSource>(source.Length, comparer);
            for (var index = 0; index < source.Length; index++)
            {
                var item = source[index];
                if (predicate.Invoke(item))
                dictionary.Add(keySelector(item), item);
            }
            return dictionary;
        }

        static Dictionary<TKey, TSource> ToDictionaryAt<TSource, TKey, TPredicate>(this ReadOnlySpan<TSource> source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TKey : notnull
            where TPredicate : struct, IPredicateAt<TSource>
        {
            var dictionary = new Dictionary<TKey, TSource>(source.Length, comparer);
            for (var index = 0; index < source.Length; index++)
            {
                var item = source[index];
                if (predicate.Invoke(item, index))
                    dictionary.Add(keySelector(item), item);
            }
            return dictionary;
        }

        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this ReadOnlySpan<TSource> source, Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = null)
            where TKey : notnull
        {
            if (keySelector is null) Throw.ArgumentNullException(nameof(keySelector));
            if (elementSelector is null) Throw.ArgumentNullException(nameof(elementSelector));

            var dictionary = new Dictionary<TKey, TElement>(source.Length, comparer);
            for (var index = 0; index < source.Length; index++)
                dictionary.Add(keySelector(source[index]), elementSelector(source[index])!);
            return dictionary;
        }

        static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement, TPredicate>(this ReadOnlySpan<TSource> source, Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TKey : notnull
            where TPredicate : struct, IPredicate<TSource>
        {
            var dictionary = new Dictionary<TKey, TElement>(source.Length, comparer);
            for (var index = 0; index < source.Length; index++)
            {
                var item = source[index];
                if (predicate.Invoke(item))
                    dictionary.Add(keySelector(item), elementSelector(item)!);
            }
            return dictionary;
        }

        static Dictionary<TKey, TElement> ToDictionaryAt<TSource, TKey, TElement, TPredicate>(this ReadOnlySpan<TSource> source, Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TKey : notnull
            where TPredicate : struct, IPredicateAt<TSource>
        {
            var dictionary = new Dictionary<TKey, TElement>(source.Length, comparer);
            for (var index = 0; index < source.Length; index++)
            {
                var item = source[index];
                if (predicate.Invoke(item, index))
                    dictionary.Add(keySelector(item), elementSelector(item)!);
            }
            return dictionary;
        }
    }
}

