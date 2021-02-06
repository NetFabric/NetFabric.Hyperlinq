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

            public readonly Enumerator GetEnumerator()
                => new (in this);

            [StructLayout(LayoutKind.Sequential)]
            public ref struct Enumerator
            {
                int index;
                readonly int end;
                readonly ReadOnlySpan<TSource> source;
                TPredicate predicate;

                internal Enumerator(in ReadOnlySpanWhereRefEnumerable<TSource, TPredicate> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    index = -1;
                    end = index + source.Length;
                }

                public readonly ref readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => ref source[index];
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    while (++index <= end)
                    {
                        if (predicate.Invoke(source[index]))
                            return true;
                    }
                    return false;
                }
            }
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
            => source.source.SumRef<int, int, TPredicate, AddInt32>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TPredicate>(this ReadOnlySpanWhereRefEnumerable<int?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<int?, bool>
            => source.source.SumRef<int?, int, TPredicate, AddNullableInt32>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TPredicate>(this ReadOnlySpanWhereRefEnumerable<long, TPredicate> source)
            where TPredicate : struct, IFunctionIn<long, bool>
            => source.source.SumRef<long, long, TPredicate, AddInt64>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TPredicate>(this ReadOnlySpanWhereRefEnumerable<long?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<long?, bool>
            => source.source.SumRef<long?, long, TPredicate, AddNullableInt64>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TPredicate>(this ReadOnlySpanWhereRefEnumerable<float, TPredicate> source)
            where TPredicate : struct, IFunctionIn<float, bool>
            => source.source.SumRef<float, float, TPredicate, AddSingle>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TPredicate>(this ReadOnlySpanWhereRefEnumerable<float?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<float?, bool>
            => source.source.SumRef<float?, float, TPredicate, AddNullableSingle>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TPredicate>(this ReadOnlySpanWhereRefEnumerable<double, TPredicate> source)
            where TPredicate : struct, IFunctionIn<double, bool>
            => source.source.SumRef<double, double, TPredicate, AddDouble>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TPredicate>(this ReadOnlySpanWhereRefEnumerable<double?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<double?, bool>
            => source.source.SumRef<double?, double, TPredicate, AddNullableDouble>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TPredicate>(this ReadOnlySpanWhereRefEnumerable<decimal, TPredicate> source)
            where TPredicate : struct, IFunctionIn<decimal, bool>
            => source.source.SumRef<decimal, decimal, TPredicate, AddDecimal>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TPredicate>(this ReadOnlySpanWhereRefEnumerable<decimal?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<decimal?, bool>
            => source.source.SumRef<decimal?, decimal, TPredicate, AddNullableDecimal>(source.predicate);
    }
}

