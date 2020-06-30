using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
#if SPAN_SUPPORTED

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> ElementAt<TSource>(this TSource[] source, int index)
            => ElementAt((ReadOnlySpan<TSource>)source.AsSpan(), index);

#else

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> ElementAt<TSource>(this TSource[] source, int index)
            => ElementAt(new ArraySegment<TSource>(source), index);

#endif
    }
}
