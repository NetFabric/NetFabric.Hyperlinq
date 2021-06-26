// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

// based on https://github.com/dotnet/runtime/blob/master/src/libraries/Common/src/System/Collections/Generic/ArrayBuilder.cs

using System;
using System.Buffers;
using System.Diagnostics;

namespace NetFabric.Hyperlinq
{
    /// <summary>
    /// Helper type for avoiding allocations while building arrays.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    struct ArrayBuilder<T> 
        : IDisposable
    {
        const int defaultMinCapacity = 4;
        const int maxCoreClrArrayLength = 0x7fefffff; // For byte arrays the limit is slightly larger

        readonly ArrayPool<T> pool;
        T[]? buffer; // Starts out null, initialized on first Add.

        /// <summary>
        /// Initializes the <see cref="ArrayBuilder{T}"/> with a specified capacity.
        /// </summary>
        /// <param name="capacity">The capacity of the array to allocate.</param>
        public ArrayBuilder(int capacity, ArrayPool<T> pool) 
            : this(pool)
        {
            Debug.Assert(capacity >= 0);
            if (capacity > 0)
            {
                buffer = this.pool.Rent(capacity);
            }
        }

        public ArrayBuilder(ArrayPool<T> pool)
        {
            this.pool = pool;
            buffer = default;
            Count = 0;
        }

        /// <summary>
        /// Gets the number of items this instance can store without re-allocating,
        /// or 0 if the backing array is <c>null</c>.
        /// </summary>
        public int Capacity 
            => buffer?.Length ?? 0;

        /// <summary>
        /// Gets the number of items in the array currently in use.
        /// </summary>
        public int Count { get; private set; }

        // /// <summary>
        // /// Gets or sets the item at a certain index in the array.
        // /// </summary>
        // /// <param name="index">The index into the array.</param>
        // public T this[int index]
        // {
        //     get
        //     {
        //         Debug.Assert(index >= 0 && index < Count);
        //         return buffer![index];
        //     }
        // }

        public readonly Span<T> AsSpan()
            => buffer!.AsSpan(0, Count);

        /// <summary>
        /// Adds an item to the backing array, resizing it if necessary.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void Add(T item)
        {
            if (Count == Capacity)
            {
                EnsureCapacity(Count + 1);
            }

            UncheckedAdd(item);
        }

        /// <summary>
        /// Adds an item to the backing array, without checking if there is room.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <remarks>
        /// Use this method if you know there is enough space in the <see cref="ArrayBuilder{T}"/>
        /// for another item, and you are writing performance-sensitive code.
        /// </remarks>
        public void UncheckedAdd(T item)
        {
            Debug.Assert(buffer is not null);
            Debug.Assert(Count < Capacity);

            buffer[Count++] = item;
        }

        void EnsureCapacity(int minimum)
        {
            Debug.Assert(minimum > Capacity);

            var capacity = Capacity;
            var nextCapacity = capacity switch
            { 
                0 => defaultMinCapacity,
                _ => 2 * capacity,
            };

            if ((uint)nextCapacity > (uint)maxCoreClrArrayLength)
            {
                nextCapacity = Math.Max(capacity + 1, maxCoreClrArrayLength);
            }

            nextCapacity = Math.Max(nextCapacity, minimum);

            var next = pool.Rent(nextCapacity);
            try
            {
                if (buffer is not null)
                {
                    Array.Copy(buffer, next, Count);
                }
            }
            finally
            {
                if (buffer is not null)
                    pool.Return(buffer);
                buffer = next;
            }
        }

        public readonly void Dispose()
        {
            if (buffer is not null)
                pool.Return(buffer);
        }
    }
}