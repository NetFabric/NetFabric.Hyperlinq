using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        [Pure]
        public static Dictionary<TKey, TSource> ToDictionary<TEnumerable, TEnumerator, TSource, TKey>(this TEnumerable source, Func<TSource, TKey> keySelector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => ToDictionary<TEnumerable, TEnumerator, TSource, TKey>(source, keySelector, EqualityComparer<TKey>.Default);

        [Pure]
        public static Dictionary<TKey, TSource> ToDictionary<TEnumerable, TEnumerator, TSource, TKey>(this TEnumerable source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (keySelector is null) ThrowHelper.ThrowArgumentNullException(nameof(keySelector));

            var dictionary = new Dictionary<TKey, TSource>(0, comparer);
            foreach (var item in source)
                dictionary.Add(keySelector(item), item);
            return dictionary;
        }

        [Pure]
        static Dictionary<TKey, TSource> ToDictionary<TEnumerable, TEnumerator, TSource, TKey>(this TEnumerable source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer, Func<TSource, bool> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (keySelector is null) ThrowHelper.ThrowArgumentNullException(nameof(keySelector));

            var dictionary = new Dictionary<TKey, TSource>(0, comparer);
            foreach (var item in source)
            {
                if (predicate(item))
                    dictionary.Add(keySelector(item), item);
            }
            return dictionary;
        }

        [Pure]
        static Dictionary<TKey, TSource> ToDictionary<TEnumerable, TEnumerator, TSource, TKey>(this TEnumerable source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer, Func<TSource, int, bool> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (keySelector is null) ThrowHelper.ThrowArgumentNullException(nameof(keySelector));

            var dictionary = new Dictionary<TKey, TSource>(0, comparer);
            var index = 0;
            foreach (var item in source)
            {
                if (predicate(item, index))
                    dictionary.Add(keySelector(item), item);

                checked { index++; }
            }
            return dictionary;
        }

        [Pure]
        public static Dictionary<TKey, TElement> ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement>(this TEnumerable source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement>(source, keySelector, elementSelector, EqualityComparer<TKey>.Default);

        [Pure]
        public static Dictionary<TKey, TElement> ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement>(this TEnumerable source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (keySelector is null) ThrowHelper.ThrowArgumentNullException(nameof(keySelector));
            if (elementSelector is null) ThrowHelper.ThrowArgumentNullException(nameof(elementSelector));

            var dictionary = new Dictionary<TKey, TElement>(0, comparer);
            foreach (var item in source)
                dictionary.Add(keySelector(item), elementSelector(item));
            return dictionary;
        }

        [Pure]
        static Dictionary<TKey, TElement> ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement>(this TEnumerable source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer, Func<TSource, bool> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (keySelector is null) ThrowHelper.ThrowArgumentNullException(nameof(keySelector));
            if (elementSelector is null) ThrowHelper.ThrowArgumentNullException(nameof(elementSelector));

            var dictionary = new Dictionary<TKey, TElement>(0, comparer);
            foreach (var item in source)
            {
                if (predicate(item))
                    dictionary.Add(keySelector(item), elementSelector(item));
            }
            return dictionary;
        }

        [Pure]
        static Dictionary<TKey, TElement> ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement>(this TEnumerable source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer, Func<TSource, int, bool> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (keySelector is null) ThrowHelper.ThrowArgumentNullException(nameof(keySelector));
            if (elementSelector is null) ThrowHelper.ThrowArgumentNullException(nameof(elementSelector));

            var dictionary = new Dictionary<TKey, TElement>(0, comparer);
            var index = 0;
            foreach (var item in source)
            {
                if (predicate(item, index))
                    dictionary.Add(keySelector(item), elementSelector(item));

                checked { index++; }
            }
            return dictionary;
        }
    }
}
