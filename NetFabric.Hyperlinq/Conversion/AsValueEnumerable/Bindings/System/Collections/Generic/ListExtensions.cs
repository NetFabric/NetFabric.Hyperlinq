using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ListExtensions
    {
        // List<TSource> is simply converted to ArraySegment<TSource> and share its IValueEnumerable<TSource> wrapper.
        // It's not converted to ReadOnlySpan<TSource> because its enumerables cannot be casted to IEnumerable<TSource>, restricting its use.
        // It's not converted to ReadOnlyMemory<TSource> because it's less efficient in enumerables (it has to call .Span on each iteration).
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.ArraySegmentValueEnumerable<TSource> AsValueEnumerable<TSource>(this List<TSource> source)
            => source.AsArraySegment().AsValueEnumerable();
        
    }
}