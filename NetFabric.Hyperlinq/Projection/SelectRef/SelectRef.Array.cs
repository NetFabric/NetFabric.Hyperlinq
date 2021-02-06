using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentSelectRefEnumerable<TSource, TResult, FunctionInWrapper<TSource, TResult>> Select<TSource, TResult>(this TSource[] source, FunctionIn<TSource, TResult> selector)
            => source.SelectRef<TSource, TResult, FunctionInWrapper<TSource, TResult>>(new FunctionInWrapper<TSource, TResult>(selector));

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentSelectRefEnumerable<TSource, TResult, TSelector> SelectRef<TSource, TResult, TSelector>(this TSource[] source, TSelector selector = default)
            where TSelector : struct, IFunctionIn<TSource, TResult>
            => new ArraySegment<TSource>(source).SelectRef<TSource, TResult, TSelector>(selector);
    }
}

