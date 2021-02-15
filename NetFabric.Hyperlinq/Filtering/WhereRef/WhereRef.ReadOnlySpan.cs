using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [GeneratorMapping("TPredicate", "NetFabric.Hyperlinq.FunctionInWrapper<TSource, bool>")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpanWhereRefEnumerable<TSource, FunctionInWrapper<TSource, bool>> Where<TSource>(this ReadOnlySpan<TSource> source, FunctionIn<TSource, bool> predicate)
            => source.WhereRef(new FunctionInWrapper<TSource, bool>(predicate));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpanWhereRefEnumerable<TSource, TPredicate> WhereRef<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            => new(source, predicate);

        [GeneratorIgnore]
        [StructLayout(LayoutKind.Auto)]
        public readonly ref struct ReadOnlySpanWhereRefEnumerable<TSource, TPredicate>
            where TPredicate : struct, IFunctionIn<TSource, bool>
        {
            internal readonly ReadOnlySpan<TSource> source;
            internal readonly TPredicate predicate;

            internal ReadOnlySpanWhereRefEnumerable(ReadOnlySpan<TSource> source, TPredicate predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            public readonly WhereReadOnlyRefEnumerator<TSource, TPredicate> GetEnumerator()
                => new(source, predicate);

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
        public static int Sum<TPredicate>(this ReadOnlySpanWhereRefEnumerable<int, TPredicate> source)
            where TPredicate : struct, IFunctionIn<int, bool>
            => source.source.SumRef<int, int, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TPredicate>(this ReadOnlySpanWhereRefEnumerable<int?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<int?, bool>
            => source.source.SumRef<int?, int, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TPredicate>(this ReadOnlySpanWhereRefEnumerable<long, TPredicate> source)
            where TPredicate : struct, IFunctionIn<long, bool>
            => source.source.SumRef<long, long, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TPredicate>(this ReadOnlySpanWhereRefEnumerable<long?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<long?, bool>
            => source.source.SumRef<long?, long, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TPredicate>(this ReadOnlySpanWhereRefEnumerable<float, TPredicate> source)
            where TPredicate : struct, IFunctionIn<float, bool>
            => source.source.SumRef<float, float, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TPredicate>(this ReadOnlySpanWhereRefEnumerable<float?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<float?, bool>
            => source.source.SumRef<float?, float, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TPredicate>(this ReadOnlySpanWhereRefEnumerable<double, TPredicate> source)
            where TPredicate : struct, IFunctionIn<double, bool>
            => source.source.SumRef<double, double, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TPredicate>(this ReadOnlySpanWhereRefEnumerable<double?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<double?, bool>
            => source.source.SumRef<double?, double, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TPredicate>(this ReadOnlySpanWhereRefEnumerable<decimal, TPredicate> source)
            where TPredicate : struct, IFunctionIn<decimal, bool>
            => source.source.SumRef<decimal, decimal, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TPredicate>(this ReadOnlySpanWhereRefEnumerable<decimal?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<decimal?, bool>
            => source.source.SumRef<decimal?, decimal, TPredicate>(source.predicate);
    }
}

