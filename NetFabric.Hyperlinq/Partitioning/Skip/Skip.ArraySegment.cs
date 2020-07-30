using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegment<TSource> Skip<TSource>(this in ArraySegment<TSource> source, int count)
        {
            if (source.Array is null)
                return source;

            var (skipCount, takeCount) = Utils.Skip(source.Count, count);
            return new ArraySegment<TSource>(source.Array!, source.Offset + skipCount, takeCount);
        }
    }
}
