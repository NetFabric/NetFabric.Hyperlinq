using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class SortedDictionaryValuesExtensions
    {
        public static int Count<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            => source.Count;

        public static int Count<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            => ReadOnlyCollection.Count<SortedDictionary<TKey, TValue>.ValueCollection, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source, predicate);

        public static bool All<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            => ReadOnlyCollection.All<SortedDictionary<TKey, TValue>.ValueCollection, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source, predicate);

        public static bool Any<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            => source.Count != 0;

        public static bool Any<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            => ReadOnlyCollection.Any<SortedDictionary<TKey, TValue>.ValueCollection, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source, predicate);

        public static bool Contains<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, TValue value)
            => source.Contains(value);

        public static bool Contains<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, TValue value, IEqualityComparer<TValue> comparer)
            => ReadOnlyCollection.Contains<SortedDictionary<TKey, TValue>.ValueCollection, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source, value, comparer);

        public static ReadOnlyCollection.SelectEnumerable<SortedDictionary<TKey, TValue>.ValueCollection, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TResult> Select<TKey, TValue, TResult>(
            this SortedDictionary<TKey, TValue>.ValueCollection source,
            Func<TValue, TResult> selector) 
            => ReadOnlyCollection.Select<SortedDictionary<TKey, TValue>.ValueCollection, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TResult>(source, selector);

        public static Enumerable.WhereEnumerable<SortedDictionary<TKey, TValue>.ValueCollection, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue> Where<TKey, TValue>(
            this SortedDictionary<TKey, TValue>.ValueCollection source,
            Func<TValue, bool> predicate) 
            => Enumerable.Where<SortedDictionary<TKey, TValue>.ValueCollection, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source, predicate);

        public static TValue First<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            => ReadOnlyCollection.First<SortedDictionary<TKey, TValue>.ValueCollection, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source);

        public static TValue First<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            => Enumerable.First<SortedDictionary<TKey, TValue>.ValueCollection, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source, predicate);

        public static TValue FirstOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            => ReadOnlyCollection.FirstOrDefault<SortedDictionary<TKey, TValue>.ValueCollection, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source);

        public static TValue FirstOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            => Enumerable.FirstOrDefault<SortedDictionary<TKey, TValue>.ValueCollection, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source, predicate);

        public static TValue? FirstOrNull<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            where TValue : struct
            => ReadOnlyCollection.FirstOrNull<SortedDictionary<TKey, TValue>.ValueCollection, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source);

        public static TValue? FirstOrNull<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            where TValue : struct
            => Enumerable.FirstOrNull<SortedDictionary<TKey, TValue>.ValueCollection, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source, predicate);

        public static TValue Single<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            => ReadOnlyCollection.Single<SortedDictionary<TKey, TValue>.ValueCollection, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source);

        public static TValue Single<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            => Enumerable.Single<SortedDictionary<TKey, TValue>.ValueCollection, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source, predicate);

        public static TValue SingleOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            => ReadOnlyCollection.SingleOrDefault<SortedDictionary<TKey, TValue>.ValueCollection, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source);

        public static TValue SingleOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            => Enumerable.SingleOrDefault<SortedDictionary<TKey, TValue>.ValueCollection, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source, predicate);

        public static TValue? SingleOrNull<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            where TValue : struct
            => ReadOnlyCollection.SingleOrNull<SortedDictionary<TKey, TValue>.ValueCollection, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source);

        public static TValue? SingleOrNull<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            where TValue : struct
            => Enumerable.SingleOrNull<SortedDictionary<TKey, TValue>.ValueCollection, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source, predicate);

        public static List<TValue> ToList<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            => ReadOnlyCollection.ToList<SortedDictionary<TKey, TValue>.ValueCollection, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source);
    }
}
