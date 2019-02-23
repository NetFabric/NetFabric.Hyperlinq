using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static bool Contains<TEnumerable, TEnumerator, TSource>(this TEnumerable source, TSource value)
            where TEnumerable : IReadOnlyList<TSource>
            where TEnumerator : IEnumerator<TSource>
            => Contains<TEnumerable, TEnumerator, TSource>(source, value, EqualityComparer<TSource>.Default);

        public static bool Contains<TEnumerable, TEnumerator, TSource>(this TEnumerable source, TSource value, IEqualityComparer<TSource> comparer)
            where TEnumerable : IReadOnlyList<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            var sourceCount = source.Count;
            if (sourceCount == 0) return false;

            for (var index = 0; index < sourceCount; index++)
            {
                if (comparer.Equals(source[index], value))
                    return true;
            }
            return false;
        }
    }
}

