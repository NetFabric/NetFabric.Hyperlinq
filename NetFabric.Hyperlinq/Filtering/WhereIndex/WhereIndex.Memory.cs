using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemoryWhereIndexEnumerable<TSource> Where<TSource>(this Memory<TSource> source, PredicateAt<TSource> predicate)
            => Where((ReadOnlyMemory<TSource>)source, predicate);
    }
}

