using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static class DictionaryBindings
    {
        public static int Count<TKey, TValue>(this Dictionary<TKey, TValue> source) 
            => source.Count;
        public static int Count<TKey, TValue>(this Dictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => ValueReadOnlyCollection.Count<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static int Count<TKey, TValue>(this Dictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, int, bool> predicate)
            => ValueReadOnlyCollection.Count<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Skip<TKey, TValue>(this Dictionary<TKey, TValue> source, int count)
            => ValueReadOnlyCollection.Skip<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), count);

        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Take<TKey, TValue>(this Dictionary<TKey, TValue> source, int count)
            => ValueReadOnlyCollection.Take<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), count);

        public static bool All<TKey, TValue>(this Dictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => ValueReadOnlyCollection.All<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static bool All<TKey, TValue>(this Dictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, int, bool> predicate)
            => ValueReadOnlyCollection.All<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => source.Count != 0;
        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => ValueReadOnlyCollection.Any<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, int, bool> predicate)
            => ValueReadOnlyCollection.Any<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static bool Contains<TKey, TValue>(this Dictionary<TKey, TValue> source, KeyValuePair<TKey, TValue> value)
            => source.Contains(value);

        public static bool Contains<TKey, TValue>(this Dictionary<TKey, TValue> source, KeyValuePair<TKey, TValue> value, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer)
            => ValueReadOnlyCollection.Contains<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), value, comparer);

        public static ValueReadOnlyCollection.SelectEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult> Select<TKey, TValue, TResult>(
            this Dictionary<TKey, TValue> source,
            Func<KeyValuePair<TKey, TValue>, TResult> selector) 
            => ValueReadOnlyCollection.Select<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult>(new ValueWrapper<TKey, TValue>(source), selector);
        public static ValueReadOnlyCollection.SelectIndexEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult> Select<TKey, TValue, TResult>(
            this Dictionary<TKey, TValue> source,
            Func<KeyValuePair<TKey, TValue>, int, TResult> selector)
            => ValueReadOnlyCollection.Select<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        public static ValueEnumerable.SelectManyEnumerable<ValueWrapper<TKey, TValue>,  Dictionary<TKey, TValue>.Enumerator,  KeyValuePair<TKey, TValue>, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TKey, TValue, TSubEnumerable, TSubEnumerator, TResult>(
            this Dictionary<TKey, TValue> source,
            Func<KeyValuePair<TKey, TValue>, TSubEnumerable> selector) 
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ValueEnumerable.SelectMany<ValueWrapper<TKey, TValue>,  Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        public static ValueEnumerable.WhereEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Where<TKey, TValue>(
            this Dictionary<TKey, TValue> source,
            Func<KeyValuePair<TKey, TValue>, bool> predicate) 
            => ValueEnumerable.Where<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static ValueEnumerable.WhereIndexEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Where<TKey, TValue>(
            this Dictionary<TKey, TValue> source,
            Func<KeyValuePair<TKey, TValue>, int, bool> predicate)
            => ValueEnumerable.Where<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static KeyValuePair<TKey, TValue> First<TKey, TValue>(this Dictionary<TKey, TValue> source) 
            => ValueReadOnlyCollection.First<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));
        public static KeyValuePair<TKey, TValue> First<TKey, TValue>(this Dictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => ValueReadOnlyCollection.First<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static KeyValuePair<TKey, TValue> FirstOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => ValueReadOnlyCollection.FirstOrDefault<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));
        public static KeyValuePair<TKey, TValue> FirstOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => ValueReadOnlyCollection.FirstOrDefault<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static (ElementResult Success, KeyValuePair<TKey, TValue> Value) TryFirst<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));
        public static (ElementResult Success, KeyValuePair<TKey, TValue> Value) TryFirst<TKey, TValue>(this Dictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static (int Index, KeyValuePair<TKey, TValue> Value) TryFirst<TKey, TValue>(this Dictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, int, bool> predicate)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static KeyValuePair<TKey, TValue> Single<TKey, TValue>(this Dictionary<TKey, TValue> source) 
            => ValueReadOnlyCollection.Single<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));
        public static KeyValuePair<TKey, TValue> Single<TKey, TValue>(this Dictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => ValueReadOnlyCollection.Single<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static KeyValuePair<TKey, TValue> SingleOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => ValueReadOnlyCollection.SingleOrDefault<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));
        public static KeyValuePair<TKey, TValue> SingleOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => ValueReadOnlyCollection.SingleOrDefault<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static (ElementResult Success, KeyValuePair<TKey, TValue> Value) TrySingle<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => ValueReadOnlyCollection.TrySingle<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));
        public static (ElementResult Success, KeyValuePair<TKey, TValue> Value) TrySingle<TKey, TValue>(this Dictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => ValueReadOnlyCollection.TrySingle<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static (int Index, KeyValuePair<TKey, TValue> Value) TrySingle<TKey, TValue>(this Dictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, int, bool> predicate)
            => ValueReadOnlyCollection.TrySingle<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static ValueEnumerable.DistinctEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Distinct<TKey, TValue>(this Dictionary<TKey, TValue> source, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer = null)
            => ValueEnumerable.Distinct<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), comparer);

        public static ValueWrapper<TKey, TValue> AsEnumerable<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => new ValueWrapper<TKey, TValue>(source);

        public static ValueWrapper<TKey, TValue> AsValueEnumerable<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => new ValueWrapper<TKey, TValue>(source);

        public static KeyValuePair<TKey, TValue>[] ToArray<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => ValueReadOnlyCollection.ToArray<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));

        public static List<KeyValuePair<TKey, TValue>> ToList<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => ValueReadOnlyCollection.ToList<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));

        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TKey, TValue>(new ValueWrapper<TKey, TValue>(source), (item => item.Key), (item => item.Value));
        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this Dictionary<TKey, TValue> source, IEqualityComparer<TKey> comparer)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TKey, TValue>(new ValueWrapper<TKey, TValue>(source), (item => item.Key), (item => item.Value), comparer);
        public static Dictionary<TKey2, KeyValuePair<TKey, TValue>> ToDictionary<TKey, TValue, TKey2>(this Dictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, TKey2> keySelector)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TKey2>(new ValueWrapper<TKey, TValue>(source), keySelector);
        public static Dictionary<TKey2, KeyValuePair<TKey, TValue>> ToDictionary<TKey, TValue, TKey2>(this Dictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, TKey2> keySelector, IEqualityComparer<TKey2> comparer)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TKey2>(new ValueWrapper<TKey, TValue>(source), keySelector, comparer);
        public static Dictionary<TKey2, TElement> ToDictionary<TKey, TValue, TKey2, TElement>(this Dictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, TKey2> keySelector, Func<KeyValuePair<TKey, TValue>, TElement> elementSelector)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TKey2, TElement>(new ValueWrapper<TKey, TValue>(source), keySelector, elementSelector);
        public static Dictionary<TKey2, TElement> ToDictionary<TKey, TValue, TKey2, TElement>(this Dictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, TKey2> keySelector, Func<KeyValuePair<TKey, TValue>, TElement> elementSelector, IEqualityComparer<TKey2> comparer)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TKey2, TElement>(new ValueWrapper<TKey, TValue>(source), keySelector, elementSelector, comparer);

        public readonly struct ValueWrapper<TKey, TValue>
            : IValueReadOnlyCollection<KeyValuePair<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator>
        {
            readonly Dictionary<TKey, TValue> source;

            public ValueWrapper(Dictionary<TKey, TValue> source)
            {
                this.source = source;
            }

            public int Count => source.Count;

            public Dictionary<TKey, TValue>.Enumerator GetEnumerator() => source.GetEnumerator();
            IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator() => source.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();
        }
    }
}