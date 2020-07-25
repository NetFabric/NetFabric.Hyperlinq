using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static class ArraySegmentExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWhole<TSource>(this in ArraySegment<TSource> source)
            => source.Count == source.Array.Length;
    }
}
