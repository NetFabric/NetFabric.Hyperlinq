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
        public static int Count<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, Func<TValue, int, bool> predicate)
            => ReadOnlyCollection.Count<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static ReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue> Skip<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, int count)
            => ReadOnlyCollection.Skip<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), count);

        public static ReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue> Take<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, int count)
            => ReadOnlyCollection.Take<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), count);

        public static bool All<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, Func<TValue, int, bool> predicate)
            => ReadOnlyCollection.All<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => source.Count != 0;

        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, Func<TValue, int, bool> predicate)
            => ReadOnlyCollection.Any<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static bool Contains<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, TValue value)
            => source.Contains(value);

        public static bool Contains<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, TValue value, IEqualityComparer<TValue> comparer)
            => ReadOnlyCollection.Contains<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), value, comparer);

        public static ReadOnlyCollection.SelectEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TResult> Select<TKey, TValue, TResult>(
            this Dictionary<TKey, TValue>.ValueCollection source,
            Func<TValue, TResult> selector) 
            => ReadOnlyCollection.Select<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TResult>(new ValueWrapper<TKey, TValue>(source), selector);
        public static ReadOnlyCollection.SelectIndexEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TResult> Select<TKey, TValue, TResult>(
            this Dictionary<TKey, TValue>.ValueCollection source,
            Func<TValue, int, TResult> selector)
            => ReadOnlyCollection.Select<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        public static ReadOnlyCollection.SelectManyEnumerable<ValueWrapper<TKey, TValue>,  Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TKey, TValue, TSubEnumerable, TSubEnumerator, TResult>(
            this Dictionary<TKey, TValue>.ValueCollection source,
            Func<TValue, TSubEnumerable> selector) 
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ReadOnlyCollection.SelectMany<ValueWrapper<TKey, TValue>,  Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        public static Enumerable.WhereEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue> Where<TKey, TValue>(
            this Dictionary<TKey, TValue>.ValueCollection source,
            Func<TValue, bool> predicate) 
            => Enumerable.Where<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static Enumerable.WhereIndexEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue> Where<TKey, TValue>(
            this Dictionary<TKey, TValue>.ValueCollection source,
            Func<TValue, int, bool> predicate)
            => Enumerable.Where<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static TValue First<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source) 
            => ReadOnlyCollection.First<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));
        public static TValue First<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            => ReadOnlyCollection.First<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static TValue FirstOrDefault<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => ReadOnlyCollection.FirstOrDefault<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));
        public static TValue FirstOrDefault<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            => ReadOnlyCollection.FirstOrDefault<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static (ElementResult Success, TValue Value) TryFirst<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => ReadOnlyCollection.TryFirst<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));
        public static (ElementResult Success, TValue Value) TryFirst<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            => ReadOnlyCollection.TryFirst<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static (int Index, TValue Value) TryFirst<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, Func<TValue, int, bool> predicate)
            => ReadOnlyCollection.TryFirst<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static TValue Single<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source) 
            => ReadOnlyCollection.Single<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));
        public static TValue Single<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            => ReadOnlyCollection.Single<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static TValue SingleOrDefault<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => ReadOnlyCollection.SingleOrDefault<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));
        public static TValue SingleOrDefault<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            => ReadOnlyCollection.SingleOrDefault<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static (ElementResult Success, TValue Value) TrySingle<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => ReadOnlyCollection.TrySingle<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));
        public static (ElementResult Success, TValue Value) TrySingle<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            => ReadOnlyCollection.TrySingle<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static (int Index, TValue Value) TrySingle<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, Func<TValue, int, bool> predicate)
            => ReadOnlyCollection.TrySingle<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static IReadOnlyCollection<TKey> AsEnumerable<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => source.Keys;

        public static ReadOnlyCollection.AsValueEnumerableEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue> AsValueEnumerable<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => ReadOnlyCollection.AsValueEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));

        public static TValue[] ToArray<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => ReadOnlyCollection.ToArray<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));

        public static List<TValue> ToList<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => ReadOnlyCollection.ToList<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));
            
        public readonly struct ValueWrapper<TKey, TValue> 
            : IValueReadOnlyCollection<TValue, Dictionary<TKey, TValue>.ValueCollection.Enumerator>
        {
            readonly Dictionary<TKey, TValue>.ValueCollection source;

            public ValueWrapper(Dictionary<TKey, TValue>.ValueCollection source)
            {
                this.source = source;
            }

            public int Count => source.Count;

            public Dictionary<TKey, TValue>.ValueCollection.Enumerator GetEnumerator() => source.GetEnumerator();
            IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator() => source.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();
        } 
    }
}