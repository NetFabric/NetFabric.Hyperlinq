using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static class ImmutableHashSetExtensions
    {
        // ImmutableHashSet<TSource> is reference-type that implements IReadOnlyCollection<TSource> and has a value-type enumerator that implements IEnumerator<TSource>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyCollectionExtensions.ValueEnumerable<ImmutableHashSet<TSource>, ImmutableHashSet<TSource>.Enumerator, ImmutableHashSet<TSource>.Enumerator, TSource, GetEnumerator<TSource>, GetEnumerator<TSource>> AsValueEnumerable<TSource>(this ImmutableHashSet<TSource> source)
            => ReadOnlyCollectionExtensions.AsValueEnumerable<ImmutableHashSet<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, GetEnumerator<TSource>>(source);

        [StructLayout(LayoutKind.Auto)]
        public readonly struct GetEnumerator<TSource>
            : IFunction<ImmutableHashSet<TSource>, ImmutableHashSet<TSource>.Enumerator>
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ImmutableHashSet<TSource>.Enumerator Invoke(ImmutableHashSet<TSource> source) 
                => source.GetEnumerator();
        }
    }
}