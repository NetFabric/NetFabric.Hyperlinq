﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        
        public static Dictionary<TKey, TSource> ToDictionary<TEnumerable, TEnumerator, TSource, TKey>(this TEnumerable source, Selector<TSource, TKey> keySelector)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => ToDictionary<TEnumerable, TEnumerator, TSource, TKey>(source, keySelector, EqualityComparer<TKey>.Default);

        
        public static Dictionary<TKey, TSource> ToDictionary<TEnumerable, TEnumerator, TSource, TKey>(this TEnumerable source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (keySelector is null) Throw.ArgumentNullException(nameof(keySelector));

            using var enumerator = source.GetEnumerator();
            var dictionary = new Dictionary<TKey, TSource>(0, comparer);
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                dictionary.Add(keySelector(item), item);
            }
            return dictionary;
        }

        
        static Dictionary<TKey, TSource> ToDictionary<TEnumerable, TEnumerator, TSource, TKey>(this TEnumerable source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer, Predicate<TSource> predicate)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (keySelector is null) Throw.ArgumentNullException(nameof(keySelector));

            using var enumerator = source.GetEnumerator();
            var dictionary = new Dictionary<TKey, TSource>(0, comparer);
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (predicate(item))
                    dictionary.Add(keySelector(item), item);
            }
            return dictionary;
        }

        
        static Dictionary<TKey, TSource> ToDictionary<TEnumerable, TEnumerator, TSource, TKey>(this TEnumerable source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer, PredicateAt<TSource> predicate)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (keySelector is null) Throw.ArgumentNullException(nameof(keySelector));

            using var enumerator = source.GetEnumerator();
            checked
            {
                var dictionary = new Dictionary<TKey, TSource>(0, comparer);
                for (var index = 0; enumerator.MoveNext(); index++)
                {
                    var item = enumerator.Current;
                    if (predicate(item, index))
                        dictionary.Add(keySelector(item), item);
                }
                return dictionary;
            }
        }

        
        public static Dictionary<TKey, TElement> ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement>(this TEnumerable source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement>(source, keySelector, elementSelector, EqualityComparer<TKey>.Default);

        
        public static Dictionary<TKey, TElement> ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement>(this TEnumerable source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (keySelector is null) Throw.ArgumentNullException(nameof(keySelector));
            if (elementSelector is null) Throw.ArgumentNullException(nameof(elementSelector));

            var dictionary = new Dictionary<TKey, TElement>(0, comparer);

            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                dictionary.Add(keySelector(item), elementSelector(item));
            }

            return dictionary;
        }

        
        static Dictionary<TKey, TElement> ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement>(this TEnumerable source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer, Predicate<TSource> predicate)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (keySelector is null) Throw.ArgumentNullException(nameof(keySelector));
            if (elementSelector is null) Throw.ArgumentNullException(nameof(elementSelector));

            using var enumerator = source.GetEnumerator();
            var dictionary = new Dictionary<TKey, TElement>(0, comparer);
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (predicate(item))
                    dictionary.Add(keySelector(item), elementSelector(item));
            }
            return dictionary;
        }

        
        static Dictionary<TKey, TElement> ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement>(this TEnumerable source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer, PredicateAt<TSource> predicate)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (keySelector is null) Throw.ArgumentNullException(nameof(keySelector));
            if (elementSelector is null) Throw.ArgumentNullException(nameof(elementSelector));

            using var enumerator = source.GetEnumerator();
            checked
            {
                var dictionary = new Dictionary<TKey, TElement>(0, comparer);
                for (var index = 0; enumerator.MoveNext(); index++)
                {
                    var item = enumerator.Current;
                    if (predicate(item, index))
                        dictionary.Add(keySelector(item), elementSelector(item));
                }
                return dictionary;
            }
        }
    }
}
