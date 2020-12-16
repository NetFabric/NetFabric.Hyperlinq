using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class DictionaryKeysBindings
    {
        
        #region Aggregation
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.Count<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source));
            
        #endregion
        #region Partitioning

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey> Skip<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, int count)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.Skip<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey> Take<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, int count)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.Take<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), count);
            
        #endregion
        #region Quantifier

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, Func<TKey, bool> predicate)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.All<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TKey, TValue, TPredicate>(this Dictionary<TKey, TValue>.KeyCollection source, TPredicate predicate = default)
            where TKey : notnull
            where TPredicate : struct, IFunction<TKey, bool>
            => ValueReadOnlyCollectionExtensions.All<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TPredicate>(new ValueWrapper<TKey, TValue>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, Func<TKey, int, bool> predicate)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.All<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AllAt<TKey, TValue, TPredicate>(this Dictionary<TKey, TValue>.KeyCollection source, TPredicate predicate = default)
            where TKey : notnull
            where TPredicate : struct, IFunction<TKey, int, bool>
            => ValueReadOnlyCollectionExtensions.AllAt<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TPredicate>(new ValueWrapper<TKey, TValue>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.Any<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, Func<TKey, bool> predicate)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.Any<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TKey, TValue, TPredicate>(this Dictionary<TKey, TValue>.KeyCollection source, TPredicate predicate)
            where TKey : notnull
            where TPredicate : struct, IFunction<TKey, bool>
            => ValueReadOnlyCollectionExtensions.Any<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TPredicate>(new ValueWrapper<TKey, TValue>(source), predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, Func<TKey, int, bool> predicate)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.Any<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AnyAt<TKey, TValue, TPredicate>(this Dictionary<TKey, TValue>.KeyCollection source, TPredicate predicate = default)
            where TKey : notnull
            where TPredicate : struct, IFunction<TKey, int, bool>
            => ValueReadOnlyCollectionExtensions.AnyAt<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TPredicate>(new ValueWrapper<TKey, TValue>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, TKey value, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.Contains<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), value, comparer);
            
        #endregion
        #region Projection

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueReadOnlyCollectionExtensions.SelectEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TResult, FunctionWrapper<TKey, TResult>> Select<TKey, TValue, TResult>(
            this Dictionary<TKey, TValue>.KeyCollection source,
            Func<TKey, TResult> selector)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.Select<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueReadOnlyCollectionExtensions.SelectEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TResult, TSelector> Select<TKey, TValue, TResult, TSelector>(
            this Dictionary<TKey, TValue>.KeyCollection source,
            TSelector selector)
            where TKey : notnull
            where TSelector : struct, IFunction<TKey, TResult>
            => ValueReadOnlyCollectionExtensions.Select<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TResult, TSelector>(new ValueWrapper<TKey, TValue>(source), selector);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueReadOnlyCollectionExtensions.SelectAtEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TResult, FunctionWrapper<TKey, int, TResult>> Select<TKey, TValue, TResult>(
            this Dictionary<TKey, TValue>.KeyCollection source,
            Func<TKey, int, TResult> selector)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.Select<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TResult>(new ValueWrapper<TKey, TValue>(source), selector);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueReadOnlyCollectionExtensions.SelectAtEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TResult, TSelector> SelectAt<TKey, TValue, TResult, TSelector>(
            this Dictionary<TKey, TValue>.KeyCollection source,
            TSelector selector)
            where TKey : notnull
            where TSelector : struct, IFunction<TKey, int, TResult>
            => ValueReadOnlyCollectionExtensions.SelectAt<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TResult, TSelector>(new ValueWrapper<TKey, TValue>(source), selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableExtensions.SelectManyEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TSubEnumerable, TSubEnumerator, TResult, FunctionWrapper<TKey, TSubEnumerable>> SelectMany<TKey, TValue, TSubEnumerable, TSubEnumerator, TResult>(
            this Dictionary<TKey, TValue>.KeyCollection source,
            Func<TKey, TSubEnumerable> selector)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            where TKey : notnull
            => ValueEnumerableExtensions.SelectMany<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableExtensions.SelectManyEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TSubEnumerable, TSubEnumerator, TResult, TSelector> SelectMany<TKey, TValue, TSubEnumerable, TSubEnumerator, TResult, TSelector>(
            this Dictionary<TKey, TValue>.KeyCollection source,
            TSelector selector)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            where TKey : notnull
            where TSelector : struct, IFunction<TKey, TSubEnumerable>
            => ValueEnumerableExtensions.SelectMany<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TSubEnumerable, TSubEnumerator, TResult, TSelector>(new ValueWrapper<TKey, TValue>(source), selector);
            
        #endregion
        #region Filtering

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableExtensions.WhereEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, FunctionWrapper<TKey, bool>> Where<TKey, TValue>(
            this Dictionary<TKey, TValue>.KeyCollection source,
            Func<TKey, bool> predicate)
            where TKey : notnull
            => ValueEnumerableExtensions.Where<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableExtensions.WhereEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TPredicate> Where<TKey, TValue, TPredicate>(
            this Dictionary<TKey, TValue>.KeyCollection source,
            TPredicate predicate)
            where TKey : notnull
            where TPredicate : struct, IFunction<TKey, bool>
            => ValueEnumerableExtensions.Where<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TPredicate>(new ValueWrapper<TKey, TValue>(source), predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableExtensions.WhereAtEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, FunctionWrapper<TKey, int, bool>> Where<TKey, TValue>(
            this Dictionary<TKey, TValue>.KeyCollection source,
            Func<TKey, int, bool> predicate)
            where TKey : notnull
            => ValueEnumerableExtensions.Where<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableExtensions.WhereAtEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TPredicate> WhereAt<TKey, TValue, TPredicate>(
            this Dictionary<TKey, TValue>.KeyCollection source,
            TPredicate predicate)
            where TKey : notnull
            where TPredicate : struct, IFunction<TKey, int, bool>
            => ValueEnumerableExtensions.WhereAt<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TPredicate>(new ValueWrapper<TKey, TValue>(source), predicate);
            
        #endregion
        #region Element

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TKey> ElementAt<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, int index)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.ElementAt<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), index);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TKey> First<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.First<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TKey> Single<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            where TKey : notnull
#pragma warning disable HLQ005 // Avoid Single() and SingleOrDefault()
            => ValueReadOnlyCollectionExtensions.Single<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source));
#pragma warning restore HLQ005 // Avoid Single() and SingleOrDefault()
            
        #endregion
        #region Set

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableExtensions.DistinctEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey> Distinct<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => ValueEnumerableExtensions.Distinct<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), comparer);
            
        #endregion
        #region Conversion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TValue>.KeyCollection AsEnumerable<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            where TKey : notnull
            => source;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueWrapper<TKey, TValue> AsValueEnumerable<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            where TKey : notnull
            => new(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TKey[] ToArray<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.ToArray<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TKey> ToList<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.ToList<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey2, TKey> ToDictionary<TKey, TValue, TKey2>(this Dictionary<TKey, TValue>.KeyCollection source, Func<TKey, TKey2> keyFunc, IEqualityComparer<TKey2>? comparer = default)
            where TKey : notnull
            where TKey2 : notnull
            => ValueReadOnlyCollectionExtensions.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TKey2>(new ValueWrapper<TKey, TValue>(source), keyFunc, comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey2, TKey> ToDictionary<TKey, TValue, TKey2, TKeySelector>(this Dictionary<TKey, TValue>.KeyCollection source, TKeySelector keyFunc, IEqualityComparer<TKey2>? comparer = default)
            where TKey : notnull
            where TKey2 : notnull
            where TKeySelector : struct, IFunction<TKey, TKey2>
            => ValueReadOnlyCollectionExtensions.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TKey2, TKeySelector>(new ValueWrapper<TKey, TValue>(source), keyFunc, comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey2, TElement> ToDictionary<TKey, TValue, TKey2, TElement>(this Dictionary<TKey, TValue>.KeyCollection source, Func<TKey, TKey2> keyFunc, Func<TKey, TElement> elementFunc, IEqualityComparer<TKey2>? comparer = default)
            where TKey : notnull
            where TKey2 : notnull
            => ValueReadOnlyCollectionExtensions.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TKey2, TElement>(new ValueWrapper<TKey, TValue>(source), keyFunc, elementFunc, comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey2, TElement> ToDictionary<TKey, TValue, TKey2, TElement, TKeySelector, TElementSelector>(this Dictionary<TKey, TValue>.KeyCollection source, TKeySelector keyFunc, TElementSelector elementFunc, IEqualityComparer<TKey2>? comparer = default)
            where TKey : notnull
            where TKey2 : notnull
            where TKeySelector : struct, IFunction<TKey, TKey2>
            where TElementSelector : struct, IFunction<TKey, TElement>
            => ValueReadOnlyCollectionExtensions.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TKey2, TElement, TKeySelector, TElementSelector>(new ValueWrapper<TKey, TValue>(source), keyFunc, elementFunc, comparer);
            
        #endregion

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
            public readonly Dictionary<TKey, TValue>.KeyCollection.Enumerator GetEnumerator() 
                => source.GetEnumerator();
            readonly IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => source.GetEnumerator();
            readonly IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => source.GetEnumerator();

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