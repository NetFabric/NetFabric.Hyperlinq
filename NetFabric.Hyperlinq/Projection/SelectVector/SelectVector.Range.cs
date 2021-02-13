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
#if NET5_0

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static RangeSelectVectorEnumerable<TResult, FunctionWrapper<Vector<int>, Vector<TResult>>, FunctionWrapper<int, TResult>> SelectVector<TResult, TVectorSelector, TSelector>(int start, int count, Func<Vector<int>, Vector<TResult>> vectorSelector, Func<int, TResult> selector)
            where TVectorSelector : struct, IFunction<Vector<int>, Vector<TResult>>
            where TSelector : struct, IFunction<int, TResult>
            where TResult : struct
            => SelectVector<TResult, FunctionWrapper<Vector<int>, Vector<TResult>>, FunctionWrapper<int, TResult>>(start, count, new FunctionWrapper<Vector<int>, Vector<TResult>>(vectorSelector), new FunctionWrapper<int, TResult>(selector));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static RangeSelectVectorEnumerable<TResult, TSelector, TSelector> SelectVector<TResult, TSelector>(int start, int count, TSelector selector = default)
            where TSelector : struct, IFunction<Vector<int>, Vector<TResult>>, IFunction<int, TResult>
            where TResult : struct
            => SelectVector<TResult, TSelector, TSelector>(start, count, selector, selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static RangeSelectVectorEnumerable<TResult, TVectorSelector, TSelector> SelectVector<TResult, TVectorSelector, TSelector>(int start, int count, TVectorSelector vectorSelector = default, TSelector selector = default)
            where TVectorSelector : struct, IFunction<Vector<int>, Vector<TResult>>
            where TSelector : struct, IFunction<int, TResult>
            where TResult : struct
            => new(start, count, vectorSelector, selector);

        [GeneratorIgnore]
        // [GeneratorMapping("TSource", "TResult")]
        [StructLayout(LayoutKind.Auto)]
        public partial struct RangeSelectVectorEnumerable<TResult, TVectorSelector, TSelector>
            : IValueReadOnlyList<TResult, RangeSelectVectorEnumerable<TResult, TVectorSelector, TSelector>.DisposableEnumerator>
            , IList<TResult>
            where TVectorSelector : struct, IFunction<Vector<int>, Vector<TResult>>
            where TSelector : struct, IFunction<int, TResult>
            where TResult : struct
        {
            internal readonly int start;
            internal readonly int count;
            internal TVectorSelector vectorSelector;
            internal TSelector selector;

            internal RangeSelectVectorEnumerable(int start, int count, TVectorSelector vectorSelector, TSelector selector)
            {
                if (Vector<int>.Count != Vector<TResult>.Count)
                    Throw.NotSupportedException();

                this.start = start;
                this.count = count;
                this.vectorSelector = vectorSelector;
                this.selector = selector;
            }

            public readonly int Count
                => count;

            public readonly TResult this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    if (index < 0 || index >= count) Throw.IndexOutOfRangeException();

                    return selector.Invoke(start + index);
                }
            }
            TResult IReadOnlyList<TResult>.this[int index]
                => this[index];
            TResult IList<TResult>.this[int index]
            {
                get => this[index];
                
                // ReSharper disable once ValueParameterNotUsed
                set => Throw.NotSupportedException();
            }

            public readonly Enumerator GetEnumerator()
                => new (in this);
            readonly DisposableEnumerator IValueEnumerable<TResult, DisposableEnumerator>.GetEnumerator()
                => new(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(in this);


            bool ICollection<TResult>.IsReadOnly
                => true;

            public void CopyTo(Span<TResult> span)
            {
                if (span.Length < count)
                    Throw.ArgumentException(Resource.DestinationNotLongEnough, nameof(span));

                ArrayExtensions.CopyRange(start, count, span, vectorSelector, selector);
            }

            void ICollection<TResult>.CopyTo(TResult[] array, int arrayIndex)
                => CopyTo(array.AsSpan().Slice(arrayIndex));

            void ICollection<TResult>.Add(TResult item)
                => Throw.NotSupportedException();
            void ICollection<TResult>.Clear()
                => Throw.NotSupportedException();
            
            public unsafe bool Contains(TResult item)
            {
                if (count is 0)
                    return false;

                var end = start + count;
                var index = 0;

                var vectorSize = Vector<int>.Count;
                if (Vector.IsHardwareAccelerated && count >= vectorSize)
                {
                    Span<int> seed = stackalloc int[vectorSize]; 
                    if (start is 0)
                    {
                        for (; index < seed.Length; index++)
                            seed[index] = index;
                    }
                    else
                    {
                        for (; index < seed.Length; index++)
                            seed[index] = index + start;
                    }

                    var vector = new Vector<int>(seed);
                    var vectorItem = new Vector<TResult>(item);
                    if (Vector.EqualsAny(vectorSelector.Invoke(vector), vectorItem))
                        return true;

                    var vectorIncrement = new Vector<int>(vectorSize);
                    vector = vector + vectorIncrement;
                    for (; index < end - vectorSize; index += vectorSize)
                    {
                        if (Vector.EqualsAny(vectorSelector.Invoke(vector), vectorItem))
                            return true;

                        vector = vector + vectorIncrement;
                    }
                }

                for (; index < end; index++)
                {
                    if (GenericsOperator.Equals(selector.Invoke(index), item))
                        return true;
                }

                return false;
            }            
            
            bool ICollection<TResult>.Remove(TResult item)
                => Throw.NotSupportedException<bool>();
            int IList<TResult>.IndexOf(TResult item)
            {
                var end = start + count;
                for (var value = start; value < end; value++)
                {
                    if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(value), item))
                        return value - start;
                }
                return -1;
            }
            
            void IList<TResult>.Insert(int index, TResult item)
                => Throw.NotSupportedException();
            void IList<TResult>.RemoveAt(int index)
                => Throw.NotSupportedException();

            [StructLayout(LayoutKind.Sequential)]
            public struct Enumerator
            {
                int value;
                readonly int end;
                TSelector selector;

                internal Enumerator(in RangeSelectVectorEnumerable<TResult, TVectorSelector, TSelector> enumerable)
                {
                    selector = enumerable.selector;
                    value = enumerable.start - 1;
                    end = value + enumerable.count;
                }

                public readonly TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector.Invoke(value);
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                    => ++value <= end;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct DisposableEnumerator
                : IEnumerator<TResult>
            {
                int value;
                readonly int end;
                TSelector selector;

                internal DisposableEnumerator(in RangeSelectVectorEnumerable<TResult, TVectorSelector, TSelector> enumerable)
                {
                    selector = enumerable.selector;
                    value = enumerable.start - 1;
                    end = value + enumerable.count;
                }

                public readonly TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector.Invoke(value);
                }
                readonly TResult IEnumerator<TResult>.Current
                    => selector.Invoke(value);
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => selector.Invoke(value);

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                    => ++value <= end;

                [ExcludeFromCodeCoverage]
                public readonly void Reset()
                    => Throw.NotSupportedException();

                public void Dispose() { }
            }

            #region Aggregation

            #endregion
            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => count is not 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TResult value, IEqualityComparer<TResult>? comparer)
                => comparer switch 
                {
                    null => Contains(value),
                    _ => ReadOnlyListExtensions.Contains(this, value, comparer)
                };

            #endregion
            #region Filtering

            #endregion
            #region Projection

            #endregion
            #region Element

            #endregion
            #region Conversion

            public TResult[] ToArray()
            {
#if NET5_0
                var result = GC.AllocateUninitializedArray<TResult>(count);
#else
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                var result = new TResult[count];
#endif
                ArrayExtensions.CopyRange<TResult, TVectorSelector, TSelector>(start, count, result.AsSpan(), vectorSelector, selector);
                return result;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public IMemoryOwner<TResult> ToArray(MemoryPool<TResult> pool)
            {
                var result = pool.RentSliced(count);
                ArrayExtensions.CopyRange<TResult, TVectorSelector, TSelector>(start, count, result.Memory.Span, vectorSelector, selector);
                return result;
            }

            public List<TResult> ToList()
                => count switch
                {
                    0 => new List<TResult>(),
                    _ => ToArray().AsList()
                };

            #endregion

            public bool SequenceEqual(IEnumerable<TResult> other, IEqualityComparer<TResult>? comparer = null)
            {
                comparer ??= EqualityComparer<TResult>.Default;

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

                    if (!comparer.Equals(enumerator.Current!, otherEnumerator.Current))
                        return false;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TResult, TVectorSelector, TSelector>(this RangeSelectVectorEnumerable<TResult, TVectorSelector, TSelector> source)
            where TVectorSelector : struct, IFunction<Vector<int>, Vector<TResult>>
            where TSelector : struct, IFunction<int, TResult>
            where TResult : struct
            => source.Count;

        // [MethodImpl(MethodImplOptions.AggressiveInlining)]
        // public static int Sum<int, TVectorSelector, TSelector>(this RangeSelectVectorEnumerable<int, TVectorSelector, TSelector> source)
        //     where TVectorSelector : struct, IFunction<Vector<int>, Vector<int>>
        //     where TSelector : struct, IFunction<int, int>
        //     where TResult : struct
        //     => source.source.Sum<int, int, TVectorSelector, TSelector>(source.vectorSelector, source.selector);
        //
        // [MethodImpl(MethodImplOptions.AggressiveInlining)]
        // public static long Sum<long, TVectorSelector, TSelector>(this RangeSelectVectorEnumerable<long, TVectorSelector, TSelector> source)
        //     where TVectorSelector : struct, IFunction<Vector<int>, Vector<long>>
        //     where TSelector : struct, IFunction<int, long>
        //     where TResult : struct
        //     => source.source.Sum<int, long, TVectorSelector, TSelector>(source.vectorSelector, source.selector);
        //
        // [MethodImpl(MethodImplOptions.AggressiveInlining)]
        // public static float Sum<float, TVectorSelector, TSelector>(this RangeSelectVectorEnumerable<float, TVectorSelector, TSelector> source)
        //     where TVectorSelector : struct, IFunction<Vector<int>, Vector<float>>
        //     where TSelector : struct, IFunction<int, float>
        //     where TResult : struct
        //     => source.source.Sum<int, float, TVectorSelector, TSelector>(source.vectorSelector, source.selector);
        //
        // [MethodImpl(MethodImplOptions.AggressiveInlining)]
        // public static double Sum<double, TVectorSelector, TSelector>(this RangeSelectVectorEnumerable<double, TVectorSelector, TSelector> source)
        //     where TVectorSelector : struct, IFunction<Vector<int>, Vector<double>>
        //     where TSelector : struct, IFunction<int, double>
        //     where TResult : struct
        //     => source.source.Sum<int, double, TVectorSelector, TSelector>(source.vectorSelector, source.selector);
        //
        // [MethodImpl(MethodImplOptions.AggressiveInlining)]
        // public static decimal Sum<decimal, TVectorSelector, TSelector>(this RangeSelectVectorEnumerable<decimal, TVectorSelector, TSelector> source)
        //     where TVectorSelector : struct, IFunction<Vector<int>, Vector<decimal>>
        //     where TSelector : struct, IFunction<int, decimal>
        //     where TResult : struct
        //     => source.source.Sum<int, decimal, TVectorSelector, TSelector>(source.vectorSelector, source.selector);
#endif
    }
}

