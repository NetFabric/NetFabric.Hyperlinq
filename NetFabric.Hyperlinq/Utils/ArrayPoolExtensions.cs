using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static class ArrayPoolExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemoryOwner<T> RentDisposable<T>(this ArrayPool<T> pool, int length, bool clearOnDispose)
            => new(pool, length, clearOnDispose);
    }

    class MemoryOwner<T>
        : IMemoryOwner<T>
    {
        readonly ArrayPool<T> pool;
        readonly int length;
        readonly bool clearOnDispose;
        T[]? rented;

        internal MemoryOwner(ArrayPool<T> pool, int length, bool clearOnDispose)
        {
            this.pool = pool;
            this.length = length;
            this.clearOnDispose = clearOnDispose;
            rented = this.pool.Rent(length);
        }

        public T[] Rented
        {
            get
            {
                var array = rented;
                if (array is null)
                    Throw.ObjectDisposedException<T[]>(nameof(MemoryOwner<T>));
                return array;
            }
        }

        public Memory<T> Memory
        {
            get
            {
                var array = rented;
                if (array is null)
                    Throw.ObjectDisposedException<T[]>(nameof(MemoryOwner<T>));
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

    class EmptyMemoryOwner<T>
        : IMemoryOwner<T>
    {
        public static EmptyMemoryOwner<T> Instance => new();
        
        private EmptyMemoryOwner() { }
        
        public Memory<T> Memory => Memory<T>.Empty;
        
        public void Dispose() { }
    }
}
