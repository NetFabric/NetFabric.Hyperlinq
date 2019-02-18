using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        public static int Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
            => source.Count;

        public static int Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (source.Count == 0) return 0;

            var count = 0;
            using (var enumerator = Enumerable.GetEnumerator<TEnumerable, TEnumerator, TSource>.Invoke(source))
            {
                while (enumerator.MoveNext())
                {
                    if (predicate(enumerator.Current))
                        count++;
                }
            }
            return count;
        }
    }
}

