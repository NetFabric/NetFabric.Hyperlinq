using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static bool All<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, long, bool> predicate)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            using (var enumerator = (TEnumerator)source.GetEnumerator())
            {
                var index = 0L;
                while (enumerator.MoveNext())
                {
                    checked
                    {
                        if (!predicate(enumerator.Current, index))
                            return false;

                        index++;
                    }
                }
            }
            return true;
        }
    }
}