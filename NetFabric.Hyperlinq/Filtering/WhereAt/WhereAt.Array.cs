using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentWhereAtEnumerable<TSource> Where<TSource>(this TSource[] source, PredicateAt<TSource> predicate)
            => Where(new ArraySegment<TSource>(source), predicate);
    }
}

