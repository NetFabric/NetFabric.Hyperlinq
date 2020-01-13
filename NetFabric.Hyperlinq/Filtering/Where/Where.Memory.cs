using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static WhereEnumerable<TSource> Where<TSource>(this Memory<TSource> source, Predicate<TSource> predicate)
            => Where((ReadOnlyMemory<TSource>)source, predicate);
    }
}

