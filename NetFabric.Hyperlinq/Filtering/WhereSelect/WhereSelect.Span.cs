using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static SpanWhereSelectEnumerable<TSource, TResult> WhereSelect<TSource, TResult>(this Span<TSource> source, Predicate<TSource> predicate, Selector<TSource, TResult> selector)
            => WhereSelect((ReadOnlySpan<TSource>)source, predicate, selector);
    }
}

