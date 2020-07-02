using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
#if SPAN_SUPPORTED

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemoryDistinctEnumerable<TSource> Distinct<TSource>(this TSource[] source, IEqualityComparer<TSource>? comparer = default)
            => Distinct((ReadOnlyMemory<TSource>)source.AsMemory(), comparer);

#else

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DistinctEnumerable<TSource> Distinct<TSource>(this TSource[] source, IEqualityComparer<TSource>? comparer = default)
            => Distinct(new ArraySegment<TSource>(source), comparer);

#endif
    }
}

