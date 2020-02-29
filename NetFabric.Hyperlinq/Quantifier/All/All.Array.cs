using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this TSource[] source, Predicate<TSource> predicate)
            => All((ReadOnlySpan<TSource>)source.AsSpan(), predicate);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this TSource[] source, PredicateAt<TSource> predicate)
            => All((ReadOnlySpan<TSource>)source.AsSpan(), predicate);
    }
}

