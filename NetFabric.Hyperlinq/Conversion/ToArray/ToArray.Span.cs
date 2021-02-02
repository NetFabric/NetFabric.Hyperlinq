using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IMemoryOwner<TSource> ToArray<TSource>(this Span<TSource> source, MemoryPool<TSource> pool)
            => ((ReadOnlySpan<TSource>)source).ToArray(pool);
    }
}

