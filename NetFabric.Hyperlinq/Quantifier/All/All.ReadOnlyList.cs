using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static bool All<TEnumerable, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate)
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var sourceCount = source.Count;
            for (var index = 0; index < sourceCount; index++)
            {
                if (!predicate(source[index], index))
                    return false;
            }
            return true;
        }
    }
}

