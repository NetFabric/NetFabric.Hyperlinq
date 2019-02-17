using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        public static List<TSource> ToList<TEnumerable, TSource>(this TEnumerable source)
            where TEnumerable : IReadOnlyCollection<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            var count = source.Count;
            var list = new List<TSource>(count);
            list.AddRange(source);
            return list;
        }
    }
}
