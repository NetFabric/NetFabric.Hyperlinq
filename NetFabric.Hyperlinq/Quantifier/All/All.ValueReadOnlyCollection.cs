using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollectionExtensions
    {
        public static bool All<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Predicate<TSource> predicate)
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return All<TEnumerable, TEnumerator, TSource, ValuePredicate<TSource>>(source, new ValuePredicate<TSource>(predicate));
        }

        public static bool All<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate = default)
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IPredicate<TSource>
        {
            if (source.Count != 0)
            {
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (!predicate.Invoke(enumerator.Current))
                        return false;
                }
            }
            return true;
        }

        public static bool All<TEnumerable, TEnumerator, TSource>(this TEnumerable source, PredicateAt<TSource> predicate)
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return AllAt<TEnumerable, TEnumerator, TSource, ValuePredicateAt<TSource>>(source, new ValuePredicateAt<TSource>(predicate));
        }
        
        public static bool AllAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate = default)
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
                        if (!predicate.Invoke(enumerator.Current, index))
                            return false;
                    }
                }
            }
            return true;
        }
    }
}

