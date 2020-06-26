using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if SPAN_SUPPORTED
        public static Memory<TSource> Take<TSource>(this TSource[] source, int count)
            => Take(source.AsMemory(), count);
#else
        public static SkipTakeEnumerable<TSource> Take<TSource>(this TSource[] source, int count)
            => SkipTake(source, 0, count);
#endif
    }
}
