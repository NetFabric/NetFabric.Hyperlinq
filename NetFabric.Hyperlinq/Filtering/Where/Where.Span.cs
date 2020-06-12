using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanWhereEnumerable<TSource> Where<TSource>(this Span<TSource> source, Predicate<TSource> predicate)
            => Where((ReadOnlySpan<TSource>)source, predicate);
    }
}

