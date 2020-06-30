using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
#if SPAN_SUPPORTED

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> First<TSource>(this TSource[] source)
            => First<TSource>((ReadOnlySpan<TSource>)source.AsSpan());

#else

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> First<TSource>(this TSource[] source)
            => First(new ArraySegment<TSource>(source));

#endif
    }
}
