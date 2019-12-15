using System;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        public static long LongCount<TSource>(this TSource[] source)
            => source.LongLength;

        [Pure]
        public static long LongCount<TSource>(this TSource[] source, Predicate<TSource> predicate)
        {
            var count = 0L;
            var end = source.LongLength;
            for (var index = 0L; index < end; index++)
            {
                if (predicate(source[index]))
                    count++;
            }
            return count;
        }
    }
}

