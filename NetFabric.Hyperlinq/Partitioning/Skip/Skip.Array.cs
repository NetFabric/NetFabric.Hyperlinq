using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if SPAN_SUPPORTED
        public static Memory<TSource> Skip<TSource>(this TSource[] source, int count)
            => Skip(source.AsMemory(), count);
#else
        public static SkipTakeEnumerable<TSource> Skip<TSource>(this TSource[] source, int count)
            => SkipTake<TSource>(source, count, source.Length);
#endif
    }
}
