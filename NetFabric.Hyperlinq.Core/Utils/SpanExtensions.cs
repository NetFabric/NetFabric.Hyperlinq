using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static class SpanExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<T> AsReadOnlySpan<T>(this Span<T> source)
            => source;
    }
}
