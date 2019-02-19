using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static TSource SingleOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IReadOnlyList<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            var count = source.Count;
            if (count == 0) return default;
            if (count > 1) ThrowHelper.ThrowNotSingleSequence<TSource>();

            return source[0];
        }

        public static TSource SingleOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IReadOnlyList<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            var count = source.Count;
            if (count == 0) return default;

            for (var index = 0; index < count; index++)
            {
                var first = source[index];
                if (predicate(first))
                {
                    // found first, keep going until end or find second
                    for(var index2 = index + 1; index2 < count; index2++)
                    {
                        if (predicate(source[index2]))
                            ThrowHelper.ThrowNotSingleSequence<TSource>();      
                    }
                    return first;
                }
            }
            return default;
        }
    }
}
