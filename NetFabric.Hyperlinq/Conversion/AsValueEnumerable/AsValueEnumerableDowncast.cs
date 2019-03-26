using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class AsValueEnumerableExtensions
    {
        public static Enumerable.AsValueEnumerableEnumerable<IEnumerable<TSource>, IEnumerator<TSource>, TSource> AsValueEnumerable<TSource>(this IEnumerable<TSource> source)
            => Enumerable.AsValueEnumerable<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source);
    }
}
