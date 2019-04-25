using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        public static List<TSource> ToList<TSource>(this Span<TSource> source)
        {
            var count = source.Length;
            var list = new List<TSource>(count);
            for (var index = 0; index < count; index++)
            {
                list.Add(source[index]);
            }
            return list;
        }
    }
}
