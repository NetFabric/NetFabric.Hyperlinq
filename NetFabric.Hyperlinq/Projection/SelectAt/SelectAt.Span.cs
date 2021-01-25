using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [GeneratorMapping("TSelector", "NetFabric.Hyperlinq.FunctionWrapper<TSource, int, TResult>")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanSelectAtEnumerable<TSource, TResult, FunctionWrapper<TSource, int, TResult>> Select<TSource, TResult>(this Span<TSource> source, Func<TSource, int, TResult> selector)
            => source.SelectAt<TSource, TResult, FunctionWrapper<TSource, int, TResult>>(new FunctionWrapper<TSource, int, TResult>(selector));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanSelectAtEnumerable<TSource, TResult, TSelector> SelectAt<TSource, TResult, TSelector>(this Span<TSource> source, TSelector selector = default)
            where TSelector : struct, IFunction<TSource, int, TResult>
            => ((ReadOnlySpan<TSource>)source).SelectAt<TSource, TResult, TSelector>(selector);
    }
}

