using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static class SortedDictionaryBindings
    {
        public static int Count<TKey, TValue>(this SortedDictionary<TKey, TValue> source) 
            => source.Count;
        public static int Count<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => ReadOnlyCollection.Count<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static int Count<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, long, bool> predicate)
            => ReadOnlyCollection.Count<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static ReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Skip<TKey, TValue>(this SortedDictionary<TKey, TValue> source, int count)
            => ReadOnlyCollection.Skip<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), count);

        public static ReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Take<TKey, TValue>(this SortedDictionary<TKey, TValue> source, int count)
            => ReadOnlyCollection.Take<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), count);

        public static bool All<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, long, bool> predicate)
            => ReadOnlyCollection.All<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static bool Any<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => source.Count != 0;

        public static bool Any<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, long, bool> predicate)
            => ReadOnlyCollection.Any<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static bool Contains<TKey, TValue>(this SortedDictionary<TKey, TValue> source, KeyValuePair<TKey, TValue> value)
            => source.Contains(value);

        public static bool Contains<TKey, TValue>(this SortedDictionary<TKey, TValue> source, KeyValuePair<TKey, TValue> value, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer)
            => ReadOnlyCollection.Contains<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), value, comparer);

        public static ReadOnlyCollection.SelectEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult> Select<TKey, TValue, TResult>(
            this SortedDictionary<TKey, TValue> source,
            Func<KeyValuePair<TKey, TValue>, long, TResult> selector) 
            => ReadOnlyCollection.Select<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        public static Enumerable.SelectManyEnumerable<ValueWrapper<TKey, TValue>,  SortedDictionary<TKey, TValue>.Enumerator,  KeyValuePair<TKey, TValue>, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TKey, TValue, TSubEnumerable, TSubEnumerator, TResult>(
            this SortedDictionary<TKey, TValue> source,
            Func<KeyValuePair<TKey, TValue>, TSubEnumerable> selector) 
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IValueEnumerator<TResult>
            => Enumerable.SelectMany<ValueWrapper<TKey, TValue>,  SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        public static Enumerable.WhereEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Where<TKey, TValue>(
            this SortedDictionary<TKey, TValue> source,
            Func<KeyValuePair<TKey, TValue>, long, bool> predicate) 
            => Enumerable.Where<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static KeyValuePair<TKey, TValue> First<TKey, TValue>(this SortedDictionary<TKey, TValue> source) 
            => ReadOnlyCollection.First<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));

        public static KeyValuePair<TKey, TValue> First<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, long, bool> predicate)
            => ReadOnlyCollection.First<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static KeyValuePair<TKey, TValue> FirstOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ReadOnlyCollection.FirstOrDefault<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));

        public static KeyValuePair<TKey, TValue> FirstOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, long, bool> predicate)
            => ReadOnlyCollection.FirstOrDefault<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static KeyValuePair<TKey, TValue>? FirstOrNull<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ReadOnlyCollection.FirstOrNull<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));

        public static KeyValuePair<TKey, TValue>? FirstOrNull<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, long, bool> predicate)
            => ReadOnlyCollection.FirstOrNull<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static KeyValuePair<TKey, TValue> Single<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ReadOnlyCollection.Single<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));

        public static KeyValuePair<TKey, TValue> Single<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, long, bool> predicate)
            => ReadOnlyCollection.Single<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static KeyValuePair<TKey, TValue> SingleOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ReadOnlyCollection.SingleOrDefault<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));

        public static KeyValuePair<TKey, TValue> SingleOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, long, bool> predicate)
            => ReadOnlyCollection.SingleOrDefault<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static KeyValuePair<TKey, TValue>? SingleOrNull<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ReadOnlyCollection.SingleOrNull<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));

        public static KeyValuePair<TKey, TValue>? SingleOrNull<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, long, bool> predicate)
            => ReadOnlyCollection.SingleOrNull<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static IReadOnlyCollection<KeyValuePair<TKey, TValue>> AsEnumerable<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => source;

        public static ReadOnlyCollection.AsValueEnumerableEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> AsValueEnumerable<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ReadOnlyCollection.AsValueEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));

        public static KeyValuePair<TKey, TValue>[] ToArray<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ReadOnlyCollection.ToArray<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));

        public static List<KeyValuePair<TKey, TValue>> ToList<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ReadOnlyCollection.ToList<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));

        public readonly struct ValueWrapper<TKey, TValue> : IReadOnlyCollection<KeyValuePair<TKey, TValue>>
        {
            readonly SortedDictionary<TKey, TValue> source;

            public ValueWrapper(SortedDictionary<TKey, TValue> source)
            {
                this.source = source;
            }

            IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();
            IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator() => source.GetEnumerator();
            int IReadOnlyCollection<KeyValuePair<TKey, TValue>>.Count => source.Count;
        }
    }
}