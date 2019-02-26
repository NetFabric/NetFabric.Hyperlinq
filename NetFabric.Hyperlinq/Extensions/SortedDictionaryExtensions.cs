using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class SortedDictionaryExtensions
    {
        public static int Count<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => source.Count;

        public static int Count<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => ReadOnlyCollection.Count<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source, predicate);

        public static bool All<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => ReadOnlyCollection.All<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source, predicate);

        public static bool Any<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => source.Count != 0;

        public static bool Any<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => ReadOnlyCollection.Any<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source, predicate);

        public static bool Contains<TKey, TValue>(this SortedDictionary<TKey, TValue> source, KeyValuePair<TKey, TValue> value)
            => source.Contains(value);

        public static bool Contains<TKey, TValue>(this SortedDictionary<TKey, TValue> source, KeyValuePair<TKey, TValue> value, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer)
            => source.Contains(value, comparer);

        public static ReadOnlyCollection.SelectEnumerable<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult> Select<TKey, TValue, TResult>(
            this SortedDictionary<TKey, TValue> source,
            Func<KeyValuePair<TKey, TValue>, TResult> selector) 
            => ReadOnlyCollection.Select<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult>(source, selector);

        public static Enumerable.WhereEnumerable<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Where<TKey, TValue>(
            this SortedDictionary<TKey, TValue> source,
            Func<KeyValuePair<TKey, TValue>, bool> predicate) 
            => Enumerable.Where<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source, predicate);

        public static KeyValuePair<TKey, TValue> First<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ReadOnlyCollection.First<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static KeyValuePair<TKey, TValue> First<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => Enumerable.First<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source, predicate);

        public static KeyValuePair<TKey, TValue> FirstOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ReadOnlyCollection.FirstOrDefault<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static KeyValuePair<TKey, TValue> FirstOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => Enumerable.FirstOrDefault<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source, predicate);

        public static KeyValuePair<TKey, TValue>? FirstOrNull<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ReadOnlyCollection.FirstOrNull<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static KeyValuePair<TKey, TValue>? FirstOrNull<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => Enumerable.FirstOrNull<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source, predicate);

        public static KeyValuePair<TKey, TValue> Single<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ReadOnlyCollection.Single<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static KeyValuePair<TKey, TValue> Single<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => Enumerable.Single<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source, predicate);

        public static KeyValuePair<TKey, TValue> SingleOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ReadOnlyCollection.SingleOrDefault<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static KeyValuePair<TKey, TValue> SingleOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => Enumerable.SingleOrDefault<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source, predicate);

        public static KeyValuePair<TKey, TValue>? SingleOrNull<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ReadOnlyCollection.SingleOrNull<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static KeyValuePair<TKey, TValue>? SingleOrNull<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => Enumerable.SingleOrNull<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source, predicate);

        public static IEnumerable<KeyValuePair<TKey, TValue>> AsEnumerable<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => source;

        public static IReadOnlyCollection<KeyValuePair<TKey, TValue>> AsReadOnlyCollection<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => source;

        public static Enumerable.AsValueEnumerableEnumerable<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> AsValueEnumerable<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => Enumerable.AsValueEnumerable<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static ReadOnlyCollection.AsValueReadOnlyCollectionEnumerable<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> AsValueReadOnlyCollection<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ReadOnlyCollection.AsValueReadOnlyCollection<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static KeyValuePair<TKey, TValue>[] ToArray<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ReadOnlyCollection.ToArray<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static List<KeyValuePair<TKey, TValue>> ToList<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ReadOnlyCollection.ToList<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);
    }
}
