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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ArraySegmentWhereEnumerable<TSource, FunctionWrapper<TSource, bool>> Where<TSource>(this in ArraySegment<TSource> source, Func<TSource, bool> predicate)
            => source.Where(new FunctionWrapper<TSource, bool>(predicate));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ArraySegmentWhereEnumerable<TSource, TPredicate> Where<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, bool>
            => new(source, predicate);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ArraySegmentWhereEnumerable<TSource, TPredicate>
            : IValueEnumerable<TSource, ArraySegmentWhereEnumerable<TSource, TPredicate>.Enumerator>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            internal readonly ArraySegment<TSource> source;
            internal readonly TPredicate predicate;

            internal ArraySegmentWhereEnumerable(in ArraySegment<TSource> source, TPredicate predicate)
                => (this.source, this.predicate) = (source, predicate);
            
            public WhereEnumerator<TSource, TPredicate> GetEnumerator()
                => new(source.AsSpan(), predicate);

            Enumerator IValueEnumerable<TSource, Enumerator>.GetEnumerator()
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
                readonly TSource[]? source;
#pragma warning disable IDE0044 // Add readonly modifier
                TPredicate predicate;
#pragma warning restore IDE0044 // Add readonly modifier
                readonly int end;
                int index;

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
                readonly TSource IEnumerator<TSource>.Current
                    => source![index];
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => source![index];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    var index = this.index;
                    while (++index <= end)
                    {
                        if (predicate.Invoke(source![index]))
                        {
                            this.index = index;
                            return true;
                        }
                    }
                    return false;
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset()
                    => throw new NotSupportedException();

                public readonly void Dispose() { }
            }

            #region Aggregation

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count()
                => source.AsReadOnlySpan().Count(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count(Func<TSource, bool> predicate)
                => Count(new FunctionWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => source.AsReadOnlySpan().Count(new PredicatePredicateCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count(Func<TSource, int, bool> predicate)
                => CountAt(new FunctionWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int CountAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => source.AsReadOnlySpan().CountAt(new PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));
            
            #endregion
            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All()
                => source.AsReadOnlySpan().All(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TSource, bool> predicate)
                => All(new FunctionWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => source.AsReadOnlySpan().All(new PredicatePredicateCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TSource, int, bool> predicate)
                => AllAt(new FunctionWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AllAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => source.AsReadOnlySpan().AllAt(new PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.AsReadOnlySpan().Any(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TSource, bool> predicate)
                => Any(new FunctionWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => source.AsReadOnlySpan().Any(new PredicatePredicateCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TSource, int, bool> predicate)
                => AnyAt(new FunctionWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AnyAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => source.AsReadOnlySpan().AnyAt(new PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

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
                => WhereAt(new FunctionWrapper<TSource, int, bool>(predicate));

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
                => source.AsReadOnlySpan().ElementAt(index, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> First()
                => source.AsReadOnlySpan().First(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> Single()
#pragma warning disable HLQ005 // Avoid Single() and SingleOrDefault()
                => source.AsReadOnlySpan().Single(predicate);
#pragma warning restore HLQ005 // Avoid Single() and SingleOrDefault()
            
            #endregion
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => source.AsReadOnlySpan().ToArray(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Lease<TSource> ToArray(ArrayPool<TSource> pool, bool clearOnDispose = default)
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ToArray(pool, clearOnDispose, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => source.AsReadOnlySpan().ToList(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ToDictionary(new FunctionWrapper<TSource, TKey>(keySelector), comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey, TKeySelector>(TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TSource, TKey>
                => source.AsReadOnlySpan().ToDictionary(keySelector, comparer, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ToDictionary<TKey, TElement, FunctionWrapper<TSource, TKey>, FunctionWrapper<TSource, TElement>>(new FunctionWrapper<TSource, TKey>(keySelector), new FunctionWrapper<TSource, TElement>(elementSelector), comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement, TKeySelector, TElementSelector>(TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TSource, TKey>
                where TElementSelector : struct, IFunction<TSource, TElement>
                => source.AsReadOnlySpan().ToDictionary<TSource, TKey, TElement, TKeySelector, TElementSelector, TPredicate>(keySelector, elementSelector, comparer, predicate);
            
            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TPredicate>(this ArraySegmentWhereEnumerable<int, TPredicate> source)
            where TPredicate : struct, IFunction<int, bool>
            => source.source.AsReadOnlySpan().Sum<int, int, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TPredicate>(this ArraySegmentWhereEnumerable<int?, TPredicate> source)
            where TPredicate : struct, IFunction<int?, bool>
            => source.source.AsReadOnlySpan().Sum<int?, int, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TPredicate>(this ArraySegmentWhereEnumerable<nint, TPredicate> source)
            where TPredicate : struct, IFunction<nint, bool>
            => source.source.AsReadOnlySpan().Sum<nint, nint, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TPredicate>(this ArraySegmentWhereEnumerable<nint?, TPredicate> source)
            where TPredicate : struct, IFunction<nint?, bool>
            => source.source.AsReadOnlySpan().Sum<nint?, nint, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TPredicate>(this ArraySegmentWhereEnumerable<nuint, TPredicate> source)
            where TPredicate : struct, IFunction<nuint, bool>
            => source.source.AsReadOnlySpan().Sum<nuint, nuint, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TPredicate>(this ArraySegmentWhereEnumerable<nuint?, TPredicate> source)
            where TPredicate : struct, IFunction<nuint?, bool>
            => source.source.AsReadOnlySpan().Sum<nuint?, nuint, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TPredicate>(this ArraySegmentWhereEnumerable<long, TPredicate> source)
            where TPredicate : struct, IFunction<long, bool>
            => source.source.AsReadOnlySpan().Sum<long, long, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TPredicate>(this ArraySegmentWhereEnumerable<long?, TPredicate> source)
            where TPredicate : struct, IFunction<long?, bool>
            => source.source.AsReadOnlySpan().Sum<long?, long, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TPredicate>(this ArraySegmentWhereEnumerable<float, TPredicate> source)
            where TPredicate : struct, IFunction<float, bool>
            => source.source.AsReadOnlySpan().Sum<float, float, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TPredicate>(this ArraySegmentWhereEnumerable<float?, TPredicate> source)
            where TPredicate : struct, IFunction<float?, bool>
            => source.source.AsReadOnlySpan().Sum<float?, float, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TPredicate>(this ArraySegmentWhereEnumerable<double, TPredicate> source)
            where TPredicate : struct, IFunction<double, bool>
            => source.source.AsReadOnlySpan().Sum<double, double, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TPredicate>(this ArraySegmentWhereEnumerable<double?, TPredicate> source)
            where TPredicate : struct, IFunction<double?, bool>
            => source.source.AsReadOnlySpan().Sum<double?, double, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TPredicate>(this ArraySegmentWhereEnumerable<decimal, TPredicate> source)
            where TPredicate : struct, IFunction<decimal, bool>
            => source.source.AsReadOnlySpan().Sum<decimal, decimal, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TPredicate>(this ArraySegmentWhereEnumerable<decimal?, TPredicate> source)
            where TPredicate : struct, IFunction<decimal?, bool>
            => source.source.AsReadOnlySpan().Sum<decimal?, decimal, TPredicate>(source.predicate);
    }
}

