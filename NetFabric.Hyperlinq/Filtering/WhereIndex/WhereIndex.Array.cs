using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if SPAN_SUPPORTED
        public static MemoryWhereIndexEnumerable<TSource> Where<TSource>(this TSource[] source, PredicateAt<TSource> predicate)
            => Where(source.AsMemory(), predicate);
#else
        public static ReadOnlyList.WhereIndexEnumerable<TSource[], TSource> Where<TSource>(this TSource[] source, PredicateAt<TSource> predicate)
            => ReadOnlyList.Where(source, predicate);
#endif
    }
}

