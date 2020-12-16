using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemorySelectAtEnumerable<TSource, TResult, FunctionWrapper<TSource, int, TResult>> Select<TSource, TResult>(this Memory<TSource> source, Func<TSource, int, TResult> selector)
            => source.SelectAt<TSource, TResult, FunctionWrapper<TSource, int, TResult>>(new FunctionWrapper<TSource, int, TResult>(selector));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemorySelectAtEnumerable<TSource, TResult, TSelector> SelectAt<TSource, TResult, TSelector>(this Memory<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, int, TResult>
            => ((ReadOnlyMemory<TSource>)source).SelectAt<TSource, TResult, TSelector>(selector);
    }
}

