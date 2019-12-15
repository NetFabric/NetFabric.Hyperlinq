using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        [Pure]
        public static List<TSource> ToList<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => source switch
            {
                ICollection<TSource> collection => new List<TSource>(collection), // no need to allocate helper class

                _ => new List<TSource>(new ToListCollection<TEnumerable, TEnumerator, TSource>(source, 0, source.Count)),
            };

        [Pure]
        static List<TSource> ToList<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int skipCount, int takeCount)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => new List<TSource>(new ToListCollection<TEnumerable, TEnumerator, TSource>(source, skipCount, takeCount));

        [Pure]
        static List<TSource> ToList<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Predicate<TSource> predicate, int skipCount, int takeCount)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
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
        static List<TSource> ToList<TEnumerable, TEnumerator, TSource>(this TEnumerable source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
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
