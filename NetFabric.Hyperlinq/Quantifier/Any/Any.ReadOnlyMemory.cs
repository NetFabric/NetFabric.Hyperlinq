using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this ReadOnlyMemory<TSource> source)
            => source.Length != 0;

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this ReadOnlyMemory<TSource> source, Predicate<TSource> predicate)
            => Any(source.Span, predicate);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this ReadOnlyMemory<TSource> source, PredicateAt<TSource> predicate)
            => Any(source.Span, predicate);
    }
}

