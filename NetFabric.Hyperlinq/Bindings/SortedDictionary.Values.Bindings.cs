using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static class SortedDictionaryValuesBindings
    {
        public static int Count<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            => source.Count;

        public static int Count<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, Func<TValue, int, bool> predicate)
            => ReadOnlyCollection.Count<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static ReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue> Skip<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, int count)
            => ReadOnlyCollection.Skip<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), count);

        public static ReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue> Take<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, int count)
            => ReadOnlyCollection.Take<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), count);

        public static bool All<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, Func<TValue, int, bool> predicate)
            => ReadOnlyCollection.All<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static bool Any<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            => source.Count != 0;

        public static bool Any<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, Func<TValue, int, bool> predicate)
            => ReadOnlyCollection.Any<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static bool Contains<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, TValue value)
            => source.Contains(value);

        public static bool Contains<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, TValue value, IEqualityComparer<TValue> comparer)
            => ReadOnlyCollection.Contains<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), value, comparer);

        public static ReadOnlyCollection.SelectEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TResult> Select<TKey, TValue, TResult>(
            this SortedDictionary<TKey, TValue>.ValueCollection source,
            Func<TValue, int, TResult> selector) 
            => ReadOnlyCollection.Select<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        public static Enumerable.SelectManyEnumerable<ValueWrapper<TKey, TValue>,  SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TKey, TValue, TSubEnumerable, TSubEnumerator, TResult>(
            this SortedDictionary<TKey, TValue>.ValueCollection source,
            Func<TValue, TSubEnumerable> selector) 
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IValueEnumerator<TResult>
            => Enumerable.SelectMany<ValueWrapper<TKey, TValue>,  SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        public static Enumerable.WhereEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue> Where<TKey, TValue>(
            this SortedDictionary<TKey, TValue>.ValueCollection source,
            Func<TValue, int, bool> predicate) 
            => Enumerable.Where<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static TValue First<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            => ReadOnlyCollection.First<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));

        public static TValue First<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, Func<TValue, int, bool> predicate)
            => ReadOnlyCollection.First<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static TValue FirstOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            => ReadOnlyCollection.FirstOrDefault<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));

        public static TValue FirstOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, Func<TValue, int, bool> predicate)
            => ReadOnlyCollection.FirstOrDefault<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static TValue? FirstOrNull<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            where TValue : struct
            => ReadOnlyCollection.FirstOrNull<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));

        public static TValue? FirstOrNull<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, Func<TValue, int, bool> predicate)
            where TValue : struct
            => ReadOnlyCollection.FirstOrNull<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static TValue Single<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            => ReadOnlyCollection.Single<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));

        public static TValue Single<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, Func<TValue, int, bool> predicate)
            => ReadOnlyCollection.Single<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static TValue SingleOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            => ReadOnlyCollection.SingleOrDefault<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));

        public static TValue SingleOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, Func<TValue, int, bool> predicate)
            => ReadOnlyCollection.SingleOrDefault<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static TValue? SingleOrNull<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            where TValue : struct
            => ReadOnlyCollection.SingleOrNull<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));

        public static TValue? SingleOrNull<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, Func<TValue, int, bool> predicate)
            where TValue : struct
            => ReadOnlyCollection.SingleOrNull<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static IReadOnlyCollection<TKey> AsEnumerable<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => source.Keys;

        public static ReadOnlyCollection.AsValueEnumerableEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue> AsValueEnumerable<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            => ReadOnlyCollection.AsValueEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));

        public static TValue[] ToArray<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            => ReadOnlyCollection.ToArray<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));

        public static List<TValue> ToList<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            => ReadOnlyCollection.ToList<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));
            
        public readonly struct ValueWrapper<TKey, TValue> : IReadOnlyCollection<TValue>
        {
            readonly SortedDictionary<TKey, TValue>.ValueCollection source;

            public ValueWrapper(SortedDictionary<TKey, TValue>.ValueCollection source)
            {
                this.source = source;
            }

            IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();
            IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator() => source.GetEnumerator();
            int IReadOnlyCollection<TValue>.Count => source.Count;
        } 
    }
}