using System;
using System.Buffers;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IMemoryOwner<TSource> ToArray<TSource>(this Memory<TSource> source, ArrayPool<TSource> pool, bool clearOnDispose = default)
            => ((ReadOnlyMemory<TSource>)source).Span.ToArray(pool, clearOnDispose);
    }
}

