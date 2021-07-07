// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

// based on https://github.com/dotnet/runtime/blob/master/src/libraries/System.Linq/src/System/Linq/Set.cs

using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    /// <summary>
    /// A lightweight hash set.
    /// </summary>
    /// <typeparam name="TElement">The type of the set's items.</typeparam>
    [StructLayout(LayoutKind.Auto)]
    struct Set<TElement> : ICollection<TElement>, IDisposable
    {
        readonly ArrayPool<int> bucketsPool;
        readonly ArrayPool<Slot> slotsPool;

        /// <summary>
        /// The comparer used to hash and compare items in the set.
        /// </summary>
        readonly IEqualityComparer<TElement> comparer;

        readonly bool useDefaultComparer;

        /// <summary>
        /// The hash buckets, which are used to index into the slots.
        /// </summary>
        int[]? buckets;

        /// <summary>
        /// The slots, each of which store an item and its hash code.
        /// </summary>
        Slot[]? slots;

        /// <summary>
        /// Constructs a set that compares items with the specified comparer.
        /// </summary>
        /// <param name="comparer">
        /// The comparer. If this is <c>null</c>, it defaults to <see cref="EqualityComparer{TElement}.Default"/>.
        /// </param>
        public Set(IEqualityComparer<TElement>? comparer = default)
        {
            bucketsPool = ArrayPool<int>.Shared;
            slotsPool = ArrayPool<Slot>.Shared;
            useDefaultComparer = comparer.UseDefaultComparer();
            this.comparer = comparer ?? EqualityComparer<TElement>.Default;
            buckets = default;
            slots = default;
            Count = 0;
        }

        /// <summary>
        /// Attempts to add an item to this set.
        /// </summary>
        /// <param name="value">The item to add.</param>
        /// <returns>
        /// <c>true</c> if the item was not in the set; otherwise, <c>false</c>.
        /// </returns>
        public bool Add(TElement value)
        {
            if (Count is 0)
            {
                buckets = bucketsPool.Rent(7);
                Array.Clear(buckets, 0, buckets.Length);

                slots = slotsPool.Rent(7);
                Array.Clear(slots, 0, slots.Length);
            }

            Debug.Assert(buckets is not null);
            Debug.Assert(slots is not null);

            var hashCode = 0;
            if (useDefaultComparer)
            {
                if (value is not null)
                    hashCode = EqualityComparer<TElement>.Default.GetHashCode(value) & 0x7FFFFFFF;

                var index = buckets[hashCode % buckets.Length] - 1;
                while (index >= 0 && index < slots.Length)
                {
                    ref readonly var current = ref slots[index];
                    if (current.HashCode == hashCode && EqualityComparer<TElement>.Default.Equals(current.Value, value))
                        return false;

                    index = current.Next;
                }
            }
            else
            {
                if (value is not null)
                    hashCode = comparer.GetHashCode(value) & 0x7FFFFFFF;

                var index = buckets[hashCode % buckets.Length] - 1;
                while (index >= 0 && index < slots.Length)
                {
                    ref readonly var current = ref slots[index];
                    if (current.HashCode == hashCode && comparer.Equals(current.Value, value))
                        return false;

                    index = current.Next;
                }
            }

            if (Count == slots.Length || Count == buckets.Length)
                Resize();

            var bucket = hashCode % buckets.Length;
            ref var slot = ref slots[Count];
            slot.HashCode = hashCode;
            slot.Value = value;
            slot.Next = buckets[bucket] - 1;
            buckets[bucket] = Count + 1;
            Count++;

            return true;
        }

        /// <summary>
        /// Expands the capacity of this set to double the current capacity, plus one.
        /// </summary>
        void Resize()
        {
            Debug.Assert(buckets is not null);
            Debug.Assert(slots is not null);

            var newSize = checked((Count * 2) + 1);
            var newBuckets = bucketsPool.Rent(newSize);
            var newSlots = slotsPool.Rent(newSize);
            try
            {
                Array.Copy(slots!, newSlots, Count);
                Array.Clear(newSlots, Count, newSlots.Length - Count);

                Array.Clear(newBuckets, 0, newBuckets.Length);
                for (var index = 0; index < Count; index++)
                {
                    var bucket = newSlots[index].HashCode % newSize;
                    newSlots[index].Next = newBuckets[bucket] - 1;
                    newBuckets[bucket] = index + 1;
                }
            }
            finally
            {
                bucketsPool.Return(buckets);
                slotsPool.Return(slots);

                buckets = newBuckets;
                slots = newSlots;
            }
        }

        /// <summary>
        /// Creates an array from the items in this set.
        /// </summary>
        /// <returns>An array of the items in this set.</returns>
        public readonly TElement[] ToArray()
        {
            var array = Utils.AllocateUninitializedArray<TElement>(Count);
            CopyTo(array);
            return array;
        }

        public readonly Lease<TElement> ToArray(ArrayPool<TElement> pool, bool clearOnDispose)
        {
            var result = pool.Lease(Count, clearOnDispose);
            CopyTo(result.Memory.Span);
            return result;
        }

        /// <summary>
        /// Creates a list from the items in this set.
        /// </summary>
        /// <returns>A list of the items in this set.</returns>
        public readonly List<TElement> ToList()
            => Count switch
            {
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                0 => new List<TElement>(),
                _ => ToArray().AsList()
            };

        /// <summary>
        /// The number of items in this set.
        /// </summary>
        public int Count { get; private set; }

        bool ICollection<TElement>.IsReadOnly 
            => true;

        public readonly void CopyTo(Span<TElement> span)
        {
            if (Count is 0)
                return;
            
            if (span.Length < Count)
                Throw.ArgumentException(Resource.DestinationNotLongEnough, nameof(span));

            var source = slots!.AsSpan(0, Count);
            for (var index = 0; index < source.Length; index++)
            {
                ref readonly var slot = ref source[index];
                span[index] = slot.Value;
            }
        }

        public readonly void CopyTo(TElement[] array, int arrayIndex)
            => CopyTo(array.AsSpan(arrayIndex));

        [ExcludeFromCodeCoverage]
        readonly void ICollection<TElement>.Add(TElement item)
            => Throw.NotSupportedException();
        [ExcludeFromCodeCoverage]
        readonly void ICollection<TElement>.Clear() 
            => Throw.NotSupportedException();
        [ExcludeFromCodeCoverage]
        readonly bool ICollection<TElement>.Contains(TElement item)
            => Throw.NotSupportedException<bool>();
        [ExcludeFromCodeCoverage]
        readonly bool ICollection<TElement>.Remove(TElement item) 
            => Throw.NotSupportedException<bool>();
        [ExcludeFromCodeCoverage]
        readonly IEnumerator<TElement> IEnumerable<TElement>.GetEnumerator()
            => Throw.NotSupportedException<IEnumerator<TElement>>();
        [ExcludeFromCodeCoverage]
        readonly IEnumerator IEnumerable.GetEnumerator()
            => Throw.NotSupportedException<IEnumerator>();

        /// <summary>
        /// An entry in the hash set.
        /// </summary>
        [StructLayout(LayoutKind.Auto)]
        struct Slot
        {
            /// <summary>
            /// The hash code of the item.
            /// </summary>
            public int HashCode;

            /// <summary>
            /// In the case of a hash collision, the index of the next slot to probe.
            /// </summary>
            public int Next;

            /// <summary>
            /// The item held by this slot.
            /// </summary>
            public TElement Value;
        }

        public void Dispose()
        {
            if (buckets is not null)
            {
                bucketsPool.Return(buckets);
                buckets = default;
            }
            if (slots is not null)
            {
                slotsPool.Return(slots);
                slots = default;
            }
        }
    }
}