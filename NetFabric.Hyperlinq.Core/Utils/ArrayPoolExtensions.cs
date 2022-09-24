using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static class ArrayPoolExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Lease<T> Lease<T>(this ArrayPool<T> pool, int length, bool clearOnDispose = default)
            => length < 0
                ? Throw.ArgumentOutOfRangeException<Lease<T>>(nameof(length))
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                : new Lease<T>(pool, length, clearOnDispose);
    }
}
