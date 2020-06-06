using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static int Count<TList, TSource>(this TList source)
            where TList : notnull, IReadOnlyList<TSource>
            => source.Count;

        static int Count<TList, TSource>(this TList source, Predicate<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var count = 0;
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                var result = predicate(source[index]);
                count += Unsafe.As<bool, byte>(ref result);
            }
            return count;
        }

        static int Count<TList, TSource>(this TList source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var count = 0;
            if (skipCount == 0)
            {
                for (var index = 0; index < takeCount; index++)
                {
                    var result = predicate(source[index], index);
                    count += Unsafe.As<bool, byte>(ref result);
                }
            }
            else
            {
                for (var index = 0; index < takeCount; index++)
                {
                    var result = predicate(source[index + skipCount], index);
                    count += Unsafe.As<bool, byte>(ref result);
                }
            }
            return count;
        }
    }
}

