using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class DictionaryKeysBindings
    {
        
        public static int Count<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            where TKey : notnull
            => source.Count;

        
        public static ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey> Skip<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, int count)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.Skip<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), count);

        
        public static ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey> Take<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, int count)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.Take<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), count);

        
        public static bool All<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, Predicate<TKey> predicate)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.All<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);
        
        public static bool All<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, PredicateAt<TKey> predicate)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.All<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);

        
        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            where TKey : notnull
            => source.Count != 0;

        
        public static bool Contains<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, TKey value)
            where TKey : notnull
            => source.Contains(value);

        
        public static bool Contains<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, TKey value, IEqualityComparer<TKey>? comparer)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.Contains<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), value, comparer);

        
        public static ValueReadOnlyCollectionExtensions.SelectEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TResult> Select<TKey, TValue, TResult>(
            this Dictionary<TKey, TValue>.KeyCollection source,
            NullableSelector<TKey, TResult> selector)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.Select<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TResult>(new ValueWrapper<TKey, TValue>(source), selector);
        
        public static ValueReadOnlyCollectionExtensions.SelectAtEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TResult> Select<TKey, TValue, TResult>(
            this Dictionary<TKey, TValue>.KeyCollection source,
            NullableSelectorAt<TKey, TResult> selector)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.Select<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        
        public static ValueEnumerableExtensions.SelectManyEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TKey, TValue, TSubEnumerable, TSubEnumerator, TResult>(
            this Dictionary<TKey, TValue>.KeyCollection source,
            Selector<TKey, TSubEnumerable> selector)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            where TKey : notnull
            => ValueEnumerableExtensions.SelectMany<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        
        public static ValueEnumerableExtensions.WhereEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, ValuePredicate<TKey>> Where<TKey, TValue>(
            this Dictionary<TKey, TValue>.KeyCollection source,
            Predicate<TKey> predicate)
            where TKey : notnull
            => ValueEnumerableExtensions.Where<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);
        
        public static ValueEnumerableExtensions.WhereAtEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, ValuePredicateAt<TKey>> Where<TKey, TValue>(
            this Dictionary<TKey, TValue>.KeyCollection source,
            PredicateAt<TKey> predicate)
            where TKey : notnull
            => ValueEnumerableExtensions.Where<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);

        
        public static Option<TKey> ElementAt<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, int index)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.ElementAt<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), index);

        
        public static Option<TKey> First<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.First<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source));

        
        public static Option<TKey> Single<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.Single<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source));

        
        public static ValueEnumerableExtensions.DistinctEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey> Distinct<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => ValueEnumerableExtensions.Distinct<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), comparer);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TValue>.KeyCollection AsEnumerable<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            where TKey : notnull
            => source;

        
        public static ValueWrapper<TKey, TValue> AsValueEnumerable<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            where TKey : notnull
            => new ValueWrapper<TKey, TValue>(source);

        
        public static TKey[] ToArray<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.ToArray<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source));

        
        public static List<TKey> ToList<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.ToList<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source));

        
        public static Dictionary<TKey2, TKey> ToDictionary<TKey, TValue, TKey2>(this Dictionary<TKey, TValue>.KeyCollection source, Selector<TKey, TKey2> keySelector, IEqualityComparer<TKey2>? comparer = default)
            where TKey : notnull
            where TKey2 : notnull
            => ValueReadOnlyCollectionExtensions.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TKey2>(new ValueWrapper<TKey, TValue>(source), keySelector, comparer);
        
        public static Dictionary<TKey2, TElement> ToDictionary<TKey, TValue, TKey2, TElement>(this Dictionary<TKey, TValue>.KeyCollection source, Selector<TKey, TKey2> keySelector, NullableSelector<TKey, TElement> elementSelector, IEqualityComparer<TKey2>? comparer = default)
            where TKey : notnull
            where TKey2 : notnull
            => ValueReadOnlyCollectionExtensions.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TKey2, TElement>(new ValueWrapper<TKey, TValue>(source), keySelector, elementSelector, comparer);

        [GeneratorMapping("TSource", "TKey")]
        public readonly partial struct ValueWrapper<TKey, TValue>
            : IValueReadOnlyCollection<TKey, Dictionary<TKey, TValue>.KeyCollection.Enumerator>
            , ICollection<TKey>
            where TKey : notnull
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

            [ExcludeFromCodeCoverage]
            void ICollection<TKey>.Add(TKey item) 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void ICollection<TKey>.Clear() 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            bool ICollection<TKey>.Contains(TKey item) 
                => Throw.NotSupportedException<bool>();
            [ExcludeFromCodeCoverage]
            bool ICollection<TKey>.Remove(TKey item) 
                => Throw.NotSupportedException<bool>();   
        }

        public static int Count<TKey, TValue>(this ValueWrapper<TKey, TValue> source)
            where TKey : notnull
            => source.Count;
    }
}