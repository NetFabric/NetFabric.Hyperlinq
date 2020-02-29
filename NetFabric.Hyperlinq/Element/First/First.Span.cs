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
        [return: MaybeNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource FirstOrDefault<TSource>(this Span<TSource> source)
            => ref FirstOrDefault((ReadOnlySpan<TSource>)source);
    }
}
