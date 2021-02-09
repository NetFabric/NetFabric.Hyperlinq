using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [GeneratorMapping("TPredicate", "NetFabric.Hyperlinq.FunctionWrapper<TSource, bool>")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentWhereEnumerable<TSource, FunctionWrapper<TSource, bool>> Where<TSource>(this in ArraySegment<TSource> source, Func<TSource, bool> predicate)
            => source.Where(new FunctionWrapper<TSource, bool>(predicate));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentWhereEnumerable<TSource, TPredicate> Where<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, bool>
            => new(source, predicate);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ArraySegmentWhereEnumerable<TSource, TPredicate>
            : IValueEnumerable<TSource, ArraySegmentWhereEnumerable<TSource, TPredicate>.DisposableEnumerator>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            internal readonly ArraySegment<TSource> source;
            internal readonly TPredicate predicate;

            internal ArraySegmentWhereEnumerable(in ArraySegment<TSource> source, TPredicate predicate)
                => (this.source, this.predicate) = (source, predicate);
            
            public readonly Enumerator GetEnumerator()
                => new(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, DisposableEnumerator>.GetEnumerator()
                => new(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(in this);

            [StructLayout(LayoutKind.Sequential)]
            public struct Enumerator
            {
                int index;
                readonly int end;
                readonly TSource[]? source;
                TPredicate predicate;

                internal Enumerator(in ArraySegmentWhereEnumerable<TSource, TPredicate> enumerable)
                {
                    source = enumerable.source.Array;
                    predicate = enumerable.predicate;
                    index = enumerable.source.Offset - 1;
                    end = index + enumerable.source.Count;
                }

                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => source![index];
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    while (++index <= end)
                    {
                        if (predicate.Invoke(source![index]))
                            return true;
                    }
                    return false;
                }
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                int index;
                readonly int end;
                readonly TSource[]? source;
                TPredicate predicate;

                internal DisposableEnumerator(in ArraySegmentWhereEnumerable<TSource, TPredicate> enumerable)
                {
                    source = enumerable.source.Array;
                    predicate = enumerable.predicate;
                    index = enumerable.source.Offset - 1;
                    end = index + enumerable.source.Count;
                }

                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => source![index];
                }
                readonly TSource IEnumerator<TSource>.Current
                    => source![index];
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => source![index];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    while (++index <= end)
                    {
                        if (predicate.Invoke(source![index]))
                            return true;
                    }
                    return false;
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset()
                    => throw new NotSupportedException();

                public void Dispose() { }
            }

            #region Aggregation

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count()
                => ((ReadOnlySpan<TSource>)source.AsSpan()).Count(predicate);
            
            #endregion
            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All()
                => ((ReadOnlySpan<TSource>)source.AsSpan()).All(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TSource, bool> predicate)
                => All(new FunctionWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => ((ReadOnlySpan<TSource>)source.AsSpan()).All(new PredicatePredicateCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TSource, int, bool> predicate)
                => AllAt(new FunctionWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AllAt<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => ((ReadOnlySpan<TSource>)source.AsSpan()).AllAt(new PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => ((ReadOnlySpan<TSource>)source.AsSpan()).Any(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TSource, bool> predicate)
                => Any(new FunctionWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => ((ReadOnlySpan<TSource>)source.AsSpan()).Any(new PredicatePredicateCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TSource, int, bool> predicate)
                => AnyAt(new FunctionWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AnyAt<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => ((ReadOnlySpan<TSource>)source.AsSpan()).AnyAt(new PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            #endregion
            #region Filtering

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentWhereEnumerable<TSource, PredicatePredicateCombination<TPredicate, FunctionWrapper<TSource, bool>, TSource>> Where(Func<TSource, bool> predicate)
                => Where(new FunctionWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentWhereEnumerable<TSource, PredicatePredicateCombination<TPredicate, TPredicate2, TSource>> Where<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => source.Where(new PredicatePredicateCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentWhereAtEnumerable<TSource, PredicatePredicateAtCombination<TPredicate, FunctionWrapper<TSource, int, bool>, TSource>> Where(Func<TSource, int, bool> predicate)
                => WhereAt<FunctionWrapper<TSource, int, bool>>(new FunctionWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentWhereAtEnumerable<TSource, PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>> WhereAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => source.WhereAt(new PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));
            
            #endregion
            #region Projection

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate, FunctionWrapper<TSource, TResult>> Select<TResult>(Func<TSource, TResult> selector)
                => Select<TResult, FunctionWrapper<TSource, TResult>>(new FunctionWrapper<TSource, TResult>(selector));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector> Select<TResult, TSelector>(TSelector selector = default)
                where TSelector : struct, IFunction<TSource, TResult>
                => source.WhereSelect<TSource, TResult, TPredicate, TSelector>(predicate, selector);
            
            #endregion
            #region Element

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> ElementAt(int index)
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ElementAt(index, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> First()
                => ((ReadOnlySpan<TSource>)source.AsSpan()).First(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> Single()
#pragma warning disable HLQ005 // Avoid Single() and SingleOrDefault()
                => ((ReadOnlySpan<TSource>)source.AsSpan()).Single(predicate);
#pragma warning restore HLQ005 // Avoid Single() and SingleOrDefault()
            
            #endregion
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ToArray(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public IMemoryOwner<TSource> ToArray(MemoryPool<TSource> memoryPool)
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ToArray(predicate, memoryPool);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ToList(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ToDictionary<TKey, FunctionWrapper<TSource, TKey>>(new FunctionWrapper<TSource, TKey>(keySelector), comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey, TKeySelector>(TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TSource, TKey>
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ToDictionary(keySelector, comparer, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ToDictionary<TKey, TElement, FunctionWrapper<TSource, TKey>, FunctionWrapper<TSource, TElement>>(new FunctionWrapper<TSource, TKey>(keySelector), new FunctionWrapper<TSource, TElement>(elementSelector), comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement, TKeySelector, TElementSelector>(TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TSource, TKey>
                where TElementSelector : struct, IFunction<TSource, TElement>
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ToDictionary<TSource, TKey, TElement, TKeySelector, TElementSelector, TPredicate>(keySelector, elementSelector, comparer, predicate);
            
            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TPredicate>(this ArraySegmentWhereEnumerable<int, TPredicate> source)
            where TPredicate : struct, IFunction<int, bool>
            => ((ReadOnlySpan<int>)source.source.AsSpan()).Sum<int, int, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TPredicate>(this ArraySegmentWhereEnumerable<int?, TPredicate> source)
            where TPredicate : struct, IFunction<int?, bool>
            => ((ReadOnlySpan<int?>)source.source.AsSpan()).Sum<int?, int, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TPredicate>(this ArraySegmentWhereEnumerable<long, TPredicate> source)
            where TPredicate : struct, IFunction<long, bool>
            => ((ReadOnlySpan<long>)source.source.AsSpan()).Sum<long, long, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TPredicate>(this ArraySegmentWhereEnumerable<long?, TPredicate> source)
            where TPredicate : struct, IFunction<long?, bool>
            => ((ReadOnlySpan<long?>)source.source.AsSpan()).Sum<long?, long, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TPredicate>(this ArraySegmentWhereEnumerable<float, TPredicate> source)
            where TPredicate : struct, IFunction<float, bool>
            => ((ReadOnlySpan<float>)source.source.AsSpan()).Sum<float, float, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TPredicate>(this ArraySegmentWhereEnumerable<float?, TPredicate> source)
            where TPredicate : struct, IFunction<float?, bool>
            => ((ReadOnlySpan<float?>)source.source.AsSpan()).Sum<float?, float, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TPredicate>(this ArraySegmentWhereEnumerable<double, TPredicate> source)
            where TPredicate : struct, IFunction<double, bool>
            => ((ReadOnlySpan<double>)source.source.AsSpan()).Sum<double, double, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TPredicate>(this ArraySegmentWhereEnumerable<double?, TPredicate> source)
            where TPredicate : struct, IFunction<double?, bool>
            => ((ReadOnlySpan<double?>)source.source.AsSpan()).Sum<double?, double, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TPredicate>(this ArraySegmentWhereEnumerable<decimal, TPredicate> source)
            where TPredicate : struct, IFunction<decimal, bool>
            => ((ReadOnlySpan<decimal>)source.source.AsSpan()).Sum<decimal, decimal, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TPredicate>(this ArraySegmentWhereEnumerable<decimal?, TPredicate> source)
            where TPredicate : struct, IFunction<decimal?, bool>
            => ((ReadOnlySpan<decimal?>)source.source.AsSpan()).Sum<decimal?, decimal, TPredicate>(source.predicate);
    }
}

