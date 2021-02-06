﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [GeneratorMapping("TPredicate", "NetFabric.Hyperlinq.FunctionInWrapper<TSource, bool>")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentWhereRefEnumerable<TSource, FunctionInWrapper<TSource, bool>> Where<TSource>(this in ArraySegment<TSource> source, FunctionIn<TSource, bool> predicate)
            => source.WhereRef(new FunctionInWrapper<TSource, bool>(predicate));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentWhereRefEnumerable<TSource, TPredicate> WhereRef<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            => new(source, predicate);

        [GeneratorIgnore]
        [StructLayout(LayoutKind.Auto)]
        public readonly struct ArraySegmentWhereRefEnumerable<TSource, TPredicate>
            : IValueEnumerableRef<TSource, ArraySegmentWhereRefEnumerable<TSource, TPredicate>.Enumerator>
            where TPredicate : struct, IFunctionIn<TSource, bool>
        {
            internal readonly ArraySegment<TSource> source;
            internal readonly TPredicate predicate;

            internal ArraySegmentWhereRefEnumerable(in ArraySegment<TSource> source, TPredicate predicate)
                => (this.source, this.predicate) = (source, predicate);
            
            public readonly Enumerator GetEnumerator()
                => new(in this);

            [StructLayout(LayoutKind.Sequential)]
            public struct Enumerator
                : IEnumeratorRef<TSource>
            {
                int index;
                readonly int end;
                readonly TSource[]? source;
                TPredicate predicate;

                internal Enumerator(in ArraySegmentWhereRefEnumerable<TSource, TPredicate> enumerable)
                {
                    source = enumerable.source.Array;
                    predicate = enumerable.predicate;
                    index = enumerable.source.Offset - 1;
                    end = index + enumerable.source.Count;
                }

                public ref TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => ref source![index];
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    while (++index <= end)
                    {
                        if (predicate.Invoke(in source![index]))
                            return true;
                    }
                    return false;
                }
            }

            #region Aggregation

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count()
                => ((ReadOnlySpan<TSource>)source.AsSpan()).CountRef(predicate);

            #endregion
            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All()
                => ((ReadOnlySpan<TSource>)source.AsSpan()).AllRef(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(FunctionIn<TSource, bool> predicate)
                => All(new FunctionInWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IFunctionIn<TSource, bool>
                => ((ReadOnlySpan<TSource>)source.AsSpan()).AllRef(new PredicatePredicateCombinationIn<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(FunctionIn<TSource, int, bool> predicate)
                => AllAt(new FunctionInWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AllAt<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IFunctionIn<TSource, int, bool>
                => ((ReadOnlySpan<TSource>)source.AsSpan()).AllAtRef(new PredicatePredicateAtCombinationIn<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => ((ReadOnlySpan<TSource>)source.AsSpan()).AnyRef(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(FunctionIn<TSource, bool> predicate)
                => Any(new FunctionInWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IFunctionIn<TSource, bool>
                => ((ReadOnlySpan<TSource>)source.AsSpan()).AnyRef(new PredicatePredicateCombinationIn<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(FunctionIn<TSource, int, bool> predicate)
                => AnyAt(new FunctionInWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AnyAt<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IFunctionIn<TSource, int, bool>
                => ((ReadOnlySpan<TSource>)source.AsSpan()).AnyAtRef(new PredicatePredicateAtCombinationIn<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            #endregion
            #region Filtering

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentWhereRefEnumerable<TSource, PredicatePredicateCombinationIn<TPredicate, FunctionInWrapper<TSource, bool>, TSource>> Where(FunctionIn<TSource, bool> predicate)
                => WhereRef(new FunctionInWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentWhereRefEnumerable<TSource, PredicatePredicateCombinationIn<TPredicate, TPredicate2, TSource>> WhereRef<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunctionIn<TSource, bool>
                => source.WhereRef(new PredicatePredicateCombinationIn<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentWhereAtRefEnumerable<TSource, PredicatePredicateAtCombinationIn<TPredicate, FunctionInWrapper<TSource, int, bool>, TSource>> Where(FunctionIn<TSource, int, bool> predicate)
                => WhereAtRef<FunctionInWrapper<TSource, int, bool>>(new FunctionInWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentWhereAtRefEnumerable<TSource, PredicatePredicateAtCombinationIn<TPredicate, TPredicate2, TSource>> WhereAtRef<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunctionIn<TSource, int, bool>
                => source.WhereAtRef(new PredicatePredicateAtCombinationIn<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            #endregion
            #region Projection

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, FunctionInWrapper<TSource, TResult>> Select<TResult>(FunctionIn<TSource, TResult> selector)
                => Select<TResult, FunctionInWrapper<TSource, TResult>>(new FunctionInWrapper<TSource, TResult>(selector));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector> Select<TResult, TSelector>(TSelector selector = default)
                where TSelector : struct, IFunctionIn<TSource, TResult>
                => source.WhereSelectRef<TSource, TResult, TPredicate, TSelector>(predicate, selector);

            #endregion


            public bool SequenceEqual(IEnumerable<TSource> other, IEqualityComparer<TSource>? comparer = null)
            {
                if (Utils.UseDefault(comparer))
                {
                    var enumerator = GetEnumerator();
                    using var otherEnumerator = other.GetEnumerator();
                    while (true)
                    {
                        var thisEnded = !enumerator.MoveNext();
                        var otherEnded = !otherEnumerator.MoveNext();

                        if (thisEnded != otherEnded)
                            return false;

                        if (thisEnded)
                            return true;

                        if (!EqualityComparer<TSource>.Default.Equals(enumerator.Current, otherEnumerator.Current))
                            return false;
                    }
                }
                else
                {
                    comparer ??= EqualityComparer<TSource>.Default;

                    var enumerator = GetEnumerator();
                    using var otherEnumerator = other.GetEnumerator();
                    while (true)
                    {
                        var thisEnded = !enumerator.MoveNext();
                        var otherEnded = !otherEnumerator.MoveNext();

                        if (thisEnded != otherEnded)
                            return false;

                        if (thisEnded)
                            return true;

                        if (!comparer.Equals(enumerator.Current, otherEnumerator.Current))
                            return false;
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TPredicate>(this ArraySegmentWhereRefEnumerable<int, TPredicate> source)
            where TPredicate : struct, IFunctionIn<int, bool>
            => ((ReadOnlySpan<int>)source.source.AsSpan()).SumRef<int, int, TPredicate, AddInt32>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TPredicate>(this ArraySegmentWhereRefEnumerable<int?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<int?, bool>
            => ((ReadOnlySpan<int?>)source.source.AsSpan()).SumRef<int?, int, TPredicate, AddNullableInt32>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TPredicate>(this ArraySegmentWhereRefEnumerable<long, TPredicate> source)
            where TPredicate : struct, IFunctionIn<long, bool>
            => ((ReadOnlySpan<long>)source.source.AsSpan()).SumRef<long, long, TPredicate, AddInt64>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TPredicate>(this ArraySegmentWhereRefEnumerable<long?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<long?, bool>
            => ((ReadOnlySpan<long?>)source.source.AsSpan()).SumRef<long?, long, TPredicate, AddNullableInt64>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TPredicate>(this ArraySegmentWhereRefEnumerable<float, TPredicate> source)
            where TPredicate : struct, IFunctionIn<float, bool>
            => ((ReadOnlySpan<float>)source.source.AsSpan()).SumRef<float, float, TPredicate, AddSingle>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TPredicate>(this ArraySegmentWhereRefEnumerable<float?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<float?, bool>
            => ((ReadOnlySpan<float?>)source.source.AsSpan()).SumRef<float?, float, TPredicate, AddNullableSingle>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TPredicate>(this ArraySegmentWhereRefEnumerable<double, TPredicate> source)
            where TPredicate : struct, IFunctionIn<double, bool>
            => ((ReadOnlySpan<double>)source.source.AsSpan()).SumRef<double, double, TPredicate, AddDouble>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TPredicate>(this ArraySegmentWhereRefEnumerable<double?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<double?, bool>
            => ((ReadOnlySpan<double?>)source.source.AsSpan()).SumRef<double?, double, TPredicate, AddNullableDouble>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TPredicate>(this ArraySegmentWhereRefEnumerable<decimal, TPredicate> source)
            where TPredicate : struct, IFunctionIn<decimal, bool>
            => ((ReadOnlySpan<decimal>)source.source.AsSpan()).SumRef<decimal, decimal, TPredicate, AddDecimal>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TPredicate>(this ArraySegmentWhereRefEnumerable<decimal?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<decimal?, bool>
            => ((ReadOnlySpan<decimal?>)source.source.AsSpan()).SumRef<decimal?, decimal, TPredicate, AddNullableDecimal>(source.predicate);
    }
}

