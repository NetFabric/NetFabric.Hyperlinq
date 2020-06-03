using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if SPAN_SUPPORTED
        public static Option<TSource> ElementAt<TSource>(this TSource[] source, int index)
            => ElementAt((ReadOnlySpan<TSource>)source.AsSpan(), index);
#else
        public static Option<TSource> ElementAt<TSource>(this TSource[] source, int index)
            => ReadOnlyList.ElementAt<TSource[], TSource>(source, index);
#endif
    }
}
