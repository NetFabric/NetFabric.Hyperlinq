// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

// based on https://github.com/dotnet/runtime/blob/master/src/libraries/Common/src/System/Collections/Generic/LargeArrayBuilder.SpeedOpt.cs

using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    /// <summary>
    /// Helper type for building dynamically-sized arrays while minimizing allocations and copying.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    struct LargeArrayBuilder<T> 
        : ICollection<T>
        , IDisposable
    {
        const int defaultMinCapacity = 4;

        readonly ArrayPool<T> pool;
        readonly int maxCapacity;  // The maximum capacity this builder can have.
        ArrayBuilder<T[]> buffers; // After ResizeLimit * 2, we store previous buffers we've filled out here.
        T[] current;               // Current buffer we're reading into. If _count <= ResizeLimit, this is _first.
        int index;                 // Index into the current buffer.
        int storedCount;           // Number of items stored in buffers. 

        /// <summary>
        /// Constructs a new builder.
        /// </summary>
        /// <param name="initialize">Pass <c>true</c>.</param>
        public LargeArrayBuilder(ArrayPool<T> pool)
            : this(maxCapacity: int.MaxValue, pool: pool, arrayBuilderPool: ArrayPool<T[]>.Shared)
        {
        }

        /// <summary>
        /// Constructs a new builder with the specified maximum capacity.
        /// </summary>
        /// <param name="maxCapacity">The maximum capacity this builder can have.</param>
        /// <remarks>
        /// Do not add more than <paramref name="maxCapacity"/> items to this builder.
        /// </remarks>
        public LargeArrayBuilder(int maxCapacity, ArrayPool<T> pool, ArrayPool<T[]> arrayBuilderPool)
        {
            Debug.Assert(maxCapacity >= 0);

            this.pool = pool;
            this.maxCapacity = maxCapacity;
            buffers = new ArrayBuilder<T[]>(arrayBuilderPool);
            current = Array.Empty<T>();
            index = 0;
            storedCount = 0;
        }

        /// <summary>
        /// Gets the number of items added to the builder.
        /// </summary>
        public readonly int Count
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => storedCount + index;
        }

        /// <summary>
        /// Adds an item to this builder.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <remarks>
        /// Use <see cref="Add"/> if adding to the builder is a bottleneck for your use case.
        /// Otherwise, use <see cref="SlowAdd"/>.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(T item)
        {
            Debug.Assert(maxCapacity > Count);

            // Must be >= and not == to enable range check elimination
            if ((uint)index >= (uint)current.Length)
                AllocateBuffer();

            current[index++] = item;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddRef(in T item)
        {
            Debug.Assert(maxCapacity > Count);

            // Must be >= and not == to enable range check elimination
            if ((uint)index >= (uint)current.Length)
                AllocateBuffer();

            current[index++] = item;
        }

        /// <summary>
        /// Copies the contents of this builder to the specified array.
        /// </summary>
        /// <param name="array">The destination array.</param>
        /// <param name="arrayIndex">The index in <paramref name="array"/> to start copying to.</param>
        public readonly void CopyTo(T[] array, int arrayIndex)
            => CopyTo(array.AsSpan().Slice(arrayIndex));

        public readonly void CopyTo(Span<T> span)
        {
            var arrayIndex = 0;
            foreach (var buffer in buffers.AsSpan())
            {
                var length = buffer.Length;
                buffer.AsSpan().CopyTo(span.Slice(arrayIndex, length));

                arrayIndex += length;
            }
            if (arrayIndex < Count)
            {
                var length = Count - arrayIndex;
                current.AsSpan().Slice(0, length).CopyTo(span.Slice(arrayIndex, length));
            }
        }

        /// <summary>
        /// Adds an item to this builder.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <remarks>
        /// Use <see cref="Add"/> if adding to the builder is a bottleneck for your use case.
        /// Otherwise, use <see cref="SlowAdd"/>.
        /// </remarks>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void SlowAdd(T item) 
            => Add(item);

        /// <summary>
        /// Creates an array from the contents of this builder.
        /// </summary>
        public readonly T[] ToArray()
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var array = new T[Count];
            if (Count is not 0)
                CopyTo(array);
            return array;
        }

        public readonly IMemoryOwner<T> ToArray(MemoryPool<T> pool)
        {
            var result = pool.RentSliced(Count);
            if (Count is not 0)
                CopyTo(result.Memory.Span);
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        void AllocateBuffer()
        {
            // - On the first few adds, simply resize _first.
            // - When we pass ResizeLimit, allocate ResizeLimit elements for _current
            //   and start reading into _current. Set _index to 0.
            // - When _current runs out of space, add it to _buffers and repeat the
            //   above step, except with _current.Length * 2.
            // - Make sure we never pass _maxCapacity in all of the above steps.

            Debug.Assert((uint)maxCapacity > (uint)Count);
            Debug.Assert(index == current.Length, $"{nameof(AllocateBuffer)} was called, but there's more space.");

            // Example scenario: Let's say _count == 64.
            // Then our buffers look like this: | 8 | 8 | 16 | 32 |
            // As you can see, our count will be just double the last buffer.
            // Now, say _maxCapacity is 100. We will find the right amount to allocate by
            // doing min(64, 100 - 64). The lhs represents double the last buffer,
            // the rhs the limit minus the amount we've already allocated.

            var nextCapacity = defaultMinCapacity;
            if (Count is not 0)
            {
                buffers.Add(current);
                nextCapacity = Math.Min(Count, maxCapacity - Count);
                storedCount += index;
            }

            current = pool.Rent(nextCapacity);
            index = 0;
        }

        public readonly void Dispose()
        {
            pool.Return(current);
            foreach(var item in buffers.AsSpan())
                pool.Return(item);
            buffers.Dispose();
        }

        bool ICollection<T>.IsReadOnly
            => true;

        [ExcludeFromCodeCoverage]
        IEnumerator<T> IEnumerable<T>.GetEnumerator() => throw new NotSupportedException();
        [ExcludeFromCodeCoverage]
        IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
        [ExcludeFromCodeCoverage]
        void ICollection<T>.Add(T item) => throw new NotSupportedException();
        [ExcludeFromCodeCoverage]
        void ICollection<T>.Clear() => throw new NotSupportedException();
        [ExcludeFromCodeCoverage]
        bool ICollection<T>.Contains(T item) => throw new NotSupportedException();
        [ExcludeFromCodeCoverage]
        bool ICollection<T>.Remove(T item) => throw new NotSupportedException();
    }
}