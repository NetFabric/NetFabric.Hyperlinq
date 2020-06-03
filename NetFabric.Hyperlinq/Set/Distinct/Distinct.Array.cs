using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if SPAN_SUPPORTED
        public static MemoryDistinctEnumerable<TSource> Distinct<TSource>(this TSource[] source, IEqualityComparer<TSource>? comparer = null)
            => Distinct((ReadOnlyMemory<TSource>)source.AsMemory(), comparer);
#else
        public static ReadOnlyList.DistinctEnumerable<TSource[], TSource> Distinct<TSource>(this TSource[] source, IEqualityComparer<TSource>? comparer = null)
            => ReadOnlyList.Distinct(source, comparer);
#endif
    }
}

