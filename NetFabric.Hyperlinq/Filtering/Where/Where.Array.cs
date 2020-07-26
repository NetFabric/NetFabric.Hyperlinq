using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentWhereEnumerable<TSource> Where<TSource>(this TSource[] source, Predicate<TSource> predicate)
            => Where(new ArraySegment<TSource>(source), predicate);
    }
}

