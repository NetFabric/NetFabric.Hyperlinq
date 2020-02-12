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
        public static ref readonly TSource First<TSource>(this Span<TSource> source)
            => ref First((ReadOnlySpan<TSource>)source);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource First<TSource>(this Span<TSource> source, Predicate<TSource> predicate)
            => ref First((ReadOnlySpan<TSource>)source, predicate);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource First<TSource>(this Span<TSource> source, PredicateAt<TSource> predicate)
            => ref First((ReadOnlySpan<TSource>)source, predicate);

        [Pure]
        [return: MaybeNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource FirstOrDefault<TSource>(this Span<TSource> source)
            => ref FirstOrDefault((ReadOnlySpan<TSource>)source);

        [Pure]
        [return: MaybeNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource FirstOrDefault<TSource>(this Span<TSource> source, Predicate<TSource> predicate)
            => ref FirstOrDefault((ReadOnlySpan<TSource>)source, predicate);

        [Pure]
        [return: MaybeNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource FirstOrDefault<TSource>(this Span<TSource> source, PredicateAt<TSource> predicate)
            => ref FirstOrDefault((ReadOnlySpan<TSource>)source, predicate);
    }
}
