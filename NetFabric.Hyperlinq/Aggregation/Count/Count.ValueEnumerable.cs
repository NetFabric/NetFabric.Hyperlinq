using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        public static long Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            var count = 0L;
            using (var enumerator = source.GetEnumerator())
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
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            var count = 0L;
            var index = 0L;
            using (var enumerator = source.GetEnumerator())
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
