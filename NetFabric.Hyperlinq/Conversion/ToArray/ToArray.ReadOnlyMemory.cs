using System;
using System.Buffers;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Lease<TSource> ToArray<TSource>(this ReadOnlyMemory<TSource> source, ArrayPool<TSource> pool, bool clearOnDispose = default)
            => source.Span.ToArray(pool, clearOnDispose);
    }
}

