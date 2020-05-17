using System;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        
        public static SpanSelectEnumerable<TSource, TResult> Select<TSource, TResult>(this Span<TSource> source, Selector<TSource, TResult> selector)
            => Select((ReadOnlySpan<TSource>)source, selector);
    }
}

