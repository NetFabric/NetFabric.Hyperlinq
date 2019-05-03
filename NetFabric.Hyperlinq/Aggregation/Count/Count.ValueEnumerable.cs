using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        public static long Count<TEnumerable, TEnumerator>(this TEnumerable source)
            where TEnumerable : IValueEnumerable<TEnumerator>
            where TEnumerator : struct, IValueEnumerator
        {
            var count = 0L;
            using (var enumerator = source.GetValueEnumerator())
            {
                checked
                {
                    while (enumerator.TryMoveNext())
                        count++;
                }            
            }
            return count;
        }

        public static long Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            var count = 0L;
            using (var enumerator = source.GetValueEnumerator())
            {
                checked
                {
                    while (enumerator.TryMoveNext())
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
            using (var enumerator = source.GetValueEnumerator())
            {
                checked
                {
                    while (enumerator.TryMoveNext(out var current))
                    {
                            if (predicate(current, index))
                                count++;

                            index++;
                    }
                }
            }
            return count;
        }
    }
}
