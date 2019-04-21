using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static int Count<TEnumerable, TSource>(this TEnumerable source)
            where TEnumerable : IReadOnlyList<TSource>
            => source.Count;

        public static int Count<TEnumerable, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate)
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));
            
            var count = 0;
            var length = source.Count;
            for (var index = 0; index < length; index++)
            {
                unchecked // always less than source.Count
                {
                    if (predicate(source[index], index))
                        count++;
                }
            }
            return count;
        }
    }
}

