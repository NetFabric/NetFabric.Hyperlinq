using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class DictionaryBindings
    {
        [Pure]
        public static int Count<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => source.Count;

        [Pure]
        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Skip<TKey, TValue>(this Dictionary<TKey, TValue> source, int count)
            => ValueReadOnlyCollection.Skip<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), count);

        [Pure]
        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Take<TKey, TValue>(this Dictionary<TKey, TValue> source, int count)
            => ValueReadOnlyCollection.Take<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), count);

        [Pure]
        public static bool All<TKey, TValue>(this Dictionary<TKey, TValue> source, Predicate<KeyValuePair<TKey, TValue>> predicate)
            => ValueReadOnlyCollection.All<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        [Pure]
        public static bool All<TKey, TValue>(this Dictionary<TKey, TValue> source, PredicateAt<KeyValuePair<TKey, TValue>> predicate)
            => ValueReadOnlyCollection.All<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        [Pure]
        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => source.Count != 0;
        [Pure]
        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue> source, Predicate<KeyValuePair<TKey, TValue>> predicate)
            => ValueReadOnlyCollection.Any<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        [Pure]
        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue> source, PredicateAt<KeyValuePair<TKey, TValue>> predicate)
            => ValueReadOnlyCollection.Any<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        [Pure]
        public static bool Contains<TKey, TValue>(this Dictionary<TKey, TValue> source, KeyValuePair<TKey, TValue> value)
            => source.Contains(value);

        [Pure]
        public static bool Contains<TKey, TValue>(this Dictionary<TKey, TValue> source, KeyValuePair<TKey, TValue> value, IEqualityComparer<KeyValuePair<TKey, TValue>>? comparer)
            => ValueReadOnlyCollection.Contains<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), value, comparer);

        [Pure]
        public static ValueReadOnlyCollection.SelectEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult> Select<TKey, TValue, TResult>(
            this Dictionary<TKey, TValue> source,
            Selector<KeyValuePair<TKey, TValue>, TResult> selector)
            => ValueReadOnlyCollection.Select<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult>(new ValueWrapper<TKey, TValue>(source), selector);
        [Pure]
        public static ValueReadOnlyCollection.SelectIndexEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult> Select<TKey, TValue, TResult>(
            this Dictionary<TKey, TValue> source,
            SelectorAt<KeyValuePair<TKey, TValue>, TResult> selector)
            => ValueReadOnlyCollection.Select<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        [Pure]
        public static ValueEnumerable.SelectManyEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TKey, TValue, TSubEnumerable, TSubEnumerator, TResult>(
            this Dictionary<TKey, TValue> source,
            Selector<KeyValuePair<TKey, TValue>, TSubEnumerable> selector)
            where TSubEnumerable : notnull, IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ValueEnumerable.SelectMany<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        [Pure]
        public static ValueEnumerable.WhereEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Where<TKey, TValue>(
            this Dictionary<TKey, TValue> source,
            Predicate<KeyValuePair<TKey, TValue>> predicate)
            => ValueEnumerable.Where<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        [Pure]
        public static ValueEnumerable.WhereIndexEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Where<TKey, TValue>(
            this Dictionary<TKey, TValue> source,
            PredicateAt<KeyValuePair<TKey, TValue>> predicate)
            => ValueEnumerable.Where<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        [Pure]
        public static KeyValuePair<TKey, TValue> ElementAt<TKey, TValue>(this Dictionary<TKey, TValue> source, int index)
            => ValueReadOnlyCollection.ElementAt<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), index);
        [Pure]
        public static KeyValuePair<TKey, TValue> ElementAtOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> source, int index)
            => ValueReadOnlyCollection.ElementAtOrDefault<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), index);
        [Pure]
        public static KeyValuePair<TKey, TValue> First<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => ValueReadOnlyCollection.First<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));
        [Pure]
        public static KeyValuePair<TKey, TValue> FirstOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => ValueReadOnlyCollection.FirstOrDefault<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));

        [Pure]
        public static KeyValuePair<TKey, TValue> Single<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => ValueReadOnlyCollection.Single<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));
        [Pure]
        public static KeyValuePair<TKey, TValue> SingleOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => ValueReadOnlyCollection.SingleOrDefault<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));

        [Pure]
        public static ValueEnumerable.DistinctEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Distinct<TKey, TValue>(this Dictionary<TKey, TValue> source, IEqualityComparer<KeyValuePair<TKey, TValue>>? comparer = null)
            => ValueEnumerable.Distinct<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), comparer);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TValue> AsEnumerable<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => source;

        [Pure]
        public static ValueWrapper<TKey, TValue> AsValueEnumerable<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => new ValueWrapper<TKey, TValue>(source);

        [Pure]
        public static KeyValuePair<TKey, TValue>[] ToArray<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => ValueReadOnlyCollection.ToArray<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));

        [Pure]
        public static List<KeyValuePair<TKey, TValue>> ToList<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => ValueReadOnlyCollection.ToList<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));

        [Pure]
        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TKey, TValue>(new ValueWrapper<TKey, TValue>(source), (item => item.Key), (item => item.Value));
        [Pure]
        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this Dictionary<TKey, TValue> source, IEqualityComparer<TKey>? comparer)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TKey, TValue>(new ValueWrapper<TKey, TValue>(source), (item => item.Key), (item => item.Value), comparer);
        [Pure]
        public static Dictionary<TKey2, KeyValuePair<TKey, TValue>> ToDictionary<TKey, TValue, TKey2>(this Dictionary<TKey, TValue> source, Selector<KeyValuePair<TKey, TValue>, TKey2> keySelector)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TKey2>(new ValueWrapper<TKey, TValue>(source), keySelector);
        [Pure]
        public static Dictionary<TKey2, KeyValuePair<TKey, TValue>> ToDictionary<TKey, TValue, TKey2>(this Dictionary<TKey, TValue> source, Selector<KeyValuePair<TKey, TValue>, TKey2> keySelector, IEqualityComparer<TKey2>? comparer)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TKey2>(new ValueWrapper<TKey, TValue>(source), keySelector, comparer);
        [Pure]
        public static Dictionary<TKey2, TElement> ToDictionary<TKey, TValue, TKey2, TElement>(this Dictionary<TKey, TValue> source, Selector<KeyValuePair<TKey, TValue>, TKey2> keySelector, Selector<KeyValuePair<TKey, TValue>, TElement> elementSelector)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TKey2, TElement>(new ValueWrapper<TKey, TValue>(source), keySelector, elementSelector);
        [Pure]
        public static Dictionary<TKey2, TElement> ToDictionary<TKey, TValue, TKey2, TElement>(this Dictionary<TKey, TValue> source, Selector<KeyValuePair<TKey, TValue>, TKey2> keySelector, Selector<KeyValuePair<TKey, TValue>, TElement> elementSelector, IEqualityComparer<TKey2>? comparer)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TKey2, TElement>(new ValueWrapper<TKey, TValue>(source), keySelector, elementSelector, comparer);

        public static void ForEach<TKey, TValue>(this Dictionary<TKey, TValue> source, Action<KeyValuePair<TKey, TValue>> action)
            => ValueReadOnlyCollection.ForEach<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), action);
        public static void ForEach<TKey, TValue>(this Dictionary<TKey, TValue> source, ActionAt<KeyValuePair<TKey, TValue>> action)
            => ValueReadOnlyCollection.ForEach<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), action);

        [GeneratorMapping("TSource", "System.Collections.Generic.KeyValuePair<TKey, TValue>", true)]
        public readonly partial struct ValueWrapper<TKey, TValue>
            : IValueReadOnlyCollection<KeyValuePair<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator>
            , ICollection<KeyValuePair<TKey, TValue>>
        {
            readonly Dictionary<TKey, TValue> source;

            public ValueWrapper(Dictionary<TKey, TValue> source) 
                => this.source = source;

            public readonly int Count
                => source.Count;

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Dictionary<TKey, TValue>.Enumerator GetEnumerator() => source.GetEnumerator();
            readonly IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator() => source.GetEnumerator();
            readonly IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();

            bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly  
                => true;

            void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) 
                => ((ICollection<KeyValuePair<TKey, TValue>>)source).CopyTo(array, arrayIndex);

            void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item) 
                => throw new NotImplementedException();
            void ICollection<KeyValuePair<TKey, TValue>>.Clear() 
                => throw new NotImplementedException();
            bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item) 
                => throw new NotImplementedException();
            bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item) 
                => throw new NotImplementedException();        
        }

        public static int Count<TKey, TValue>(this ValueWrapper<TKey, TValue> source)
            => source.Count;
    }
}