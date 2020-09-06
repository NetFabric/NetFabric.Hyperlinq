using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class SortedDictionaryValuesBindings
    {
        
        public static int Count<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            where TKey : notnull
            => source.Count;

        
        public static ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue> Skip<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, int count)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.Skip<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), count);

        
        public static ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue> Take<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, int count)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.Take<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), count);

        
        public static bool All<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, Predicate<TValue> predicate)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.All<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);
        
        public static bool All<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, PredicateAt<TValue> predicate)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.All<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        
        public static bool Any<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            where TKey : notnull
            => source.Count != 0;

        
        public static bool Contains<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, TValue value)
            where TKey : notnull
            => source.Contains(value);

        
        public static bool Contains<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, TValue value, IEqualityComparer<TValue>? comparer)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.Contains<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), value, comparer);

        
        public static ValueReadOnlyCollectionExtensions.SelectEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TResult> Select<TKey, TValue, TResult>(
            this SortedDictionary<TKey, TValue>.ValueCollection source,
            NullableSelector<TValue, TResult> selector)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.Select<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TResult>(new ValueWrapper<TKey, TValue>(source), selector);
        
        public static ValueReadOnlyCollectionExtensions.SelectAtEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TResult> Select<TKey, TValue, TResult>(
            this SortedDictionary<TKey, TValue>.ValueCollection source,
            NullableSelectorAt<TValue, TResult> selector)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.Select<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        
        public static ValueEnumerableExtensions.SelectManyEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TKey, TValue, TSubEnumerable, TSubEnumerator, TResult>(
            this SortedDictionary<TKey, TValue>.ValueCollection source,
            Selector<TValue, TSubEnumerable> selector)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            where TKey : notnull
            => ValueEnumerableExtensions.SelectMany<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        
        public static ValueEnumerableExtensions.WhereEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, ValuePredicate<TValue>> Where<TKey, TValue>(
            this SortedDictionary<TKey, TValue>.ValueCollection source,
            Predicate<TValue> predicate)
            where TKey : notnull
            => ValueEnumerableExtensions.Where<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);
        
        public static ValueEnumerableExtensions.WhereAtEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, ValuePredicateAt<TValue>> Where<TKey, TValue>(
            this SortedDictionary<TKey, TValue>.ValueCollection source,
            PredicateAt<TValue> predicate)
            where TKey : notnull
            => ValueEnumerableExtensions.Where<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        
        public static Option<TValue> ElementAt<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, int index)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.ElementAt<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), index);

        
        public static Option<TValue> First<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.First<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));

        
        public static Option<TValue> Single<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.Single<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));

        
        public static ValueEnumerableExtensions.DistinctEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue> Distinct<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source, IEqualityComparer<TValue>? comparer = default)
            where TKey : notnull
            => ValueEnumerableExtensions.Distinct<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), comparer);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SortedDictionary<TKey, TValue>.ValueCollection AsEnumerable<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            where TKey : notnull
            => source;

        
        public static ValueWrapper<TKey, TValue> AsValueEnumerable<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            where TKey : notnull
            => new ValueWrapper<TKey, TValue>(source);

        
        public static TValue[] ToArray<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.ToArray<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));

        
        public static List<TValue> ToList<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.ToList<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));

        
        public static Dictionary<TKey2, TValue> ToDictionary<TKey, TValue, TKey2>(this SortedDictionary<TKey, TValue>.ValueCollection source, Selector<TValue, TKey2> keySelector, IEqualityComparer<TKey2>? comparer = default)
            where TKey : notnull
            where TKey2 : notnull
            => ValueReadOnlyCollectionExtensions.ToDictionary<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TKey2>(new ValueWrapper<TKey, TValue>(source), keySelector, comparer);
        
        public static Dictionary<TKey2, TElement> ToDictionary<TKey, TValue, TKey2, TElement>(this SortedDictionary<TKey, TValue>.ValueCollection source, Selector<TValue, TKey2> keySelector, NullableSelector<TValue, TElement> elementSelector, IEqualityComparer<TKey2>? comparer = default)
            where TKey : notnull
            where TKey2 : notnull
            => ValueReadOnlyCollectionExtensions.ToDictionary<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TKey2, TElement>(new ValueWrapper<TKey, TValue>(source), keySelector, elementSelector, comparer);

        [GeneratorMapping("TSource", "TValue")]
        public readonly partial struct ValueWrapper<TKey, TValue>
            : IValueReadOnlyCollection<TValue, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator>
            , ICollection<TValue>
            where TKey : notnull
        {
            readonly SortedDictionary<TKey, TValue>.ValueCollection source;

            public ValueWrapper(SortedDictionary<TKey, TValue>.ValueCollection source) 
                => this.source = source;

            public readonly int Count
                => source.Count;

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly SortedDictionary<TKey, TValue>.ValueCollection.Enumerator GetEnumerator() => source.GetEnumerator();
            readonly IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator() => source.GetEnumerator();
            readonly IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();

            bool ICollection<TValue>.IsReadOnly  
                => true;

            void ICollection<TValue>.CopyTo(TValue[] array, int arrayIndex) 
                => ((ICollection<TValue>)source).CopyTo(array, arrayIndex);

            [ExcludeFromCodeCoverage]
            void ICollection<TValue>.Add(TValue item) 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void ICollection<TValue>.Clear() 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            bool ICollection<TValue>.Contains(TValue item) 
                => Throw.NotSupportedException<bool>();
            [ExcludeFromCodeCoverage]
            bool ICollection<TValue>.Remove(TValue item) 
                => Throw.NotSupportedException<bool>();
        }

        public static int Count<TKey, TValue>(this ValueWrapper<TKey, TValue> source)
            where TKey : notnull
            => source.Count;
    }
}