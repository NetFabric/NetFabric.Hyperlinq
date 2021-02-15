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
#if NET5_0

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentSelectVectorEnumerable<TSource, TResult, FunctionWrapper<Vector<TSource>, Vector<TResult>>, FunctionWrapper<TSource, TResult>> SelectVector<TSource, TResult>(this ArraySegment<TSource> source, Func<Vector<TSource>, Vector<TResult>> vectorSelector, Func<TSource, TResult> selector)
            where TSource : struct
            where TResult : struct
            => source.SelectVector<TSource, TResult, FunctionWrapper<Vector<TSource>, Vector<TResult>>, FunctionWrapper<TSource, TResult>>(new FunctionWrapper<Vector<TSource>, Vector<TResult>>(vectorSelector), new FunctionWrapper<TSource, TResult>(selector));

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentSelectVectorEnumerable<TSource, TResult, TSelector, TSelector> SelectVector<TSource, TResult, TSelector>(this ArraySegment<TSource> source, TSelector selector = default)
            where TSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
            => source.SelectVector<TSource, TResult, TSelector, TSelector>(selector, selector);

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentSelectVectorEnumerable<TSource, TResult, TVectorSelector, TSelector> SelectVector<TSource, TResult, TVectorSelector, TSelector>(this ArraySegment<TSource> source, TVectorSelector vectorSelector = default, TSelector selector = default)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>
            where TSelector : struct, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
            => new(source, vectorSelector, selector);

        [GeneratorIgnore]
        // [GeneratorMapping("TSource", "TResult")]
        [StructLayout(LayoutKind.Auto)]
        public partial struct ArraySegmentSelectVectorEnumerable<TSource, TResult, TVectorSelector, TSelector>
            : IValueReadOnlyList<TResult, ArraySegmentSelectVectorEnumerable<TSource, TResult, TVectorSelector, TSelector>.Enumerator>
            , IList<TResult>
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>
            where TSelector : struct, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
        {
            internal readonly ArraySegment<TSource> source;
            internal TVectorSelector vectorSelector;
            internal TSelector selector;

            internal ArraySegmentSelectVectorEnumerable(ArraySegment<TSource> source, TVectorSelector vectorSelector, TSelector selector)
            {
                if (Vector<TSource>.Count != Vector<TResult>.Count)
                    Throw.NotSupportedException();

                this.source = source;
                this.vectorSelector = vectorSelector;
                this.selector = selector;
            }

            public readonly int Count
                => source.Count;

            public TResult this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    if (index < 0 || index >= source.Count) Throw.IndexOutOfRangeException();

                    return selector.Invoke(source.Array![index + source.Offset]);
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

            public readonly SelectVectorEnumerator<TSource, TResult, TSelector> GetEnumerator()
                => new(source.AsSpan(), selector);
            readonly Enumerator IValueEnumerable<TResult, Enumerator>.GetEnumerator()
                => new(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);


            bool ICollection<TResult>.IsReadOnly
                => true;

            public void CopyTo(Span<TResult> span)
            {
                if (span.Length < source.Count)
                    Throw.ArgumentException(Resource.DestinationNotLongEnough, nameof(span));

                ArrayExtensions.CopyVector<TSource, TResult, TVectorSelector, TSelector>(source.AsSpan(), span, vectorSelector, selector);
            }

            void ICollection<TResult>.CopyTo(TResult[] array, int arrayIndex)
                => CopyTo(array.AsSpan().Slice(arrayIndex));

            void ICollection<TResult>.Add(TResult item)
                => Throw.NotSupportedException();
            void ICollection<TResult>.Clear()
                => Throw.NotSupportedException();

            public bool Contains(TResult item)
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ContainsVector(item, vectorSelector, selector);
            
            bool ICollection<TResult>.Remove(TResult item)
                => Throw.NotSupportedException<bool>();
            int IList<TResult>.IndexOf(TResult item)
            {
                var span = source.AsSpan();
                if (Utils.IsValueType<TResult>())
                {
                    for (var index = 0; index < span.Length; index++)
                    {
                        if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(span[index]), item))
                            return index;
                    }
                }
                else
                {
                    var defaultComparer = EqualityComparer<TResult>.Default;
                    for (var index = 0; index < span.Length; index++)
                    {
                        if (defaultComparer.Equals(selector.Invoke(span[index]), item))
                            return index;
                    }
                }
                return -1;
            }
            
            void IList<TResult>.Insert(int index, TResult item)
                => Throw.NotSupportedException();
            void IList<TResult>.RemoveAt(int index)
                => Throw.NotSupportedException();

            [StructLayout(LayoutKind.Sequential)]
            public struct Enumerator
                : IEnumerator<TResult>
            {
                int index;
                readonly int end;
                readonly TSource[]? source;
                TSelector selector;

                internal Enumerator(in ArraySegmentSelectVectorEnumerable<TSource, TResult, TVectorSelector, TSelector> enumerable)
                {
                    source = enumerable.source.Array;
                    selector = enumerable.selector;
                    index = enumerable.source.Offset - 1;
                    end = index + enumerable.source.Count;
                }

                public TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector.Invoke(source![index]);
                }
                TResult IEnumerator<TResult>.Current
                    => selector.Invoke(source![index]);
                object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => selector.Invoke(source![index]);

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                    => ++index <= end;

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
                => source.Count is not 0;

            #endregion
            #region Filtering

            #endregion
            #region Projection

            #endregion
            #region Element

            #endregion
            #region Conversion

            public TResult[] ToArray()
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ToArrayVector<TSource, TResult, TVectorSelector, TSelector>(vectorSelector, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public IMemoryOwner<TResult> ToArray(MemoryPool<TResult> pool)
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ToArrayVector<TSource, TResult, TVectorSelector, TSelector>(vectorSelector, selector, pool);

            public List<TResult> ToList()
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ToListVector<TSource, TResult, TVectorSelector, TSelector>(vectorSelector, selector);

            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource, TResult, TVectorSelector, TSelector>(this ArraySegmentSelectVectorEnumerable<TSource, TResult, TVectorSelector, TSelector> source)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>
            where TSelector : struct, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
            => source.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource, TVectorSelector, TSelector>(this ArraySegmentSelectVectorEnumerable<TSource, int, TVectorSelector, TSelector> source)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<int>>
            where TSelector : struct, IFunction<TSource, int>
            where TSource : struct
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).Sum<TSource, int, TVectorSelector, TSelector>(source.vectorSelector, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TVectorSelector, TSelector>(this ArraySegmentSelectVectorEnumerable<TSource, long, TVectorSelector, TSelector> source)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<long>>
            where TSelector : struct, IFunction<TSource, long>
            where TSource : struct
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).Sum<TSource, long, TVectorSelector, TSelector>(source.vectorSelector, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TVectorSelector, TSelector>(this ArraySegmentSelectVectorEnumerable<TSource, float, TVectorSelector, TSelector> source)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<float>>
            where TSelector : struct, IFunction<TSource, float>
            where TSource : struct
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).Sum<TSource, float, TVectorSelector, TSelector>(source.vectorSelector, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TVectorSelector, TSelector>(this ArraySegmentSelectVectorEnumerable<TSource, double, TVectorSelector, TSelector> source)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<double>>
            where TSelector : struct, IFunction<TSource, double>
            where TSource : struct
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).Sum<TSource, double, TVectorSelector, TSelector>(source.vectorSelector, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TVectorSelector, TSelector>(this ArraySegmentSelectVectorEnumerable<TSource, decimal, TVectorSelector, TSelector> source)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<decimal>>
            where TSelector : struct, IFunction<TSource, decimal>
            where TSource : struct
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).Sum<TSource, decimal, TVectorSelector, TSelector>(source.vectorSelector, source.selector);

#endif    
    }
}

