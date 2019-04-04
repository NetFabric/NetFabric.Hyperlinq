using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static List<TSource> ToList<TEnumerable, TSource>(this TEnumerable source)
            where TEnumerable : IReadOnlyList<TSource>
        {
            var count = source.Count;
            var list = new List<TSource>(count);
            list.AddRange(source);
            return list;
        }
    }
}
