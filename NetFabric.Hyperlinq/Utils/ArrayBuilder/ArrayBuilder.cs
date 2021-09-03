// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

// based on https://github.com/dotnet/runtime/blob/master/src/libraries/Common/src/System/Collections/Generic/ArrayBuilder.cs

using System;
using System.Buffers;
using System.Diagnostics;
using System.Runtime.CompilerServices;

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
        public int Count 
            => index;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public readonly Span<T> AsSpan()
            => buffer.AsSpan(0, index);

        /// <summary>
        /// Adds an item to the backing array, resizing it if necessary.
        /// </summary>
        /// <param name="item">The item to add.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public void Add(T item)
        {
            // Must be >= and not == to enable range check elimination
            if ((uint)index >= (uint)buffer.Length)
                EnsureCapacity(Count + 1);

            buffer[index++] = item;
        }

        /// <summary>
        /// Adds an item to the backing array, without checking if there is room.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <remarks>
        /// Use this method if you know there is enough space in the <see cref="ArrayBuilder{T}"/>
        /// for another item, and you are writing performance-sensitive code.
        /// </remarks>
        // [MethodImpl(MethodImplOptions.AggressiveInlining)]
        // [SkipLocalsInit]
        // public void UncheckedAdd(T item)
        // {
        //     Debug.Assert(Count < Capacity);
        //
        //     buffer[Count++] = item;
        // }

        [SkipLocalsInit]
        void EnsureCapacity(int minimum)
        {
            Debug.Assert(minimum > index);

            var capacity = index;
            var nextCapacity = capacity switch
            { 
                0 => defaultMinCapacity,
                _ => 2 * capacity,
            };

            if ((uint)nextCapacity > (uint)maxCoreClrArrayLength)
                nextCapacity = Math.Max(capacity + 1, maxCoreClrArrayLength);

            nextCapacity = Math.Max(nextCapacity, minimum);

            var next = pool.Rent(nextCapacity);
            if (index is not 0)
            {
                Array.Copy(buffer, next, Count);
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