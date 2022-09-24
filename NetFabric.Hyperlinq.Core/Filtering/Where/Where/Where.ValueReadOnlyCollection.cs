using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollectionExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate> Where<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate = default)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            => new(in source, predicate);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate> 
            : IValueEnumerable<TSource, WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate>.Enumerator>
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            internal readonly TEnumerable source;
            internal readonly TPredicate predicate;

            internal WhereEnumerable(in TEnumerable source, TPredicate predicate)
                => (this.source, this.predicate) = (source, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator GetEnumerator() 
                => new(in this);

            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);

            IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);

            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator
                : IEnumerator<TSource>
            {
#pragma warning disable IDE0044 // Add readonly modifier
                TEnumerator enumerator;
                TPredicate predicate;
#pragma warning restore IDE0044 // Add readonly modifier

                internal Enumerator(in WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    predicate = enumerable.predicate;
                }

                public readonly TSource Current 
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => enumerator.Current;
                }
                readonly TSource IEnumerator<TSource>.Current 
                    => enumerator.Current;
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => enumerator.Current;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    while (enumerator.MoveNext())
                    {
                        if (predicate.Invoke(enumerator.Current))
                            return true;
                    }
                    return false;
                }

                [ExcludeFromCodeCoverage]
                [DoesNotReturn]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public void Dispose() 
                    => enumerator.Dispose();
            }

            #region Aggregation

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count()
                => ValueReadOnlyCollectionExtensions.Count<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => ValueReadOnlyCollectionExtensions.Count<TEnumerable, TEnumerator, TSource, PredicatePredicateCombination<TPredicate, TPredicate2, TSource>>(source, new PredicatePredicateCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int CountAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => ValueReadOnlyCollectionExtensions.CountAt<TEnumerable, TEnumerator, TSource, PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>>(source, new PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            #endregion
            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All()
                => ValueReadOnlyCollectionExtensions.All<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => ValueReadOnlyCollectionExtensions.All<TEnumerable, TEnumerator, TSource, PredicatePredicateCombination<TPredicate, TPredicate2, TSource>>(source, new PredicatePredicateCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AllAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => ValueReadOnlyCollectionExtensions.AllAt<TEnumerable, TEnumerator, TSource, PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>>(source, new PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => ValueReadOnlyCollectionExtensions.Any<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => ValueReadOnlyCollectionExtensions.Any<TEnumerable, TEnumerator, TSource, PredicatePredicateCombination<TPredicate, TPredicate2, TSource>>(source, new PredicatePredicateCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AnyAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => ValueReadOnlyCollectionExtensions.AnyAt<TEnumerable, TEnumerator, TSource, PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>>(source, new PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            #endregion
            #region Filtering

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereEnumerable<TEnumerable, TEnumerator, TSource, PredicatePredicateCombination<TPredicate, TPredicate2, TSource>> Where<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => ValueReadOnlyCollectionExtensions.Where<TEnumerable, TEnumerator, TSource, PredicatePredicateCombination<TPredicate, TPredicate2, TSource>>(source, new PredicatePredicateCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereAtEnumerable<TEnumerable, TEnumerator, TSource, PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>> WhereAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => ValueReadOnlyCollectionExtensions.WhereAt<TEnumerable, TEnumerator, TSource, PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>>(source, new PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));
            
            #endregion
            #region Projection

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector> Select<TResult, TSelector>(TSelector selector = default)
                where TSelector : struct, IFunction<TSource, TResult>
                => WhereSelect<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(source, predicate, selector);
            
            #endregion
            #region Element

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> ElementAt(int index)
                => ValueReadOnlyCollectionExtensions.ElementAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, index, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> First()
                => ValueReadOnlyCollectionExtensions.First<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> Single()
#pragma warning disable HLQ005 // Avoid Single() and SingleOrDefault()
                => ValueReadOnlyCollectionExtensions.Single<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);
#pragma warning restore HLQ005 // Avoid Single() and SingleOrDefault()
            
            #endregion
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => ValueReadOnlyCollectionExtensions.ToArray<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Lease<TSource> ToArray(ArrayPool<TSource> pool, bool clearOnDispose = default)
                => ValueReadOnlyCollectionExtensions.ToArray<TEnumerable, TEnumerator, TSource, TPredicate>(source, pool, clearOnDispose, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => ValueReadOnlyCollectionExtensions.ToList<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey, TKeySelector>(TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TSource, TKey>
                => ValueReadOnlyCollectionExtensions.ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TKeySelector, TPredicate>(source, keySelector, comparer, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement, TKeySelector, TElementSelector>(TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TSource, TKey>
                where TElementSelector : struct, IFunction<TSource, TElement>
                => ValueReadOnlyCollectionExtensions.ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement, TKeySelector, TElementSelector, TPredicate>(source, keySelector, elementSelector, comparer, predicate);
            
            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, int, TPredicate> source)
            where TEnumerable : IValueReadOnlyCollection<int, TEnumerator>
            where TEnumerator : struct, IEnumerator<int>
            where TPredicate : struct, IFunction<int, bool>
            => Sum<TEnumerable, TEnumerator, int, int, TPredicate>(source.source, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, int?, TPredicate> source)
            where TEnumerable : IValueReadOnlyCollection<int?, TEnumerator>
            where TEnumerator : struct, IEnumerator<int?>
            where TPredicate : struct, IFunction<int?, bool>
            => Sum<TEnumerable, TEnumerator, int?, int, TPredicate>(source.source, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, nint, TPredicate> source)
            where TEnumerable : IValueReadOnlyCollection<nint, TEnumerator>
            where TEnumerator : struct, IEnumerator<nint>
            where TPredicate : struct, IFunction<nint, bool>
            => Sum<TEnumerable, TEnumerator, nint, nint, TPredicate>(source.source, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, nint?, TPredicate> source)
            where TEnumerable : IValueReadOnlyCollection<nint?, TEnumerator>
            where TEnumerator : struct, IEnumerator<nint?>
            where TPredicate : struct, IFunction<nint?, bool>
            => Sum<TEnumerable, TEnumerator, nint?, nint, TPredicate>(source.source, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, nuint, TPredicate> source)
            where TEnumerable : IValueReadOnlyCollection<nuint, TEnumerator>
            where TEnumerator : struct, IEnumerator<nuint>
            where TPredicate : struct, IFunction<nuint, bool>
            => Sum<TEnumerable, TEnumerator, nuint, nuint, TPredicate>(source.source, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, nuint?, TPredicate> source)
            where TEnumerable : IValueReadOnlyCollection<nuint?, TEnumerator>
            where TEnumerator : struct, IEnumerator<nuint?>
            where TPredicate : struct, IFunction<nuint?, bool>
            => Sum<TEnumerable, TEnumerator, nuint?, nuint, TPredicate>(source.source, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, long, TPredicate> source)
            where TEnumerable : IValueReadOnlyCollection<long, TEnumerator>
            where TEnumerator : struct, IEnumerator<long>
            where TPredicate : struct, IFunction<long, bool>
            => Sum<TEnumerable, TEnumerator, long, long, TPredicate>(source.source, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, long?, TPredicate> source)
            where TEnumerable : IValueReadOnlyCollection<long?, TEnumerator>
            where TEnumerator : struct, IEnumerator<long?>
            where TPredicate : struct, IFunction<long?, bool>
            => Sum<TEnumerable, TEnumerator, long?, long, TPredicate>(source.source, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, float, TPredicate> source)
            where TEnumerable : IValueReadOnlyCollection<float, TEnumerator>
            where TEnumerator : struct, IEnumerator<float>
            where TPredicate : struct, IFunction<float, bool>
            => Sum<TEnumerable, TEnumerator, float, float, TPredicate>(source.source, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, float?, TPredicate> source)
            where TEnumerable : IValueReadOnlyCollection<float?, TEnumerator>
            where TEnumerator : struct, IEnumerator<float?>
            where TPredicate : struct, IFunction<float?, bool>
            => Sum<TEnumerable, TEnumerator, float?, float, TPredicate>(source.source, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, double, TPredicate> source)
            where TEnumerable : IValueReadOnlyCollection<double, TEnumerator>
            where TEnumerator : struct, IEnumerator<double>
            where TPredicate : struct, IFunction<double, bool>
            => Sum<TEnumerable, TEnumerator, double, double, TPredicate>(source.source, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, double?, TPredicate> source)
            where TEnumerable : IValueReadOnlyCollection<double?, TEnumerator>
            where TEnumerator : struct, IEnumerator<double?>
            where TPredicate : struct, IFunction<double?, bool>
            => Sum<TEnumerable, TEnumerator, double?, double, TPredicate>(source.source, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, decimal, TPredicate> source)
            where TEnumerable : IValueReadOnlyCollection<decimal, TEnumerator>
            where TEnumerator : struct, IEnumerator<decimal>
            where TPredicate : struct, IFunction<decimal, bool>
            => Sum<TEnumerable, TEnumerator, decimal, decimal, TPredicate>(source.source, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, decimal?, TPredicate> source)
            where TEnumerable : IValueReadOnlyCollection<decimal?, TEnumerator>
            where TEnumerator : struct, IEnumerator<decimal?>
            where TPredicate : struct, IFunction<decimal?, bool>
            => Sum<TEnumerable, TEnumerator, decimal?, decimal, TPredicate>(source.source, source.predicate);
    }
}

