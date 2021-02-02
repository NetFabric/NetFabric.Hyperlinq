using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource[] ToArray<TSource>(this in ArraySegment<TSource> source)
            => source.AsSpan().ToArray();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IMemoryOwner<TSource> ToArray<TSource>(this in ArraySegment<TSource> source, MemoryPool<TSource> pool)
            => source.AsSpan().ToArray(pool);
    }
}

