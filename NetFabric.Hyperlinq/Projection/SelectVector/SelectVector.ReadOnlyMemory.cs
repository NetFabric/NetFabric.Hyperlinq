using System;
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
            readonly ReadOnlyMemory<TSource> source;
            TVectorSelector vectorSelector;
            TSelector selector;

            internal MemorySelectVectorEnumerable(ReadOnlyMemory<TSource> source, TVectorSelector vectorSelector, TSelector selector)
            {
                if (Vector<TSource>.Count != Vector<TResult>.Count)
                    Throw.NotSupportedException();

                this.source = source;
                this.vectorSelector = vectorSelector;
                this.selector = selector;
            }

            public readonly Enumerator GetEnumerator()
                => new(in this);
            readonly DisposableEnumerator IValueEnumerable<TResult, DisposableEnumerator>.GetEnumerator()
                => new(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(in this);

            [StructLayout(LayoutKind.Sequential)]
            public ref struct Enumerator
            {
                int index;
                int resultIndex;
                TResult current;
                Vector<TResult> result;
                readonly int remainingIndex;
                readonly int end;
                readonly int count;
                readonly ReadOnlySpan<TSource> source;
                TVectorSelector vectorSelector;
                TSelector selector;

                internal Enumerator(in MemorySelectVectorEnumerable<TSource, TResult, TVectorSelector, TSelector> enumerable)
                {
                    source = enumerable.source.Span;
                    vectorSelector = enumerable.vectorSelector;
                    selector = enumerable.selector;
                    current = default;
                    index = -1;
                    end = index + source.Length;
                    result = new Vector<TResult>();
                    count = Vector<TSource>.Count;
                    remainingIndex = source.Length - (source.Length % count);
                    resultIndex = count;
                }

                public readonly TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => current;
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    if (++index > end)
                    {
                        current = default;
                        return false;
                    }

                    if (index >= remainingIndex)
                    {
                        current = selector.Invoke(source[index]);
                    }
                    else
                    {
                        if (++resultIndex >= count)
                        {
                            result = vectorSelector.Invoke(new Vector<TSource>(source[index..]));
                            resultIndex = 0;
                        }
                        current = result[resultIndex];
                    }
                    return true;
                }
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct DisposableEnumerator
                : IEnumerator<TResult>
            {
                int index;
                int resultIndex;
                TResult current;
                Vector<TResult> result;
                readonly int remainingIndex;
                readonly int end;
                readonly int count;
                readonly ReadOnlyMemory<TSource> source;
                TVectorSelector vectorSelector;
                TSelector selector;

                internal DisposableEnumerator(in MemorySelectVectorEnumerable<TSource, TResult, TVectorSelector, TSelector> enumerable)
                {
                    source = enumerable.source;
                    vectorSelector = enumerable.vectorSelector;
                    selector = enumerable.selector;
                    current = default;
                    index = -1;
                    end = index + source.Length;
                    result = new Vector<TResult>();
                    count = Vector<TSource>.Count;
                    remainingIndex = source.Length - (source.Length % count);
                    resultIndex = count;
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
                    if (++index > end)
                    {
                        current = default;
                        return false;
                    }

                    if (index >= remainingIndex)
                    {
                        current = selector.Invoke(source.Span[index]);
                    }
                    else
                    {
                        if (++resultIndex >= count)
                        {
                            result = vectorSelector.Invoke(new Vector<TSource>(source.Span[index..]));
                            resultIndex = 0;
                        }
                        current = result[resultIndex];
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
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource, TVectorSelector, TSelector>(this MemorySelectVectorEnumerable<TSource, int, TVectorSelector, TSelector> source)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<int>>
            where TSelector : struct, IFunction<TSource, int>
            where TSource : struct
            => source.Sum<MemorySelectVectorEnumerable<TSource, int, TVectorSelector, TSelector>, MemorySelectVectorEnumerable<TSource, int, TVectorSelector, TSelector>.DisposableEnumerator, int, int, AddInt32>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TVectorSelector, TSelector>(this MemorySelectVectorEnumerable<TSource, long, TVectorSelector, TSelector> source)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<long>>
            where TSelector : struct, IFunction<TSource, long>
            where TSource : struct
            => source.Sum<MemorySelectVectorEnumerable<TSource, long, TVectorSelector, TSelector>, MemorySelectVectorEnumerable<TSource, long, TVectorSelector, TSelector>.DisposableEnumerator, long, long, AddInt64>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TVectorSelector, TSelector>(this MemorySelectVectorEnumerable<TSource, float, TVectorSelector, TSelector> source)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<float>>
            where TSelector : struct, IFunction<TSource, float>
            where TSource : struct
            => source.Sum<MemorySelectVectorEnumerable<TSource, float, TVectorSelector, TSelector>, MemorySelectVectorEnumerable<TSource, float, TVectorSelector, TSelector>.DisposableEnumerator, float, float, AddSingle>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TVectorSelector, TSelector>(this MemorySelectVectorEnumerable<TSource, double, TVectorSelector, TSelector> source)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<double>>
            where TSelector : struct, IFunction<TSource, double>
            where TSource : struct
            => source.Sum<MemorySelectVectorEnumerable<TSource, double, TVectorSelector, TSelector>, MemorySelectVectorEnumerable<TSource, double, TVectorSelector, TSelector>.DisposableEnumerator, double, double, AddDouble>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TVectorSelector, TSelector>(this MemorySelectVectorEnumerable<TSource, decimal, TVectorSelector, TSelector> source)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<decimal>>
            where TSelector : struct, IFunction<TSource, decimal>
            where TSource : struct
            => source.Sum<MemorySelectVectorEnumerable<TSource, decimal, TVectorSelector, TSelector>, MemorySelectVectorEnumerable<TSource, decimal, TVectorSelector, TSelector>.DisposableEnumerator, decimal, decimal, AddDecimal>();

#endif    
    }
}

