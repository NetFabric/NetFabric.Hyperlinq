using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegment<TSource> Take<TSource>(this in ArraySegment<TSource> source, int count)
            => new ArraySegment<TSource>(source.Array, source.Offset, Utils.Take(source.Count, count));
    }
}
