using System;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        
        public static MemorySelectIndexEnumerable<TSource, TResult> Select<TSource, TResult>(this Memory<TSource> source, SelectorAt<TSource, TResult> selector)
            => Select((ReadOnlyMemory<TSource>)source, selector);
    }
}

