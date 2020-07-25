using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Memory<TSource> Take<TSource>(this TSource[] source, int count)
            => new ArraySegment<TSource>(source, 0, Utils.Take(source.Length, count));
    }
}
