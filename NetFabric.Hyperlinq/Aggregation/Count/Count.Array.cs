using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this TSource[] source)
            => source.Length;

#if SPAN_SUPPORTED

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this TSource[] source, Predicate<TSource> predicate)
            => Count((ReadOnlySpan<TSource>)source.AsSpan(), predicate);

#else

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this TSource[] source, Predicate<TSource> predicate)
            => Count(new ArraySegment<TSource>(source), predicate);

#endif
    }
}

