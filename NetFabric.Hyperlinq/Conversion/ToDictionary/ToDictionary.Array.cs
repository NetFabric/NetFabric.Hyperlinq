using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this TSource[] source, Selector<TSource, TKey> keySelector)
        {
            if (keySelector is null) ThrowHelper.ThrowArgumentNullException(nameof(keySelector));

            return ToDictionary<TSource, TKey>(source, keySelector, EqualityComparer<TKey>.Default, 0, source.Length);
        }

        [Pure]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this TSource[] source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            if (keySelector is null) ThrowHelper.ThrowArgumentNullException(nameof(keySelector));

            return ToDictionary<TSource, TKey>(source, keySelector, comparer, 0, source.Length);
        }

        [Pure]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this TSource[] source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector)
        {
            if (keySelector is null) ThrowHelper.ThrowArgumentNullException(nameof(keySelector));
            if (elementSelector is null) ThrowHelper.ThrowArgumentNullException(nameof(elementSelector));

            return ToDictionary<TSource, TKey, TElement>(source, keySelector, elementSelector, EqualityComparer<TKey>.Default, 0, source.Length);
        }

        [Pure]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this TSource[] source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            if (keySelector is null) ThrowHelper.ThrowArgumentNullException(nameof(keySelector));
            if (elementSelector is null) ThrowHelper.ThrowArgumentNullException(nameof(elementSelector));

            return ToDictionary<TSource, TKey, TElement>(source, keySelector, elementSelector, comparer, 0, source.Length);
        }

        [Pure]
        [return:NotNull]
        static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this TSource[] source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer, int skipCount, int takeCount)
        {
            var dictionary = new Dictionary<TKey, TSource>(source.Length, comparer);
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
                dictionary.Add(keySelector(source[index]), source[index]);
            return dictionary;
        }

        [Pure]
        static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this TSource[] source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer, int skipCount, int takeCount)
        {
            var dictionary = new Dictionary<TKey, TElement>(source.Length, comparer);
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
                dictionary.Add(keySelector(source[index]), elementSelector(source[index]));
            return dictionary;
        }

        [Pure]
        static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this TSource[] source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer, Predicate<TSource> predicate, int skipCount, int takeCount)
        {
            var dictionary = new Dictionary<TKey, TSource>(source.Length, comparer);
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                    dictionary.Add(keySelector(source[index]), source[index]);
            }
            return dictionary;
        }

        [Pure]
        static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this TSource[] source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer, Predicate<TSource> predicate, int skipCount, int takeCount)
        {
            var dictionary = new Dictionary<TKey, TElement>(source.Length, comparer);
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                    dictionary.Add(keySelector(source[index]), elementSelector(source[index]));
            }
            return dictionary;
        }

        [Pure]
        static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this TSource[] source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer, PredicateAt<TSource> predicate, int skipCount, int takeCount)
        {
            var dictionary = new Dictionary<TKey, TSource>(source.Length, comparer);
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index], index))
                    dictionary.Add(keySelector(source[index]), source[index]);
            }
            return dictionary;
        }

        [Pure]
        static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this TSource[] source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer, PredicateAt<TSource> predicate, int skipCount, int takeCount)
        {
            var dictionary = new Dictionary<TKey, TElement>(source.Length, comparer);
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

