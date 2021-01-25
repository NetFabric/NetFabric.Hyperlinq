using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [GeneratorMapping("TSelector", "NetFabric.Hyperlinq.FunctionWrapper<TSource, TResult>")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemorySelectEnumerable<TSource, TResult, FunctionWrapper<TSource, TResult>> Select<TSource, TResult>(this Memory<TSource> source, Func<TSource, TResult> selector)
            => source.Select<TSource, TResult, FunctionWrapper<TSource, TResult>>(new FunctionWrapper<TSource, TResult>(selector));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemorySelectEnumerable<TSource, TResult, TSelector> Select<TSource, TResult, TSelector>(this Memory<TSource> source, TSelector selector = default)
            where TSelector : struct, IFunction<TSource, TResult>
            => ((ReadOnlyMemory<TSource>)source).Select<TSource, TResult, TSelector>(selector);
    }
}

