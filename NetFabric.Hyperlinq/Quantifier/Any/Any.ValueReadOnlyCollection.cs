using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollectionExtensions
    {
        
        public static bool Any<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => source.Count != 0;

        
        static bool Any<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate)
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IPredicate<TSource>
        {
            if (source.Count != 0)
            {
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (predicate.Invoke(enumerator.Current))
                        return true;
                }
            }
            return false;
        }

        
        static bool AnyAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate)
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IPredicateAt<TSource>
        {
            if (source.Count != 0)
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
            }

            return false;
        }
    }
}

