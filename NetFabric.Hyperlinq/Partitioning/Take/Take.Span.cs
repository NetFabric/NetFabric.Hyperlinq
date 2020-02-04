using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<TSource> Take<TSource>(this Span<TSource> source, int count)
            => Take((ReadOnlySpan<TSource>)source, count);
    }
}
