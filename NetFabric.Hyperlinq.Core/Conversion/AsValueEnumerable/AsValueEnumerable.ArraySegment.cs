using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentValueEnumerable<TSource> AsValueEnumerable<TSource>(this ArraySegment<TSource> source)
            => new(source);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ArraySegmentValueEnumerable<TSource>
            : IValueReadOnlyList<TSource, ArraySegmentValueEnumerable<TSource>.DisposableEnumerator>
            , IList<TSource>
        {
            internal readonly ArraySegment<TSource> source;

            internal ArraySegmentValueEnumerable(ArraySegment<TSource> source)
                => this.source = source;

            public int Count
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source.Count;
            }

            public TSource this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    ThrowIfArgument.OutOfRange(index, Count, nameof(index));
                    return source.Array![source.Offset + index];
                }
            }

            TSource IList<TSource>.this[int index]
            {
                get => this[index];

                [ExcludeFromCodeCoverage]
                // ReSharper disable once ValueParameterNotUsed
                set => Throw.NotSupportedException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SpanEnumerator<TSource> GetEnumerator()
                => new(source);

            DisposableEnumerator IValueEnumerable<TSource, DisposableEnumerator>.GetEnumerator()
                => new(source);

            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(source);

            IEnumerator IEnumerable.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(source);


            bool ICollection<TSource>.IsReadOnly
                => true;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void CopyTo(Span<TSource> span)
                => source.AsReadOnlySpan().CopyTo(span);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void CopyTo(TSource[] array, int arrayIndex)
                => ((ICollection<TSource>)source).CopyTo(array, arrayIndex);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource item)
                => ((ICollection<TSource>)source).Contains(item);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int IndexOf(TSource item)
                => ((IList<TSource>)source).IndexOf(item);

            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Add(TSource item)
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            bool ICollection<TSource>.Remove(TSource item)
                => Throw.NotSupportedException<bool>();
            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Clear()
                => Throw.NotSupportedException();

            [ExcludeFromCodeCoverage]
            void IList<TSource>.Insert(int index, TSource item)
                => Throw.NotSupportedException();

            [ExcludeFromCodeCoverage]
            void IList<TSource>.RemoveAt(int index)
                => Throw.NotSupportedException();

            [StructLayout(LayoutKind.Auto)]
            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                readonly ArraySegment<TSource> source;
                int index;

                internal DisposableEnumerator(ArraySegment<TSource> source)
                {
                    this.source = source;
                    index = -1;
                }

                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => source.Array![source.Offset + index];
                }
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => Current;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                    => ++index < source.Count;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                [ExcludeFromCodeCoverage]
                public void Reset()
                    => index = -1;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public readonly void Dispose() { }
            }

            #region Partitioning

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentValueEnumerable<TSource> Skip(int count)
            {
                var (newOffset, newCount) = Utils.Skip(source.Count, count);
                return new ArraySegmentValueEnumerable<TSource>(new ArraySegment<TSource>(source.Array!, source.Offset + newOffset, newCount));
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentValueEnumerable<TSource> Take(int count)
                => new(new ArraySegment<TSource>(source.Array!, source.Offset, Utils.Take(source.Count, count)));

            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this ArraySegmentValueEnumerable<int> source)
            => source.source.AsReadOnlySpan().SumVector<int, int>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this ArraySegmentValueEnumerable<int?> source)
            => source.source.AsReadOnlySpan().Sum<int?, int>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum(this ArraySegmentValueEnumerable<nint> source)
            => source.source.AsReadOnlySpan().SumVector<nint, nint>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum(this ArraySegmentValueEnumerable<nint?> source)
            => source.source.AsReadOnlySpan().Sum<nint?, nint>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum(this ArraySegmentValueEnumerable<nuint> source)
            => source.source.AsReadOnlySpan().SumVector<nuint, nuint>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum(this ArraySegmentValueEnumerable<nuint?> source)
            => source.source.AsReadOnlySpan().Sum<nuint?, nuint>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this ArraySegmentValueEnumerable<long> source)
            => source.source.AsReadOnlySpan().SumVector<long, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this ArraySegmentValueEnumerable<long?> source)
            => source.source.AsReadOnlySpan().Sum<long?, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this ArraySegmentValueEnumerable<float> source)
            => source.source.AsReadOnlySpan().SumVector<float, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this ArraySegmentValueEnumerable<float?> source)
            => source.source.AsReadOnlySpan().Sum<float?, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this ArraySegmentValueEnumerable<double> source)
            => source.source.AsReadOnlySpan().SumVector<double, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this ArraySegmentValueEnumerable<double?> source)
            => source.source.AsReadOnlySpan().Sum<double?, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this ArraySegmentValueEnumerable<decimal> source)
            => source.source.AsReadOnlySpan().Sum<decimal, decimal>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this ArraySegmentValueEnumerable<decimal?> source)
            => source.source.AsReadOnlySpan().Sum<decimal?, decimal>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsVector<TSource>(this ArraySegmentValueEnumerable<TSource> source, TSource value)
            where TSource : struct
            => source.source.AsReadOnlySpan().ContainsVector(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanSelectVectorContext<TSource, TResult, FunctionWrapper<Vector<TSource>, Vector<TResult>>, FunctionWrapper<TSource, TResult>> SelectVector<TSource, TResult>(this ArraySegmentValueEnumerable<TSource> source, Func<Vector<TSource>, Vector<TResult>> vectorSelector, Func<TSource, TResult> selector)
            where TSource : struct
            where TResult : struct
            => source.source.AsReadOnlySpan().SelectVector(vectorSelector, selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanSelectVectorContext<TSource, TResult, TSelector, TSelector> SelectVector<TSource, TResult, TSelector>(this ArraySegmentValueEnumerable<TSource> source, TSelector selector = default)
            where TSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
            => source.source.AsReadOnlySpan().SelectVector<TSource, TResult, TSelector, TSelector>(selector, selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanSelectVectorContext<TSource, TResult, TVectorSelector, TSelector> SelectVector<TSource, TResult, TVectorSelector, TSelector>(this ArraySegmentValueEnumerable<TSource> source, TVectorSelector vectorSelector = default, TSelector selector = default)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>
            where TSelector : struct, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
            => source.source.AsReadOnlySpan().SelectVector<TSource, TResult, TVectorSelector, TSelector>(vectorSelector, selector);
    }
}