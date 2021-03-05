using System;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static class ImmutableArrayExtensions
    {
        // Get the inner array and return its IValueEnumerable<> wrapper.
        // Do not use the available AsSpan() or AsMemory() because the enumerables for ReadOnlySpan<> do not
        // implement IEnumerable<>, restricting its use, and the enumerables for ReadOnlyMemory<> are less efficient 
        // because they call .Span in each iteration.

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.ArraySegmentValueEnumerable<TSource> AsValueEnumerable<TSource>(this ImmutableArray<TSource> source)
            => source.GetArray().AsValueEnumerable();
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] GetArray<TSource>(this ImmutableArray<TSource> source)
            => Unsafe.As<ImmutableArray<TSource>, TSource[]?>(ref source) ?? Array.Empty<TSource>();
    }
}
