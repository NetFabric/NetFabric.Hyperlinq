using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static bool All<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var index = 0;
            var count = source.Count;
            while (index < count && predicate(source[index]))
            {
                index++;
            }
            return index == count;
        }

        public static bool All<TEnumerable, TSource>(this TEnumerable source, Func<TSource, long, bool> predicate)
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var index = 0;
            var count = source.Count;
            while (index < count && predicate(source[index], index))
            {
                index++;
            }
            return index == count;
        }
    }
}

