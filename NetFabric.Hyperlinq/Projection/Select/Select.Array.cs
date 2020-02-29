using System;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        public static MemorySelectEnumerable<TSource, TResult> Select<TSource, TResult>(this TSource[] source, Selector<TSource, TResult> selector)
            => Select((ReadOnlyMemory<TSource>)source.AsMemory(), selector);
    }
}

