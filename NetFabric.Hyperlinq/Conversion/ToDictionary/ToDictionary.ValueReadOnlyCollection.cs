using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollectionExtensions
    {
        
        public static Dictionary<TKey, TSource> ToDictionary<TEnumerable, TEnumerator, TSource, TKey>(this TEnumerable source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TKey : notnull
        {
            if (keySelector is null) Throw.ArgumentNullException(nameof(keySelector));

            var dictionary = new Dictionary<TKey, TSource>(0, comparer);
            if (source.Count != 0)
            {
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    var item = enumerator.Current;
                    dictionary.Add(keySelector(item), item);
                }
            }
            return dictionary;
        }

        
        static Dictionary<TKey, TSource> ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TPredicate>(this TEnumerable source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TKey : notnull
            where TPredicate : struct, IPredicate<TSource>
        {
            var dictionary = new Dictionary<TKey, TSource>(0, comparer);
            if (source.Count != 0)
            {
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    var item = enumerator.Current;
                    if (predicate.Invoke(item))
                        dictionary.Add(keySelector(item), item);
                }
            }
            return dictionary;
        }

        
        static Dictionary<TKey, TSource> ToDictionaryAt<TEnumerable, TEnumerator, TSource, TKey, TPredicate>(this TEnumerable source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TKey : notnull
            where TPredicate : struct, IPredicateAt<TSource>
        {
            var dictionary = new Dictionary<TKey, TSource>(0, comparer);
            if (source.Count != 0)
            {
                using var enumerator = source.GetEnumerator();
                checked
                {
                    for (var index = 0; enumerator.MoveNext(); index++)
                    {
                        var item = enumerator.Current;
                        if (predicate.Invoke(item, index))
                            dictionary.Add(keySelector(item), item);
                    }
                }
            }
            return dictionary;
        }

        
        public static Dictionary<TKey, TElement> ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement>(this TEnumerable source, Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TKey : notnull
        {
            if (keySelector is null) Throw.ArgumentNullException(nameof(keySelector));
            if (elementSelector is null) Throw.ArgumentNullException(nameof(elementSelector));

            var dictionary = new Dictionary<TKey, TElement>(0, comparer);
            if (source.Count != 0)
            {
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    var item = enumerator.Current;
                    dictionary.Add(keySelector(item), elementSelector(item)!);
                }
            }
            return dictionary;
        }

        
        static Dictionary<TKey, TElement> ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement, TPredicate>(this TEnumerable source, Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TKey : notnull
            where TPredicate : struct, IPredicate<TSource>
        {
            var dictionary = new Dictionary<TKey, TElement>(0, comparer);
            if (source.Count != 0)
            {
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (predicate.Invoke(enumerator.Current))
                        dictionary.Add(keySelector(enumerator.Current), elementSelector(enumerator.Current)!);
                }
            }
            return dictionary;
        }

        
        static Dictionary<TKey, TElement> ToDictionaryAt<TEnumerable, TEnumerator, TSource, TKey, TElement, TPredicate>(this TEnumerable source, Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TKey : notnull
            where TPredicate : struct, IPredicateAt<TSource>
        {
            var dictionary = new Dictionary<TKey, TElement>(0, comparer);
            if (source.Count != 0)
            {
                using var enumerator = source.GetEnumerator();
                checked
                {
                    for (var index = 0; enumerator.MoveNext(); index++)
                    {
                        var item = enumerator.Current;
                        if (predicate.Invoke(item, index))
                            dictionary.Add(keySelector(item), elementSelector(item)!);
                    }
                }
            }
            return dictionary;
        }
    }
}

