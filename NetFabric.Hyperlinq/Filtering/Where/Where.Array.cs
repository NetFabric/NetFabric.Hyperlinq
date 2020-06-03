using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if SPAN_SUPPORTED
        public static MemoryWhereEnumerable<TSource> Where<TSource>(this TSource[] source, Predicate<TSource> predicate)
            => Where(source.AsMemory(), predicate);
#else
        public static ReadOnlyList.WhereEnumerable<TSource[], TSource> Where<TSource>(this TSource[] source, Predicate<TSource> predicate)
            => ReadOnlyList.Where(source, predicate);
#endif
    }
}

