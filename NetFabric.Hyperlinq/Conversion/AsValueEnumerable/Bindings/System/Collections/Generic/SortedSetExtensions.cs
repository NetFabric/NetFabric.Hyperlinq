using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static class SortedSetExtensions
    {
        // SortedSet<TSource> is reference-type that implements IReadOnlyCollection<TSource> and has a value-type enumerator that implements IEnumerator<TSource>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyCollectionExtensions.ValueEnumerable<SortedSet<TSource>, SortedSet<TSource>.Enumerator, SortedSet<TSource>.Enumerator, TSource, GetEnumerator<TSource>, GetEnumerator<TSource>> AsValueEnumerable<TSource>(this SortedSet<TSource> source)
            => ReadOnlyCollectionExtensions.AsValueEnumerable<SortedSet<TSource>, SortedSet<TSource>.Enumerator, TSource, GetEnumerator<TSource>>(source);

        [StructLayout(LayoutKind.Auto)]
        public readonly struct GetEnumerator<TSource>
            : IFunction<SortedSet<TSource>, SortedSet<TSource>.Enumerator>
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SortedSet<TSource>.Enumerator Invoke(SortedSet<TSource> source) 
                => source.GetEnumerator();
        }
    }
}