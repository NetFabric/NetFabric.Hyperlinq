using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static class ImmutableStackExtensions
    {
        // ImmutableStack<TSource> implements IEnumerable<TSource> and has two enumerators:
        // One that is a value-type and doesn't implement interfaces.
        // Another that is a reference-type and implements IEnumerator<TSource>.
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static EnumerableExtensions.ValueEnumerable<ImmutableStack<TSource>, ValueEnumerator<TSource>, ImmutableStack<TSource>.Enumerator, TSource, GetEnumerator<TSource>, GetEnumerator2<TSource>> AsValueEnumerable<TSource>(this ImmutableStack<TSource> source)
            => source.AsValueEnumerable<ImmutableStack<TSource>, ValueEnumerator<TSource>, ImmutableStack<TSource>.Enumerator, TSource, GetEnumerator<TSource>, GetEnumerator2<TSource>>();

        [StructLayout(LayoutKind.Auto)]
        public readonly struct GetEnumerator<TSource>
            : IFunction<ImmutableStack<TSource>, ValueEnumerator<TSource>> 
        {
            public ValueEnumerator<TSource> Invoke(ImmutableStack<TSource> source) 
                => new(((IEnumerable<TSource>)source).GetEnumerator());
        }

        [StructLayout(LayoutKind.Auto)]
        public readonly struct GetEnumerator2<TSource>
            : IFunction<ImmutableStack<TSource>, ImmutableStack<TSource>.Enumerator>
        {
            public ImmutableStack<TSource>.Enumerator Invoke(ImmutableStack<TSource> source) 
                => source.GetEnumerator();
        }
    }
}