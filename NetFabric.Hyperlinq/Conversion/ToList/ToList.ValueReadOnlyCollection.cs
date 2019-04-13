using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        public static List<TSource> ToList<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            var count = source.Count;
            var list = new List<TSource>(count);
            if(count != 0)
                list.AddRange(ValueReadOnlyCollection.AsEnumerable<TEnumerable, TEnumerator, TSource>(source));
            return list;
        }
    }
}
