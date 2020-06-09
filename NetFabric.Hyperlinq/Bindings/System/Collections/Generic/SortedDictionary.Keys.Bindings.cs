using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class SortedDictionaryKeysBindings
    {
        
        public static int Count<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source)
            => source.Count;

        
        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey> Skip<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, int count)
            => ValueReadOnlyCollection.Skip<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), count);

        
        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey> Take<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, int count)
            => ValueReadOnlyCollection.Take<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), count);

        
        public static bool All<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, Predicate<TKey> predicate)
            => ValueReadOnlyCollection.All<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);
        
        public static bool All<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, PredicateAt<TKey> predicate)
            => ValueReadOnlyCollection.All<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);

        
        public static bool Any<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source)
            => source.Count != 0;
        
        public static bool Any<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, Predicate<TKey> predicate)
            => ValueReadOnlyCollection.Any<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);
        
        public static bool Any<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, PredicateAt<TKey> predicate)
            => ValueReadOnlyCollection.Any<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);

        
        public static bool Contains<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, TKey value)
            => source.Contains(value);

        
        public static bool Contains<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, TKey value, IEqualityComparer<TKey>? comparer)
            => ValueReadOnlyCollection.Contains<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), value, comparer);

        
        public static ValueReadOnlyCollection.SelectEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TResult> Select<TKey, TValue, TResult>(
            this SortedDictionary<TKey, TValue>.KeyCollection source,
            Selector<TKey, TResult> selector)
            => ValueReadOnlyCollection.Select<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TResult>(new ValueWrapper<TKey, TValue>(source), selector);
        
        public static ValueReadOnlyCollection.SelectAtEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TResult> Select<TKey, TValue, TResult>(
            this SortedDictionary<TKey, TValue>.KeyCollection source,
            SelectorAt<TKey, TResult> selector)
            => ValueReadOnlyCollection.Select<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        
        public static ValueEnumerable.SelectManyEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TKey, TValue, TSubEnumerable, TSubEnumerator, TResult>(
            this SortedDictionary<TKey, TValue>.KeyCollection source,
            Selector<TKey, TSubEnumerable> selector)
            where TSubEnumerable : notnull, IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ValueEnumerable.SelectMany<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        
        public static ValueEnumerable.WhereEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey> Where<TKey, TValue>(
            this SortedDictionary<TKey, TValue>.KeyCollection source,
            Predicate<TKey> predicate)
            => ValueEnumerable.Where<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);
        
        public static ValueEnumerable.WhereAtEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey> Where<TKey, TValue>(
            this SortedDictionary<TKey, TValue>.KeyCollection source,
            PredicateAt<TKey> predicate)
            => ValueEnumerable.Where<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);

        
        public static Option<TKey> ElementAt<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, int index)
            => ValueReadOnlyCollection.ElementAt<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), index);

        
        public static Option<TKey> First<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source)
            => ValueReadOnlyCollection.First<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source));

        
        public static Option<TKey> Single<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source)
            => ValueReadOnlyCollection.Single<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source));

        
        public static ValueEnumerable.DistinctEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey> Distinct<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, IEqualityComparer<TKey>? comparer = null)
            => ValueEnumerable.Distinct<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), comparer);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SortedDictionary<TKey, TValue>.KeyCollection AsEnumerable<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source)
            => source;

        
        public static ValueWrapper<TKey, TValue> AsValueEnumerable<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source)
            => new ValueWrapper<TKey, TValue>(source);

        
        public static TKey[] ToArray<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source)
            => ValueReadOnlyCollection.ToArray<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source));

        
        public static List<TKey> ToList<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source)
            => ValueReadOnlyCollection.ToList<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source));

        
        public static Dictionary<TKey2, TKey> ToDictionary<TKey, TValue, TKey2>(this SortedDictionary<TKey, TValue>.KeyCollection source, Selector<TKey, TKey2> keySelector)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TKey2>(new ValueWrapper<TKey, TValue>(source), keySelector);
        
        public static Dictionary<TKey2, TKey> ToDictionary<TKey, TValue, TKey2>(this SortedDictionary<TKey, TValue>.KeyCollection source, Selector<TKey, TKey2> keySelector, IEqualityComparer<TKey2>? comparer)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TKey2>(new ValueWrapper<TKey, TValue>(source), keySelector, comparer);
        
        public static Dictionary<TKey2, TElement> ToDictionary<TKey, TValue, TKey2, TElement>(this SortedDictionary<TKey, TValue>.KeyCollection source, Selector<TKey, TKey2> keySelector, Selector<TKey, TElement> elementSelector)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TKey2, TElement>(new ValueWrapper<TKey, TValue>(source), keySelector, elementSelector);
        
        public static Dictionary<TKey2, TElement> ToDictionary<TKey, TValue, TKey2, TElement>(this SortedDictionary<TKey, TValue>.KeyCollection source, Selector<TKey, TKey2> keySelector, Selector<TKey, TElement> elementSelector, IEqualityComparer<TKey2>? comparer)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TKey2, TElement>(new ValueWrapper<TKey, TValue>(source), keySelector, elementSelector, comparer);

        [GeneratorMapping("TSource", "TKey")]
        public readonly partial struct ValueWrapper<TKey, TValue>
            : IValueReadOnlyCollection<TKey, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator>
            , ICollection<TKey>
        {
            readonly SortedDictionary<TKey, TValue>.KeyCollection source;

            public ValueWrapper(SortedDictionary<TKey, TValue>.KeyCollection source) 
                => this.source = source;

            public readonly int Count
                => source.Count;

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly SortedDictionary<TKey, TValue>.KeyCollection.Enumerator GetEnumerator() => source.GetEnumerator();
            readonly IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator() => source.GetEnumerator();
            readonly IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();

            bool ICollection<TKey>.IsReadOnly  
                => true;

            void ICollection<TKey>.CopyTo(TKey[] array, int arrayIndex) 
                => ((ICollection<TKey>)source).CopyTo(array, arrayIndex);

            void ICollection<TKey>.Add(TKey item) 
                => throw new NotSupportedException();
            void ICollection<TKey>.Clear() 
                => throw new NotSupportedException();
            bool ICollection<TKey>.Contains(TKey item) 
                => throw new NotSupportedException();
            bool ICollection<TKey>.Remove(TKey item) 
                => throw new NotSupportedException();   
        }

        public static int Count<TKey, TValue>(this ValueWrapper<TKey, TValue> source)
            => source.Count;
    }
}