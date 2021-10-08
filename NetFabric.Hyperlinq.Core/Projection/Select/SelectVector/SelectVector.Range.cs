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
        static RangeSelectVectorContext<TResult, FunctionWrapper<Vector<int>, Vector<TResult>>, FunctionWrapper<int, TResult>> SelectVector<TResult>(int start, int count, Func<Vector<int>, Vector<TResult>> vectorSelector, Func<int, TResult> selector)
            where TResult : struct
            => SelectVector<TResult, FunctionWrapper<Vector<int>, Vector<TResult>>, FunctionWrapper<int, TResult>>(start, count, new FunctionWrapper<Vector<int>, Vector<TResult>>(vectorSelector), new FunctionWrapper<int, TResult>(selector));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static RangeSelectVectorContext<TResult, TSelector, TSelector> SelectVector<TResult, TSelector>(int start, int count, TSelector selector = default)
            where TSelector : struct, IFunction<Vector<int>, Vector<TResult>>, IFunction<int, TResult>
            where TResult : struct
            => SelectVector<TResult, TSelector, TSelector>(start, count, selector, selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static RangeSelectVectorContext<TResult, TVectorSelector, TSelector> SelectVector<TResult, TVectorSelector, TSelector>(int start, int count, TVectorSelector vectorSelector = default, TSelector selector = default)
            where TVectorSelector : struct, IFunction<Vector<int>, Vector<TResult>>
            where TSelector : struct, IFunction<int, TResult>
            where TResult : struct
            => new(start, count, vectorSelector, selector);


        [StructLayout(LayoutKind.Auto)]
        public partial struct RangeSelectVectorContext<TResult, TVectorSelector, TSelector>
            where TVectorSelector : struct, IFunction<Vector<int>, Vector<TResult>>
            where TSelector : struct, IFunction<int, TResult>
            where TResult : struct
        {
            internal readonly int start;
            internal readonly int count;
            internal TVectorSelector vectorSelector;
            internal TSelector selector;

            internal RangeSelectVectorContext(int start, int count, TVectorSelector vectorSelector, TSelector selector)
            {
                if (Vector<int>.Count != Vector<TResult>.Count)
                    Throw.NotSupportedException();

                this.start = start;
                this.count = count;
                this.vectorSelector = vectorSelector;
                this.selector = selector;
            }

            #region Aggregation

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count()
                => count;

            #endregion
            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => count is not 0;

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
            public Lease<TResult> ToArray(ArrayPool<TResult> pool, bool clearOnDispose = default)
            {
                var result = pool.Lease(count, clearOnDispose);
                ArrayExtensions.CopyRange(start, count, result.Memory.Span, vectorSelector, selector);
                return result;
            }

            public List<TResult> ToList()
                => count switch
                {
                    // ReSharper disable once HeapView.ObjectAllocation.Evident
                    0 => new List<TResult>(),
                    _ => ToArray().AsList()
                };

        #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TVectorSelector, TSelector>(this RangeSelectVectorContext<int, TVectorSelector, TSelector> source)
            where TVectorSelector : struct, IFunction<Vector<int>, Vector<int>>
            where TSelector : struct, IFunction<int, int>
            => SumRange<int, TVectorSelector, TSelector>(source.start, source.count, source.vectorSelector, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TVectorSelector, TSelector>(this RangeSelectVectorContext<nint, TVectorSelector, TSelector> source)
            where TVectorSelector : struct, IFunction<Vector<int>, Vector<nint>>
            where TSelector : struct, IFunction<int, nint>
            => SumRange<nint, TVectorSelector, TSelector>(source.start, source.count, source.vectorSelector, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TVectorSelector, TSelector>(this RangeSelectVectorContext<nuint, TVectorSelector, TSelector> source)
            where TVectorSelector : struct, IFunction<Vector<int>, Vector<nuint>>
            where TSelector : struct, IFunction<int, nuint>
            => SumRange<nuint, TVectorSelector, TSelector>(source.start, source.count, source.vectorSelector, source.selector);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TVectorSelector, TSelector>(this RangeSelectVectorContext<long, TVectorSelector, TSelector> source)
            where TVectorSelector : struct, IFunction<Vector<int>, Vector<long>>
            where TSelector : struct, IFunction<int, long>
            => SumRange<long, TVectorSelector, TSelector>(source.start, source.count, source.vectorSelector, source.selector);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TVectorSelector, TSelector>(this RangeSelectVectorContext<float, TVectorSelector, TSelector> source)
            where TVectorSelector : struct, IFunction<Vector<int>, Vector<float>>
            where TSelector : struct, IFunction<int, float>
            => SumRange<float, TVectorSelector, TSelector>(source.start, source.count, source.vectorSelector, source.selector);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TVectorSelector, TSelector>(this RangeSelectVectorContext<double, TVectorSelector, TSelector> source)
            where TVectorSelector : struct, IFunction<Vector<int>, Vector<double>>
            where TSelector : struct, IFunction<int, double>
            => SumRange<double, TVectorSelector, TSelector>(source.start, source.count, source.vectorSelector, source.selector);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TVectorSelector, TSelector>(this RangeSelectVectorContext<decimal, TVectorSelector, TSelector> source)
            where TVectorSelector : struct, IFunction<Vector<int>, Vector<decimal>>
            where TSelector : struct, IFunction<int, decimal>
            => SumRange<decimal, TVectorSelector, TSelector>(source.start, source.count, source.vectorSelector, source.selector);
    }
}

