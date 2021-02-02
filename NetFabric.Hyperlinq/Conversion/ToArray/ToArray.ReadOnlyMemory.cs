using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IMemoryOwner<TSource> ToArray<TSource>(this ReadOnlyMemory<TSource> source, MemoryPool<TSource> pool)
            => source.Span.ToArray(pool);
    }
}

