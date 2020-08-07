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
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    /// <summary>
    /// A lightweight hash set.
    /// </summary>
    /// <typeparam name="TElement">The type of the set's items.</typeparam>
    struct Set<TElement> : ICollection<TElement>, IDisposable
    {
        readonly ArrayPool<int> bucketsPool;
        readonly ArrayPool<Slot> slotsPool;

        /// <summary>
        /// The comparer used to hash and compare items in the set.
        /// </summary>
        readonly IEqualityComparer<TElement> comparer;

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
        public bool Add([AllowNull] TElement value)
        {
            if (Count == 0)
            {
                buckets = bucketsPool.Rent(7);
                Array.Clear(buckets, 0, buckets.Length);

                slots = slotsPool.Rent(7);
                Array.Clear(slots, 0, slots.Length);
            }

            Debug.Assert(buckets is object);
            Debug.Assert(slots is object);

            var hashCode = value switch
            { 
                null => 0,
                _ => comparer.GetHashCode(value) & 0x7FFFFFFF,
            };
            if (Utils.IsValueType<TElement>() && ReferenceEquals(comparer, EqualityComparer<TElement>.Default))
            {
                for (var index = buckets[hashCode % buckets.Length] - 1; index >= 0; index = slots[index].Next)
                {
                    if (slots[index].HashCode == hashCode && EqualityComparer<TElement>.Default.Equals(slots[index].Value!, value!))
                        return false;
                }
            }
            else
            {
                for (var index = buckets[hashCode % buckets.Length] - 1; index >= 0; index = slots[index].Next)
                {
                    if (slots[index].HashCode == hashCode && comparer.Equals(slots[index].Value!, value!))
                        return false;
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
            Debug.Assert(buckets is object);
            Debug.Assert(slots is object);

            var newSize = checked((Count * 2) + 1);
            var newBuckets = bucketsPool.Rent(newSize);
            var newSlots = slotsPool.Rent(newSize);
            try
            {
                Array.Copy(slots, newSlots, Count);
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly TElement[] ToArray()
        {
#if NET5_0
            var array = GC.AllocateUninitializedArray<TElement>(Count);
#else
            var array = new TElement[Count];
#endif
            CopyTo(array);
            return array;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly IMemoryOwner<TElement> ToArray(MemoryPool<TElement> pool)
        {
            var result = pool.RentSliced(Count);
            CopyTo(result.Memory.Span);
            return result;
        }

        /// <summary>
        /// Creates a list from the items in this set.
        /// </summary>
        /// <returns>A list of the items in this set.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly List<TElement> ToList()
            => new List<TElement>(this);

        /// <summary>
        /// The number of items in this set.
        /// </summary>
        public int Count { get; private set; }

        bool ICollection<TElement>.IsReadOnly 
            => true;

        public readonly void CopyTo(Span<TElement> span)
        {
            if (slots is object)
            {
                for (var index = 0; index < Count; index++)
                    span[index] = slots[index].Value!;
            }
        }

        public readonly void CopyTo(TElement[] array)
        {
            if (slots is object)
            {
                for (var index = 0; index < Count; index++)
                    array[index] = slots[index].Value!;
            }
        }

        public readonly void CopyTo(TElement[] array, int arrayIndex)
        {
            if (slots is object)
            {
                if (arrayIndex == 0)
                {
                    for (var index = 0; index < Count; index++)
                        array[index] = slots[index].Value!;
                }
                else
                {
                    for (var index = 0; index < Count; index++)
                        array[index + arrayIndex] = slots[index].Value!;
                }
            }
        }

        [ExcludeFromCodeCoverage]
        void ICollection<TElement>.Add(TElement item) 
            => Throw.NotSupportedException();
        [ExcludeFromCodeCoverage]
        void ICollection<TElement>.Clear() 
            => Throw.NotSupportedException();
        [ExcludeFromCodeCoverage]
        bool ICollection<TElement>.Contains(TElement item) 
            => Throw.NotSupportedException<bool>();
        [ExcludeFromCodeCoverage]
        bool ICollection<TElement>.Remove(TElement item) 
            => Throw.NotSupportedException<bool>();
        [ExcludeFromCodeCoverage]
        IEnumerator<TElement> IEnumerable<TElement>.GetEnumerator() 
            => Throw.NotSupportedException<IEnumerator<TElement>>();
        [ExcludeFromCodeCoverage]
        IEnumerator IEnumerable.GetEnumerator() 
            => Throw.NotSupportedException<IEnumerator>();

        /// <summary>
        /// An entry in the hash set.
        /// </summary>
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
            [MaybeNull, AllowNull] public TElement Value;
        }

        public void Dispose()
        {
            if (buckets is object)
            {
                bucketsPool.Return(buckets);
                buckets = default;
            }
            if (slots is object)
            {
                slotsPool.Return(slots);
                slots = default;
            }
        }
    }
}