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

        static int Count<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IPredicate<TSource>
        {
            var counter = 0;
            using var enumerator = source.GetEnumerator();
            checked
            {
                while (enumerator.MoveNext())
                    counter += predicate.Invoke(enumerator.Current).AsByte();
            }
            return counter;
        }

        static int CountAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IPredicateAt<TSource>
        {
            var counter = 0;
            using var enumerator = source.GetEnumerator();
            checked
            {
                for (var index = 0; enumerator.MoveNext(); index++)
                    counter += predicate.Invoke(enumerator.Current, index).AsByte();
            }
            return counter;
        }
    }
}
