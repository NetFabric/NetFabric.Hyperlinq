using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    [GeneratorIgnore]
    public static partial class ImmutableHashSetBindings
    {
        
        #region Aggregation
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this ImmutableHashSet<TSource> source)
            => ValueReadOnlyCollectionExtensions.Count<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
            
        #endregion
        #region Partitioning

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource> Skip<TSource>(this ImmutableHashSet<TSource> source, int count)
            => ValueReadOnlyCollectionExtensions.Skip<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource> Take<TSource>(this ImmutableHashSet<TSource> source, int count)
            => ValueReadOnlyCollectionExtensions.Take<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);
            
        #endregion
        #region Quantifier

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this ImmutableHashSet<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollectionExtensions.All<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource, TPredicate>(this ImmutableHashSet<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, bool>
            => ValueReadOnlyCollectionExtensions.All<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TPredicate>(new ValueWrapper<TSource>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this ImmutableHashSet<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyCollectionExtensions.All<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AllAt<TSource, TPredicate>(this ImmutableHashSet<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, int, bool>
            => ValueReadOnlyCollectionExtensions.AllAt<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TPredicate>(new ValueWrapper<TSource>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this ImmutableHashSet<TSource> source)
            => ValueReadOnlyCollectionExtensions.Any<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this ImmutableHashSet<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollectionExtensions.Any<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource, TPredicate>(this ImmutableHashSet<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, bool>
            => ValueReadOnlyCollectionExtensions.Any<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TPredicate>(new ValueWrapper<TSource>(source), predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this ImmutableHashSet<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyCollectionExtensions.Any<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AnyAt<TSource, TPredicate>(this ImmutableHashSet<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, int, bool>
            => ValueReadOnlyCollectionExtensions.AnyAt<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TPredicate>(new ValueWrapper<TSource>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<TSource>(this ImmutableHashSet<TSource> source, TSource value, IEqualityComparer<TSource>? comparer = default)
            => ValueReadOnlyCollectionExtensions.Contains<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), value, comparer);
            
        #endregion
        #region Projection

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueReadOnlyCollectionExtensions.SelectEnumerable<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TResult, FunctionWrapper<TSource, TResult>> Select<TSource, TResult>(
            this ImmutableHashSet<TSource> source,
            Func<TSource, TResult> selector)
            => ValueReadOnlyCollectionExtensions.Select<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueReadOnlyCollectionExtensions.SelectEnumerable<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TResult, TSelector> Select<TSource, TResult, TSelector>(
            this ImmutableHashSet<TSource> source,
            TSelector selector = default)
            where TSelector : struct, IFunction<TSource, TResult>
            => ValueReadOnlyCollectionExtensions.Select<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TResult, TSelector>(new ValueWrapper<TSource>(source), selector);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueReadOnlyCollectionExtensions.SelectAtEnumerable<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TResult, FunctionWrapper<TSource, int, TResult>> Select<TSource, TResult>(
            this ImmutableHashSet<TSource> source,
            Func<TSource, int, TResult> selector)
            => ValueReadOnlyCollectionExtensions.Select<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueReadOnlyCollectionExtensions.SelectAtEnumerable<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TResult, TSelector> SelectAt<TSource, TResult, TSelector>(
            this ImmutableHashSet<TSource> source,
            TSelector selector = default)
            where TSelector : struct, IFunction<TSource, int, TResult>
            => ValueReadOnlyCollectionExtensions.SelectAt<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TResult, TSelector>(new ValueWrapper<TSource>(source), selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableExtensions.SelectManyEnumerable<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, FunctionWrapper<TSource, TSubEnumerable>> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this ImmutableHashSet<TSource> source,
            Func<TSource, TSubEnumerable> selector)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ValueEnumerableExtensions.SelectMany<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TSource>(source), selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableExtensions.SelectManyEnumerable<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>(
            this ImmutableHashSet<TSource> source,
            TSelector selector = default)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
            => ValueEnumerableExtensions.SelectMany<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>(new ValueWrapper<TSource>(source), selector);
            
        #endregion
        #region Filtering

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableExtensions.WhereEnumerable<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, FunctionWrapper<TSource, bool>> Where<TSource>(
            this ImmutableHashSet<TSource> source,
            Func<TSource, bool> predicate)
            => ValueEnumerableExtensions.Where<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableExtensions.WhereEnumerable<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TPredicate> Where<TSource, TPredicate>(
            this ImmutableHashSet<TSource> source,
            TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, bool>
            => ValueEnumerableExtensions.Where<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TPredicate>(new ValueWrapper<TSource>(source), predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableExtensions.WhereAtEnumerable<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, FunctionWrapper<TSource, int, bool>> Where<TSource>(
            this ImmutableHashSet<TSource> source,
            Func<TSource, int, bool> predicate)
            => ValueEnumerableExtensions.Where<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableExtensions.WhereAtEnumerable<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TPredicate> WhereAt<TSource, TPredicate>(
            this ImmutableHashSet<TSource> source,
            TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, int, bool>
            => ValueEnumerableExtensions.WhereAt<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TPredicate>(new ValueWrapper<TSource>(source), predicate);
            
        #endregion
        #region Element

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> ElementAt<TSource>(this ImmutableHashSet<TSource> source, int index)
            => ValueReadOnlyCollectionExtensions.ElementAt<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), index);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> First<TSource>(this ImmutableHashSet<TSource> source)
            => ValueReadOnlyCollectionExtensions.First<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> Single<TSource>(this ImmutableHashSet<TSource> source)
#pragma warning disable HLQ005 // Avoid Single() and SingleOrDefault()
            => ValueReadOnlyCollectionExtensions.Single<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
#pragma warning restore HLQ005 // Avoid Single() and SingleOrDefault()
            
        #endregion
        #region Set

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableExtensions.DistinctEnumerable<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource> Distinct<TSource>(this ImmutableHashSet<TSource> source, IEqualityComparer<TSource>? comparer = default)
            => ValueEnumerableExtensions.Distinct<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), comparer);
            
        #endregion
        #region Conversion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ImmutableHashSet<TSource> AsEnumerable<TSource>(this ImmutableHashSet<TSource> source)
            => source;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueWrapper<TSource> AsValueEnumerable<TSource>(this ImmutableHashSet<TSource> source)
            => new(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource[] ToArray<TSource>(this ImmutableHashSet<TSource> source)
            => ValueReadOnlyCollectionExtensions.ToArray<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> ToList<TSource>(this ImmutableHashSet<TSource> source)
            => ValueReadOnlyCollectionExtensions.ToList<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this ImmutableHashSet<TSource> source, Func<TSource, TKey> keyFunc, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.ToDictionary<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TKey>(new ValueWrapper<TSource>(source), keyFunc, comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey, TKeySelector>(this ImmutableHashSet<TSource> source, TKeySelector keyFunc, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            => ValueReadOnlyCollectionExtensions.ToDictionary<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TKey, TKeySelector>(new ValueWrapper<TSource>(source), keyFunc, comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this ImmutableHashSet<TSource> source, Func<TSource, TKey> keyFunc, Func<TSource, TElement> elementFunc, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.ToDictionary<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TKey, TElement>(new ValueWrapper<TSource>(source), keyFunc, elementFunc, comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement, TKeySelector, TElementSelector>(this ImmutableHashSet<TSource> source, TKeySelector keyFunc, TElementSelector elementFunc, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            where TElementSelector : struct, IFunction<TSource, TElement>
            => ValueReadOnlyCollectionExtensions.ToDictionary<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TKey, TElement, TKeySelector, TElementSelector>(new ValueWrapper<TSource>(source), keyFunc, elementFunc, comparer);
            
        #endregion

        public readonly partial struct ValueWrapper<TSource>
            : IValueReadOnlyCollection<TSource, ImmutableHashSet<TSource>.Enumerator>
            , ICollection<TSource>
        {
            readonly ImmutableHashSet<TSource> source;

            public ValueWrapper(ImmutableHashSet<TSource> source) 
                => this.source = source;

            public int Count 
                => source.Count;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ImmutableHashSet<TSource>.Enumerator GetEnumerator() 
                => source.GetEnumerator();
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => source.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => source.GetEnumerator();

            bool ICollection<TSource>.IsReadOnly  
                => true;

            void ICollection<TSource>.CopyTo(TSource[] array, int arrayIndex) 
                => ((ICollection<TSource>)source).CopyTo(array, arrayIndex);

            void ICollection<TSource>.Add(TSource item) 
                => throw new NotSupportedException();
            void ICollection<TSource>.Clear() 
                => throw new NotSupportedException();
            bool ICollection<TSource>.Contains(TSource item) 
                => throw new NotSupportedException();
            bool ICollection<TSource>.Remove(TSource item) 
                => throw new NotSupportedException();
        }

        public static int Count<TSource>(this ValueWrapper<TSource> source)
            => source.Count;
    }
}