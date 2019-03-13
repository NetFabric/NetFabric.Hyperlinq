using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static TSource Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            using (var enumerator = Dynamic.GetEnumerator<TEnumerable, TEnumerator, TSource>.Invoke(source))
            {
                if (!enumerator.MoveNext())
                    ThrowHelper.ThrowEmptySequence<TSource>();

                var first = enumerator.Current;

                if (enumerator.MoveNext())
                    ThrowHelper.ThrowNotSingleSequence<TSource>();

                return first;
            }
        }

        public static TSource Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            using (var enumerator = Dynamic.GetEnumerator<TEnumerable, TEnumerator, TSource>.Invoke(source))
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
                return ThrowHelper.ThrowEmptySequence<TSource>();
            }
        }
    }
}
