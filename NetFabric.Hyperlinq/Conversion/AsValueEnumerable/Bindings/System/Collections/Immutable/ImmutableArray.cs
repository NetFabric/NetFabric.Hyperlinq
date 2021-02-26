using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static class ImmutableArrayExtensions
    {
        // ImmutableArray<TSource> implements IReadOnlyList<TSource> 
        // No need for bindings
/*
        // ImmutableArray<TSource> implements IReadOnlyCollection<TSource> and has two enumerators:
        // One that is a value-type and doesn't implement interfaces.
        // Another that is a reference-type and implements IEnumerator<TSource>.
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyCollectionExtensions.ValueEnumerable<ImmutableArray<TSource>, ValueEnumerator<TSource>, ImmutableArray<TSource>.Enumerator, TSource, GetEnumerator<TSource>, GetEnumerator2<TSource>> AsValueEnumerable<TSource>(this ImmutableArray<TSource> source)
            => ReadOnlyCollectionExtensions.AsValueEnumerable<ImmutableArray<TSource>, ValueEnumerator<TSource>, ImmutableArray<TSource>.Enumerator, TSource, GetEnumerator<TSource>, GetEnumerator2<TSource>>(source);

        [StructLayout(LayoutKind.Auto)]
        public readonly struct GetEnumerator<TSource>
            : IFunction<ImmutableArray<TSource>, ValueEnumerator<TSource>> 
        {
            public ValueEnumerator<TSource> Invoke(ImmutableArray<TSource> source) 
                => new(((IEnumerable<TSource>)source).GetEnumerator());
        }

        [StructLayout(LayoutKind.Auto)]
        public readonly struct GetEnumerator2<TSource>
            : IFunction<ImmutableArray<TSource>, ImmutableArray<TSource>.Enumerator>
        {
            public ImmutableArray<TSource>.Enumerator Invoke(ImmutableArray<TSource> source) 
                => source.GetEnumerator();
        }
*/        
    }
}