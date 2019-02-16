using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        public static int Count<TEnumerable, TSource>(this TEnumerable source)
            where TEnumerable : IReadOnlyCollection<TSource>
            => source.Count;

        public static int Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();
            if (source.Count == 0) return 0;

#if EXPRESSION_TREES
            return Enumerable.CountPredicateMethod<TEnumerable, TSource>.Invoke(source, predicate);
#else
            var count = 0;
            using (var enumerator = (TEnumerator)source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (predicate(enumerator.Current))
                        count++;
                }
            }
            return count;
#endif

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
        }
    }
}

