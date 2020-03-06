using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        [Pure]
        public static bool Any<TList, TSource>(this TList source)
            where TList : notnull, IReadOnlyList<TSource>
            => source.Count != 0;

        [Pure]
        static bool Any<TList, TSource>(this TList source, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
            => takeCount != 0;

        [Pure]
        public static bool Any<TList, TSource>(this TList source, Predicate<TSource> predicate)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return Any<TList, TSource>(source, predicate, 0, source.Count);
        }

        [Pure]
        static bool Any<TList, TSource>(this TList source, Predicate<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                    return true;
            }
            return false;
        }

        [Pure]
        public static bool Any<TList, TSource>(this TList source, PredicateAt<TSource> predicate)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return Any<TList, TSource>(source, predicate, 0, source.Count);
        }

        [Pure]
        static bool Any<TList, TSource>(this TList source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (skipCount == 0)
            {
                for (var index = 0; index < takeCount; index++)
                {
                    if (predicate(source[index], index))
                        return true;
                }
            }
            else
            {
                for (var index = 0; index < takeCount; index++)
                {
                    if (predicate(source[index + skipCount], index))
                        return true;
                }
            }
            return false;
        }
    }
}

