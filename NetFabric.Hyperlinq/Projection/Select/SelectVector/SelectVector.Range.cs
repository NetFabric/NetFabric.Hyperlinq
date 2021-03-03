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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static RangeSelectVectorEnumerable<TResult, FunctionWrapper<Vector<int>, Vector<TResult>>, FunctionWrapper<int, TResult>> SelectVector<TResult>(int start, int count, Func<Vector<int>, Vector<TResult>> vectorSelector, Func<int, TResult> selector)
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

            public TResult this[int index]
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

                var index = 0;

                if (Vector.IsHardwareAccelerated && count > Vector<int>.Count * 2)
                {
                    var seed = stackalloc int[Vector<int>.Count]; 
                    if (start is 0)
                    {
                        for (var seedIndex = 0; seedIndex < Vector<int>.Count; seedIndex++)
                            seed[seedIndex] = seedIndex;
                    }
                    else
                    {
                        for (var seedIndex = 0; seedIndex < Vector<int>.Count; seedIndex++)
                            seed[seedIndex] = seedIndex + start;
                    }

                    var vector = Unsafe.AsRef<Vector<int>>(seed);
                    var vectorItem = new Vector<TResult>(item);
                    if (Vector.EqualsAny(vectorSelector.Invoke(vector), vectorItem))
                        return true;

                    var vectorIncrement = new Vector<int>(Vector<int>.Count);
                    vector += vectorIncrement;
                    for (index = 0; index < count - Vector<int>.Count; index += Vector<int>.Count)
                    {
                        if (Vector.EqualsAny(vectorSelector.Invoke(vector), vectorItem))
                            return true;

                        vector += vectorIncrement;
                    }
                }

                var end = start + count;
                for (var value = index + start; value < end; value++)
                {
                    if (GenericsOperator.Equals(selector.Invoke(value), item))
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

            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator
            {
                TSelector selector;
                readonly int end;
                int value;

                internal Enumerator(in RangeSelectVectorEnumerable<TResult, TVectorSelector, TSelector> enumerable)
                {
                    selector = enumerable.selector;
                    value = enumerable.start - 1;
                    end = value + enumerable.count;
                }

                public TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector.Invoke(value);
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                    => ++value <= end;
            }

            [StructLayout(LayoutKind.Auto)]
            public struct DisposableEnumerator
                : IEnumerator<TResult>
            {
                TSelector selector;
                readonly int end;
                int value;

                internal DisposableEnumerator(in RangeSelectVectorEnumerable<TResult, TVectorSelector, TSelector> enumerable)
                {
                    selector = enumerable.selector;
                    value = enumerable.start - 1;
                    end = value + enumerable.count;
                }

                public TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector.Invoke(value);
                }
                TResult IEnumerator<TResult>.Current
                    => selector.Invoke(value);
                object IEnumerator.Current
                    // ReSharper disable once HeapView.BoxingAllocation
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
                var result = Utils.AllocateUninitializedArray<TResult>(count);
                ArrayExtensions.CopyRange(start, count, result.AsSpan(), vectorSelector, selector);
                return result;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public IMemoryOwner<TResult> ToArray(MemoryPool<TResult> pool)
            {
                var result = pool.RentSliced(count);
                ArrayExtensions.CopyRange(start, count, result.Memory.Span, vectorSelector, selector);
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TVectorSelector, TSelector>(this RangeSelectVectorEnumerable<int, TVectorSelector, TSelector> source)
            where TVectorSelector : struct, IFunction<Vector<int>, Vector<int>>
            where TSelector : struct, IFunction<int, int>
            => SumRange<int, TVectorSelector, TSelector>(source.start, source.count, source.vectorSelector, source.selector);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TVectorSelector, TSelector>(this RangeSelectVectorEnumerable<long, TVectorSelector, TSelector> source)
            where TVectorSelector : struct, IFunction<Vector<int>, Vector<long>>
            where TSelector : struct, IFunction<int, long>
            => SumRange<long, TVectorSelector, TSelector>(source.start, source.count, source.vectorSelector, source.selector);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TVectorSelector, TSelector>(this RangeSelectVectorEnumerable<float, TVectorSelector, TSelector> source)
            where TVectorSelector : struct, IFunction<Vector<int>, Vector<float>>
            where TSelector : struct, IFunction<int, float>
            => SumRange<float, TVectorSelector, TSelector>(source.start, source.count, source.vectorSelector, source.selector);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TVectorSelector, TSelector>(this RangeSelectVectorEnumerable<double, TVectorSelector, TSelector> source)
            where TVectorSelector : struct, IFunction<Vector<int>, Vector<double>>
            where TSelector : struct, IFunction<int, double>
            => SumRange<double, TVectorSelector, TSelector>(source.start, source.count, source.vectorSelector, source.selector);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TVectorSelector, TSelector>(this RangeSelectVectorEnumerable<decimal, TVectorSelector, TSelector> source)
            where TVectorSelector : struct, IFunction<Vector<int>, Vector<decimal>>
            where TSelector : struct, IFunction<int, decimal>
            => SumRange<decimal, TVectorSelector, TSelector>(source.start, source.count, source.vectorSelector, source.selector);
    }
}

