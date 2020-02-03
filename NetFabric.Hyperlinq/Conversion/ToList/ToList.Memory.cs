using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> ToList<TSource>(this Memory<TSource> source)
            => ToList((ReadOnlyMemory<TSource>)source);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> ToList<TSource>(this Memory<TSource> source, Predicate<TSource> predicate)
            => ToList((ReadOnlyMemory<TSource>)source, predicate);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> ToList<TSource>(this Memory<TSource> source, PredicateAt<TSource> predicate)
            => ToList((ReadOnlyMemory<TSource>)source, predicate);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TResult> ToList<TSource, TResult>(this Memory<TSource> source, Selector<TSource, TResult> selector)
            => ToList((ReadOnlyMemory<TSource>)source, selector);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TResult> ToList<TSource, TResult>(this Memory<TSource> source, SelectorAt<TSource, TResult> selector)
            => ToList((ReadOnlyMemory<TSource>)source, selector);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TResult> ToList<TSource, TResult>(this Memory<TSource> source, Predicate<TSource> predicate, Selector<TSource, TResult> selector)
            => ToList((ReadOnlyMemory<TSource>)source, predicate, selector);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TResult> ToList<TSource, TResult>(this Memory<TSource> source, PredicateAt<TSource> predicate, SelectorAt<TSource, TResult> selector)
            => ToList((ReadOnlyMemory<TSource>)source, predicate, selector);
    }
}
