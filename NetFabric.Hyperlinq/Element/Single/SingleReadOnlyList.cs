using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static TSource Single<TEnumerable, TSource>(this TEnumerable source) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (source.Count == 0) ThrowHelper.ThrowEmptySequence();
            if (source.Count > 1) ThrowHelper.ThrowNotSingleSequence();

            return source[0];
        }

        public static TSource Single<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            var index = 0;
            var count = source.Count;
            while (index < count)
            {
                var first = source[index];
                if (predicate(first))
                {
                    // found first, keep going until end or find second
                    index++;
                    while (index < count)
                    {
                        if (predicate(source[index]))
                            ThrowHelper.ThrowNotSingleSequence();

                        index++;
                    }
                    return first;
                }
                index++;
            }
            ThrowHelper.ThrowEmptySequence();
            return default;
        }
    }
}
