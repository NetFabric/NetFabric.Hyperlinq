#if NET60_OR_GREATER

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{

    public static class PriorityQueueExtensions
    {
        // PriorityQueue<TSource> is reference-type that implements IReadOnlyCollection<TSource> and has a value-type enumerator that implements IEnumerator<TSource>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyCollectionExtensions.ValueEnumerable<PriorityQueue<TSource>, PriorityQueue<TSource>.Enumerator, PriorityQueue<TSource>.Enumerator, TSource, GetEnumerator<TSource>, GetEnumerator<TSource>> AsValueEnumerable<TSource>(this PriorityQueue<TSource> source)
            => ReadOnlyCollectionExtensions.AsValueEnumerable<PriorityQueue<TSource>, PriorityQueue<TSource>.Enumerator, TSource, GetEnumerator<TSource>>(source);

        [StructLayout(LayoutKind.Auto)]
        public readonly struct GetEnumerator<TSource>
            : IFunction<PriorityQueue<TSource>, PriorityQueue<TSource>.Enumerator>
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public PriorityQueue<TSource>.Enumerator Invoke(PriorityQueue<TSource> source) 
                => source.GetEnumerator();
        }
    }
}

#endif