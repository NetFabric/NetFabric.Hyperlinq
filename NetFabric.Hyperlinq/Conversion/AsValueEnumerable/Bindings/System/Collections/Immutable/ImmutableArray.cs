using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static class ImmutableArrayExtensions
    {
        // ImmutableArray<TSource> is a value-type that implements IReadOnlyList<TSource>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyListExtensions.ValueEnumerable<ImmutableArray<TSource>, TSource> AsValueEnumerable<TSource>(this ImmutableArray<TSource> source)
            => source.AsValueEnumerable<ImmutableArray<TSource>, TSource>();
    }
}