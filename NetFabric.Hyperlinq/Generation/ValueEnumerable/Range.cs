﻿using System;
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

            try
            {
                _ = checked(start + count);
            }
            catch (OverflowException)
            {
                Throw.ArgumentOutOfRangeException(nameof(count));
            }

            return new RangeEnumerable(start, count);
        }

        [GeneratorMapping("TSource", "int", true)]
        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct RangeEnumerable
            : IValueReadOnlyList<int, RangeEnumerable.DisposableEnumerator>
            , IList<int>
        {
            readonly int start;

            internal RangeEnumerable(int start, int count)
                => (this.start, Count) = (start, count); 

            public int this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    ThrowIfArgument.OutOfRange(index, Count, nameof(index));
                    return index + start;
                }
            }

            int IList<int>.this[int index]
            {
                get => this[index];
                [DoesNotReturn]
                // ReSharper disable once ValueParameterNotUsed
                set => Throw.NotSupportedException();
            }

            public int Count { get; }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator GetEnumerator()
                => new(in this);

            DisposableEnumerator IValueEnumerable<int, DisposableEnumerator>.GetEnumerator()
                => new(in this);

            IEnumerator<int> IEnumerable<int>.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(in this);

            IEnumerator IEnumerable.GetEnumerator()
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
                => CopyTo(array.AsSpan(arrayIndex));


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(int value)
                => value >= start && value < start + Count;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int IndexOf(int value)
            {
                if (value < start || value >= start + Count)
                    return -1;
                return value - start;
            }

            [ExcludeFromCodeCoverage]
            void ICollection<int>.Add(int item)
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void ICollection<int>.Clear()
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            bool ICollection<int>.Remove(int item)
                => Throw.NotSupportedException<bool>();
            [ExcludeFromCodeCoverage]
            void IList<int>.Insert(int index, int item)
                => Throw.NotSupportedException<bool>();
            [ExcludeFromCodeCoverage]
            void IList<int>.RemoveAt(int index)
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
                [DoesNotReturn]
                public readonly void Reset()
                    => Throw.NotSupportedException();

                public readonly void Dispose() { }
            }

            #region Partitioning

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RangeEnumerable Skip(int count)
            {
                var (newOffset, newCount) = Utils.Skip(Count, count);
                return Range(start + newOffset, newCount);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RangeEnumerable Take(int count)
                => Range(start, Utils.Take(Count, count));

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

                var end = start + Count;
                
                if (Utils.UseDefault(comparer))
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
