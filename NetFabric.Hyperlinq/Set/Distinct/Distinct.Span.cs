using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RefDistinctEnumerable<TSource> Distinct<TSource>(
            this Span<TSource> source, 
            IEqualityComparer<TSource>? comparer = null)
            => Distinct((ReadOnlySpan<TSource>)source, comparer);
    }
}

