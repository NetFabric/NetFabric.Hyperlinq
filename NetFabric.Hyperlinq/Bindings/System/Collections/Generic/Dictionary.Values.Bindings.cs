using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class DictionaryValuesBindings
    {
        
        #region Aggregation
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.Count<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));
            
        #endregion
        #region Partitioning

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue> Skip<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, int count)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.Skip<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue> Take<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, int count)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.Take<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), count);
            
        #endregion
        #region Quantifier

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.All<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TKey, TValue, TPredicate>(this Dictionary<TKey, TValue>.ValueCollection source, TPredicate predicate = default)
            where TKey : notnull
            where TPredicate : struct, IFunction<TValue, bool>
            => ValueReadOnlyCollectionExtensions.All<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TPredicate>(new ValueWrapper<TKey, TValue>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, Func<TValue, int, bool> predicate)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.All<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AllAt<TKey, TValue, TPredicate>(this Dictionary<TKey, TValue>.ValueCollection source, TPredicate predicate = default)
            where TKey : notnull
            where TPredicate : struct, IFunction<TValue, int, bool>
            => ValueReadOnlyCollectionExtensions.AllAt<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TPredicate>(new ValueWrapper<TKey, TValue>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.Any<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.Any<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TKey, TValue, TPredicate>(this Dictionary<TKey, TValue>.ValueCollection source, TPredicate predicate = default)
            where TKey : notnull
            where TPredicate : struct, IFunction<TValue, bool>
            => ValueReadOnlyCollectionExtensions.Any<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TPredicate>(new ValueWrapper<TKey, TValue>(source), predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, Func<TValue, int, bool> predicate)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.Any<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AnyAt<TKey, TValue, TPredicate>(this Dictionary<TKey, TValue>.ValueCollection source, TPredicate predicate = default)
            where TKey : notnull
            where TPredicate : struct, IFunction<TValue, int, bool>
            => ValueReadOnlyCollectionExtensions.AnyAt<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TPredicate>(new ValueWrapper<TKey, TValue>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, TValue value, IEqualityComparer<TValue>? comparer = default)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.Contains<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), value, comparer);
            
        #endregion
        #region Projection

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueReadOnlyCollectionExtensions.SelectEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TResult, FunctionWrapper<TValue, TResult>> Select<TKey, TValue, TResult>(
            this Dictionary<TKey, TValue>.ValueCollection source,
            Func<TValue, TResult> selector)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.Select<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueReadOnlyCollectionExtensions.SelectEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TResult, TSelector> Select<TKey, TValue, TResult, TSelector>(
            this Dictionary<TKey, TValue>.ValueCollection source,
            TSelector selector = default)
            where TKey : notnull
            where TSelector : struct, IFunction<TValue, TResult>
            => ValueReadOnlyCollectionExtensions.Select<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TResult, TSelector>(new ValueWrapper<TKey, TValue>(source), selector);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueReadOnlyCollectionExtensions.SelectAtEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TResult, FunctionWrapper<TValue, int, TResult>> Select<TKey, TValue, TResult>(
            this Dictionary<TKey, TValue>.ValueCollection source,
            Func<TValue, int, TResult> selector)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.Select<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TResult>(new ValueWrapper<TKey, TValue>(source), selector);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueReadOnlyCollectionExtensions.SelectAtEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TResult, TSelector> SelectAt<TKey, TValue, TResult, TSelector>(
            this Dictionary<TKey, TValue>.ValueCollection source,
            TSelector selector = default)
            where TKey : notnull
            where TSelector : struct, IFunction<TValue, int, TResult>
            => ValueReadOnlyCollectionExtensions.SelectAt<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TResult, TSelector>(new ValueWrapper<TKey, TValue>(source), selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableExtensions.SelectManyEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TSubEnumerable, TSubEnumerator, TResult, FunctionWrapper<TValue, TSubEnumerable>> SelectMany<TKey, TValue, TSubEnumerable, TSubEnumerator, TResult>(
            this Dictionary<TKey, TValue>.ValueCollection source,
            Func<TValue, TSubEnumerable> selector)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            where TKey : notnull
            => ValueEnumerableExtensions.SelectMany<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableExtensions.SelectManyEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TSubEnumerable, TSubEnumerator, TResult, TSelector> SelectMany<TKey, TValue, TSubEnumerable, TSubEnumerator, TResult, TSelector>(
            this Dictionary<TKey, TValue>.ValueCollection source,
            TSelector selector = default)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            where TKey : notnull
            where TSelector : struct, IFunction<TValue, TSubEnumerable>
            => ValueEnumerableExtensions.SelectMany<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TSubEnumerable, TSubEnumerator, TResult, TSelector>(new ValueWrapper<TKey, TValue>(source), selector);
            
        #endregion
        #region Filtering

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableExtensions.WhereEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, FunctionWrapper<TValue, bool>> Where<TKey, TValue>(
            this Dictionary<TKey, TValue>.ValueCollection source,
            Func<TValue, bool> predicate)
            where TKey : notnull
            => ValueEnumerableExtensions.Where<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableExtensions.WhereEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TPredicate> Where<TKey, TValue, TPredicate>(
            this Dictionary<TKey, TValue>.ValueCollection source,
            TPredicate predicate = default)
            where TKey : notnull
            where TPredicate : struct, IFunction<TValue, bool>
            => ValueEnumerableExtensions.Where<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TPredicate>(new ValueWrapper<TKey, TValue>(source), predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableExtensions.WhereAtEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, FunctionWrapper<TValue, int, bool>> Where<TKey, TValue>(
            this Dictionary<TKey, TValue>.ValueCollection source,
            Func<TValue, int, bool> predicate)
            where TKey : notnull
            => ValueEnumerableExtensions.Where<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableExtensions.WhereAtEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TPredicate> WhereAt<TKey, TValue, TPredicate>(
            this Dictionary<TKey, TValue>.ValueCollection source,
            TPredicate predicate = default)
            where TKey : notnull
            where TPredicate : struct, IFunction<TValue, int, bool>
            => ValueEnumerableExtensions.WhereAt<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TPredicate>(new ValueWrapper<TKey, TValue>(source), predicate);
            
        #endregion
        #region Element

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TValue> ElementAt<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, int index)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.ElementAt<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), index);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TValue> First<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.First<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TValue> Single<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            where TKey : notnull
#pragma warning disable HLQ005 // Avoid Single() and SingleOrDefault()
            => ValueReadOnlyCollectionExtensions.Single<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));
#pragma warning restore HLQ005 // Avoid Single() and SingleOrDefault()
            
        #endregion
        #region Set

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableExtensions.DistinctEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue> Distinct<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, IEqualityComparer<TValue>? comparer = default)
            where TKey : notnull
            => ValueEnumerableExtensions.Distinct<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), comparer);
            
        #endregion
        #region Conversion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TValue>.ValueCollection AsEnumerable<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            where TKey : notnull
            => source;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueWrapper<TKey, TValue> AsValueEnumerable<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            where TKey : notnull
            => new(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TValue[] ToArray<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.ToArray<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TValue> ToList<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.ToList<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey2, TValue> ToDictionary<TKey, TValue, TKey2>(this Dictionary<TKey, TValue>.ValueCollection source, Func<TValue, TKey2> keyFunc, IEqualityComparer<TKey2>? comparer = default)
            where TKey : notnull
            where TKey2 : notnull
            => ValueReadOnlyCollectionExtensions.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TKey2>(new ValueWrapper<TKey, TValue>(source), keyFunc, comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey2, TValue> ToDictionary<TKey, TValue, TKey2, TKeySelector>(this Dictionary<TKey, TValue>.ValueCollection source, TKeySelector keyFunc, IEqualityComparer<TKey2>? comparer = default)
            where TKey : notnull
            where TKey2 : notnull
            where TKeySelector : struct, IFunction<TValue, TKey2>
            => ValueReadOnlyCollectionExtensions.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TKey2, TKeySelector>(new ValueWrapper<TKey, TValue>(source), keyFunc, comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey2, TElement> ToDictionary<TKey, TValue, TKey2, TElement>(this Dictionary<TKey, TValue>.ValueCollection source, Func<TValue, TKey2> keyFunc, Func<TValue, TElement> elementFunc, IEqualityComparer<TKey2>? comparer = default)
            where TKey : notnull
            where TKey2 : notnull
            => ValueReadOnlyCollectionExtensions.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TKey2, TElement>(new ValueWrapper<TKey, TValue>(source), keyFunc, elementFunc, comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey2, TElement> ToDictionary<TKey, TValue, TKey2, TElement, TKeySelector, TElementSelector>(this Dictionary<TKey, TValue>.ValueCollection source, TKeySelector keyFunc, TElementSelector elementFunc, IEqualityComparer<TKey2>? comparer = default)
            where TKey : notnull
            where TKey2 : notnull
            where TKeySelector : struct, IFunction<TValue, TKey2>
            where TElementSelector : struct, IFunction<TValue, TElement>
            => ValueReadOnlyCollectionExtensions.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TKey2, TElement, TKeySelector, TElementSelector>(new ValueWrapper<TKey, TValue>(source), keyFunc, elementFunc, comparer);
            
        #endregion

        [GeneratorMapping("TSource", "TValue")]
        public readonly partial struct ValueWrapper<TKey, TValue>
            : IValueReadOnlyCollection<TValue, Dictionary<TKey, TValue>.ValueCollection.Enumerator>
            , ICollection<TValue>
            where TKey : notnull
        {
            readonly Dictionary<TKey, TValue>.ValueCollection source;

            public ValueWrapper(Dictionary<TKey, TValue>.ValueCollection source) 
                => this.source = source;

            public readonly int Count
                => source.Count;

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Dictionary<TKey, TValue>.ValueCollection.Enumerator GetEnumerator() 
                => source.GetEnumerator();
            readonly IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => source.GetEnumerator();
            readonly IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => source.GetEnumerator();

            bool ICollection<TValue>.IsReadOnly  
                => true;

            void ICollection<TValue>.CopyTo(TValue[] array, int arrayIndex) 
                => source.CopyTo(array, arrayIndex);

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

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly TValue[] ToArray()
            => ValueReadOnlyCollectionExtensions.ToArray<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(this);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TKey, TValue>(this ValueWrapper<TKey, TValue> source)
            where TKey : notnull
            => source.Count;
    }
}