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

        public static ReadOnlyCollection.SelectReadOnlyCollection<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult> Select<TKey, TValue, TResult>(
            this Dictionary<TKey, TValue> source,
            Func<KeyValuePair<TKey, TValue>, TResult> selector) 
            => ReadOnlyCollection.Select<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult>(source, selector);

        public static Enumerable.WhereEnumerable<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Where<TKey, TValue>(
            this Dictionary<TKey, TValue> source,
            Func<KeyValuePair<TKey, TValue>, bool> predicate) 
            => Enumerable.Where<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source, predicate);

        public static KeyValuePair<TKey, TValue> First<TKey, TValue>(this Dictionary<TKey, TValue> source) 
            => ReadOnlyCollection.First<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static KeyValuePair<TKey, TValue> FirstOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => ReadOnlyCollection.FirstOrDefault<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static KeyValuePair<TKey, TValue> Single<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => ReadOnlyCollection.Single<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static KeyValuePair<TKey, TValue> SingleOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => ReadOnlyCollection.SingleOrDefault<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static List<KeyValuePair<TKey, TValue>> ToList<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => ReadOnlyCollection.ToList<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);
    }
}
