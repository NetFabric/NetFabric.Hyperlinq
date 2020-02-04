using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this Memory<TSource> source)
            => source.Length != 0;

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this Memory<TSource> source, Predicate<TSource> predicate)
            => Any((ReadOnlySpan<TSource>)source.Span, predicate);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this Memory<TSource> source, PredicateAt<TSource> predicate)
            => Any((ReadOnlySpan<TSource>)source.Span, predicate);
    }
}

