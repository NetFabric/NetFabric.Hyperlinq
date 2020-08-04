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
    }
}

