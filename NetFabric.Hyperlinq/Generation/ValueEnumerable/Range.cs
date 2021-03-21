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
    public static partial class ValueEnumerable
    {

        public static RangeEnumerable Range(int start, int count)
        {
            if (count < 0)
                Throw.ArgumentOutOfRangeException(nameof(count));

            var end = 0;
            try
            {
                end = checked(start + count);
            }
            catch (OverflowException)
            {
                Throw.ArgumentOutOfRangeException(nameof(count));
            }

            return new RangeEnumerable(start, end);
        }

        [GeneratorMapping("TSource", "int", true)]
        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct RangeEnumerable
            : IValueReadOnlyCollection<int, RangeEnumerable.DisposableEnumerator>
            , ICollection<int>
        {
            readonly int start;
            readonly int end;

            internal RangeEnumerable(int start, int end)
                => (this.start, this.end) = (start, end); 

            public readonly int Count
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => end - start;
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator()
                => new(in this);
            readonly DisposableEnumerator IValueEnumerable<int, DisposableEnumerator>.GetEnumerator()
                => new(in this);
            readonly IEnumerator<int> IEnumerable<int>.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(in this);

            bool ICollection<int>.IsReadOnly
                => true;

            public void CopyTo(Span<int> span)
            {
                if (span.Length < Count)
                    Throw.ArgumentException(Resource.DestinationNotLongEnough, nameof(span));

                ArrayExtensions.CopyRange(start, Count, span);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void CopyTo(int[] array, int arrayIndex)
                => CopyTo(array.AsSpan().Slice(arrayIndex));


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(int value)
                => value >= start && value < end;

            [ExcludeFromCodeCoverage]
            void ICollection<int>.Add(int item)
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void ICollection<int>.Clear()
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            bool ICollection<int>.Remove(int item)
                => Throw.NotSupportedException<bool>();

            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator
            {
                readonly int end;
                int current;

                internal Enumerator(in RangeEnumerable enumerable)
                {
                    current = enumerable.start - 1;
                    end = current + enumerable.Count;
                }

                public int Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => current;
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                    => ++current <= end;
            }

            [StructLayout(LayoutKind.Auto)]
            public struct DisposableEnumerator
                : IEnumerator<int>
            {
                readonly int end;
                int current;

                internal DisposableEnumerator(in RangeEnumerable enumerable)
                {
                    current = enumerable.start - 1;
                    end = current + enumerable.Count;
                }

                public int Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => current;
                }
                object? IEnumerator.Current
                    // ReSharper disable once HeapView.BoxingAllocation
                    => current;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                    => ++current <= end;

                [ExcludeFromCodeCoverage]
                public readonly void Reset()
                    => Throw.NotSupportedException();

                public readonly void Dispose() { }
            }

            #region Partitioning

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RangeEnumerable Skip(int count)
            {
                var (skipCount, takeCount) = Partition.Skip(Count, count);
                return Range(start + skipCount, takeCount);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RangeEnumerable Take(int count)
                => Range(start, Partition.Take(Count, count));

            #endregion
            #region Aggregation

            public int Sum()
                => SumRange(start, Count);

            #endregion
            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => Count is not 0;

            public bool Contains(int value, IEqualityComparer<int>? comparer)
            {
                if (Count is 0)
                    return false;

                if (comparer is null || ReferenceEquals(comparer, EqualityComparer<int>.Default))
                    return value >= start && value < end;

                for (var item = start; item < end; item++)
                {
                    if (comparer.Equals(item, value))
                        return true;
                }
                return false;
            }

            #endregion
            #region Filtering

            #endregion
            #region Projection

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RangeSelectVectorContext<TResult, FunctionWrapper<Vector<int>, Vector<TResult>>, FunctionWrapper<int, TResult>> SelectVector<TResult>(Func<Vector<int>, Vector<TResult>> vectorSelector, Func<int, TResult> selector)
                where TResult : struct
                => ValueEnumerable.SelectVector(start, Count, vectorSelector, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RangeSelectVectorContext<TResult, TSelector, TSelector> SelectVector<TResult, TSelector>(TSelector selector = default)
                where TSelector : struct, IFunction<Vector<int>, Vector<TResult>>, IFunction<int, TResult>
                where TResult : struct
                => ValueEnumerable.SelectVector<TResult, TSelector, TSelector>(start, Count, selector, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RangeSelectVectorContext<TResult, TVectorSelector, TSelector> SelectVector<TResult, TVectorSelector, TSelector>(TVectorSelector vectorSelector = default, TSelector selector = default)
                where TVectorSelector : struct, IFunction<Vector<int>, Vector<TResult>>
                where TSelector : struct, IFunction<int, TResult>
                where TResult : struct
                => ValueEnumerable.SelectVector<TResult, TVectorSelector, TSelector>(start, Count, vectorSelector, selector);

            #endregion
            #region Element

            #endregion
            #region Conversion

            public int[] ToArray()
            {
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                var array = new int[Count];
                ArrayExtensions.CopyRange(start, Count, array.AsSpan());
                return array;
            }

            public ValueMemoryOwner<int> ToArray(ArrayPool<int> pool, bool clearOnDispose = default)
            {
                var result = pool.RentSliced(Count, clearOnDispose);
                ArrayExtensions.CopyRange(start, Count, result.Memory.Span);
                return result;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<int> ToList()
                => Count switch
                {
                    0 => new List<int>(),
                    _ => ToArray().AsList()
                };

            #endregion
        }
    }
}
