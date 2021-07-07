using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentValueEnumerable<TSource> AsValueEnumerable<TSource>(this TSource[] source)
            => new(new ArraySegment<TSource>(source));
    }
}