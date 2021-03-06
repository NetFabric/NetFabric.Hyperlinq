using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static class LinkedListExtensions
    {
        // LinkedList<TSource> is reference-type that implements IReadOnlyCollection<TSource> and has a value-type enumerator that implements IEnumerator<TSource>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyCollectionExtensions.ValueEnumerable<LinkedList<TSource>, LinkedList<TSource>.Enumerator, LinkedList<TSource>.Enumerator, TSource, GetEnumerator<TSource>, GetEnumerator<TSource>> AsValueEnumerable<TSource>(this LinkedList<TSource> source)
            => ReadOnlyCollectionExtensions.AsValueEnumerable<LinkedList<TSource>, LinkedList<TSource>.Enumerator, TSource, GetEnumerator<TSource>>(source);

        [StructLayout(LayoutKind.Auto)]
        public readonly struct GetEnumerator<TSource>
            : IFunction<LinkedList<TSource>, LinkedList<TSource>.Enumerator>
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public LinkedList<TSource>.Enumerator Invoke(LinkedList<TSource> source) 
                => source.GetEnumerator();
        }
    }
}