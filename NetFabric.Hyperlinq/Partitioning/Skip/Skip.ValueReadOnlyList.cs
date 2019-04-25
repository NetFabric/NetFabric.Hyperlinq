using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        public static SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> Skip<TEnumerable, TEnumerator, TSource>(this TEnumerable source, long count)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => SkipTake<TEnumerable, TEnumerator, TSource>(source, count, source.Count);
    }
}