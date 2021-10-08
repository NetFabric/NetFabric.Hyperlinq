using System;
using System.Buffers;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanValueEnumerable<TSource> AsValueEnumerable<TSource>(this ReadOnlySpan<TSource> source)
            => new(source);

        [StructLayout(LayoutKind.Auto)]
        public readonly ref partial struct SpanValueEnumerable<TSource>
        {
            internal readonly ReadOnlySpan<TSource> source;

            internal SpanValueEnumerable(ReadOnlySpan<TSource> source)
                => this.source = source;

            public ReadOnlySpan<TSource> Span
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source;
            }

            public int Count
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source.Length;
            }

            public TSource this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source[index];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SpanEnumerator<TSource> GetEnumerator()
                => new(source);
             
            #region Partitioning

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SpanValueEnumerable<TSource> Skip(int count)
            {
                var (newOffset, newCount) = Utils.Skip(source.Length, count);
                return new SpanValueEnumerable<TSource>(source.Slice(newOffset, newCount));
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SpanValueEnumerable<TSource> Take(int count)
                => new(source.Slice(0, Utils.Take(source.Length, count)));

            #endregion

            public bool SequenceEqual(IEnumerable<TSource> other, IEqualityComparer<TSource>? comparer = null)
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this SpanValueEnumerable<int> source)
            => source.source.SumVector<int, int>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this SpanValueEnumerable<int?> source)
            => source.source.Sum<int?, int>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum(this SpanValueEnumerable<nint> source)
            => source.source.SumVector<nint, nint>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum(this SpanValueEnumerable<nint?> source)
            => source.source.Sum<nint?, nint>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum(this SpanValueEnumerable<nuint> source)
            => source.source.SumVector<nuint, nuint>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum(this SpanValueEnumerable<nuint?> source)
            => source.source.Sum<nuint?, nuint>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this SpanValueEnumerable<long> source)
            => source.source.SumVector<long, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this SpanValueEnumerable<long?> source)
            => source.source.Sum<long?, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this SpanValueEnumerable<float> source)
            => source.source.SumVector<float, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this SpanValueEnumerable<float?> source)
            => source.source.Sum<float?, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this SpanValueEnumerable<double> source)
            => source.source.SumVector<double, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this SpanValueEnumerable<double?> source)
            => source.source.Sum<double?, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this SpanValueEnumerable<decimal> source)
            => source.source.Sum<decimal, decimal>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this SpanValueEnumerable<decimal?> source)
            => source.source.Sum<decimal?, decimal>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsVector<TSource>(this SpanValueEnumerable<TSource> source, TSource value)
            where TSource : struct
            => source.source.ContainsVector(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanSelectVectorContext<TSource, TResult, FunctionWrapper<Vector<TSource>, Vector<TResult>>, FunctionWrapper<TSource, TResult>> SelectVector<TSource, TResult>(this SpanValueEnumerable<TSource> source, Func<Vector<TSource>, Vector<TResult>> vectorSelector, Func<TSource, TResult> selector)
            where TSource : struct
            where TResult : struct
            => source.source.SelectVector(vectorSelector, selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanSelectVectorContext<TSource, TResult, TVectorSelector, TSelector> SelectVector<TSource, TResult, TVectorSelector, TSelector>(this SpanValueEnumerable<TSource> source, TVectorSelector vectorSelector = default, TSelector selector = default)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>
            where TSelector : struct, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
            => source.source.SelectVector<TSource, TResult, TVectorSelector, TSelector>(vectorSelector, selector);
    }
}