// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    /// <summary>
    /// A lightweight hash set.
    /// </summary>
    /// <typeparam name="TElement">The type of the set's items.</typeparam>
    sealed class Set<TElement> : ICollection<TElement>
    {
        /// <summary>
        /// The comparer used to hash and compare items in the set.
        /// </summary>
        readonly IEqualityComparer<TElement>? comparer;

        /// <summary>
        /// The hash buckets, which are used to index into the slots.
        /// </summary>
        int[] buckets;

        /// <summary>
        /// The slots, each of which store an item and its hash code.
        /// </summary>
        Slot[] slots;

        /// <summary>
        /// Constructs a set that compares items with the specified comparer.
        /// </summary>
        /// <param name="comparer">
        /// The comparer. If this is <c>null</c>, it defaults to <see cref="EqualityComparer{TElement}.Default"/>.
        /// </param>
        public Set(IEqualityComparer<TElement>? comparer)
        {
            if (comparer is null)
            {
                if (!typeof(TElement).IsValueType)
                    this.comparer = EqualityComparer<TElement>.Default;
            }
            else 
            {
                if (comparer != EqualityComparer<TElement>.Default)
                    this.comparer = comparer;
            }

            buckets = new int[7];
            slots = new Slot[7];
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
            int hashCode;
            if (Utils.UseDefault(comparer))
            {
                hashCode = value is null ? 0 : EqualityComparer<TElement>.Default.GetHashCode(value) & 0x7FFFFFFF;
                for (var i = buckets[hashCode % buckets.Length] - 1; i >= 0; i = slots[i].Next)
                {
                    if (slots[i].HashCode == hashCode && EqualityComparer<TElement>.Default.Equals(slots[i].Value, value))
                        return false;
                }
            }
            else
            {
                var comparer = this.comparer ?? EqualityComparer<TElement>.Default;
                hashCode = value is null ? 0 : comparer.GetHashCode(value) & 0x7FFFFFFF;
                for (var i = buckets[hashCode % buckets.Length] - 1; i >= 0; i = slots[i].Next)
                {
                    if (slots[i].HashCode == hashCode && comparer.Equals(slots[i].Value, value))
                        return false;
                }
            }

            if (Count == slots.Length)
                Resize();

            var index = Count;
            Count++;
            var bucket = hashCode % buckets.Length;
            ref var slot = ref slots[index];
            slot.HashCode = hashCode;
            slot.Value = value;
            slot.Next = buckets[bucket] - 1;
            buckets[bucket] = index + 1;
            return true;
        }

        /// <summary>
        /// Expands the capacity of this set to double the current capacity, plus one.
        /// </summary>
        void Resize()
        {
            var newSize = checked((Count * 2) + 1);
            var newBuckets = new int[newSize];
            var newSlots = new Slot[newSize];
            System.Array.Copy(slots, newSlots, Count);
            for (var i = 0; i < Count; i++)
            {
                var bucket = newSlots[i].HashCode % newSize;
                newSlots[i].Next = newBuckets[bucket] - 1;
                newBuckets[bucket] = i + 1;
            }

            buckets = newBuckets;
            slots = newSlots;
        }

        /// <summary>
        /// Creates an array from the items in this set.
        /// </summary>
        /// <returns>An array of the items in this set.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TElement[] ToArray()
        {
            var array = new TElement[Count];
            CopyTo(array, 0);
            return array;
        }

        /// <summary>
        /// Creates a list from the items in this set.
        /// </summary>
        /// <returns>A list of the items in this set.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public List<TElement> ToList()
            => new List<TElement>(this);

        /// <summary>
        /// The number of items in this set.
        /// </summary>
        public int Count { get; private set; }

        bool ICollection<TElement>.IsReadOnly 
            => true;
        void ICollection<TElement>.Add(TElement item) 
            => Throw.NotSupportedException();
        void ICollection<TElement>.Clear() 
            => Throw.NotSupportedException();
        bool ICollection<TElement>.Contains(TElement item) 
            => Throw.NotSupportedException<bool>();
        public void CopyTo(TElement[] array, int _)
        {
            for (var index = 0; index < Count; index++)
                array[index] = slots[index].Value;
        }
        bool ICollection<TElement>.Remove(TElement item) 
            => Throw.NotSupportedException<bool>();
        IEnumerator<TElement> IEnumerable<TElement>.GetEnumerator() 
            => Throw.NotSupportedException<IEnumerator<TElement>>();
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
            public TElement Value;
        }
    }
}