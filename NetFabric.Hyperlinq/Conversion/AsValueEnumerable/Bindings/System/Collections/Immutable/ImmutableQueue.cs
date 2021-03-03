using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static class ImmutableQueueExtensions
    {
        // ImmutableQueue<TSource> is reference-type that implements IEnumerable<TSource> and has two enumerators:
        // One that is a value-type and doesn't implement interfaces.
        // Another that is a reference-type and implements IEnumerator<TSource>.
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static EnumerableExtensions.ValueEnumerable<ImmutableQueue<TSource>, ValueEnumerator<TSource>, ImmutableQueue<TSource>.Enumerator, TSource, GetEnumerator<TSource>, GetEnumerator2<TSource>> AsValueEnumerable<TSource>(this ImmutableQueue<TSource> source)
            => source.AsValueEnumerable<ImmutableQueue<TSource>, ValueEnumerator<TSource>, ImmutableQueue<TSource>.Enumerator, TSource, GetEnumerator<TSource>, GetEnumerator2<TSource>>();

        [StructLayout(LayoutKind.Auto)]
        public readonly struct GetEnumerator<TSource>
            : IFunction<ImmutableQueue<TSource>, ValueEnumerator<TSource>> 
        {
            public ValueEnumerator<TSource> Invoke(ImmutableQueue<TSource> source) 
                => new(((IEnumerable<TSource>)source).GetEnumerator());
        }

        [StructLayout(LayoutKind.Auto)]
        public readonly struct GetEnumerator2<TSource>
            : IFunction<ImmutableQueue<TSource>, ImmutableQueue<TSource>.Enumerator>
        {
            public ImmutableQueue<TSource>.Enumerator Invoke(ImmutableQueue<TSource> source) 
                => source.GetEnumerator();
        }
    }
}