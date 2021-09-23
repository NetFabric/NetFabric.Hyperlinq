using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static class Lease
    {
        static class EmptyLease<T>
        {
            // ReSharper disable once InconsistentNaming
            internal static readonly Lease<T> Value = new(ArrayPool<T>.Shared, 0, default);
        }

        public static Lease<T> Empty<T>() 
            => EmptyLease<T>.Value;
    }

    public sealed class Lease<T>
        : IMemoryOwner<T>
        , IValueEnumerable<T, Lease<T>.DisposableEnumerator>
    {
        readonly ArrayPool<T> pool;
        readonly bool clearOnDispose;
        T[]? rented;
        int length;
        
        internal Lease(ArrayPool<T> pool, int length, bool clearOnDispose)
        {
            Debug.Assert(length >= 0);

            this.pool = pool;
            this.length = length;
            this.clearOnDispose = clearOnDispose;
            rented = length is 0
                ? Array.Empty<T>()
                : pool.Rent(length);
        }

        /// <summary>
        /// Gets or sets the length of memory to be used.
        /// </summary>
        public int Length
        {
            get => length;
            set
            {
                var array = rented;
                if (array is null)
                    Throw.ObjectDisposedException(nameof(Lease<T>));
                if (value < 0 || value > array.Length)
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
            if (length is 0) 
                return; // do not dispose empty 
            
            var array = rented;
            if (array is null) 
                return; // it's already disposed
            
            rented = null;
            pool.Return(array, clearOnDispose);
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
            => GetDisposableEnumerator();
        
        IEnumerator<T> IEnumerable<T>.GetEnumerator() 
            // ReSharper disable once HeapView.BoxingAllocation
            => GetDisposableEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            // ReSharper disable once HeapView.BoxingAllocation
            => GetDisposableEnumerator();
        
        DisposableEnumerator GetDisposableEnumerator() 
        {
            var array = rented;
            if (array is null)
                Throw.ObjectDisposedException(nameof(Lease<T>));
            return new DisposableEnumerator(array, length);
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
            {
                if (index >= length) 
                    return false;
                index++;
                return index < length;
            }
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
            {
                if (index >= length) 
                    return false;
                index++;
                return index < length;
            }

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
        public Lease<T> AsEnumerable()
            => this;
    }
}