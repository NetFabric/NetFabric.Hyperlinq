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
        [return: MaybeNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource SingleOrDefault<TSource>(this Memory<TSource> source)
            => ref SingleOrDefault((ReadOnlySpan<TSource>)source.Span);
    }
}
