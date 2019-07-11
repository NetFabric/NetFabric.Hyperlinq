using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static int Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            var count = 0;
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

        public static int Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            var count = 0;
            using (var enumerator = (TEnumerator)source.GetEnumerator())
            {
                checked
                {
                    while (enumerator.MoveNext())
                    {
                        if (predicate(enumerator.Current))
                            count++;
                    }
                }
            }
            return count;
        }

        public static int Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            var count = 0;
            var index = 0;
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