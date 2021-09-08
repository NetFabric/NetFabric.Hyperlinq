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
        T[]? rented;
        int length;
        
        internal Lease(ArrayPool<T> pool, int length, bool clearOnDispose)
        {
            this.pool = pool;
            this.length = length;
            this.clearOnDispose = clearOnDispose;
            rented = length is 0
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
                if (value < 0 || value > rented.Length)
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
                var array = rented;
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
                var array = rented;
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
                var array = rented;
                if (array is null)
                    Throw.ObjectDisposedException(nameof(Lease<T>));
                return array.AsMemory(length);
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Enumerator GetEnumerator()
        {
            var array = rented;
            if (array is null)
                Throw.ObjectDisposedException(nameof(Lease<T>));
            return new Enumerator(array, length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        DisposableEnumerator IValueEnumerable<T, DisposableEnumerator>.GetEnumerator() 
        {
            var array = rented;
            if (array is null)
                Throw.ObjectDisposedException(nameof(Lease<T>));
            return new DisposableEnumerator(array, length);
        }
        
        IEnumerator<T> IEnumerable<T>.GetEnumerator() 
        {
            var array = rented;
            if (array is null)
                Throw.ObjectDisposedException(nameof(Lease<T>));
            // ReSharper disable once HeapView.BoxingAllocation
            return new DisposableEnumerator(array, length);
        }
        
        IEnumerator IEnumerable.GetEnumerator() 
        {
            var array = rented;
            if (array is null)
                Throw.ObjectDisposedException(nameof(Lease<T>));
            return array.GetEnumerator();
        }

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

            public void Reset() 
                => index = -1;

            public readonly void Dispose()
            { }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ArrayExtensions.ArraySegmentValueEnumerable<T> AsValueEnumerable()
            => rented is null 
                ? Throw.ObjectDisposedException<ArrayExtensions.ArraySegmentValueEnumerable<T>>(nameof(Lease<T>))
                : new ArraySegment<T>(rented, 0, length).AsValueEnumerable();
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IEnumerable<T> AsEnumerable()
            => this;
    }
}