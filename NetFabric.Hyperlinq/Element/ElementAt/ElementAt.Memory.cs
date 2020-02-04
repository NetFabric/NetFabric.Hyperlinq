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
        public static ref readonly TSource ElementAt<TSource>(this Memory<TSource> source, int index)
            => ref ElementAt<TSource>((ReadOnlySpan<TSource>)source.Span, index);

        [Pure]
        [return: MaybeNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource ElementAtOrDefault<TSource>(this Memory<TSource> source, int index)
            => ref ElementAtOrDefault<TSource>((ReadOnlySpan<TSource>)source.Span, index);
    }
}
