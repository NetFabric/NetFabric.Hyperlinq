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
        internal static ReadOnlyMemoryWhereAtRefEnumerable<TSource, FunctionInWrapper<TSource, int, bool>> Where<TSource>(this ReadOnlyMemory<TSource> source, FunctionIn<TSource, int, bool> predicate)
            => source.WhereAtRef(new FunctionInWrapper<TSource, int, bool>(predicate));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ReadOnlyMemoryWhereAtRefEnumerable<TSource, TPredicate> WhereAtRef<TSource, TPredicate>(this ReadOnlyMemory<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
            => new(source, predicate);

        [GeneratorIgnore]
        [StructLayout(LayoutKind.Auto)]
        public readonly struct ReadOnlyMemoryWhereAtRefEnumerable<TSource, TPredicate>
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
        {
            internal readonly ReadOnlyMemory<TSource> source;
            internal readonly TPredicate predicate;

            internal ReadOnlyMemoryWhereAtRefEnumerable(ReadOnlyMemory<TSource> source, TPredicate predicate)
                => (this.source, this.predicate) = (source, predicate);

            public readonly Enumerator GetEnumerator()
                => new (in this);

            [StructLayout(LayoutKind.Sequential)]
            public ref struct Enumerator
            {
                int index;
                readonly int end;
                readonly ReadOnlySpan<TSource> source;
                TPredicate predicate;

                internal Enumerator(in ReadOnlyMemoryWhereAtRefEnumerable<TSource, TPredicate> enumerable)
                {
                    source = enumerable.source.Span;
                    predicate = enumerable.predicate;
                    index = -1;
                    end = index + source.Length;
                }

                public readonly ref readonly TSource Current
                    => ref source[index];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    while (++index <= end)
                    {
                        if (predicate.Invoke(source[index], index))
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
        public static int Sum<TPredicate>(this ReadOnlyMemoryWhereAtRefEnumerable<int, TPredicate> source)
            where TPredicate : struct, IFunctionIn<int, int, bool>
            => source.source.Span.SumAtRef<int, int, TPredicate, AddInt32>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TPredicate>(this ReadOnlyMemoryWhereAtRefEnumerable<int?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<int?, int, bool>
            => source.source.Span.SumAtRef<int?, int, TPredicate, AddNullableInt32>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TPredicate>(this ReadOnlyMemoryWhereAtRefEnumerable<long, TPredicate> source)
            where TPredicate : struct, IFunctionIn<long, int, bool>
            => source.source.Span.SumAtRef<long, long, TPredicate, AddInt64>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TPredicate>(this ReadOnlyMemoryWhereAtRefEnumerable<long?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<long?, int, bool>
            => source.source.Span.SumAtRef<long?, long, TPredicate, AddNullableInt64>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TPredicate>(this ReadOnlyMemoryWhereAtRefEnumerable<float, TPredicate> source)
            where TPredicate : struct, IFunctionIn<float, int, bool>
            => source.source.Span.SumAtRef<float, float, TPredicate, AddSingle>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TPredicate>(this ReadOnlyMemoryWhereAtRefEnumerable<float?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<float?, int, bool>
            => source.source.Span.SumAtRef<float?, float, TPredicate, AddNullableSingle>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TPredicate>(this ReadOnlyMemoryWhereAtRefEnumerable<double, TPredicate> source)
            where TPredicate : struct, IFunctionIn<double, int, bool>
            => source.source.Span.SumAtRef<double, double, TPredicate, AddDouble>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TPredicate>(this ReadOnlyMemoryWhereAtRefEnumerable<double?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<double?, int, bool>
            => source.source.Span.SumAtRef<double?, double, TPredicate, AddNullableDouble>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TPredicate>(this ReadOnlyMemoryWhereAtRefEnumerable<decimal, TPredicate> source)
            where TPredicate : struct, IFunctionIn<decimal, int, bool>
            => source.source.Span.SumAtRef<decimal, decimal, TPredicate, AddDecimal>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TPredicate>(this ReadOnlyMemoryWhereAtRefEnumerable<decimal?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<decimal?, int, bool>
            => source.source.Span.SumAtRef<decimal?, decimal, TPredicate, AddNullableDecimal>(source.predicate);
    }
}
