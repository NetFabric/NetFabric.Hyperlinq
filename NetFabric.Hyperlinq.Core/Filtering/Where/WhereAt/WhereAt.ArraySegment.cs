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
        static ArraySegmentWhereAtEnumerable<TSource, FunctionWrapper<TSource, int, bool>> Where<TSource>(this in ArraySegment<TSource> source, Func<TSource, int, bool> predicate)
            => source.WhereAt(new FunctionWrapper<TSource, int, bool>(predicate));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ArraySegmentWhereAtEnumerable<TSource, TPredicate> WhereAt<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, int, bool>
            => new(source, predicate);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ArraySegmentWhereAtEnumerable<TSource, TPredicate>
            : IValueEnumerable<TSource, ArraySegmentWhereAtEnumerable<TSource, TPredicate>.Enumerator>
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            internal readonly ArraySegment<TSource> source;
            internal readonly TPredicate predicate;

            internal ArraySegmentWhereAtEnumerable(in ArraySegment<TSource> source, TPredicate predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }


            public WhereAtEnumerator<TSource, TPredicate> GetEnumerator()
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
                readonly int offset;
                readonly int end;
                int index;

                internal Enumerator(in ArraySegmentWhereAtEnumerable<TSource, TPredicate> enumerable)
                {
                    source = enumerable.source.Array;
                    predicate = enumerable.predicate;
                    offset = enumerable.source.Offset;
                    index = -1;
                    end = index + enumerable.source.Count;
                }

                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => source![index + offset];
                }
                readonly TSource IEnumerator<TSource>.Current
                    => source![index + offset];
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => source![index + offset];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    var index = this.index;
                    while (++index <= end)
                    {
                        if (predicate.Invoke(source![index + offset], index))
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
                => source.AsReadOnlySpan().CountAt(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count(Func<TSource, bool> predicate)
                => Count(new FunctionWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => source.AsReadOnlySpan().CountAt(new PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>(predicate, this.predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count(Func<TSource, int, bool> predicate)
                => CountAt(new FunctionWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int CountAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => source.AsReadOnlySpan().CountAt(new PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            #endregion
            #region Quantifier


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All()
                => source.AsReadOnlySpan().AllAt(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TSource, bool> predicate)
                => All(new FunctionWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => source.AsReadOnlySpan().AllAt(new PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>(predicate, this.predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TSource, int, bool> predicate)
                => AllAt(new FunctionWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AllAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => source.AsReadOnlySpan().AllAt(new PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.AsReadOnlySpan().AnyAt(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TSource, bool> predicate)
                => Any(new FunctionWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => source.AsReadOnlySpan().AnyAt(new PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>(predicate, this.predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TSource, int, bool> predicate)
                => AnyAt(new FunctionWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AnyAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => source.AsReadOnlySpan().AnyAt(new PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            #endregion
            #region Filtering

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentWhereAtEnumerable<TSource, PredicatePredicateAtCombination<FunctionWrapper<TSource, bool>, TPredicate, TSource>> Where(Func<TSource, bool> predicate)
                => Where(new FunctionWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentWhereAtEnumerable<TSource, PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>> Where<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => source.WhereAt(new PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>(predicate, this.predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentWhereAtEnumerable<TSource, PredicateAtPredicateAtCombination<TPredicate, FunctionWrapper<TSource, int, bool>, TSource>> Where(Func<TSource, int, bool> predicate)
                => WhereAt(new FunctionWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentWhereAtEnumerable<TSource, PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>> WhereAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => source.WhereAt(new PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));
            
            #endregion
            #region Projection
            
            #endregion
            #region Element

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> ElementAt(int index)
                => source.AsReadOnlySpan().ElementAtAt(index, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> First()
                => source.AsReadOnlySpan().FirstAt(predicate);

#pragma warning disable HLQ005 // Avoid Single() and SingleOrDefault()
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> Single()
                => source.AsReadOnlySpan().SingleAt(predicate);
#pragma warning restore HLQ005 // Avoid Single() and SingleOrDefault()
            
            #endregion
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => source.AsReadOnlySpan().ToArrayAt(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Lease<TSource> ToArray(ArrayPool<TSource> pool, bool clearOnDispose = default)
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ToArrayAt(pool, clearOnDispose, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => source.AsReadOnlySpan().ToListAt(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ToDictionary(new FunctionWrapper<TSource, TKey>(keySelector), comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey, TKeySelector>(TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TSource, TKey>
                => source.AsReadOnlySpan().ToDictionaryAt(keySelector, comparer, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ToDictionary<TKey, TElement, FunctionWrapper<TSource, TKey>, FunctionWrapper<TSource, TElement>>(new FunctionWrapper<TSource, TKey>(keySelector), new FunctionWrapper<TSource, TElement>(elementSelector), comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement, TKeySelector, TElementSelector>(TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TSource, TKey>
                where TElementSelector : struct, IFunction<TSource, TElement>
                => source.AsReadOnlySpan().ToDictionaryAt<TSource, TKey, TElement, TKeySelector, TElementSelector, TPredicate>(keySelector, elementSelector, comparer, predicate);
            
            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TPredicate>(this ArraySegmentWhereAtEnumerable<int, TPredicate> source)
            where TPredicate : struct, IFunction<int, int, bool>
            => source.source.AsReadOnlySpan().SumAt<int, int, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TPredicate>(this ArraySegmentWhereAtEnumerable<int?, TPredicate> source)
            where TPredicate : struct, IFunction<int?, int, bool>
            => source.source.AsReadOnlySpan().SumAt<int?, int, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TPredicate>(this ArraySegmentWhereAtEnumerable<nint, TPredicate> source)
            where TPredicate : struct, IFunction<nint, int, bool>
            => source.source.AsReadOnlySpan().SumAt<nint, nint, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TPredicate>(this ArraySegmentWhereAtEnumerable<nint?, TPredicate> source)
            where TPredicate : struct, IFunction<nint?, int, bool>
            => source.source.AsReadOnlySpan().SumAt<nint?, nint, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TPredicate>(this ArraySegmentWhereAtEnumerable<nuint, TPredicate> source)
            where TPredicate : struct, IFunction<nuint, int, bool>
            => source.source.AsReadOnlySpan().SumAt<nuint, nuint, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TPredicate>(this ArraySegmentWhereAtEnumerable<nuint?, TPredicate> source)
            where TPredicate : struct, IFunction<nuint?, int, bool>
            => source.source.AsReadOnlySpan().SumAt<nuint?, nuint, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TPredicate>(this ArraySegmentWhereAtEnumerable<long, TPredicate> source)
            where TPredicate : struct, IFunction<long, int, bool>
            => source.source.AsReadOnlySpan().SumAt<long, long, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TPredicate>(this ArraySegmentWhereAtEnumerable<long?, TPredicate> source)
            where TPredicate : struct, IFunction<long?, int, bool>
            => source.source.AsReadOnlySpan().SumAt<long?, long, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TPredicate>(this ArraySegmentWhereAtEnumerable<float, TPredicate> source)
            where TPredicate : struct, IFunction<float, int, bool>
            => source.source.AsReadOnlySpan().SumAt<float, float, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TPredicate>(this ArraySegmentWhereAtEnumerable<float?, TPredicate> source)
            where TPredicate : struct, IFunction<float?, int, bool>
            => source.source.AsReadOnlySpan().SumAt<float?, float, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TPredicate>(this ArraySegmentWhereAtEnumerable<double, TPredicate> source)
            where TPredicate : struct, IFunction<double, int, bool>
            => source.source.AsReadOnlySpan().SumAt<double, double, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TPredicate>(this ArraySegmentWhereAtEnumerable<double?, TPredicate> source)
            where TPredicate : struct, IFunction<double?, int, bool>
            => source.source.AsReadOnlySpan().SumAt<double?, double, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TPredicate>(this ArraySegmentWhereAtEnumerable<decimal, TPredicate> source)
            where TPredicate : struct, IFunction<decimal, int, bool>
            => source.source.AsReadOnlySpan().SumAt<decimal, decimal, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TPredicate>(this ArraySegmentWhereAtEnumerable<decimal?, TPredicate> source)
            where TPredicate : struct, IFunction<decimal?, int, bool>
            => source.source.AsReadOnlySpan().SumAt<decimal?, decimal, TPredicate>(source.predicate);
    }
}

