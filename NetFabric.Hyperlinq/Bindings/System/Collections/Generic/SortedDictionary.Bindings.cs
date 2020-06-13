using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class SortedDictionaryBindings
    {
        
        public static int Count<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => source.Count;

        
        public static ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Skip<TKey, TValue>(this SortedDictionary<TKey, TValue> source, int count)
            => ValueReadOnlyCollectionExtensions.Skip<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), count);

        
        public static ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Take<TKey, TValue>(this SortedDictionary<TKey, TValue> source, int count)
            => ValueReadOnlyCollectionExtensions.Take<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), count);

        
        public static bool All<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Predicate<KeyValuePair<TKey, TValue>> predicate)
            => ValueReadOnlyCollectionExtensions.All<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        
        public static bool All<TKey, TValue>(this SortedDictionary<TKey, TValue> source, PredicateAt<KeyValuePair<TKey, TValue>> predicate)
            => ValueReadOnlyCollectionExtensions.All<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        
        public static bool Any<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => source.Count != 0;
        
        public static bool Any<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Predicate<KeyValuePair<TKey, TValue>> predicate)
            => ValueReadOnlyCollectionExtensions.Any<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        
        public static bool Any<TKey, TValue>(this SortedDictionary<TKey, TValue> source, PredicateAt<KeyValuePair<TKey, TValue>> predicate)
            => ValueReadOnlyCollectionExtensions.Any<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        
        public static bool Contains<TKey, TValue>(this SortedDictionary<TKey, TValue> source, KeyValuePair<TKey, TValue> value)
            => source.Contains(value);

        
        public static bool Contains<TKey, TValue>(this SortedDictionary<TKey, TValue> source, KeyValuePair<TKey, TValue> value, IEqualityComparer<KeyValuePair<TKey, TValue>>? comparer)
            => ValueReadOnlyCollectionExtensions.Contains<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), value, comparer);

        
        public static ValueReadOnlyCollectionExtensions.SelectEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult> Select<TKey, TValue, TResult>(
            this SortedDictionary<TKey, TValue> source,
            NullableSelector<KeyValuePair<TKey, TValue>, TResult> selector)
            => ValueReadOnlyCollectionExtensions.Select<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult>(new ValueWrapper<TKey, TValue>(source), selector);
        
        public static ValueReadOnlyCollectionExtensions.SelectAtEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult> Select<TKey, TValue, TResult>(
            this SortedDictionary<TKey, TValue> source,
            NullableSelectorAt<KeyValuePair<TKey, TValue>, TResult> selector)
            => ValueReadOnlyCollectionExtensions.Select<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        
        public static ValueEnumerableExtensions.SelectManyEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TKey, TValue, TSubEnumerable, TSubEnumerator, TResult>(
            this SortedDictionary<TKey, TValue> source,
            Selector<KeyValuePair<TKey, TValue>, TSubEnumerable> selector)
            where TSubEnumerable : notnull, IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ValueEnumerableExtensions.SelectMany<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        
        public static ValueEnumerableExtensions.WhereEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Where<TKey, TValue>(
            this SortedDictionary<TKey, TValue> source,
            Predicate<KeyValuePair<TKey, TValue>> predicate)
            => ValueEnumerableExtensions.Where<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        
        public static ValueEnumerableExtensions.WhereAtEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Where<TKey, TValue>(
            this SortedDictionary<TKey, TValue> source,
            PredicateAt<KeyValuePair<TKey, TValue>> predicate)
            => ValueEnumerableExtensions.Where<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        
        public static Option<KeyValuePair<TKey, TValue>> ElementAt<TKey, TValue>(this SortedDictionary<TKey, TValue> source, int index)
            => ValueReadOnlyCollectionExtensions.ElementAt<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), index);

        
        public static Option<KeyValuePair<TKey, TValue>> First<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ValueReadOnlyCollectionExtensions.First<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));

        
        public static Option<KeyValuePair<TKey, TValue>> Single<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ValueReadOnlyCollectionExtensions.Single<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));

        
        public static ValueEnumerableExtensions.DistinctEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Distinct<TKey, TValue>(this SortedDictionary<TKey, TValue> source, IEqualityComparer<KeyValuePair<TKey, TValue>>? comparer = default)
            => ValueEnumerableExtensions.Distinct<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), comparer);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SortedDictionary<TKey, TValue> AsEnumerable<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => source;

        
        public static ValueWrapper<TKey, TValue> AsValueEnumerable<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => new ValueWrapper<TKey, TValue>(source);

        
        public static KeyValuePair<TKey, TValue>[] ToArray<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ValueReadOnlyCollectionExtensions.ToArray<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));

        
        public static List<KeyValuePair<TKey, TValue>> ToList<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ValueReadOnlyCollectionExtensions.ToList<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));

        
        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ValueReadOnlyCollectionExtensions.ToDictionary<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TKey, TValue>(new ValueWrapper<TKey, TValue>(source), item => item.Key, item => item.Value);
        
        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this SortedDictionary<TKey, TValue> source, IEqualityComparer<TKey>? comparer)
            => ValueReadOnlyCollectionExtensions.ToDictionary<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TKey, TValue>(new ValueWrapper<TKey, TValue>(source), item => item.Key, item => item.Value, comparer);
        
        public static Dictionary<TKey2, KeyValuePair<TKey, TValue>> ToDictionary<TKey, TValue, TKey2>(this SortedDictionary<TKey, TValue> source, NullableSelector<KeyValuePair<TKey, TValue>, TKey2> keySelector)
            => ValueReadOnlyCollectionExtensions.ToDictionary<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TKey2>(new ValueWrapper<TKey, TValue>(source), keySelector);
        
        public static Dictionary<TKey2, KeyValuePair<TKey, TValue>> ToDictionary<TKey, TValue, TKey2>(this SortedDictionary<TKey, TValue> source, NullableSelector<KeyValuePair<TKey, TValue>, TKey2> keySelector, IEqualityComparer<TKey2>? comparer)
            => ValueReadOnlyCollectionExtensions.ToDictionary<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TKey2>(new ValueWrapper<TKey, TValue>(source), keySelector, comparer);
        
        public static Dictionary<TKey2, TElement> ToDictionary<TKey, TValue, TKey2, TElement>(this SortedDictionary<TKey, TValue> source, NullableSelector<KeyValuePair<TKey, TValue>, TKey2> keySelector, NullableSelector<KeyValuePair<TKey, TValue>, TElement> elementSelector)
            => ValueReadOnlyCollectionExtensions.ToDictionary<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TKey2, TElement>(new ValueWrapper<TKey, TValue>(source), keySelector, elementSelector);
        
        public static Dictionary<TKey2, TElement> ToDictionary<TKey, TValue, TKey2, TElement>(this SortedDictionary<TKey, TValue> source, NullableSelector<KeyValuePair<TKey, TValue>, TKey2> keySelector, NullableSelector<KeyValuePair<TKey, TValue>, TElement> elementSelector, IEqualityComparer<TKey2>? comparer)
            => ValueReadOnlyCollectionExtensions.ToDictionary<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TKey2, TElement>(new ValueWrapper<TKey, TValue>(source), keySelector, elementSelector, comparer);

        [GeneratorMapping("TSource", "System.Collections.Generic.KeyValuePair<TKey, TValue>", true)]
        public readonly partial struct ValueWrapper<TKey, TValue>
            : IValueReadOnlyCollection<KeyValuePair<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator>
            , ICollection<KeyValuePair<TKey, TValue>>
        {
            readonly SortedDictionary<TKey, TValue> source;

            public ValueWrapper(SortedDictionary<TKey, TValue> source) 
                => this.source = source;

            public readonly int Count
                => source.Count;

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly SortedDictionary<TKey, TValue>.Enumerator GetEnumerator() => source.GetEnumerator();
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