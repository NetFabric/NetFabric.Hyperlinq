using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {
        
        public static bool Any<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = source.GetEnumerator();
            return enumerator.MoveNext();
        }

        
        static bool Any<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IPredicate<TSource>
        {
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (predicate.Invoke(enumerator.Current))
                    return true;
            }
            return false;
        }

        public static bool AnyAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IPredicateAt<TSource>
        {
            using var enumerator = source.GetEnumerator();
            checked
            {
                for (var index = 0; enumerator.MoveNext(); index++)
                {
                    if (predicate.Invoke(enumerator.Current, index))
                        return true;
                }
            }
            return false;
        }
    }
}
