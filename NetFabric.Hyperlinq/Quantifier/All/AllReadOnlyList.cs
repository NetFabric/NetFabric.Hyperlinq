using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static bool All<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            var sourceCount = source.Count;
            if (sourceCount == 0) return false;

            for (var index = 0; index < sourceCount; index++)
            {
                if (!predicate(source[index]))
                    return false;
            }
            return true;
        }
    }
}

