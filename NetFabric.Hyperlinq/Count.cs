using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static long Count<TEnumerable, TSource>(this TEnumerable source) where TEnumerable : IEnumerable<TSource>
        {
            if (source is IReadOnlyCollection<TSource> collection)
                return collection.Count;

            using (var enumerator = source.GetEnumerator())
            {
                var counter = 0L;
                while (enumerator.MoveNext())
                    counter++;

                return counter;
            }
        }
    }
}
