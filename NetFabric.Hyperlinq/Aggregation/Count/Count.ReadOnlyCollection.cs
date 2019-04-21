using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        public static int Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
            => source.Count;

        public static int Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            var count = 0;
            if (source.Count != 0)
            {
                var index = 0;
                using (var enumerator = (TEnumerator)source.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        unchecked // always less than source.Count
                        {
                            if (predicate(enumerator.Current, index))
                                count++;

                            index++;
                        }
                    }
                }
            }
            return count;
        }
    }
}
