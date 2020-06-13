using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanSelectEnumerable<TSource, TResult> Select<TSource, TResult>(this Span<TSource> source, NullableSelector<TSource, TResult> selector)
            => Select((ReadOnlySpan<TSource>)source, selector);
    }
}

