using System;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        
        public static MemorySelectEnumerable<TSource, TResult> Select<TSource, TResult>(this Memory<TSource> source, Selector<TSource, TResult> selector)
            => Select((ReadOnlyMemory<TSource>)source, selector);
    }
}

