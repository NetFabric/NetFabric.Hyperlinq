using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        public static int Count<TList, TSource>(this TList source)
            where TList : IReadOnlyList<TSource>
            => source.Count;

        static unsafe int Count<TList, TSource>(this TList source, Predicate<TSource> predicate, int skipCount, int takeCount)
            where TList : IReadOnlyList<TSource>
        {
            var count = 0;
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                var result = predicate(source[index]);
                count += *(int*)&result;
            }
            return count;
        }

        static unsafe int Count<TList, TSource>(this TList source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            where TList : IReadOnlyList<TSource>
        {
            var count = 0;
            if (skipCount == 0)
            {
                for (var index = 0; index < takeCount; index++)
                {
                    var result = predicate(source[index], index);
                    count += *(int*)&result;
                }
            }
            else
            {
                for (var index = 0; index < takeCount; index++)
                {
                    var result = predicate(source[index + skipCount], index);
                    count += *(int*)&result;
                }
            }
            return count;
        }
    }
}

