using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static class ArrayPoolExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Lease<T> Lease<T>(this ArrayPool<T> pool, int length, bool clearOnDispose)
            => new(pool, length, clearOnDispose);
    }
}
