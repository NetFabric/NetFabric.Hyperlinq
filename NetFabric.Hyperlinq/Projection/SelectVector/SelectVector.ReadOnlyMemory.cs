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
        public static MemorySelectVectorEnumerable<TSource, TResult, FunctionWrapper<Vector<TSource>, Vector<TResult>>, FunctionWrapper<TSource, TResult>> SelectVector<TSource, TResult>(this ReadOnlyMemory<TSource> source, Func<Vector<TSource>, Vector<TResult>> vectorSelector, Func<TSource, TResult> selector)
            where TSource : struct
            where TResult : struct
            => source.SelectVector<TSource, TResult, FunctionWrapper<Vector<TSource>, Vector<TResult>>, FunctionWrapper<TSource, TResult>>(new FunctionWrapper<Vector<TSource>, Vector<TResult>>(vectorSelector), new FunctionWrapper<TSource, TResult>(selector));

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemorySelectVectorEnumerable<TSource, TResult, TVectorSelector, TSelector> SelectVector<TSource, TResult, TVectorSelector, TSelector>(this ReadOnlyMemory<TSource> source, TVectorSelector vectorSelector = default, TSelector selector = default)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>
            where TSelector : struct, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
            => new(source, vectorSelector, selector);

        [GeneratorIgnore]
        [StructLayout(LayoutKind.Auto)]
        public partial struct MemorySelectVectorEnumerable<TSource, TResult, TVectorSelector, TSelector>
            : IValueEnumerable<TResult, MemorySelectVectorEnumerable<TSource, TResult, TVectorSelector, TSelector>.DisposableEnumerator>
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>
            where TSelector : struct, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
        {
            internal readonly ReadOnlyMemory<TSource> source;
            internal TVectorSelector vectorSelector;
            internal TSelector selector;

            internal MemorySelectVectorEnumerable(ReadOnlyMemory<TSource> source, TVectorSelector vectorSelector, TSelector selector)
            {
                if (Vector<TSource>.Count != Vector<TResult>.Count)
                    Throw.NotSupportedException();

                this.source = source;
                this.vectorSelector = vectorSelector;
                this.selector = selector;
            }

            public readonly SelectVectorEnumerator<TSource, TResult, TVectorSelector, TSelector> GetEnumerator()
                => new(source.Span, vectorSelector, selector);
            readonly DisposableEnumerator IValueEnumerable<TResult, DisposableEnumerator>.GetEnumerator()
                => new(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(in this);

            [StructLayout(LayoutKind.Auto)]
            public struct DisposableEnumerator
                : IEnumerator<TResult>
            {
                readonly int vectorSize;
                TResult current;
                int index;
                int status;
                Vector<TResult> vector;
                ReadOnlyMemory<TSource> source;
                TVectorSelector vectorSelector;
                TSelector selector;

                internal DisposableEnumerator(in MemorySelectVectorEnumerable<TSource, TResult, TVectorSelector, TSelector> enumerable)
                {
                    source = enumerable.source;
                    vectorSelector = enumerable.vectorSelector;
                    selector = enumerable.selector;

                    vectorSize = Vector<TSource>.Count;
                    status = 0;
                    current = default;
                    index = 0;
                    vector = new Vector<TResult>();
                }

                public readonly TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => current;
                }
                readonly TResult IEnumerator<TResult>.Current
                    => current;
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => current;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    switch (status)
                    {
                        case 0: // fill vector
                            if (source.Length < vectorSize)
                            {
                                index = -1;
                                status = 2;
                                goto case 2;
                            }

                            vector = vectorSelector.Invoke(new Vector<TSource>(source.Span));
                            index = 0;
                            current = vector[0];
                            status = 1;
                            break;

                        case 1: // handle vector
                            if (++index >= vectorSize)
                            {
                                source = source[vectorSize..];
                                status = 0;
                                goto case 0;
                            }
                            current = vector[index];
                            break;

                        case 2: // handle remaining
                            if (++index >= source.Length)
                                return false;

                            current = selector.Invoke(source.Span[index]);
                            break;
                    }
                    return true;
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset()
                    => Throw.NotSupportedException();

                public void Dispose() { }
            }

            #region Aggregation

            public int Count()
                => source.Length;

            #endregion

            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.Length is not 0;

            #endregion
            #region Filtering

            #endregion
            #region Projection

            #endregion
            #region Element

            #endregion
            #region Conversion

            public TResult[] ToArray()
                => source.Span.ToArrayVector<TSource, TResult, TVectorSelector, TSelector>(vectorSelector, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public IMemoryOwner<TResult> ToArray(MemoryPool<TResult> pool)
                => source.Span.ToArrayVector<TSource, TResult, TVectorSelector, TSelector>(vectorSelector, selector, pool);

            public List<TResult> ToList()
                => source.Span.ToListVector<TSource, TResult, TVectorSelector, TSelector>(vectorSelector, selector);

            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource, TVectorSelector, TSelector>(this MemorySelectVectorEnumerable<TSource, int, TVectorSelector, TSelector> source)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<int>>
            where TSelector : struct, IFunction<TSource, int>
            where TSource : struct
            => source.source.Sum<TSource, int, TVectorSelector, TSelector>(source.vectorSelector, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TVectorSelector, TSelector>(this MemorySelectVectorEnumerable<TSource, long, TVectorSelector, TSelector> source)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<long>>
            where TSelector : struct, IFunction<TSource, long>
            where TSource : struct
            => source.source.Sum<TSource, long, TVectorSelector, TSelector>(source.vectorSelector, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TVectorSelector, TSelector>(this MemorySelectVectorEnumerable<TSource, float, TVectorSelector, TSelector> source)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<float>>
            where TSelector : struct, IFunction<TSource, float>
            where TSource : struct
            => source.source.Sum<TSource, float, TVectorSelector, TSelector>(source.vectorSelector, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TVectorSelector, TSelector>(this MemorySelectVectorEnumerable<TSource, double, TVectorSelector, TSelector> source)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<double>>
            where TSelector : struct, IFunction<TSource, double>
            where TSource : struct
            => source.source.Sum<TSource, double, TVectorSelector, TSelector>(source.vectorSelector, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TVectorSelector, TSelector>(this MemorySelectVectorEnumerable<TSource, decimal, TVectorSelector, TSelector> source)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<decimal>>
            where TSelector : struct, IFunction<TSource, decimal>
            where TSource : struct
            => source.source.Sum<TSource, decimal, TVectorSelector, TSelector>(source.vectorSelector, source.selector);

#endif    
    }
}

