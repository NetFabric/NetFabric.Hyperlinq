using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static SpanWhereSelectEnumerable<TSource, TResult> WhereSelect<TSource, TResult>(this Span<TSource> source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector)
            => WhereSelect((ReadOnlySpan<TSource>)source, predicate, selector);
    }
}

