using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static class QueueExtensions
    {
        // Queue<TSource> is reference-type that implements IReadOnlyCollection<TSource> and has a value-type enumerator that implements IEnumerator<TSource>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyCollectionExtensions.ValueEnumerable<Queue<TSource>, Queue<TSource>.Enumerator, Queue<TSource>.Enumerator, TSource, GetEnumerator<TSource>, GetEnumerator<TSource>> AsValueEnumerable<TSource>(this Queue<TSource> source)
            => ReadOnlyCollectionExtensions.AsValueEnumerable<Queue<TSource>, Queue<TSource>.Enumerator, TSource, GetEnumerator<TSource>>(source);

        [StructLayout(LayoutKind.Auto)]
        public readonly struct GetEnumerator<TSource>
            : IFunction<Queue<TSource>, Queue<TSource>.Enumerator>
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Queue<TSource>.Enumerator Invoke(Queue<TSource> source) 
                => source.GetEnumerator();
        }
    }
}