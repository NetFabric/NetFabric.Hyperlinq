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
        public static int Count<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => source.Count;

        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Skip<TKey, TValue>(this Dictionary<TKey, TValue> source, int count)
            => ValueReadOnlyCollection.Skip<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), count);

        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Take<TKey, TValue>(this Dictionary<TKey, TValue> source, int count)
            => ValueReadOnlyCollection.Take<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), count);

        public static bool All<TKey, TValue>(this Dictionary<TKey, TValue> source, Predicate<KeyValuePair<TKey, TValue>> predicate)
            => ValueReadOnlyCollection.All<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static bool All<TKey, TValue>(this Dictionary<TKey, TValue> source, PredicateAt<KeyValuePair<TKey, TValue>> predicate)
            => ValueReadOnlyCollection.All<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => source.Count != 0;
        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue> source, Predicate<KeyValuePair<TKey, TValue>> predicate)
            => ValueReadOnlyCollection.Any<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue> source, PredicateAt<KeyValuePair<TKey, TValue>> predicate)
            => ValueReadOnlyCollection.Any<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static bool Contains<TKey, TValue>(this Dictionary<TKey, TValue> source, KeyValuePair<TKey, TValue> value)
            => source.Contains(value);

        public static bool Contains<TKey, TValue>(this Dictionary<TKey, TValue> source, KeyValuePair<TKey, TValue> value, IEqualityComparer<KeyValuePair<TKey, TValue>>? comparer)
            => ValueReadOnlyCollection.Contains<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), value, comparer);

        public static ValueReadOnlyCollection.SelectEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult> Select<TKey, TValue, TResult>(
            this Dictionary<TKey, TValue> source,
            Selector<KeyValuePair<TKey, TValue>, TResult> selector)
            => ValueReadOnlyCollection.Select<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult>(new ValueWrapper<TKey, TValue>(source), selector);
        public static ValueReadOnlyCollection.SelectAtEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult> Select<TKey, TValue, TResult>(
            this Dictionary<TKey, TValue> source,
            SelectorAt<KeyValuePair<TKey, TValue>, TResult> selector)
            => ValueReadOnlyCollection.Select<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        public static ValueEnumerable.SelectManyEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TKey, TValue, TSubEnumerable, TSubEnumerator, TResult>(
            this Dictionary<TKey, TValue> source,
            Selector<KeyValuePair<TKey, TValue>, TSubEnumerable> selector)
            where TSubEnumerable : notnull, IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ValueEnumerable.SelectMany<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        public static ValueEnumerable.WhereEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Where<TKey, TValue>(
            this Dictionary<TKey, TValue> source,
            Predicate<KeyValuePair<TKey, TValue>> predicate)
            => ValueEnumerable.Where<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static ValueEnumerable.WhereAtEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Where<TKey, TValue>(
            this Dictionary<TKey, TValue> source,
            PredicateAt<KeyValuePair<TKey, TValue>> predicate)
            => ValueEnumerable.Where<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static Option<KeyValuePair<TKey, TValue>> ElementAt<TKey, TValue>(this Dictionary<TKey, TValue> source, int index)
            => ValueReadOnlyCollection.ElementAt<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), index);

        public static Option<KeyValuePair<TKey, TValue>> First<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => ValueReadOnlyCollection.First<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));

        public static Option<KeyValuePair<TKey, TValue>> Single<TKey, TValue>(this Dictionary<TKey, TValue> source)
#pragma warning disable HLQ005 // Avoid Single() and SingleOrDefault()
            => ValueReadOnlyCollection.Single<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));
#pragma warning restore HLQ005 // Avoid Single() and SingleOrDefault()

        public static ValueEnumerable.DistinctEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Distinct<TKey, TValue>(this Dictionary<TKey, TValue> source, IEqualityComparer<KeyValuePair<TKey, TValue>>? comparer = null)
            => ValueEnumerable.Distinct<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TValue> AsEnumerable<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => source;

        public static ValueWrapper<TKey, TValue> AsValueEnumerable<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => new ValueWrapper<TKey, TValue>(source);

        public static KeyValuePair<TKey, TValue>[] ToArray<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => ValueReadOnlyCollection.ToArray<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));

        public static List<KeyValuePair<TKey, TValue>> ToList<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => ValueReadOnlyCollection.ToList<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));

        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this Dictionary<TKey, TValue> source, IEqualityComparer<TKey>? comparer = null)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TKey, TValue>(new ValueWrapper<TKey, TValue>(source), (item => item.Key), (item => item.Value), comparer);

        public static Dictionary<TKey2, KeyValuePair<TKey, TValue>> ToDictionary<TKey, TValue, TKey2>(this Dictionary<TKey, TValue> source, Selector<KeyValuePair<TKey, TValue>, TKey2> keySelector, IEqualityComparer<TKey2>? comparer = null)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TKey2>(new ValueWrapper<TKey, TValue>(source), keySelector, comparer);

        public static Dictionary<TKey2, TElement> ToDictionary<TKey, TValue, TKey2, TElement>(this Dictionary<TKey, TValue> source, Selector<KeyValuePair<TKey, TValue>, TKey2> keySelector, Selector<KeyValuePair<TKey, TValue>, TElement> elementSelector, IEqualityComparer<TKey2>? comparer = null)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TKey2, TElement>(new ValueWrapper<TKey, TValue>(source), keySelector, elementSelector, comparer);

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

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Dictionary<TKey, TValue>.Enumerator GetEnumerator() => source.GetEnumerator();
            readonly IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator() => source.GetEnumerator();
            readonly IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();

            bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly  
                => true;

            void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) 
                => ((ICollection<KeyValuePair<TKey, TValue>>)source).CopyTo(array, arrayIndex);

            void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item) 
                => Throw.NotSupportedException();
            void ICollection<KeyValuePair<TKey, TValue>>.Clear() 
                => Throw.NotSupportedException();
            bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item) 
                => Throw.NotSupportedException<bool>();
            bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item) 
                => Throw.NotSupportedException<bool>();        
        }

        public static int Count<TKey, TValue>(this ValueWrapper<TKey, TValue> source)
            => source.Count;
    }
}