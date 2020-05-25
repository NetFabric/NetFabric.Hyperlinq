using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemoryWhereEnumerable<TSource> Where<TSource>(this Memory<TSource> source, Predicate<TSource> predicate)
            => Where((ReadOnlyMemory<TSource>)source, predicate);
    }
}

