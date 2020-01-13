using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource Single<TSource>(this Span<TSource> source)
            => ref Single<TSource>((ReadOnlySpan<TSource>)source);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource Single<TSource>(this Span<TSource> source, Predicate<TSource> predicate)
            => ref Single((ReadOnlySpan<TSource>)source, predicate);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource Single<TSource>(this Span<TSource> source, PredicateAt<TSource> predicate)
            => ref Single((ReadOnlySpan<TSource>)source, predicate);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource Single<TSource>(this Span<TSource> source, PredicateAt<TSource> predicate, out int index)
            => ref Single((ReadOnlySpan<TSource>)source, predicate, out index);

        [Pure]
        [return: MaybeNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource SingleOrDefault<TSource>(this Span<TSource> source)
            => ref SingleOrDefault<TSource>((ReadOnlySpan<TSource>)source);

        [Pure]
        [return: MaybeNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource SingleOrDefault<TSource>(this Span<TSource> source, Predicate<TSource> predicate)
            => ref SingleOrDefault((ReadOnlySpan<TSource>)source, predicate);

        [Pure]
        [return: MaybeNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource SingleOrDefault<TSource>(this Span<TSource> source, PredicateAt<TSource> predicate)
            => ref SingleOrDefault((ReadOnlySpan<TSource>)source, predicate);

        [Pure]
        [return: MaybeNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource SingleOrDefault<TSource>(this Span<TSource> source, PredicateAt<TSource> predicate, out int index)
            => ref SingleOrDefault((ReadOnlySpan<TSource>)source, predicate, out index);
    }
}
