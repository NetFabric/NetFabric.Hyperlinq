using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this ReadOnlyMemory<TSource> source, Predicate<TSource> predicate)
            => All(source.Span, predicate);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this ReadOnlyMemory<TSource> source, PredicateAt<TSource> predicate)
            => All(source.Span, predicate);
    }
}

