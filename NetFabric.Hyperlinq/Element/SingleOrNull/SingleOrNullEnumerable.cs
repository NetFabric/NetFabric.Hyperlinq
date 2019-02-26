using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static TSource? SingleOrNull<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
            where TSource : struct
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            using (var enumerator = Enumerable.GetEnumerator<TEnumerable, TEnumerator, TSource>.Invoke(source))
            {
                if (!enumerator.MoveNext())
                    return null;

                var first = enumerator.Current;

                if (enumerator.MoveNext())
                    ThrowHelper.ThrowNotSingleSequence<TSource>();

                return first;
            }
        }

        public static TSource? SingleOrNull<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
            where TSource : struct
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            using (var enumerator = Enumerable.GetEnumerator<TEnumerable, TEnumerator, TSource>.Invoke(source))
            {
                while (enumerator.MoveNext())
                {
                    var first = enumerator.Current;
                    if (predicate(first))
                    {
                        // found first, keep going until end or find second
                        while (enumerator.MoveNext())
                        {
                            if (predicate(enumerator.Current))
                                ThrowHelper.ThrowNotSingleSequence<TSource>();
                        }
                        return first;
                    }
                }
                return null;
            }
        }
    }
}
