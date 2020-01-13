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
        public static ref readonly TSource First<TSource>(this ReadOnlyMemory<TSource> source)
            => ref First(source.Span);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource First<TSource>(this ReadOnlyMemory<TSource> source, Predicate<TSource> predicate)
            => ref First(source.Span, predicate);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource First<TSource>(this ReadOnlyMemory<TSource> source, PredicateAt<TSource> predicate)
            => ref First(source.Span, predicate);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource First<TSource>(this ReadOnlyMemory<TSource> source, PredicateAt<TSource> predicate, out int index)
            => ref First(source.Span, predicate, out index);

        [Pure]
        [return: MaybeNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource FirstOrDefault<TSource>(this ReadOnlyMemory<TSource> source)
            => ref FirstOrDefault(source.Span);

        [Pure]
        [return: MaybeNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource FirstOrDefault<TSource>(this ReadOnlyMemory<TSource> source, Predicate<TSource> predicate)
            => ref FirstOrDefault(source.Span, predicate);

        [Pure]
        [return: MaybeNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource FirstOrDefault<TSource>(this ReadOnlyMemory<TSource> source, PredicateAt<TSource> predicate)
            => ref FirstOrDefault(source.Span, predicate);

        [Pure]
        [return: MaybeNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource FirstOrDefault<TSource>(this ReadOnlyMemory<TSource> source, PredicateAt<TSource> predicate, out int index)
            => ref FirstOrDefault(source.Span, predicate, out index);
    }
}
