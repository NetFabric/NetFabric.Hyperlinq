using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemoryDistinctEnumerable<TSource> Distinct<TSource>(this Memory<TSource> source, IEqualityComparer<TSource>? comparer = null)
            => Distinct((ReadOnlyMemory<TSource>)source, comparer);
    }
}

