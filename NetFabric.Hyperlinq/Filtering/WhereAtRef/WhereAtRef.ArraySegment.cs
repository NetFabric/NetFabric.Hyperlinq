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

        [GeneratorMapping("TPredicate", "NetFabric.Hyperlinq.FunctionInWrapper<TSource, int, bool>")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ArraySegmentWhereAtRefEnumerable<TSource, FunctionInWrapper<TSource, int, bool>> Where<TSource>(this in ArraySegment<TSource> source, FunctionIn<TSource, int, bool> predicate)
            => source.WhereAtRef(new FunctionInWrapper<TSource, int, bool>(predicate));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ArraySegmentWhereAtRefEnumerable<TSource, TPredicate> WhereAtRef<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
            => new(source, predicate);

        [GeneratorIgnore]
        [StructLayout(LayoutKind.Auto)]
        public readonly struct ArraySegmentWhereAtRefEnumerable<TSource, TPredicate>
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
        {
            internal readonly ArraySegment<TSource> source;
            internal readonly TPredicate predicate;

            internal ArraySegmentWhereAtRefEnumerable(in ArraySegment<TSource> source, TPredicate predicate)
                => (this.source, this.predicate) = (source, predicate);

            public readonly WhereAtRefEnumerator<TSource, TPredicate> GetEnumerator()
                => new(source.AsSpan(), predicate);

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
        public static int Sum<TPredicate>(this ArraySegmentWhereAtRefEnumerable<int, TPredicate> source)
            where TPredicate : struct, IFunctionIn<int, int, bool>
            => ((ReadOnlySpan<int>)source.source.AsSpan()).SumAtRef<int, int, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TPredicate>(this ArraySegmentWhereAtRefEnumerable<int?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<int?, int, bool>
            => ((ReadOnlySpan<int?>)source.source.AsSpan()).SumAtRef<int?, int, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TPredicate>(this ArraySegmentWhereAtRefEnumerable<long, TPredicate> source)
            where TPredicate : struct, IFunctionIn<long, int, bool>
            => ((ReadOnlySpan<long>)source.source.AsSpan()).SumAtRef<long, long, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TPredicate>(this ArraySegmentWhereAtRefEnumerable<long?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<long?, int, bool>
            => ((ReadOnlySpan<long?>)source.source.AsSpan()).SumAtRef<long?, long, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TPredicate>(this ArraySegmentWhereAtRefEnumerable<float, TPredicate> source)
            where TPredicate : struct, IFunctionIn<float, int, bool>
            => ((ReadOnlySpan<float>)source.source.AsSpan()).SumAtRef<float, float, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TPredicate>(this ArraySegmentWhereAtRefEnumerable<float?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<float?, int, bool>
            => ((ReadOnlySpan<float?>)source.source.AsSpan()).SumAtRef<float?, float, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TPredicate>(this ArraySegmentWhereAtRefEnumerable<double, TPredicate> source)
            where TPredicate : struct, IFunctionIn<double, int, bool>
            => ((ReadOnlySpan<double>)source.source.AsSpan()).SumAtRef<double, double, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TPredicate>(this ArraySegmentWhereAtRefEnumerable<double?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<double?, int, bool>
            => ((ReadOnlySpan<double?>)source.source.AsSpan()).SumAtRef<double?, double, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TPredicate>(this ArraySegmentWhereAtRefEnumerable<decimal, TPredicate> source)
            where TPredicate : struct, IFunctionIn<decimal, int, bool>
            => ((ReadOnlySpan<decimal>)source.source.AsSpan()).SumAtRef<decimal, decimal, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TPredicate>(this ArraySegmentWhereAtRefEnumerable<decimal?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<decimal?, int, bool>
            => ((ReadOnlySpan<decimal?>)source.source.AsSpan()).SumAtRef<decimal?, decimal, TPredicate>(source.predicate);
    }
}

