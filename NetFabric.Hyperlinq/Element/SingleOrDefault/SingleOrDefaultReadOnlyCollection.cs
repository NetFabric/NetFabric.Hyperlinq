using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        public static TSource SingleOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (source.Count == 0) return default;
            if (source.Count > 1) ThrowHelper.ThrowNotSingleSequence<TSource>();

            using (var enumerator = Enumerable.GetEnumerator<TEnumerable, TEnumerator, TSource>.Invoke(source))
            {
                enumerator.MoveNext();
                return enumerator.Current;
            }
        }
    }
}
