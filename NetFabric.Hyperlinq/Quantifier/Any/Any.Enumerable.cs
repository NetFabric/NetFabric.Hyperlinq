using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static bool Any<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            using (var enumerator = (TEnumerator)source.GetEnumerator())
            {
                return enumerator.MoveNext();
            }
        }

        public static bool Any<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, long, bool> predicate)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            using (var enumerator = (TEnumerator)source.GetEnumerator())
            {
                var index = 0L;
                while (enumerator.MoveNext())
                {
                    checked
                    {
                        if (predicate(enumerator.Current, index))
                            return true;

                        index++;
                    }
                }
            }
            return false;
        }
    }
}