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
        public static ref readonly TSource ElementAt<TSource>(this Span<TSource> source, int index)
            => ref ElementAt((ReadOnlySpan<TSource>)source, index);

        [Pure]
        [return: MaybeNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource ElementAtOrDefault<TSource>(this Span<TSource> source, int index)
            => ref ElementAtOrDefault((ReadOnlySpan<TSource>)source, index);
    }
}
