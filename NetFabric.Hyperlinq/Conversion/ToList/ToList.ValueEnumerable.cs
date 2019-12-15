using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        [Pure]
        public static List<TSource> ToList<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var list = new List<TSource>();

            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
                list.Add(enumerator.Current);

            return list;
        }

        [Pure]
        static List<TSource> ToList<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Predicate<TSource> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var list = new List<TSource>();

            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (predicate(enumerator.Current))
                    list.Add(enumerator.Current);
            }

            return list;
        }

        [Pure]
        static List<TSource> ToList<TEnumerable, TEnumerator, TSource>(this TEnumerable source, PredicateAt<TSource> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var list = new List<TSource>();

            using var enumerator = source.GetEnumerator();
            checked
            {
                for (var index = 0; enumerator.MoveNext(); index++)
                {
                    if (predicate(enumerator.Current, index))
                        list.Add(enumerator.Current);
                }
            }

            return list;
        }
    }
}
