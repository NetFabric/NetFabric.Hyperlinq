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
            => ValueReadOnlyCollection.Count<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static int Count<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, int, bool> predicate)
            => ValueReadOnlyCollection.Count<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Skip<TKey, TValue>(this SortedDictionary<TKey, TValue> source, int count)
            => ValueReadOnlyCollection.Skip<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), count);

        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Take<TKey, TValue>(this SortedDictionary<TKey, TValue> source, int count)
            => ValueReadOnlyCollection.Take<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), count);

        public static bool All<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, int, bool> predicate)
            => ValueReadOnlyCollection.All<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static bool Any<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => source.Count != 0;

        public static bool Any<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, int, bool> predicate)
            => ValueReadOnlyCollection.Any<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static bool Contains<TKey, TValue>(this SortedDictionary<TKey, TValue> source, KeyValuePair<TKey, TValue> value)
            => source.Contains(value);

        public static bool Contains<TKey, TValue>(this SortedDictionary<TKey, TValue> source, KeyValuePair<TKey, TValue> value, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer)
            => ValueReadOnlyCollection.Contains<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), value, comparer);

        public static ValueReadOnlyCollection.SelectEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult> Select<TKey, TValue, TResult>(
            this SortedDictionary<TKey, TValue> source,
            Func<KeyValuePair<TKey, TValue>, TResult> selector) 
            => ValueReadOnlyCollection.Select<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult>(new ValueWrapper<TKey, TValue>(source), selector);
        public static ValueReadOnlyCollection.SelectIndexEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult> Select<TKey, TValue, TResult>(
            this SortedDictionary<TKey, TValue> source,
            Func<KeyValuePair<TKey, TValue>, int, TResult> selector)
            => ValueReadOnlyCollection.Select<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        public static ValueEnumerable.SelectManyEnumerable<ValueWrapper<TKey, TValue>,  SortedDictionary<TKey, TValue>.Enumerator,  KeyValuePair<TKey, TValue>, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TKey, TValue, TSubEnumerable, TSubEnumerator, TResult>(
            this SortedDictionary<TKey, TValue> source,
            Func<KeyValuePair<TKey, TValue>, TSubEnumerable> selector) 
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ValueEnumerable.SelectMany<ValueWrapper<TKey, TValue>,  SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        public static ValueEnumerable.WhereEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Where<TKey, TValue>(
            this SortedDictionary<TKey, TValue> source,
            Func<KeyValuePair<TKey, TValue>, bool> predicate) 
            => ValueEnumerable.Where<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static ValueEnumerable.WhereIndexEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Where<TKey, TValue>(
            this SortedDictionary<TKey, TValue> source,
            Func<KeyValuePair<TKey, TValue>, int, bool> predicate)
            => ValueEnumerable.Where<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static KeyValuePair<TKey, TValue> First<TKey, TValue>(this SortedDictionary<TKey, TValue> source) 
            => ValueReadOnlyCollection.First<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));
        public static KeyValuePair<TKey, TValue> First<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => ValueReadOnlyCollection.First<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static KeyValuePair<TKey, TValue> FirstOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ValueReadOnlyCollection.FirstOrDefault<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));
        public static KeyValuePair<TKey, TValue> FirstOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => ValueReadOnlyCollection.FirstOrDefault<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static (ElementResult Success, KeyValuePair<TKey, TValue> Value) TryFirst<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));
        public static (ElementResult Success, KeyValuePair<TKey, TValue> Value) TryFirst<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static (int Index, KeyValuePair<TKey, TValue> Value) TryFirst<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, int, bool> predicate)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static KeyValuePair<TKey, TValue> Single<TKey, TValue>(this SortedDictionary<TKey, TValue> source) 
            => ValueReadOnlyCollection.Single<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));
        public static KeyValuePair<TKey, TValue> Single<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => ValueReadOnlyCollection.Single<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static KeyValuePair<TKey, TValue> SingleOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ValueReadOnlyCollection.SingleOrDefault<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));
        public static KeyValuePair<TKey, TValue> SingleOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => ValueReadOnlyCollection.SingleOrDefault<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static (ElementResult Success, KeyValuePair<TKey, TValue> Value) TrySingle<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ValueReadOnlyCollection.TrySingle<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));
        public static (ElementResult Success, KeyValuePair<TKey, TValue> Value) TrySingle<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => ValueReadOnlyCollection.TrySingle<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static (int Index, KeyValuePair<TKey, TValue> Value) TrySingle<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, int, bool> predicate)
            => ValueReadOnlyCollection.TrySingle<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static ValueWrapper<TKey, TValue> AsEnumerable<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => new ValueWrapper<TKey, TValue>(source);

        public static ValueWrapper<TKey, TValue> AsValueEnumerable<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => new ValueWrapper<TKey, TValue>(source);

        public static KeyValuePair<TKey, TValue>[] ToArray<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ValueReadOnlyCollection.ToArray<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));

        public static List<KeyValuePair<TKey, TValue>> ToList<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ValueReadOnlyCollection.ToList<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));

        public readonly struct ValueWrapper<TKey, TValue> 
            : IValueReadOnlyCollection<KeyValuePair<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator>
        {
            readonly SortedDictionary<TKey, TValue> source;

            public ValueWrapper(SortedDictionary<TKey, TValue> source)
            {
                this.source = source;
            }

            public int Count => source.Count;

            public SortedDictionary<TKey, TValue>.Enumerator GetEnumerator() => source.GetEnumerator();
            IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator() => source.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();
        }
    }
}