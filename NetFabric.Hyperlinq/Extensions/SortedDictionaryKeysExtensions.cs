using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static class SortedDictionaryKeysExtensions
    {
        public static int Count<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source)
            => source.Count;

        public static int Count<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, Func<TKey, bool> predicate)
            => ReadOnlyCollection.Count<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source, predicate);

        public static bool All<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, Func<TKey, bool> predicate)
            => ReadOnlyCollection.All<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source, predicate);

        public static bool Any<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source)
            => source.Count != 0;

        public static bool Any<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, Func<TKey, bool> predicate)
            => ReadOnlyCollection.Any<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source, predicate);

        public static bool Contains<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, TKey value)
            => source.Contains(value);

        public static bool Contains<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, TKey value, IEqualityComparer<TKey> comparer)
            => ReadOnlyCollection.Contains<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source, value, comparer);

        public static ReadOnlyCollection.SelectEnumerable<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TResult> Select<TKey, TValue, TResult>(
            this SortedDictionary<TKey, TValue>.KeyCollection source,
            Func<TKey, TResult> selector) 
            => ReadOnlyCollection.Select<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TResult>(source, selector);

        public static Enumerable.SelectManyEnumerable<SortedDictionary<TKey, TValue>.KeyCollection,  SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TKey, TValue, TSubEnumerable, TSubEnumerator, TResult>(
            this SortedDictionary<TKey, TValue>.KeyCollection source,
            Func<TKey, TSubEnumerable> selector) 
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IValueEnumerator<TResult>
            => Enumerable.SelectMany<SortedDictionary<TKey, TValue>.KeyCollection,  SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TSubEnumerable, TSubEnumerator, TResult>(source, selector);

        public static Enumerable.WhereEnumerable<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey> Where<TKey, TValue>(
            this SortedDictionary<TKey, TValue>.KeyCollection source,
            Func<TKey, bool> predicate) 
            => Enumerable.Where<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source, predicate);

        public static TKey First<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source)
            => ReadOnlyCollection.First<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source);

        public static TKey First<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, Func<TKey, bool> predicate)
            => Enumerable.First<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source, predicate);

        public static TKey FirstOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source)
            => ReadOnlyCollection.FirstOrDefault<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source);

        public static TKey FirstOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, Func<TKey, bool> predicate)
            => Enumerable.FirstOrDefault<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source, predicate);

        public static TKey? FirstOrNull<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source)
            where TKey : struct
            => ReadOnlyCollection.FirstOrNull<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source);

        public static TKey? FirstOrNull<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, Func<TKey, bool> predicate)
            where TKey : struct
            => Enumerable.FirstOrNull<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source, predicate);

        public static TKey Single<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source)
            => ReadOnlyCollection.Single<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source);

        public static TKey Single<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, Func<TKey, bool> predicate)
            => Enumerable.Single<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source, predicate);

        public static TKey SingleOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source)
            => ReadOnlyCollection.SingleOrDefault<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source);

        public static TKey SingleOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, Func<TKey, bool> predicate)
            => Enumerable.SingleOrDefault<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source, predicate);

        public static TKey? SingleOrNull<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source)
            where TKey : struct
            => ReadOnlyCollection.SingleOrNull<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source);

        public static TKey? SingleOrNull<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, Func<TKey, bool> predicate)
            where TKey : struct
            => Enumerable.SingleOrNull<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source, predicate);

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
