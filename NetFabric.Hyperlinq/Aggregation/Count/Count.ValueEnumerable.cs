using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        public static int Count<TEnumerable, TEnumerator>(this TEnumerable source)
            where TEnumerable : IValueEnumerable<TEnumerator>
            where TEnumerator : struct, IValueEnumerator
        {
            var count = 0;
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

        public static int Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            var count = 0;
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

        public static int Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            var count = 0;
            var index = 0;
            using (var enumerator = source.GetValueEnumerator())
            {
                while (enumerator.TryMoveNext(out var current))
                {
                    checked
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
