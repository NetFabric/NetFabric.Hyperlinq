using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static class InternalArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<T> AsReadOnlySpan<T>(this T[] source)
            => source;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyMemory<T> AsReadOnlyMemory<T>(this T[] source)
            => source;
    }
}
