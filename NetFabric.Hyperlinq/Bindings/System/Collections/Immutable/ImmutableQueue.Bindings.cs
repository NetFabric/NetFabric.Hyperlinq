using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    [GeneratorIgnore]
    public static partial class ImmutableQueueBindings
    {
        
        #region Aggregation
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this ImmutableQueue<TSource> source)
            => ValueEnumerableExtensions.Count<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
            
        #endregion
        #region Partitioning

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableExtensions.SkipEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource> Skip<TSource>(this ImmutableQueue<TSource> source, int count)
            => ValueEnumerableExtensions.Skip<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableExtensions.TakeEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource> Take<TSource>(this ImmutableQueue<TSource> source, int count)
            => ValueEnumerableExtensions.Take<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);
            
        #endregion
        #region Quantifier

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this ImmutableQueue<TSource> source, Func<TSource, bool> predicate)
            => ValueEnumerableExtensions.All<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource, TPredicate>(this ImmutableQueue<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, bool>
            => ValueEnumerableExtensions.All<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TPredicate>(new ValueWrapper<TSource>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this ImmutableQueue<TSource> source, Func<TSource, int, bool> predicate)
            => ValueEnumerableExtensions.All<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AllAt<TSource, TPredicate>(this ImmutableQueue<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, int, bool>
            => ValueEnumerableExtensions.AllAt<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TPredicate>(new ValueWrapper<TSource>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this ImmutableQueue<TSource> source)
            => ValueEnumerableExtensions.Any<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this ImmutableQueue<TSource> source, Func<TSource, bool> predicate)
            => ValueEnumerableExtensions.Any<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource, TPredicate>(this ImmutableQueue<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, bool>
            => ValueEnumerableExtensions.Any<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TPredicate>(new ValueWrapper<TSource>(source), predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this ImmutableQueue<TSource> source, Func<TSource, int, bool> predicate)
            => ValueEnumerableExtensions.Any<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AnyAt<TSource, TPredicate>(this ImmutableQueue<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, int, bool>
            => ValueEnumerableExtensions.AnyAt<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TPredicate>(new ValueWrapper<TSource>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<TSource>(this ImmutableQueue<TSource> source, TSource value, IEqualityComparer<TSource>? comparer = default)
            => ValueEnumerableExtensions.Contains<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), value, comparer);
            
        #endregion
        #region Projection

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableExtensions.SelectEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TResult, FunctionWrapper<TSource, TResult>> Select<TSource, TResult>(
            this ImmutableQueue<TSource> source,
            Func<TSource, TResult> selector)
            => ValueEnumerableExtensions.Select<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableExtensions.SelectEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TResult, TSelector> Select<TSource, TResult, TSelector>(
            this ImmutableQueue<TSource> source,
            TSelector selector = default)
            where TSelector : struct, IFunction<TSource, TResult>
            => ValueEnumerableExtensions.Select<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TResult, TSelector>(new ValueWrapper<TSource>(source), selector);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableExtensions.SelectAtEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TResult, FunctionWrapper<TSource, int, TResult>> Select<TSource, TResult>(
            this ImmutableQueue<TSource> source,
            Func<TSource, int, TResult> selector)
            => ValueEnumerableExtensions.Select<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableExtensions.SelectAtEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TResult, TSelector> SelectAt<TSource, TResult, TSelector>(
            this ImmutableQueue<TSource> source,
            TSelector selector = default)
            where TSelector : struct, IFunction<TSource, int, TResult>
            => ValueEnumerableExtensions.SelectAt<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TResult, TSelector>(new ValueWrapper<TSource>(source), selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableExtensions.SelectManyEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, FunctionWrapper<TSource, TSubEnumerable>> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this ImmutableQueue<TSource> source,
            Func<TSource, TSubEnumerable> selector)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ValueEnumerableExtensions.SelectMany<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TSource>(source), selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableExtensions.SelectManyEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>(
            this ImmutableQueue<TSource> source,
            TSelector selector = default)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
            => ValueEnumerableExtensions.SelectMany<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>(new ValueWrapper<TSource>(source), selector);
            
        #endregion
        #region Filtering

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableExtensions.WhereEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, FunctionWrapper<TSource, bool>> Where<TSource>(
            this ImmutableQueue<TSource> source,
            Func<TSource, bool> predicate)
            => ValueEnumerableExtensions.Where<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableExtensions.WhereEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TPredicate> Where<TSource, TPredicate>(
            this ImmutableQueue<TSource> source,
            TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, bool>
            => ValueEnumerableExtensions.Where<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TPredicate>(new ValueWrapper<TSource>(source), predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableExtensions.WhereAtEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, FunctionWrapper<TSource, int, bool>> Where<TSource>(
            this ImmutableQueue<TSource> source,
            Func<TSource, int, bool> predicate)
            => ValueEnumerableExtensions.Where<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableExtensions.WhereAtEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TPredicate> WhereAt<TSource, TPredicate>(
            this ImmutableQueue<TSource> source,
            TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, int, bool>
            => ValueEnumerableExtensions.WhereAt<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TPredicate>(new ValueWrapper<TSource>(source), predicate);
            
        #endregion
        #region Element

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> ElementAt<TSource>(this ImmutableQueue<TSource> source, int index)
            => ValueEnumerableExtensions.ElementAt<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), index);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> First<TSource>(this ImmutableQueue<TSource> source)
            => ValueEnumerableExtensions.First<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> Single<TSource>(this ImmutableQueue<TSource> source)
#pragma warning disable HLQ005 // Avoid Single() and SingleOrDefault()
            => ValueEnumerableExtensions.Single<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
#pragma warning restore HLQ005 // Avoid Single() and SingleOrDefault()
            
        #endregion
        #region Set

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableExtensions.DistinctEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource> Distinct<TSource>(this ImmutableQueue<TSource> source, IEqualityComparer<TSource>? comparer = default)
            => ValueEnumerableExtensions.Distinct<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), comparer);
            
        #endregion
        #region Conversion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ImmutableQueue<TSource> AsEnumerable<TSource>(this ImmutableQueue<TSource> source)
            => source;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueWrapper<TSource> AsValueEnumerable<TSource>(this ImmutableQueue<TSource> source)
            => new(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource[] ToArray<TSource>(this ImmutableQueue<TSource> source)
            => ValueEnumerableExtensions.ToArray<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> ToList<TSource>(this ImmutableQueue<TSource> source)
            => ValueEnumerableExtensions.ToList<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this ImmutableQueue<TSource> source, Func<TSource, TKey> keyFunc, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => ValueEnumerableExtensions.ToDictionary<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TKey>(new ValueWrapper<TSource>(source), keyFunc, comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey, TKeySelector>(this ImmutableQueue<TSource> source, TKeySelector keyFunc, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            => ValueEnumerableExtensions.ToDictionary<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TKey, TKeySelector>(new ValueWrapper<TSource>(source), keyFunc, comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this ImmutableQueue<TSource> source, Func<TSource, TKey> keyFunc, Func<TSource, TElement> elementFunc, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => ValueEnumerableExtensions.ToDictionary<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TKey, TElement>(new ValueWrapper<TSource>(source), keyFunc, elementFunc, comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement, TKeySelector, TElementSelector>(this ImmutableQueue<TSource> source, TKeySelector keyFunc, TElementSelector elementFunc, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            where TElementSelector : struct, IFunction<TSource, TElement>
            => ValueEnumerableExtensions.ToDictionary<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TKey, TElement, TKeySelector, TElementSelector>(new ValueWrapper<TSource>(source), keyFunc, elementFunc, comparer);
            
        #endregion

        public readonly partial struct ValueWrapper<TSource>
            : IValueEnumerable<TSource, ValueWrapper<TSource>.Enumerator>
        {
            readonly ImmutableQueue<TSource> source;

            public ValueWrapper(ImmutableQueue<TSource> source) 
                => this.source = source;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() 
                => new(source);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(source);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(source);

            public struct Enumerator
                : IEnumerator<TSource>
            {
                ImmutableQueue<TSource>.Enumerator enumerator;

                internal Enumerator(ImmutableQueue<TSource> enumerable) 
                    => enumerator = enumerable.GetEnumerator();

                public readonly TSource Current 
                    => enumerator.Current;
                readonly TSource IEnumerator<TSource>.Current 
                    => enumerator.Current;
                readonly object IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => enumerator.Current;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public readonly bool MoveNext() 
                    => enumerator.MoveNext();

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => throw new NotSupportedException();

                public readonly void Dispose() { }
            }
        }
    }
}