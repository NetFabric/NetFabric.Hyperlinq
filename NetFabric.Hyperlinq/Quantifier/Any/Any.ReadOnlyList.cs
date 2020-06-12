using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        
        public static bool Any<TList, TSource>(this TList source)
            where TList : notnull, IReadOnlyList<TSource>
            => source.Count != 0;


        static bool Any<TList, TSource>(this TList source, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            (_, var count) = Utils.SkipTake(source.Count, skipCount, takeCount);
            return count != 0;
        }


        public static bool Any<TList, TSource>(this TList source, Predicate<TSource> predicate)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return Any<TList, TSource>(source, predicate, 0, source.Count);
        }


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

        
        public static bool Any<TList, TSource>(this TList source, PredicateAt<TSource> predicate)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return Any<TList, TSource>(source, predicate, 0, source.Count);
        }


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

