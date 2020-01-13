using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RefWhereEnumerable<TSource> Where<TSource>(this Span<TSource> source, Predicate<TSource> predicate)
            => Where((ReadOnlySpan<TSource>)source, predicate);
    }
}

