using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this Span<TSource> source)
            => source.Length;

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this Span<TSource> source, Predicate<TSource> predicate)
            => Count((ReadOnlySpan<TSource>)source, predicate);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this Span<TSource> source, PredicateAt<TSource> predicate)
            => Count((ReadOnlySpan<TSource>)source, predicate);
    }
}

