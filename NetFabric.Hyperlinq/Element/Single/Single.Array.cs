using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
#if SPAN_SUPPORTED

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> Single<TSource>(this TSource[] source)
            => Single((ReadOnlySpan<TSource>)source.AsSpan());

#else

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> Single<TSource>(this TSource[] source)
            => Single(new ArraySegment<TSource>(source));

#endif
    }
}
