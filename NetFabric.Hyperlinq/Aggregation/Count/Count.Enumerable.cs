using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static long Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            var count = 0L;
            using(var enumerator = (TEnumerator)source.GetEnumerator())
            {
                checked
                {
                    while (enumerator.MoveNext())
                        count++;
                }
            }
            return count;
        }

        public static long Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, long, bool> predicate)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            var count = 0L;
            var index = 0L;
            using (var enumerator = (TEnumerator)source.GetEnumerator())
            {
                checked
                {
                    while (enumerator.MoveNext())
                    {
                        if (predicate(enumerator.Current, index))
                            count++;

                        index++;
                    }
                }
            }
            return count;
        }
    }
}