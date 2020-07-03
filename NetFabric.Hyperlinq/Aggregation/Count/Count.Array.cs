using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this TSource[] source)
            => source.Length;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this TSource[] source, Predicate<TSource> predicate)
            => Count((ReadOnlySpan<TSource>)source.AsSpan(), predicate);
    }
}

