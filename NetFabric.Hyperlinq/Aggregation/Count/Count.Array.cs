using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        public static int Count<TSource>(this TSource[] source)
            => source.Length;

        [Pure]
        public static int Count<TSource>(this TSource[] source, Predicate<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return Count<TSource>(source, predicate, 0, source.Length);
        }

        [Pure]
        static int Count<TSource>(this TSource[] source, Predicate<TSource> predicate, int skipCount, int takeCount)
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

        [Pure]
        public static int Count<TSource>(this TSource[] source, PredicateAt<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return Count<TSource>(source, predicate, 0, source.Length);
        }

        [Pure]
        static int Count<TSource>(this TSource[] source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
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

