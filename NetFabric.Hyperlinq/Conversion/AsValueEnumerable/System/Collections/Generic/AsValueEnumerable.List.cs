using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ListBindings
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.ArraySegmentValueEnumerable<TSource> AsValueEnumerable<TSource>(this List<TSource> source)
            => source.AsArraySegment().AsValueEnumerable();
    }
}