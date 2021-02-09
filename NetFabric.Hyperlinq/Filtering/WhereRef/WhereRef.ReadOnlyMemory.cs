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
        internal static ReadOnlyMemoryWhereRefEnumerable<TSource, FunctionInWrapper<TSource, bool>> Where<TSource>(this ReadOnlyMemory<TSource> source, FunctionIn<TSource, bool> predicate)
            => source.WhereRef(new FunctionInWrapper<TSource, bool>(predicate));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ReadOnlyMemoryWhereRefEnumerable<TSource, TPredicate> WhereRef<TSource, TPredicate>(this ReadOnlyMemory<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            => new(source, predicate);

        [GeneratorIgnore]
        [StructLayout(LayoutKind.Auto)]
        public readonly struct ReadOnlyMemoryWhereRefEnumerable<TSource, TPredicate>
            where TPredicate : struct, IFunctionIn<TSource, bool>
        {
            internal readonly ReadOnlyMemory<TSource> source;
            internal readonly TPredicate predicate;

            internal ReadOnlyMemoryWhereRefEnumerable(ReadOnlyMemory<TSource> source, TPredicate predicate)
                => (this.source, this.predicate) = (source, predicate);

            public readonly Enumerator GetEnumerator() 
                => new(in this);

            [StructLayout(LayoutKind.Sequential)]
            public ref struct Enumerator 
            {
                int index;
                readonly int end;
                readonly ReadOnlySpan<TSource> source;
                TPredicate predicate;

                internal Enumerator(in ReadOnlyMemoryWhereRefEnumerable<TSource, TPredicate> enumerable)
                {
                    source = enumerable.source.Span;
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
        public static int Sum<TPredicate>(this ReadOnlyMemoryWhereRefEnumerable<int, TPredicate> source)
            where TPredicate : struct, IFunctionIn<int, bool>
            => source.source.Span.SumRef<int, int, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TPredicate>(this ReadOnlyMemoryWhereRefEnumerable<int?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<int?, bool>
            => source.source.Span.SumRef<int?, int, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TPredicate>(this ReadOnlyMemoryWhereRefEnumerable<long, TPredicate> source)
            where TPredicate : struct, IFunctionIn<long, bool>
            => source.source.Span.SumRef<long, long, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TPredicate>(this ReadOnlyMemoryWhereRefEnumerable<long?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<long?, bool>
            => source.source.Span.SumRef<long?, long, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TPredicate>(this ReadOnlyMemoryWhereRefEnumerable<float, TPredicate> source)
            where TPredicate : struct, IFunctionIn<float, bool>
            => source.source.Span.SumRef<float, float, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TPredicate>(this ReadOnlyMemoryWhereRefEnumerable<float?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<float?, bool>
            => source.source.Span.SumRef<float?, float, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TPredicate>(this ReadOnlyMemoryWhereRefEnumerable<double, TPredicate> source)
            where TPredicate : struct, IFunctionIn<double, bool>
            => source.source.Span.SumRef<double, double, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TPredicate>(this ReadOnlyMemoryWhereRefEnumerable<double?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<double?, bool>
            => source.source.Span.SumRef<double?, double, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TPredicate>(this ReadOnlyMemoryWhereRefEnumerable<decimal, TPredicate> source)
            where TPredicate : struct, IFunctionIn<decimal, bool>
            => source.source.Span.SumRef<decimal, decimal, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TPredicate>(this ReadOnlyMemoryWhereRefEnumerable<decimal?, TPredicate> source)
            where TPredicate : struct, IFunctionIn<decimal?, bool>
            => source.source.Span.SumRef<decimal?, decimal, TPredicate>(source.predicate);
    }
}

