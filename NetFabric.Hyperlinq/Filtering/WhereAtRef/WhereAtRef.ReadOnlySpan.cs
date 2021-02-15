using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [GeneratorMapping("TPredicate", "NetFabric.Hyperlinq.FunctionInWrapper<TSource, int, bool>")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpanWhereAtRefEnumerable<TSource, FunctionInWrapper<TSource, int, bool>> Where<TSource>(this ReadOnlySpan<TSource> source, FunctionIn<TSource, int, bool> predicate)
            => source.WhereAtRef(new FunctionInWrapper<TSource, int, bool>(predicate));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpanWhereAtRefEnumerable<TSource, TPredicate> WhereAtRef<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
            => new(source, predicate);

        [GeneratorIgnore]
        [StructLayout(LayoutKind.Auto)]
        public readonly ref struct ReadOnlySpanWhereAtRefEnumerable<TSource, TPredicate>
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
        {
            internal readonly ReadOnlySpan<TSource> source;
            internal readonly TPredicate predicate;

            internal ReadOnlySpanWhereAtRefEnumerable(ReadOnlySpan<TSource> source, TPredicate predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            public readonly WhereAtReadOnlyRefEnumerator<TSource, TPredicate> GetEnumerator() 
                => new (source, predicate);

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
        public static int Sum<TPredicate>(this ReadOnlySpanWhereAtRefEnumerable<int, TPredicate> source)
            where TPredicate : struct, IFunctionIn<int, int, bool>
            => source.source.SumAtRef<int, int, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TPredicate>(this ReadOnlySpanWhereAtRefEnumerable<int?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<int?, int, bool>
            => source.source.SumAtRef<int?, int, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TPredicate>(this ReadOnlySpanWhereAtRefEnumerable<long, TPredicate> source)
            where TPredicate : struct, IFunctionIn<long, int, bool>
            => source.source.SumAtRef<long, long, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TPredicate>(this ReadOnlySpanWhereAtRefEnumerable<long?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<long?, int, bool>
            => source.source.SumAtRef<long?, long, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TPredicate>(this ReadOnlySpanWhereAtRefEnumerable<float, TPredicate> source)
            where TPredicate : struct, IFunctionIn<float, int, bool>
            => source.source.SumAtRef<float, float, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TPredicate>(this ReadOnlySpanWhereAtRefEnumerable<float?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<float?, int, bool>
            => source.source.SumAtRef<float?, float, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TPredicate>(this ReadOnlySpanWhereAtRefEnumerable<double, TPredicate> source)
            where TPredicate : struct, IFunctionIn<double, int, bool>
            => source.source.SumAtRef<double, double, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TPredicate>(this ReadOnlySpanWhereAtRefEnumerable<double?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<double?, int, bool>
            => source.source.SumAtRef<double?, double, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TPredicate>(this ReadOnlySpanWhereAtRefEnumerable<decimal, TPredicate> source)
            where TPredicate : struct, IFunctionIn<decimal, int, bool>
            => source.source.SumAtRef<decimal, decimal, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TPredicate>(this ReadOnlySpanWhereAtRefEnumerable<decimal?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<decimal?, int, bool>
            => source.source.SumAtRef<decimal?, decimal, TPredicate>(source.predicate);
    }
}

