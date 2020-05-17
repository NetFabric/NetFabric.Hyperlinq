using System;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        
        public static SpanSelectIndexEnumerable<TSource, TResult> Select<TSource, TResult>(this Span<TSource> source, SelectorAt<TSource, TResult> selector)
            => Select((ReadOnlySpan<TSource>)source, selector);
    }
}

