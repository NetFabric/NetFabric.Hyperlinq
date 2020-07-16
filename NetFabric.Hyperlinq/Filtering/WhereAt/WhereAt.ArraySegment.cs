using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemoryWhereAtEnumerable<TSource> Where<TSource>(this in ArraySegment<TSource> source, PredicateAt<TSource> predicate)
            => Where(source.AsMemory(), predicate);
    }
}

