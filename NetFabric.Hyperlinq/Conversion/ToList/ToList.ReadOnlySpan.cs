using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        public static List<TSource> ToList<TSource>(this ReadOnlySpan<TSource> source)
        {
            var length = source.Length;
            var list = new List<TSource>(length);
            for (var index = 0; index < length; index++)
            {
                list.Add(source[index]);
            }
            return list;
        }
    }
}
