using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {
        public static int Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var counter = 0;
            using var enumerator = source.GetEnumerator();
            checked
            {
                while (enumerator.MoveNext())
                    counter++;
            }
            return counter;
        }

        static int Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Predicate<TSource> predicate)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var counter = 0;
            using var enumerator = source.GetEnumerator();
            checked
            {
                while (enumerator.MoveNext())
                    counter += predicate(enumerator.Current).AsByte();
            }
            return counter;
        }

        static int Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source, PredicateAt<TSource> predicate)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var counter = 0;
            using var enumerator = source.GetEnumerator();
            checked
            {
                for (var index = 0; enumerator.MoveNext(); index++)
                    counter += predicate(enumerator.Current, index).AsByte();
            }
            return counter;
        }
    }
}
