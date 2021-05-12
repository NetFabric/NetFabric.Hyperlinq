using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static class ArrayPoolExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueMemoryOwner<T> RentMemory<T>(this ArrayPool<T> pool, int length, bool clearOnDispose)
            => new(pool, length, sliced: false, clearOnDispose);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueMemoryOwner<T> RentSliced<T>(this ArrayPool<T> pool, int length, bool clearOnDispose)
            => new(pool, length, sliced: true, clearOnDispose);
    }

    public struct ValueMemoryOwner<T>
        : IMemoryOwner<T>
    {
        readonly ArrayPool<T> pool;
        T[]? array;
        readonly int length;
        readonly bool clearOnDispose;

        internal ValueMemoryOwner(ArrayPool<T> pool, int length, bool sliced, bool clearOnDispose)
        {
            this.pool = pool;
            array = pool.Rent(length);
            this.length = sliced ? length : array.Length;
            this.clearOnDispose = clearOnDispose;
        }

        public Memory<T> Memory
        {
            get
            {
                var array = this.array;
                if (array is null)
                    Throw.ObjectDisposedException(nameof(ValueMemoryOwner<T>));

                return new Memory<T>(array, 0, length);
            }
        }

        public void Dispose()
        {
            var array = this.array;
            if (array is not null)
            {
                this.array = null;
                pool.Return(array, clearOnDispose);
            }
        }
    }
    
}
