using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static class DictionaryValuesBindings
    {
        public static int Count<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => source.Count;

        public static int Count<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            => ReadOnlyCollection.Count<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static bool All<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            => ReadOnlyCollection.All<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => source.Count != 0;

        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            => ReadOnlyCollection.Any<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static bool Contains<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, TValue value)
            => source.Contains(value);

        public static bool Contains<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, TValue value, IEqualityComparer<TValue> comparer)
            => ReadOnlyCollection.Contains<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), value, comparer);

        public static ReadOnlyCollection.SelectEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TResult> Select<TKey, TValue, TResult>(
            this Dictionary<TKey, TValue>.ValueCollection source,
            Func<TValue, TResult> selector) 
            => ReadOnlyCollection.Select<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        public static Enumerable.SelectManyEnumerable<ValueWrapper<TKey, TValue>,  Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TKey, TValue, TSubEnumerable, TSubEnumerator, TResult>(
            this Dictionary<TKey, TValue>.ValueCollection source,
            Func<TValue, TSubEnumerable> selector) 
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IValueEnumerator<TResult>
            => Enumerable.SelectMany<ValueWrapper<TKey, TValue>,  Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        public static Enumerable.WhereEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue> Where<TKey, TValue>(
            this Dictionary<TKey, TValue>.ValueCollection source,
            Func<TValue, bool> predicate) 
            => Enumerable.Where<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static TValue First<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => ReadOnlyCollection.First<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));

        public static TValue First<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            => Enumerable.First<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static TValue FirstOrDefault<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => ReadOnlyCollection.FirstOrDefault<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));

        public static TValue FirstOrDefault<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            => Enumerable.FirstOrDefault<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static TValue? FirstOrNull<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            where TValue : struct
            => ReadOnlyCollection.FirstOrNull<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));

        public static TValue? FirstOrNull<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            where TValue : struct
            => Enumerable.FirstOrNull<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static TValue Single<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => ReadOnlyCollection.Single<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));

        public static TValue Single<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            => Enumerable.Single<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static TValue SingleOrDefault<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => ReadOnlyCollection.SingleOrDefault<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));

        public static TValue SingleOrDefault<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            => Enumerable.SingleOrDefault<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static TValue? SingleOrNull<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            where TValue : struct
            => ReadOnlyCollection.SingleOrNull<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));

        public static TValue? SingleOrNull<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            where TValue : struct
            => Enumerable.SingleOrNull<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static IEnumerable<TKey> AsEnumerable<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => source.Keys;

        public static IReadOnlyCollection<TKey> AsReadOnlyCollection<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => source.Keys;

        public static Enumerable.AsValueEnumerableEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue> AsValueEnumerable<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => Enumerable.AsValueEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));

        public static ReadOnlyCollection.AsValueReadOnlyCollectionEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue> AsValueReadOnlyCollection<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => ReadOnlyCollection.AsValueReadOnlyCollection<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));

        public static TValue[] ToArray<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => ReadOnlyCollection.ToArray<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));

        public static List<TValue> ToList<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => ReadOnlyCollection.ToList<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));
            
        public readonly struct ValueWrapper<TKey, TValue> : IReadOnlyCollection<TValue>
        {
            readonly Dictionary<TKey, TValue>.ValueCollection source;

            public ValueWrapper(Dictionary<TKey, TValue>.ValueCollection source)
            {
                this.source = source;
            }

            IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();
            IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator() => source.GetEnumerator();
            int IReadOnlyCollection<TValue>.Count => source.Count;
        } 
    }
}