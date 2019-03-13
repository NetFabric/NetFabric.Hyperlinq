using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static Enumerable.AsValueEnumerableEnumerable<IEnumerable<TSource>, IEnumerator<TSource>, TSource> AsValueEnumerable<TSource>(this TSource[] source)
            => Enumerable.AsValueEnumerable<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source);
    }
}
