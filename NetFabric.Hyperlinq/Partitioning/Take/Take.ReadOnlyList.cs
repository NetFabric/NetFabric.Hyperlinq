using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static SkipTakeEnumerable<TEnumerable, TSource> Take<TEnumerable, TSource>(this TEnumerable source, int count)
            where TEnumerable : IReadOnlyList<TSource>
            => SkipTake<TEnumerable, TSource>(source, 0, count);
    }
}