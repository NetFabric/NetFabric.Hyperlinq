using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {
        
        public static Dictionary<TKey, TSource> ToDictionary<TEnumerable, TEnumerator, TSource, TKey>(this TEnumerable source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TKey : notnull
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

        
        static Dictionary<TKey, TSource> ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TPredicate>(this TEnumerable source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TKey : notnull
            where TPredicate : struct, IPredicate<TSource>
        {
            using var enumerator = source.GetEnumerator();
            var dictionary = new Dictionary<TKey, TSource>(0, comparer);
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (predicate.Invoke(item))
                    dictionary.Add(keySelector(item), item);
            }
            return dictionary;
        }

        
        static Dictionary<TKey, TSource> ToDictionaryAt<TEnumerable, TEnumerator, TSource, TKey, TPredicate>(this TEnumerable source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TKey : notnull
            where TPredicate : struct, IPredicateAt<TSource>
        {
            using var enumerator = source.GetEnumerator();
            checked
            {
                var dictionary = new Dictionary<TKey, TSource>(0, comparer);
                for (var index = 0; enumerator.MoveNext(); index++)
                {
                    var item = enumerator.Current;
                    if (predicate.Invoke(item, index))
                        dictionary.Add(keySelector(item), item);
                }
                return dictionary;
            }
        }

        
        public static Dictionary<TKey, TElement> ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement>(this TEnumerable source, Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TKey : notnull
        {
            if (keySelector is null) Throw.ArgumentNullException(nameof(keySelector));
            if (elementSelector is null) Throw.ArgumentNullException(nameof(elementSelector));

            var dictionary = new Dictionary<TKey, TElement>(0, comparer);

            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                dictionary.Add(keySelector(item), elementSelector(item)!);
            }

            return dictionary;
        }

        static Dictionary<TKey, TElement> ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement, TPredicate>(this TEnumerable source, Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TKey : notnull
            where TPredicate : struct, IPredicate<TSource>
        {
            using var enumerator = source.GetEnumerator();
            var dictionary = new Dictionary<TKey, TElement>(0, comparer);
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (predicate.Invoke(item))
                    dictionary.Add(keySelector(item), elementSelector(item)!);
            }
            return dictionary;
        }

        
        static Dictionary<TKey, TElement> ToDictionaryAt<TEnumerable, TEnumerator, TSource, TKey, TElement, TPredicate>(this TEnumerable source, Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TKey : notnull
            where TPredicate : struct, IPredicateAt<TSource>
        {
            using var enumerator = source.GetEnumerator();
            checked
            {
                var dictionary = new Dictionary<TKey, TElement>(0, comparer);
                for (var index = 0; enumerator.MoveNext(); index++)
                {
                    var item = enumerator.Current;
                    if (predicate.Invoke(item, index))
                        dictionary.Add(keySelector(item), elementSelector(item)!);
                }
                return dictionary;
            }
        }
    }
}
