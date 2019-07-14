using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static class SortedDictionaryValuesBindings
    {
        public static int Count<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            => source.Count;
        public static int Count<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            => ValueReadOnlyCollection.Count<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static int Count<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, Func<TValue, int, bool> predicate)
            => ValueReadOnlyCollection.Count<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue> Skip<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, int count)
            => ValueReadOnlyCollection.Skip<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), count);

        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue> Take<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, int count)
            => ValueReadOnlyCollection.Take<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), count);

        public static bool All<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, Func<TValue, int, bool> predicate)
            => ValueReadOnlyCollection.All<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static bool Any<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            => source.Count != 0;

        public static bool Any<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, Func<TValue, int, bool> predicate)
            => ValueReadOnlyCollection.Any<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static bool Contains<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, TValue value)
            => source.Contains(value);

        public static bool Contains<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, TValue value, IEqualityComparer<TValue> comparer)
            => ValueReadOnlyCollection.Contains<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), value, comparer);

        public static ValueReadOnlyCollection.SelectEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TResult> Select<TKey, TValue, TResult>(
            this SortedDictionary<TKey, TValue>.ValueCollection source,
            Func<TValue, TResult> selector) 
            => ValueReadOnlyCollection.Select<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TResult>(new ValueWrapper<TKey, TValue>(source), selector);
        public static ValueReadOnlyCollection.SelectIndexEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TResult> Select<TKey, TValue, TResult>(
            this SortedDictionary<TKey, TValue>.ValueCollection source,
            Func<TValue, int, TResult> selector)
            => ValueReadOnlyCollection.Select<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        public static ValueEnumerable.SelectManyEnumerable<ValueWrapper<TKey, TValue>,  SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TKey, TValue, TSubEnumerable, TSubEnumerator, TResult>(
            this SortedDictionary<TKey, TValue>.ValueCollection source,
            Func<TValue, TSubEnumerable> selector) 
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ValueEnumerable.SelectMany<ValueWrapper<TKey, TValue>,  SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        public static ValueEnumerable.WhereEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue> Where<TKey, TValue>(
            this SortedDictionary<TKey, TValue>.ValueCollection source,
            Func<TValue, bool> predicate) 
            => ValueEnumerable.Where<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static ValueEnumerable.WhereIndexEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue> Where<TKey, TValue>(
            this SortedDictionary<TKey, TValue>.ValueCollection source,
            Func<TValue, int, bool> predicate)
            => ValueEnumerable.Where<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static TValue First<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source) 
            => ValueReadOnlyCollection.First<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));
        public static TValue First<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            => ValueReadOnlyCollection.First<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static TValue FirstOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            => ValueReadOnlyCollection.FirstOrDefault<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));
        public static TValue FirstOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            => ValueReadOnlyCollection.FirstOrDefault<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static (ElementResult Success, TValue Value) TryFirst<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));
        public static (ElementResult Success, TValue Value) TryFirst<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static (int Index, TValue Value) TryFirst<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, Func<TValue, int, bool> predicate)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static TValue Single<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source) 
            => ValueReadOnlyCollection.Single<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));
        public static TValue Single<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            => ValueReadOnlyCollection.Single<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static TValue SingleOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            => ValueReadOnlyCollection.SingleOrDefault<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));
        public static TValue SingleOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            => ValueReadOnlyCollection.SingleOrDefault<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static (ElementResult Success, TValue Value) TrySingle<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            => ValueReadOnlyCollection.TrySingle<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));
        public static (ElementResult Success, TValue Value) TrySingle<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            => ValueReadOnlyCollection.TrySingle<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static (int Index, TValue Value) TrySingle<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, Func<TValue, int, bool> predicate)
            => ValueReadOnlyCollection.TrySingle<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static ValueWrapper<TKey, TValue> AsEnumerable<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            => new ValueWrapper<TKey, TValue>(source);

        public static ValueWrapper<TKey, TValue> AsValueEnumerable<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            => new ValueWrapper<TKey, TValue>(source);

        public static TValue[] ToArray<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            => ValueReadOnlyCollection.ToArray<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));

        public static List<TValue> ToList<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            => ValueReadOnlyCollection.ToList<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));
            
        public readonly struct ValueWrapper<TKey, TValue> 
            : IValueReadOnlyCollection<TValue, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator>
        {
            readonly SortedDictionary<TKey, TValue>.ValueCollection source;

            public ValueWrapper(SortedDictionary<TKey, TValue>.ValueCollection source)
            {
                this.source = source;
            }

            public int Count => source.Count;

            public SortedDictionary<TKey, TValue>.ValueCollection.Enumerator GetEnumerator() => source.GetEnumerator();
            IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator() => source.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();
        } 
    }
}