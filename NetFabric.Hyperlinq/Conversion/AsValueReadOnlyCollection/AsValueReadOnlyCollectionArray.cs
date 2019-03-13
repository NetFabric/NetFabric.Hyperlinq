using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static ReadOnlyCollection.AsValueReadOnlyCollectionEnumerable<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource> AsValueReadOnlyCollection<TSource>(this TSource[] source)
            => ReadOnlyCollection.AsValueReadOnlyCollection<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);
    }
}
