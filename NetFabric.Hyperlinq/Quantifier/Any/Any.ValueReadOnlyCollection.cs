using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        [Pure]
        public static bool Any<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => source.Count != 0;

        [Pure]
        public static bool Any<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Predicate<TSource> predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            if (source.Count != 0)
            {
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (predicate(enumerator.Current))
                        return true;
                }
            }
            return false;
        }

        [Pure]
        public static bool Any<TEnumerable, TEnumerator, TSource>(this TEnumerable source, PredicateAt<TSource> predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            if (source.Count != 0)
            {
                using var enumerator = source.GetEnumerator();
                checked
                {
                    for (var index = 0; enumerator.MoveNext(); index++)
                    {
                        if (predicate(enumerator.Current, index))
                            return true;
                    }
                }
            }

            return false;
        }
    }
}

