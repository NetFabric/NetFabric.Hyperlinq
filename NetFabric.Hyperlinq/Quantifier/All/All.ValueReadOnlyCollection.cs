using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        public static bool All<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            if (source.Count == 0) return true;

            using (var enumerator = source.GetEnumerator())
            {
                var index = 0;
                while (enumerator.MoveNext())
                {
                    if (!predicate(enumerator.Current))
                        return false;
                        
                    index++;
                }
            }
            return true;
        }

        public static bool All<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            if (source.Count == 0) return true;

            using (var enumerator = source.GetEnumerator())
            {
                var index = 0;
                while (enumerator.MoveNext())
                {
                    if (!predicate(enumerator.Current, index))
                        return false;
                        
                    index++;
                }
            }
            return true;
        }
    }
}

