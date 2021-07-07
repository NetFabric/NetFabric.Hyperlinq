using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static class ArraySegmentExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEmpty<T>(this in ArraySegment<T> source)
            => source.Count is 0;

        // NOTE: Inner array can only be null if length is zero. Should validate before calling this method.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWhole<T>(this in ArraySegment<T> source)
            => source.Count == source.Array!.Length;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<T> AsReadOnlySpan<T>(this in ArraySegment<T> source)
            => source.AsSpan();
    }
}
