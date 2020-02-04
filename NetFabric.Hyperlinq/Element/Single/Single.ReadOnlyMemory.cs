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
        public static ref readonly TSource Single<TSource>(this ReadOnlyMemory<TSource> source)
            => ref Single(source.Span);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource Single<TSource>(this ReadOnlyMemory<TSource> source, Predicate<TSource> predicate)
            => ref Single(source.Span, predicate);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource Single<TSource>(this ReadOnlyMemory<TSource> source, PredicateAt<TSource> predicate)
            => ref Single(source.Span, predicate);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource Single<TSource>(this ReadOnlyMemory<TSource> source, PredicateAt<TSource> predicate, out int index)
            => ref Single(source.Span, predicate, out index);

        [Pure]
        [return: MaybeNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource SingleOrDefault<TSource>(this ReadOnlyMemory<TSource> source)
            => ref SingleOrDefault(source.Span);

        [Pure]
        [return: MaybeNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource SingleOrDefault<TSource>(this ReadOnlyMemory<TSource> source, Predicate<TSource> predicate)
            => ref SingleOrDefault(source.Span, predicate);

        [Pure]
        [return: MaybeNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource SingleOrDefault<TSource>(this ReadOnlyMemory<TSource> source, PredicateAt<TSource> predicate)
            => ref SingleOrDefault(source.Span, predicate);

        [Pure]
        [return: MaybeNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource SingleOrDefault<TSource>(this ReadOnlyMemory<TSource> source, PredicateAt<TSource> predicate, out int index)
            => ref SingleOrDefault(source.Span, predicate, out index);
    }
}
