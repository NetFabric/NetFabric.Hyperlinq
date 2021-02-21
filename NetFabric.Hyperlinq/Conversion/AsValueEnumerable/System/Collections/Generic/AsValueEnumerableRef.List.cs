using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ListBindings
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.ArraySegmentValueEnumerableRef<TSource> AsValueEnumerableRef<TSource>(this List<TSource> source)
            => source.AsArraySegment().AsValueEnumerableRef();
    }
}