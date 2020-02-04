using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> ToList<TSource>(this Span<TSource> source)
            => ToList((ReadOnlySpan<TSource>)source);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> ToList<TSource>(this Span<TSource> source, Predicate<TSource> predicate)
            => ToList((ReadOnlySpan<TSource>)source, predicate);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> ToList<TSource>(this Span<TSource> source, PredicateAt<TSource> predicate)
            => ToList((ReadOnlySpan<TSource>)source, predicate);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TResult> ToList<TSource, TResult>(this Span<TSource> source, Selector<TSource, TResult> selector)
            => ToList((ReadOnlySpan<TSource>)source, selector);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TResult> ToList<TSource, TResult>(this Span<TSource> source, SelectorAt<TSource, TResult> selector)
            => ToList((ReadOnlySpan<TSource>)source, selector);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TResult> ToList<TSource, TResult>(this Span<TSource> source, Predicate<TSource> predicate, Selector<TSource, TResult> selector)
            => ToList((ReadOnlySpan<TSource>)source, predicate, selector);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TResult> ToList<TSource, TResult>(this Span<TSource> source, PredicateAt<TSource> predicate, SelectorAt<TSource, TResult> selector)
            => ToList((ReadOnlySpan<TSource>)source, predicate, selector);
    }
}
