using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class SortedDictionaryKeysExtensions
    {
        public static int Count<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source)
            => source.Count;

        public static int Count<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, Func<TKey, bool> predicate)
            => ReadOnlyCollection.Count<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source, predicate);

        public static ReadOnlyCollection.SelectReadOnlyCollection<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TResult> Select<TKey, TValue, TResult>(
            this SortedDictionary<TKey, TValue>.KeyCollection source,
            Func<TKey, TResult> selector) 
            => ReadOnlyCollection.Select<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TResult>(source, selector);

        public static Enumerable.WhereEnumerable<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey> Where<TKey, TValue>(
            this SortedDictionary<TKey, TValue>.KeyCollection source,
            Func<TKey, bool> predicate) 
            => Enumerable.Where<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source, predicate);

        public static TKey First<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source)
            => ReadOnlyCollection.First<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source);

        public static TKey FirstOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source)
            => ReadOnlyCollection.FirstOrDefault<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source);

        public static TKey Single<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source)
            => ReadOnlyCollection.Single<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source);

        public static TKey SingleOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source)
            => ReadOnlyCollection.SingleOrDefault<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source);

        public static IEnumerable<TValue> AsEnumerable<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => source.Values;

        public static IReadOnlyCollection<TValue> AsReadOnlyCollection<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => source.Values;

        public static Enumerable.AsValueEnumerableEnumerable<SortedDictionary<TKey, TValue>.ValueCollection, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue> AsValueEnumerable<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => Enumerable.AsValueEnumerable<SortedDictionary<TKey, TValue>.ValueCollection, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source.Values);

        public static ReadOnlyCollection.AsValueReadOnlyCollectionEnumerable<SortedDictionary<TKey, TValue>.ValueCollection, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue> AsValueReadOnlyCollection<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ReadOnlyCollection.AsValueReadOnlyCollection<SortedDictionary<TKey, TValue>.ValueCollection, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source.Values);

        public static TValue[] ToArray<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ReadOnlyCollection.ToArray<SortedDictionary<TKey, TValue>.ValueCollection, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source.Values);

        public static List<TValue> ToList<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ReadOnlyCollection.ToList<SortedDictionary<TKey, TValue>.ValueCollection, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source.Values);
    }
}
