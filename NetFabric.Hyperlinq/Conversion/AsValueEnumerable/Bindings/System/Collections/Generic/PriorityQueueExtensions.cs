#if NET6_0_OR_GREATER

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{

    public static class PriorityQueueExtensions
    {
        // PriorityQueue<TElement, TPriority>.UnorderedItemsCollection is reference-type that implements IReadOnlyCollection<TElement> and has a value-type enumerator that implements IEnumerator<TElement>

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyCollectionExtensions.ValueEnumerable<PriorityQueue<TElement, TPriority>.UnorderedItemsCollection, PriorityQueue<TElement, TPriority>.UnorderedItemsCollection.Enumerator, PriorityQueue<TElement, TPriority>.UnorderedItemsCollection.Enumerator, (TElement Element, TPriority Priority), GetEnumerator<TElement, TPriority>, GetEnumerator<TElement, TPriority>> AsValueEnumerable<TElement, TPriority>(this PriorityQueue<TElement, TPriority>.UnorderedItemsCollection source)
            => ReadOnlyCollectionExtensions.AsValueEnumerable<PriorityQueue<TElement, TPriority>.UnorderedItemsCollection, PriorityQueue<TElement, TPriority>.UnorderedItemsCollection.Enumerator, (TElement Element, TPriority Priority), GetEnumerator<TElement, TPriority>>(source);

        [StructLayout(LayoutKind.Auto)]
        public readonly struct GetEnumerator<TElement, TPriority>
            : IFunction<PriorityQueue<TElement, TPriority>.UnorderedItemsCollection, PriorityQueue<TElement, TPriority>.UnorderedItemsCollection.Enumerator>
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public PriorityQueue<TElement, TPriority>.UnorderedItemsCollection.Enumerator Invoke(PriorityQueue<TElement, TPriority>.UnorderedItemsCollection source) 
                => source.GetEnumerator();
        }
    }
}

#endif