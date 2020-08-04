using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static class ListExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegment<TSource> AsArraySegment<TSource>(this List<TSource> source)
            => new ArraySegment<TSource>(source.GetItems(), 0, source.Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Span<TSource> AsSpan<TSource>(this List<TSource> source)
            => source.GetItems().AsSpan().Slice(0, source.Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Memory<TSource> AsMemory<TSource>(this List<TSource> source)
            => source.GetItems().AsMemory().Slice(0, source.Count);

        class ListLayout<TSource>
        {
            public TSource[] Items = default!;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] GetItems<TSource>(this List<TSource> source)
            => Unsafe.As<List<TSource>, ListLayout<TSource>>(ref source).Items;
    }
}
