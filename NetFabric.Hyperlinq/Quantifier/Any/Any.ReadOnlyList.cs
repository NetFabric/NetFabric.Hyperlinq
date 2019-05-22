using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static bool Any<TEnumerable, TSource>(this TEnumerable source)
            where TEnumerable : IReadOnlyList<TSource>
            => source.Count != 0;

        public static bool Any<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var sourceCount = source.Count;
            for (var index = 0; index < sourceCount; index++)
            {
                if (predicate(source[index]))
                    return true;
            }
            return false;
        }

        public static bool Any<TEnumerable, TSource>(this TEnumerable source, Func<TSource, long, bool> predicate)
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var sourceCount = source.Count;
            for (var index = 0; index < sourceCount; index++)
            {
                if (predicate(source[index], index))
                    return true;
            }
            return false;
        }
    }
}

