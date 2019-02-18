using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        public static TSource Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (source.Count == 0) ThrowHelper.ThrowEmptySequence<TSource>();
            if (source.Count > 1) ThrowHelper.ThrowNotSingleSequence<TSource>();

            using (var enumerator = Enumerable.GetEnumerator<TEnumerable, TEnumerator, TSource>.Invoke(source))
            {
                if (!enumerator.MoveNext())
                    ThrowHelper.ThrowEmptySequence<TSource>();

                var first = enumerator.Current;

                if (enumerator.MoveNext())
                    ThrowHelper.ThrowNotSingleSequence<TSource>();

                return first;
            }
        }
    }
}
