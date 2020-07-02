using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
#if SPAN_SUPPORTED

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Memory<TSource> Skip<TSource>(this TSource[] source, int count)
            => Skip(source.AsMemory(), count);

#else

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegment<TSource> Skip<TSource>(this TSource[] source, int count)
        {
            var (skipCount, takeCount) = Utils.Skip(source.Length, count);
            return new ArraySegment<TSource>(source, skipCount, takeCount);
        }

#endif
    }
}
