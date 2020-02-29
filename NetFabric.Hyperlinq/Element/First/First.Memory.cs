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
        public static ref readonly TSource First<TSource>(this Memory<TSource> source)
            => ref First<TSource>((ReadOnlySpan<TSource>)source.Span);

        [Pure]
        [return: MaybeNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource FirstOrDefault<TSource>(this Memory<TSource> source)
            => ref FirstOrDefault<TSource>((ReadOnlySpan<TSource>)source.Span);
    }
}
