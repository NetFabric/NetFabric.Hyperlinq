using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public sealed class Lease<T>
        : IMemoryOwner<T>
        , IValueEnumerable<T, Lease<T>.DisposableEnumerator>
    {
        public readonly static Lease<T> Default = new(ArrayPool<T>.Shared, 0, default);

        readonly ArrayPool<T> pool;
        readonly bool clearOnDispose;
        T[]? leased;
        int length;
        
        internal Lease(ArrayPool<T> pool, int length, bool clearOnDispose)
        {
            this.pool = pool;
            this.length = length;
            this.clearOnDispose = clearOnDispose;
            leased = length is 0
                ? Array.Empty<T>()
                : this.pool.Rent(length);
        }

        /// <summary>
        /// Gets or sets the length of memory to be used.
        /// </summary>
        public int Length
        {
            get => length;
            set
            {
                if (leased is null || value > leased.Length)
                    Throw.ArgumentOutOfRangeException(nameof(value));

                length = value;
            }
        }
        
        /// <summary>
        /// Gets all the memory rented.
        /// </summary>
        public T[] Rented
        {
            get
            {
                var array = leased;
                if (array is null)
                    Throw.ObjectDisposedException(nameof(Lease<T>));
                return array;
            }
        }

        /// <summary>
        /// Gets the slice of memory to be used.
        /// </summary>
        public Memory<T> Memory
        {
            get
            {
                var array = leased;
                if (array is null)
                    Throw.ObjectDisposedException(nameof(Lease<T>));
                return array.AsMemory(0, length);
            }
        }

        /// <summary>
        /// Gets the slice of memory that is rented but not used.
        /// </summary>
        public Memory<T> Remaining
        {
            get
            {
                var array = leased;
                if (array is null)
                    Throw.ObjectDisposedException(nameof(Lease<T>));
                return array.AsMemory(length);
            }
        }

        public void Dispose()
        {
            var array = leased;
            if (array is not null)
            {
                leased = null;
                pool.Return(array, clearOnDispose);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Enumerator GetEnumerator() 
            => new(Rented, length);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        DisposableEnumerator IValueEnumerable<T, DisposableEnumerator>.GetEnumerator() 
            => new(Rented, length);
        
        IEnumerator<T> IEnumerable<T>.GetEnumerator() 
            // ReSharper disable once HeapView.BoxingAllocation
            => new DisposableEnumerator(Rented, length);
        
        IEnumerator IEnumerable.GetEnumerator() 
            => Rented.GetEnumerator();

        public struct Enumerator
        {
            readonly T[] source;
            readonly int length;
            int index;

            internal Enumerator(T[] source, int length) 
            {
                this.source = source;
                this.length = length;
                index = -1;
            }

            public readonly T Current
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source[index];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext()
                => ++index < length;
        }

        public struct DisposableEnumerator
            : IEnumerator<T>
        {
            readonly T[] source;
            readonly int length;
            int index;

            internal DisposableEnumerator(T[] source, int length) 
            {
                this.source = source;
                this.length = length;
                index = -1;
            }

            public readonly T Current
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source[index];
            }
            
            readonly object? IEnumerator.Current
                // ReSharper disable once HeapView.PossibleBoxingAllocation
                => source[index];
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext()
                => ++index < length;        

            [ExcludeFromCodeCoverage]
            [DoesNotReturn]
            public readonly void Reset() 
                => Throw.NotSupportedException();

            public readonly void Dispose()
            { }
        }
        
    }
}