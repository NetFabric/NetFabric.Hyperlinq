using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if SPAN_SUPPORTED
        public static Option<TSource> First<TSource>(this TSource[] source)
            => First<TSource>((ReadOnlySpan<TSource>)source.AsSpan());
#else
        public static Option<TSource> First<TSource>(this TSource[] source)
            => ReadOnlyList.First<TSource[], TSource>(source);
#endif
    }
}
