using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    static class ListExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegment<TSource> AsArraySegment<TSource>(this List<TSource> source)
            => new(source.GetItems(), 0, source.Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Span<TSource> AsSpan<TSource>(this List<TSource> source)
#if NET5_0
            => CollectionsMarshal.AsSpan(source);
#else
            => source.GetItems().AsSpan().Slice(0, source.Count);
#endif

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Memory<TSource> AsMemory<TSource>(this List<TSource> source)
            => source.GetItems().AsMemory().Slice(0, source.Count);

        // ReSharper disable once ClassNeverInstantiated.Local
        class ListLayout<TSource>
        {
            public readonly TSource[] Items = default!;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] GetItems<TSource>(this List<TSource> source)
            => Unsafe.As<List<TSource>, ListLayout<TSource>>(ref source).Items;
    }
}
