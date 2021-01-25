using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [GeneratorMapping("TSelector", "NetFabric.Hyperlinq.FunctionWrapper<TSource, TSubEnumerable>")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemorySelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, FunctionWrapper<TSource, TSubEnumerable>> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(this Memory<TSource> source, Func<TSource, TSubEnumerable> selector)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => source.SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult, FunctionWrapper<TSource, TSubEnumerable>>(new FunctionWrapper<TSource, TSubEnumerable>(selector));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemorySelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>(this Memory<TSource> source, TSelector selector = default)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
            => ((ReadOnlyMemory<TSource>)source).SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>(selector);
    }
}

