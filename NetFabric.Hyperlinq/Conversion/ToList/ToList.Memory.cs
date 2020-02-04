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
        public static List<TSource> ToList<TSource>(this Memory<TSource> source)
            => ToList((ReadOnlySpan<TSource>)source.Span);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> ToList<TSource>(this Memory<TSource> source, Predicate<TSource> predicate)
            => ToList((ReadOnlySpan<TSource>)source.Span, predicate);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> ToList<TSource>(this Memory<TSource> source, PredicateAt<TSource> predicate)
            => ToList((ReadOnlySpan<TSource>)source.Span, predicate);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TResult> ToList<TSource, TResult>(this Memory<TSource> source, Selector<TSource, TResult> selector)
            => ToList((ReadOnlySpan<TSource>)source.Span, selector);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TResult> ToList<TSource, TResult>(this Memory<TSource> source, SelectorAt<TSource, TResult> selector)
            => ToList((ReadOnlySpan<TSource>)source.Span, selector);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TResult> ToList<TSource, TResult>(this Memory<TSource> source, Predicate<TSource> predicate, Selector<TSource, TResult> selector)
            => ToList((ReadOnlySpan<TSource>)source.Span, predicate, selector);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TResult> ToList<TSource, TResult>(this Memory<TSource> source, PredicateAt<TSource> predicate, SelectorAt<TSource, TResult> selector)
            => ToList((ReadOnlySpan<TSource>)source.Span, predicate, selector);
    }
}
