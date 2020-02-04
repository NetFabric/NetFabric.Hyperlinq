using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource Single<TSource>(this Memory<TSource> source)
            => ref Single((ReadOnlySpan<TSource>)source.Span);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource Single<TSource>(this Memory<TSource> source, Predicate<TSource> predicate)
            => ref Single((ReadOnlySpan<TSource>)source.Span, predicate);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource Single<TSource>(this Memory<TSource> source, PredicateAt<TSource> predicate)
            => ref Single((ReadOnlySpan<TSource>)source.Span, predicate);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource Single<TSource>(this Memory<TSource> source, PredicateAt<TSource> predicate, out int index)
            => ref Single((ReadOnlySpan<TSource>)source.Span, predicate, out index);

        [Pure]
        [return: MaybeNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource SingleOrDefault<TSource>(this Memory<TSource> source)
            => ref SingleOrDefault((ReadOnlySpan<TSource>)source.Span);

        [Pure]
        [return: MaybeNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource SingleOrDefault<TSource>(this Memory<TSource> source, Predicate<TSource> predicate)
            => ref SingleOrDefault((ReadOnlySpan<TSource>)source.Span, predicate);

        [Pure]
        [return: MaybeNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource SingleOrDefault<TSource>(this Memory<TSource> source, PredicateAt<TSource> predicate)
            => ref SingleOrDefault((ReadOnlySpan<TSource>)source.Span, predicate);

        [Pure]
        [return: MaybeNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource SingleOrDefault<TSource>(this Memory<TSource> source, PredicateAt<TSource> predicate, out int index)
            => ref SingleOrDefault((ReadOnlySpan<TSource>)source.Span, predicate, out index);
    }
}
