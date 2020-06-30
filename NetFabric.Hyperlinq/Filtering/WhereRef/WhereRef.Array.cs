using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
#if SPAN_SUPPORTED

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemoryWhereRefEnumerable<TSource> WhereRef<TSource>(this TSource[] source, Predicate<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return WhereRef(source.AsMemory(), predicate);
        }

#else

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static WhereRefEnumerable<TSource> WhereRef<TSource>(this TSource[] source, Predicate<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return WhereRef(new ArraySegment<TSource>(source), predicate);
        }

#endif
    }
}

