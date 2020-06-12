using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class DictionaryKeysBindings
    {
        
        public static int Count<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            => source.Count;

        
        public static ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey> Skip<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, int count)
            => ValueReadOnlyCollectionExtensions.Skip<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), count);

        
        public static ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey> Take<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, int count)
            => ValueReadOnlyCollectionExtensions.Take<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), count);

        
        public static bool All<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, Predicate<TKey> predicate)
            => ValueReadOnlyCollectionExtensions.All<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);
        
        public static bool All<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, PredicateAt<TKey> predicate)
            => ValueReadOnlyCollectionExtensions.All<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);

        
        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            => source.Count != 0;
        
        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, Predicate<TKey> predicate)
            => ValueReadOnlyCollectionExtensions.Any<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);
        
        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, PredicateAt<TKey> predicate)
            => ValueReadOnlyCollectionExtensions.Any<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);

        
        public static bool Contains<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, TKey value)
            => source.Contains(value);

        
        public static bool Contains<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, TKey value, IEqualityComparer<TKey>? comparer)
            => ValueReadOnlyCollectionExtensions.Contains<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), value, comparer);

        
        public static ValueReadOnlyCollectionExtensions.SelectEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TResult> Select<TKey, TValue, TResult>(
            this Dictionary<TKey, TValue>.KeyCollection source,
            Selector<TKey, TResult> selector)
            => ValueReadOnlyCollectionExtensions.Select<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TResult>(new ValueWrapper<TKey, TValue>(source), selector);
        
        public static ValueReadOnlyCollectionExtensions.SelectAtEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TResult> Select<TKey, TValue, TResult>(
            this Dictionary<TKey, TValue>.KeyCollection source,
            SelectorAt<TKey, TResult> selector)
            => ValueReadOnlyCollectionExtensions.Select<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        
        public static ValueEnumerableExtensions.SelectManyEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TKey, TValue, TSubEnumerable, TSubEnumerator, TResult>(
            this Dictionary<TKey, TValue>.KeyCollection source,
            Selector<TKey, TSubEnumerable> selector)
            where TSubEnumerable : notnull, IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ValueEnumerableExtensions.SelectMany<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        
        public static ValueEnumerableExtensions.WhereEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey> Where<TKey, TValue>(
            this Dictionary<TKey, TValue>.KeyCollection source,
            Predicate<TKey> predicate)
            => ValueEnumerableExtensions.Where<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);
        
        public static ValueEnumerableExtensions.WhereAtEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey> Where<TKey, TValue>(
            this Dictionary<TKey, TValue>.KeyCollection source,
            PredicateAt<TKey> predicate)
            => ValueEnumerableExtensions.Where<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);

        
        public static Option<TKey> ElementAt<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, int index)
            => ValueReadOnlyCollectionExtensions.ElementAt<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), index);

        
        public static Option<TKey> First<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            => ValueReadOnlyCollectionExtensions.First<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source));

        
        public static Option<TKey> Single<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            => ValueReadOnlyCollectionExtensions.Single<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source));

        
        public static ValueEnumerableExtensions.DistinctEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey> Distinct<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, IEqualityComparer<TKey>? comparer = default)
            => ValueEnumerableExtensions.Distinct<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), comparer);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TValue>.KeyCollection AsEnumerable<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            => source;

        
        public static ValueWrapper<TKey, TValue> AsValueEnumerable<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            => new ValueWrapper<TKey, TValue>(source);

        
        public static TKey[] ToArray<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            => ValueReadOnlyCollectionExtensions.ToArray<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source));

        
        public static List<TKey> ToList<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            => ValueReadOnlyCollectionExtensions.ToList<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source));

        
        public static Dictionary<TKey2, TKey> ToDictionary<TKey, TValue, TKey2>(this Dictionary<TKey, TValue>.KeyCollection source, Selector<TKey, TKey2> keySelector, IEqualityComparer<TKey2>? comparer = default)
            => ValueReadOnlyCollectionExtensions.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TKey2>(new ValueWrapper<TKey, TValue>(source), keySelector, comparer);
        
        public static Dictionary<TKey2, TElement> ToDictionary<TKey, TValue, TKey2, TElement>(this Dictionary<TKey, TValue>.KeyCollection source, Selector<TKey, TKey2> keySelector, Selector<TKey, TElement> elementSelector, IEqualityComparer<TKey2>? comparer = default)
            => ValueReadOnlyCollectionExtensions.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TKey2, TElement>(new ValueWrapper<TKey, TValue>(source), keySelector, elementSelector, comparer);

        [GeneratorMapping("TSource", "TKey")]
        public readonly partial struct ValueWrapper<TKey, TValue>
            : IValueReadOnlyCollection<TKey, Dictionary<TKey, TValue>.KeyCollection.Enumerator>
            , ICollection<TKey>
        {
            readonly Dictionary<TKey, TValue>.KeyCollection source;

            public ValueWrapper(Dictionary<TKey, TValue>.KeyCollection source)
                => this.source = source;

            public readonly int Count
                => source.Count;

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Dictionary<TKey, TValue>.KeyCollection.Enumerator GetEnumerator() => source.GetEnumerator();
            readonly IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator() => source.GetEnumerator();
            readonly IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();

            bool ICollection<TKey>.IsReadOnly  
                => true;

            void ICollection<TKey>.CopyTo(TKey[] array, int arrayIndex) 
                => ((ICollection<TKey>)source).CopyTo(array, arrayIndex);

            void ICollection<TKey>.Add(TKey item) 
                => Throw.NotSupportedException();
            void ICollection<TKey>.Clear() 
                => Throw.NotSupportedException();
            bool ICollection<TKey>.Contains(TKey item) 
                => Throw.NotSupportedException<bool>();
            bool ICollection<TKey>.Remove(TKey item) 
                => Throw.NotSupportedException<bool>();   
        }

        public static int Count<TKey, TValue>(this ValueWrapper<TKey, TValue> source)
            => source.Count;
    }
}