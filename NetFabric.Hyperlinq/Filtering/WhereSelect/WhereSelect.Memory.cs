using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static MemoryWhereSelectEnumerable<TSource, TResult> WhereSelect<TSource, TResult>(this Memory<TSource> source, Predicate<TSource> predicate, Selector<TSource, TResult> selector)
            => WhereSelect((ReadOnlyMemory<TSource>)source, predicate, selector);
    }
}

