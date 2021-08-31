using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static class ArrayPoolExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueMemoryOwner<T> RentDisposable<T>(this ArrayPool<T> pool, int length, bool clearOnDispose)
            => new(pool, length, clearOnDispose);
    }

    public struct ValueMemoryOwner<T>
        : IMemoryOwner<T>
    {
        readonly ArrayPool<T> pool;
        readonly int length;
        readonly bool clearOnDispose;
        T[]? rented;

        internal ValueMemoryOwner(ArrayPool<T> pool, int length, bool clearOnDispose)
        {
            this.pool = pool;
            this.length = length;
            this.clearOnDispose = clearOnDispose;
            rented = this.pool.Rent(length);
        }

        public readonly T[] Rented 
        {
            get
            {
                var array = rented;
                if (array is null)
                    Throw.ObjectDisposedException(nameof(ValueMemoryOwner<T>));
                return array;
            }
        }
        public readonly Memory<T> Memory
        {
            get
            {
                var array = rented;
                if (array is null)
                    Throw.ObjectDisposedException(nameof(ValueMemoryOwner<T>));
                return new Memory<T>(array, 0, length);
            }
        }

        public void Dispose()
        {
            var array = rented;
            if (array is not null)
            {
                rented = null;
                pool.Return(array, clearOnDispose);
            }
        }
    }
    
}
