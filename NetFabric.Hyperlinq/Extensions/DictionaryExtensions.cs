using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class DictionaryExtensions
    {
        public static int Count<TKey, TValue>(this Dictionary<TKey, TValue> source) 
            => source.Count;

        public static int Count<TKey, TValue>(this Dictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => ReadOnlyCollection.Count<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source, predicate);

        public static bool All<TKey, TValue>(this Dictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => ReadOnlyCollection.All<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source, predicate);

        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => source.Count != 0;

        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => ReadOnlyCollection.Any<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source, predicate);

        public static bool Contains<TKey, TValue>(this Dictionary<TKey, TValue> source, KeyValuePair<TKey, TValue> value)
            => source.Contains(value);

        public static bool Contains<TKey, TValue>(this Dictionary<TKey, TValue> source, KeyValuePair<TKey, TValue> value, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer)
            => source.Contains(value, comparer);

        public static ReadOnlyCollection.SelectEnumerable<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult> Select<TKey, TValue, TResult>(
            this Dictionary<TKey, TValue> source,
            Func<KeyValuePair<TKey, TValue>, TResult> selector) 
            => ReadOnlyCollection.Select<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult>(source, selector);

        public static Enumerable.WhereEnumerable<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Where<TKey, TValue>(
            this Dictionary<TKey, TValue> source,
            Func<KeyValuePair<TKey, TValue>, bool> predicate) 
            => Enumerable.Where<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source, predicate);

        public static KeyValuePair<TKey, TValue> First<TKey, TValue>(this Dictionary<TKey, TValue> source) 
            => ReadOnlyCollection.First<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static KeyValuePair<TKey, TValue> First<TKey, TValue>(this Dictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => Enumerable.First<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source, predicate);

        public static KeyValuePair<TKey, TValue> FirstOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => ReadOnlyCollection.FirstOrDefault<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static KeyValuePair<TKey, TValue> FirstOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => Enumerable.FirstOrDefault<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source, predicate);

        public static KeyValuePair<TKey, TValue>? FirstOrNull<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => ReadOnlyCollection.FirstOrNull<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static KeyValuePair<TKey, TValue>? FirstOrNull<TKey, TValue>(this Dictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => Enumerable.FirstOrNull<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source, predicate);

        public static KeyValuePair<TKey, TValue> Single<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => ReadOnlyCollection.Single<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static KeyValuePair<TKey, TValue> Single<TKey, TValue>(this Dictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => Enumerable.Single<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source, predicate);

        public static KeyValuePair<TKey, TValue> SingleOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => ReadOnlyCollection.SingleOrDefault<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static KeyValuePair<TKey, TValue> SingleOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => Enumerable.SingleOrDefault<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source, predicate);

        public static KeyValuePair<TKey, TValue>? SingleOrNull<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => ReadOnlyCollection.SingleOrNull<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static KeyValuePair<TKey, TValue>? SingleOrNull<TKey, TValue>(this Dictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => Enumerable.SingleOrNull<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source, predicate);

        public static IEnumerable<KeyValuePair<TKey, TValue>> AsEnumerable<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => source;

        public static IReadOnlyCollection<KeyValuePair<TKey, TValue>> AsReadOnlyCollection<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => source;

        public static Enumerable.AsValueEnumerableEnumerable<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> AsValueEnumerable<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => Enumerable.AsValueEnumerable<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static ReadOnlyCollection.AsValueReadOnlyCollectionEnumerable<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> AsValueReadOnlyCollection<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => ReadOnlyCollection.AsValueReadOnlyCollection<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static KeyValuePair<TKey, TValue>[] ToArray<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => ReadOnlyCollection.ToArray<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static List<KeyValuePair<TKey, TValue>> ToList<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => ReadOnlyCollection.ToList<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);
    }
}
