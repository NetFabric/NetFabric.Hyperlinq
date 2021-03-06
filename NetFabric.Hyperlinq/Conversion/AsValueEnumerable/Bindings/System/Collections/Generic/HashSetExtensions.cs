using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static class HashSetExtensions
    {
        // HashSet<TSource> is reference-type that implements IReadOnlyCollection<TSource> and has a value-type enumerator that implements IEnumerator<TSource>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyCollectionExtensions.ValueEnumerable<HashSet<TSource>, HashSet<TSource>.Enumerator, HashSet<TSource>.Enumerator, TSource, GetEnumerator<TSource>, GetEnumerator<TSource>> AsValueEnumerable<TSource>(this HashSet<TSource> source)
            => ReadOnlyCollectionExtensions.AsValueEnumerable<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource, GetEnumerator<TSource>>(source);

        [StructLayout(LayoutKind.Auto)]
        public readonly struct GetEnumerator<TSource>
            : IFunction<HashSet<TSource>, HashSet<TSource>.Enumerator>
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public HashSet<TSource>.Enumerator Invoke(HashSet<TSource> source) 
                => source.GetEnumerator();
        }
    }
}