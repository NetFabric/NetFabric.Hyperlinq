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
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));
            
            return Count<TEnumerable, TSource>(source, predicate, 0, source.Count);
        }

        static int Count<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate, int skipCount, int takeCount)
            where TEnumerable : IReadOnlyList<TSource>
        {
            var count = 0;
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                    count++;
            }
            return count;
        }

        public static int Count<TEnumerable, TSource>(this TEnumerable source, Func<TSource, long, bool> predicate)
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));
            
            return Count<TEnumerable, TSource>(source, predicate, 0, source.Count);
        }

        static int Count<TEnumerable, TSource>(this TEnumerable source, Func<TSource, long, bool> predicate, int skipCount, int takeCount)
            where TEnumerable : IReadOnlyList<TSource>
        {
            var count = 0;
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index], index))
                    count++;
            }
            return count;
        }
    }
}

