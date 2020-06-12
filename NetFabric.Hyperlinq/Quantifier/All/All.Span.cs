using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this Span<TSource> source, Predicate<TSource> predicate)
            => All((ReadOnlySpan<TSource>)source, predicate);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this Span<TSource> source, PredicateAt<TSource> predicate)
            => All((ReadOnlySpan<TSource>)source, predicate);
    }
}

