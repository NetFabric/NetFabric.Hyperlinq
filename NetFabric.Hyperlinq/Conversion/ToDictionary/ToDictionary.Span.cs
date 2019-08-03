using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this Span<TSource> source, Func<TSource, TKey> keySelector)
            => ToDictionary<TSource, TKey>(source, keySelector, EqualityComparer<TKey>.Default, 0, source.Length);

        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this Span<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
            => ToDictionary<TSource, TKey>(source, keySelector, comparer, 0, source.Length);

        static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this Span<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer, int skipCount, int takeCount)
        {
            var dictionary = new Dictionary<TKey, TSource>(source.Length, comparer);
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
                dictionary.Add(keySelector(source[index]), source[index]);
            return dictionary;
        }

        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this Span<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
            => ToDictionary<TSource, TKey, TElement>(source, keySelector, elementSelector, EqualityComparer<TKey>.Default, 0, source.Length);

        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this Span<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer)
            => ToDictionary<TSource, TKey, TElement>(source, keySelector, elementSelector, comparer, 0, source.Length);

        static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this Span<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer, int skipCount, int takeCount)
        {
            var dictionary = new Dictionary<TKey, TElement>(source.Length, comparer);
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
                dictionary.Add(keySelector(source[index]), elementSelector(source[index]));
            return dictionary;
        }
    }
}

