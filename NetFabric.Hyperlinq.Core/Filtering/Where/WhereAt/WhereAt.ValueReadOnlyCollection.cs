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
        public static WhereAtEnumerable<TEnumerable, TEnumerator, TSource, TPredicate> WhereAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate = default)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
            => new(in source, predicate);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct WhereAtEnumerable<TEnumerable, TEnumerator, TSource, TPredicate> 
            : IValueEnumerable<TSource, WhereAtEnumerable<TEnumerable, TEnumerator, TSource, TPredicate>.Enumerator>
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            internal readonly TEnumerable source;
            internal readonly TPredicate predicate;

            internal WhereAtEnumerable(in TEnumerable source, TPredicate predicate)
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
                int index;

                internal Enumerator(in WhereAtEnumerable<TEnumerable, TEnumerator, TSource, TPredicate> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    predicate = enumerable.predicate;
                    index = -1;
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
                    checked
                    {
                        while (enumerator.MoveNext())
                        {
                            if (predicate.Invoke(enumerator.Current, ++index))
                                return true;
                        }
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
                => CountAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => ValueReadOnlyCollectionExtensions.CountAt<TEnumerable, TEnumerator, TSource, PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>>(source, new PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>(predicate, this.predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int CountAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => ValueReadOnlyCollectionExtensions.CountAt<TEnumerable, TEnumerator, TSource, PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>>(source, new PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            #endregion
            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All()
                => ValueReadOnlyCollectionExtensions.AllAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => ValueReadOnlyCollectionExtensions.AllAt<TEnumerable, TEnumerator, TSource, PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>>(source, new PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>(predicate, this.predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AllAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => ValueReadOnlyCollectionExtensions.AllAt<TEnumerable, TEnumerator, TSource, PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>>(source, new PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => ValueReadOnlyCollectionExtensions.AnyAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => ValueReadOnlyCollectionExtensions.AnyAt<TEnumerable, TEnumerator, TSource, PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>>(source, new PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>(predicate, this.predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AnyAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => ValueReadOnlyCollectionExtensions.AnyAt<TEnumerable, TEnumerator, TSource, PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>>(source, new PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            #endregion
            #region Filtering

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereAtEnumerable<TEnumerable, TEnumerator, TSource, PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>> Where<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => ValueReadOnlyCollectionExtensions.WhereAt<TEnumerable, TEnumerator, TSource, PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>>(source, new PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>(predicate, this.predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereAtEnumerable<TEnumerable, TEnumerator, TSource, PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>> WhereAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => ValueReadOnlyCollectionExtensions.WhereAt<TEnumerable, TEnumerator, TSource, PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>>(source, new PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));
            
            #endregion
            #region Projection
            
            #endregion
            #region Element

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> ElementAt(int index)
                => ElementAtAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, index, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> First()
                => FirstAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> Single()
#pragma warning disable HLQ005 // Avoid Single() and SingleOrDefault()
                => SingleAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);
#pragma warning restore HLQ005 // Avoid Single() and SingleOrDefault()
            
            #endregion
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => ToArrayAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Lease<TSource> ToArray(ArrayPool<TSource> pool, bool clearOnDispose = default)
                => ToArrayAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, pool, clearOnDispose, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => ToListAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey, TKeySelector>(TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TSource, TKey>
                => ToDictionaryAt<TEnumerable, TEnumerator, TSource, TKey, TKeySelector, TPredicate>(source, keySelector, comparer, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement, TKeySelector, TElementSelector>(TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TSource, TKey>
                where TElementSelector : struct, IFunction<TSource, TElement>
                => ToDictionaryAt<TEnumerable, TEnumerator, TSource, TKey, TElement, TKeySelector, TElementSelector, TPredicate>(source, keySelector, elementSelector, comparer, predicate);
            
            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerable, TEnumerator, TPredicate>(this WhereAtEnumerable<TEnumerable, TEnumerator, int, TPredicate> source)
            where TEnumerable : IValueReadOnlyCollection<int, TEnumerator>
            where TEnumerator : struct, IEnumerator<int>
            where TPredicate : struct, IFunction<int, int, bool>
            => SumAt<TEnumerable, TEnumerator, int, int, TPredicate>(source.source, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerable, TEnumerator, TPredicate>(this WhereAtEnumerable<TEnumerable, TEnumerator, int?, TPredicate> source)
            where TEnumerable : IValueReadOnlyCollection<int?, TEnumerator>
            where TEnumerator : struct, IEnumerator<int?>
            where TPredicate : struct, IFunction<int?, int, bool>
            => SumAt<TEnumerable, TEnumerator, int?, int, TPredicate>(source.source, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TEnumerable, TEnumerator, TPredicate>(this WhereAtEnumerable<TEnumerable, TEnumerator, nint, TPredicate> source)
            where TEnumerable : IValueReadOnlyCollection<nint, TEnumerator>
            where TEnumerator : struct, IEnumerator<nint>
            where TPredicate : struct, IFunction<nint, int, bool>
            => SumAt<TEnumerable, TEnumerator, nint, nint, TPredicate>(source.source, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TEnumerable, TEnumerator, TPredicate>(this WhereAtEnumerable<TEnumerable, TEnumerator, nint?, TPredicate> source)
            where TEnumerable : IValueReadOnlyCollection<nint?, TEnumerator>
            where TEnumerator : struct, IEnumerator<nint?>
            where TPredicate : struct, IFunction<nint?, int, bool>
            => SumAt<TEnumerable, TEnumerator, nint?, nint, TPredicate>(source.source, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TEnumerable, TEnumerator, TPredicate>(this WhereAtEnumerable<TEnumerable, TEnumerator, nuint, TPredicate> source)
            where TEnumerable : IValueReadOnlyCollection<nuint, TEnumerator>
            where TEnumerator : struct, IEnumerator<nuint>
            where TPredicate : struct, IFunction<nuint, int, bool>
            => SumAt<TEnumerable, TEnumerator, nuint, nuint, TPredicate>(source.source, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TEnumerable, TEnumerator, TPredicate>(this WhereAtEnumerable<TEnumerable, TEnumerator, nuint?, TPredicate> source)
            where TEnumerable : IValueReadOnlyCollection<nuint?, TEnumerator>
            where TEnumerator : struct, IEnumerator<nuint?>
            where TPredicate : struct, IFunction<nuint?, int, bool>
            => SumAt<TEnumerable, TEnumerator, nuint?, nuint, TPredicate>(source.source, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerable, TEnumerator, TPredicate>(this WhereAtEnumerable<TEnumerable, TEnumerator, long, TPredicate> source)
            where TEnumerable : IValueReadOnlyCollection<long, TEnumerator>
            where TEnumerator : struct, IEnumerator<long>
            where TPredicate : struct, IFunction<long, int, bool>
            => SumAt<TEnumerable, TEnumerator, long, long, TPredicate>(source.source, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerable, TEnumerator, TPredicate>(this WhereAtEnumerable<TEnumerable, TEnumerator, long?, TPredicate> source)
            where TEnumerable : IValueReadOnlyCollection<long?, TEnumerator>
            where TEnumerator : struct, IEnumerator<long?>
            where TPredicate : struct, IFunction<long?, int, bool>
            => SumAt<TEnumerable, TEnumerator, long?, long, TPredicate>(source.source, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerable, TEnumerator, TPredicate>(this WhereAtEnumerable<TEnumerable, TEnumerator, float, TPredicate> source)
            where TEnumerable : IValueReadOnlyCollection<float, TEnumerator>
            where TEnumerator : struct, IEnumerator<float>
            where TPredicate : struct, IFunction<float, int, bool>
            => SumAt<TEnumerable, TEnumerator, float, float, TPredicate>(source.source, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerable, TEnumerator, TPredicate>(this WhereAtEnumerable<TEnumerable, TEnumerator, float?, TPredicate> source)
            where TEnumerable : IValueReadOnlyCollection<float?, TEnumerator>
            where TEnumerator : struct, IEnumerator<float?>
            where TPredicate : struct, IFunction<float?, int, bool>
            => SumAt<TEnumerable, TEnumerator, float?, float, TPredicate>(source.source, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerable, TEnumerator, TPredicate>(this WhereAtEnumerable<TEnumerable, TEnumerator, double, TPredicate> source)
            where TEnumerable : IValueReadOnlyCollection<double, TEnumerator>
            where TEnumerator : struct, IEnumerator<double>
            where TPredicate : struct, IFunction<double, int, bool>
            => SumAt<TEnumerable, TEnumerator, double, double, TPredicate>(source.source, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerable, TEnumerator, TPredicate>(this WhereAtEnumerable<TEnumerable, TEnumerator, double?, TPredicate> source)
            where TEnumerable : IValueReadOnlyCollection<double?, TEnumerator>
            where TEnumerator : struct, IEnumerator<double?>
            where TPredicate : struct, IFunction<double?, int, bool>
            => SumAt<TEnumerable, TEnumerator, double?, double, TPredicate>(source.source, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerable, TEnumerator, TPredicate>(this WhereAtEnumerable<TEnumerable, TEnumerator, decimal, TPredicate> source)
            where TEnumerable : IValueReadOnlyCollection<decimal, TEnumerator>
            where TEnumerator : struct, IEnumerator<decimal>
            where TPredicate : struct, IFunction<decimal, int, bool>
            => SumAt<TEnumerable, TEnumerator, decimal, decimal, TPredicate>(source.source, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerable, TEnumerator, TPredicate>(this WhereAtEnumerable<TEnumerable, TEnumerator, decimal?, TPredicate> source)
            where TEnumerable : IValueReadOnlyCollection<decimal?, TEnumerator>
            where TEnumerator : struct, IEnumerator<decimal?>
            where TPredicate : struct, IFunction<decimal?, int, bool>
            => SumAt<TEnumerable, TEnumerator, decimal?, decimal, TPredicate>(source.source, source.predicate);
    }
}

