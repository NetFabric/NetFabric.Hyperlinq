using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanSelectAtEnumerable<TSource, TResult> Select<TSource, TResult>(this Span<TSource> source, SelectorAt<TSource, TResult> selector)
            => Select((ReadOnlySpan<TSource>)source, selector);
    }
}

