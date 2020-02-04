using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemoryWhereSelectEnumerable<TSource, TResult> WhereSelect<TSource, TResult>(this Memory<TSource> source, Predicate<TSource> predicate, Selector<TSource, TResult> selector)
            => WhereSelect((ReadOnlyMemory<TSource>)source, predicate, selector);
    }
}

