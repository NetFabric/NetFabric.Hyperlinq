using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class DictionaryKeysExtensions
    {
        public static int Count<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            => source.Count;

        public static int Count<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, Func<TKey, bool> predicate)
            => ReadOnlyCollection.Count<Dictionary<TKey, TValue>.KeyCollection, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source, predicate);

        public static bool All<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, Func<TKey, bool> predicate)
            => ReadOnlyCollection.All<Dictionary<TKey, TValue>.KeyCollection, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source, predicate);

        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            => source.Count != 0;

        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, Func<TKey, bool> predicate)
            => ReadOnlyCollection.Any<Dictionary<TKey, TValue>.KeyCollection, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source, predicate);

        public static bool Contains<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, KeyValuePair<TKey, TValue> value)
            => source.Contains(value);

        public static bool Contains<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, KeyValuePair<TKey, TValue> value, IEqualityComparer<TKey> comparer)
            => source.Contains(value, comparer);

        public static ReadOnlyCollection.SelectEnumerable<Dictionary<TKey, TValue>.KeyCollection, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TResult> Select<TKey, TValue, TResult>(
            this Dictionary<TKey, TValue>.KeyCollection source,
            Func<TKey, TResult> selector) 
            => ReadOnlyCollection.Select<Dictionary<TKey, TValue>.KeyCollection, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TResult>(source, selector);

        public static Enumerable.WhereEnumerable<Dictionary<TKey, TValue>.KeyCollection, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey> Where<TKey, TValue>(
            this Dictionary<TKey, TValue>.KeyCollection source,
            Func<TKey, bool> predicate) 
            => Enumerable.Where<Dictionary<TKey, TValue>.KeyCollection, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source, predicate);

        public static TKey First<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source) 
            => ReadOnlyCollection.First<Dictionary<TKey, TValue>.KeyCollection, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source);

        public static TKey FirstOrDefault<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            => ReadOnlyCollection.FirstOrDefault<Dictionary<TKey, TValue>.KeyCollection, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source);

        public static TKey Single<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            => ReadOnlyCollection.Single<Dictionary<TKey, TValue>.KeyCollection, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source);

        public static TKey SingleOrDefault<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            => ReadOnlyCollection.SingleOrDefault<Dictionary<TKey, TValue>.KeyCollection, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source);

        public static IEnumerable<TValue> AsEnumerable<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => source.Values;

        public static IReadOnlyCollection<TValue> AsReadOnlyCollection<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => source.Values;

        public static Enumerable.AsValueEnumerableEnumerable<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue> AsValueEnumerable<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => Enumerable.AsValueEnumerable<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source.Values);

        public static ReadOnlyCollection.AsValueReadOnlyCollectionEnumerable<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue> AsValueReadOnlyCollection<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => ReadOnlyCollection.AsValueReadOnlyCollection<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source.Values);

        public static TValue[] ToArray<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => ReadOnlyCollection.ToArray<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source.Values);

        public static List<TValue> ToList<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => ReadOnlyCollection.ToList<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source.Values);
    }
}
