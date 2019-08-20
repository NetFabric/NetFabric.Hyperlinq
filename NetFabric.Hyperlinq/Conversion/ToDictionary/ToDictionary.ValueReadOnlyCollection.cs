using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        [Pure]
        public static Dictionary<TKey, TSource> ToDictionary<TEnumerable, TEnumerator, TSource, TKey>(this TEnumerable source, Func<TSource, TKey> keySelector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => ToDictionary<TEnumerable, TEnumerator, TSource, TKey>(source, keySelector, EqualityComparer<TKey>.Default);

        [Pure]
        public static Dictionary<TKey, TSource> ToDictionary<TEnumerable, TEnumerator, TSource, TKey>(this TEnumerable source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (keySelector is null) ThrowHelper.ThrowArgumentNullException(nameof(keySelector));

            var dictionary = new Dictionary<TKey, TSource>(source.Count, comparer);
            foreach (var item in source)
                dictionary.Add(keySelector(item), item);
            return dictionary;
        }

        [Pure]
        public static Dictionary<TKey, TElement> ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement>(this TEnumerable source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement>(source, keySelector, elementSelector, EqualityComparer<TKey>.Default);

        [Pure]
        public static Dictionary<TKey, TElement> ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement>(this TEnumerable source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (keySelector is null) ThrowHelper.ThrowArgumentNullException(nameof(keySelector));
            if (elementSelector is null) ThrowHelper.ThrowArgumentNullException(nameof(elementSelector));

            var dictionary = new Dictionary<TKey, TElement>(source.Count, comparer);
            foreach (var item in source)
                dictionary.Add(keySelector(item), elementSelector(item));
            return dictionary;
        }
    }
}

