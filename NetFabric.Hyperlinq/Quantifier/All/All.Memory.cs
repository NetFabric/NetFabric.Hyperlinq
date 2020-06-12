using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this Memory<TSource> source, Predicate<TSource> predicate)
            => All((ReadOnlySpan<TSource>)source.Span, predicate);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this Memory<TSource> source, PredicateAt<TSource> predicate)
            => All((ReadOnlySpan<TSource>)source.Span, predicate);
    }
}

