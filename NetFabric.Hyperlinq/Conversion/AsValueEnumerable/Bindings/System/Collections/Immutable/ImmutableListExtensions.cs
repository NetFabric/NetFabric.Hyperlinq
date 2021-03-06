using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static class ImmutableListExtensions
    {
        // ImmutableList<TSource> is reference-type that implements IReadOnlyCollection<TSource> and has a value-type enumerator that implements IEnumerator<TSource>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyCollectionExtensions.ValueEnumerable<ImmutableList<TSource>, ImmutableList<TSource>.Enumerator, ImmutableList<TSource>.Enumerator, TSource, GetEnumerator<TSource>, GetEnumerator<TSource>> AsValueEnumerable<TSource>(this ImmutableList<TSource> source)
            => ReadOnlyCollectionExtensions.AsValueEnumerable<ImmutableList<TSource>, ImmutableList<TSource>.Enumerator, TSource, GetEnumerator<TSource>>(source);

        [StructLayout(LayoutKind.Auto)]
        public readonly struct GetEnumerator<TSource>
            : IFunction<ImmutableList<TSource>, ImmutableList<TSource>.Enumerator>
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ImmutableList<TSource>.Enumerator Invoke(ImmutableList<TSource> source) 
                => source.GetEnumerator();
        }
    }
}