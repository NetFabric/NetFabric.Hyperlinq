using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static class ArrayPool
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegment<T> RentSliced<T>(this ArrayPool<T> pool, int count)
            => new ArraySegment<T>(pool.Rent(count), 0, count);
    }
}
