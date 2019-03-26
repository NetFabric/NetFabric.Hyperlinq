using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class AsValueReadOnlyListExtensions
    {
        public static ReadOnlyList.AsValueReadOnlyListEnumerable<IReadOnlyList<TSource>, TSource> AsValueReadOnlyList<TSource>(this IReadOnlyList<TSource> source)
            => ReadOnlyList.AsValueReadOnlyList<IReadOnlyList<TSource>, TSource>(source);
    }
}
