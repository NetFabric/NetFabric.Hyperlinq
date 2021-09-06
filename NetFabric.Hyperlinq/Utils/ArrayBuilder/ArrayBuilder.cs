// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

// based on https://github.com/dotnet/runtime/blob/master/src/libraries/Common/src/System/Collections/Generic/ArrayBuilder.cs

using System;
using System.Buffers;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    /// <summary>
    /// Helper type for avoiding allocations while building arrays.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    [StructLayout(LayoutKind.Auto)]
    struct ArrayBuilder<T> 
        : IDisposable
    {
        const int defaultMinCapacity = 4;
        const int maxCoreClrArrayLength = 0x7fefffff; // For byte arrays the limit is slightly larger

        readonly ArrayPool<T> pool;
        T[] buffer;
        int index;

        /// <summary>
        /// Initializes the <see cref="ArrayBuilder{T}"/> with a specified capacity.
        /// </summary>
        /// <param name="capacity">The capacity of the array to allocate.</param>
        public ArrayBuilder(int capacity, ArrayPool<T> pool) 
            : this(pool)
        {
            Debug.Assert(capacity >= 0);
            if (capacity > 0)
                buffer = this.pool.Rent(capacity);
        }

        public ArrayBuilder(ArrayPool<T> pool)
        {
            this.pool = pool;
            buffer = Array.Empty<T>();
            index = 0;
        }

        /// <summary>
        /// Gets the number of items in the array currently in use.
        /// </summary>
        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public int Count => index;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly ReadOnlySpan<T> AsSpan()
            => buffer.AsSpan(0, index);

        /// <summary>
        /// Adds an item to the backing array, resizing it if necessary.
        /// </summary>
        /// <param name="item">The item to add.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(T item)
        {
            var buffer = this.buffer;
            var index = this.index;
            
            // Must be >= and not == to enable range check elimination
            if ((uint)index >= (uint)buffer.Length)
            {
                AddWithBufferAllocation(item);
            }
            else
            {
                buffer[index] = item;
                this.index = index + 1;                
            }
        }
        
        // Non-inline to improve code quality as uncommon path
        [MethodImpl(MethodImplOptions.NoInlining)]
        void AddWithBufferAllocation(T item)
        {
            EnsureCapacity(index + 1);
            buffer[index++] = item;
        }

        void EnsureCapacity(int minimum)
        {
            Debug.Assert(minimum > index);

            var capacity = index;
            var nextCapacity = capacity is 0
                ? defaultMinCapacity
                : 2 * capacity;

            if ((uint)nextCapacity > (uint)maxCoreClrArrayLength)
                nextCapacity = Math.Max(capacity + 1, maxCoreClrArrayLength);

            nextCapacity = Math.Max(nextCapacity, minimum);

            var next = pool.Rent(nextCapacity);
            if (index is not 0)
            {
                buffer.AsSpan().CopyTo(next.AsSpan(index));
                pool.Return(buffer);
            }

            buffer = next; 
        }

        public readonly void Dispose()
        {
            if (index is not 0)
                pool.Return(buffer);
        }
    }
}