using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanDistinctEnumerable<TSource> Distinct<TSource>(
            this Span<TSource> source, 
            IEqualityComparer<TSource>? comparer = null)
            => Distinct((ReadOnlySpan<TSource>)source, comparer);
    }
}

