using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        public static List<TSource> ToList<TSource>(this TSource[] source)
            => new List<TSource>(source);

        [Pure]
        static List<TSource> ToList<TSource>(this TSource[] source, int skipCount, int takeCount)
            => new List<TSource>(new ToListCollection<TSource>(source, skipCount, takeCount));

        [Pure]
        static List<TSource> ToList<TSource>(this TSource[] source, Predicate<TSource> predicate, int skipCount, int takeCount)
        {
            var list = new List<TSource>();

            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                    list.Add(source[index]);
            }

            return list;
        }

        [Pure]
        static List<TSource> ToList<TSource>(this TSource[] source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
        {
            var list = new List<TSource>();

            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index], index))
                    list.Add(source[index]);
            }

            return list;
        }
    }
}
