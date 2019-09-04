using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        [Pure]
        public static long LongCount<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var count = 0L;
            foreach (var _ in source)
                checked { count++; }
            return count;
        }

        [Pure]
        public static long LongCount<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var count = 0L;
            checked
            {
                foreach (var item in source)
                {
                    if (predicate(item))
                        count++;
                }
                return count;
            }
        }
    }
}
