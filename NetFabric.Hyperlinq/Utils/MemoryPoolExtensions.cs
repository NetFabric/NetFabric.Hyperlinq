using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static class MemoryPoolExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IMemoryOwner<T> RentSliced<T>(this MemoryPool<T> pool, int count)
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            => new SlicedMemoryOwner<T>(pool.Rent(count), count);

        sealed class SlicedMemoryOwner<T>
            : IMemoryOwner<T>
        {
            readonly IMemoryOwner<T> oversized;
            readonly int count;

            public SlicedMemoryOwner(IMemoryOwner<T> oversized, int count)
                => (this.oversized, this.count) = (oversized, count);

            public Memory<T> Memory 
                => oversized.Memory.Slice(0, count);

            public void Dispose() 
                => oversized.Dispose();
        }
    }
}
