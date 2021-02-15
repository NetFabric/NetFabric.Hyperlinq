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
#if NET5_0

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanSelectVectorEnumerable<TSource, TResult, FunctionWrapper<Vector<TSource>, Vector<TResult>>, FunctionWrapper<TSource, TResult>> SelectVector<TSource, TResult>(this ReadOnlySpan<TSource> source, Func<Vector<TSource>, Vector<TResult>> vectorSelector, Func<TSource, TResult> selector)
            where TSource : struct
            where TResult : struct
            => source.SelectVector<TSource, TResult, FunctionWrapper<Vector<TSource>, Vector<TResult>>, FunctionWrapper<TSource, TResult>>(new FunctionWrapper<Vector<TSource>, Vector<TResult>>(vectorSelector), new FunctionWrapper<TSource, TResult>(selector));

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanSelectVectorEnumerable<TSource, TResult, TSelector, TSelector> SelectVector<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector = default)
            where TSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
            => source.SelectVector<TSource, TResult, TSelector, TSelector>(selector, selector);

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanSelectVectorEnumerable<TSource, TResult, TVectorSelector, TSelector> SelectVector<TSource, TResult, TVectorSelector, TSelector>(this ReadOnlySpan<TSource> source, TVectorSelector vectorSelector = default, TSelector selector = default)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>
            where TSelector : struct, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
            => new(source, vectorSelector, selector);

        [GeneratorIgnore]
        // [GeneratorMapping("TSource", "TResult")]
        [StructLayout(LayoutKind.Auto)]
        public ref struct SpanSelectVectorEnumerable<TSource, TResult, TVectorSelector, TSelector>
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>
            where TSelector : struct, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
        {
            internal readonly ReadOnlySpan<TSource> source;
            internal TVectorSelector vectorSelector;
            internal TSelector selector;

            internal SpanSelectVectorEnumerable(ReadOnlySpan<TSource> source, TVectorSelector vectorSelector, TSelector selector)
            {
                if (Vector<TSource>.Count != Vector<TResult>.Count)
                    Throw.NotSupportedException();

                this.source = source;
                this.vectorSelector = vectorSelector;
                this.selector = selector;
            }

            public readonly int Count
                => source.Length;

            public TResult this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => selector.Invoke(source[index]);
            }

            public readonly SelectVectorEnumerator<TSource, TResult, TSelector> GetEnumerator()
                => new(source, selector);

            #region Aggregation

            #endregion

            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.Length is not 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TResult value)
                => source.ContainsVector(value, vectorSelector, selector);

            #endregion
            #region Filtering

            #endregion
            #region Projection

            #endregion
            #region Element

            #endregion
            #region Conversion

            public TResult[] ToArray()
                => source.ToArrayVector<TSource, TResult, TVectorSelector, TSelector>(vectorSelector, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public IMemoryOwner<TResult> ToArray(MemoryPool<TResult> pool)
                => source.ToArrayVector<TSource, TResult, TVectorSelector, TSelector>(vectorSelector, selector, pool);

            public List<TResult> ToList()
                => source.ToListVector<TSource, TResult, TVectorSelector, TSelector>(vectorSelector, selector);

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
        public static int Count<TSource, TResult, TVectorSelector, TSelector>(this SpanSelectVectorEnumerable<TSource, TResult, TVectorSelector, TSelector> source)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>
            where TSelector : struct, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
            => source.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource, TVectorSelector, TSelector>(this SpanSelectVectorEnumerable<TSource, int, TVectorSelector, TSelector> source)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<int>>
            where TSelector : struct, IFunction<TSource, int>
            where TSource : struct
            => source.source.Sum<TSource, int, TVectorSelector, TSelector>(source.vectorSelector, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TVectorSelector, TSelector>(this SpanSelectVectorEnumerable<TSource, long, TVectorSelector, TSelector> source)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<long>>
            where TSelector : struct, IFunction<TSource, long>
            where TSource : struct
            => source.source.Sum<TSource, long, TVectorSelector, TSelector>(source.vectorSelector, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TVectorSelector, TSelector>(this SpanSelectVectorEnumerable<TSource, float, TVectorSelector, TSelector> source)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<float>>
            where TSelector : struct, IFunction<TSource, float>
            where TSource : struct
            => source.source.Sum<TSource, float, TVectorSelector, TSelector>(source.vectorSelector, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TVectorSelector, TSelector>(this SpanSelectVectorEnumerable<TSource, double, TVectorSelector, TSelector> source)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<double>>
            where TSelector : struct, IFunction<TSource, double>
            where TSource : struct
            => source.source.Sum<TSource, double, TVectorSelector, TSelector>(source.vectorSelector, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TVectorSelector, TSelector>(this SpanSelectVectorEnumerable<TSource, decimal, TVectorSelector, TSelector> source)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<decimal>>
            where TSelector : struct, IFunction<TSource, decimal>
            where TSource : struct
            => source.source.Sum<TSource, decimal, TVectorSelector, TSelector>(source.vectorSelector, source.selector);

#endif    
    }
}

