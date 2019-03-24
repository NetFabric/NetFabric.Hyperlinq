using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static int Count<TEnumerable, TSource>(this TEnumerable source)
            where TEnumerable : IReadOnlyList<TSource>
            => source.Count;

        public static int Count<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            var sourceCount = source.Count;
            if (sourceCount == 0) return 0;

            var count = 0;
            for (var index = 0; index < sourceCount; index++)
            {
                if (predicate(source[index]))
                    count++;
            }
            return count;
        }
    }
}

