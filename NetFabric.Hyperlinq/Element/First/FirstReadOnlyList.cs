using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static TSource First<TEnumerable, TSource>(this TEnumerable source) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            if (source.Count == 0) ThrowHelper.ThrowEmptySequence<TSource>();

            return source[0];
        }

        public static TSource First<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var count = source.Count;
            if (count == 0) ThrowHelper.ThrowEmptySequence<TSource>();
            
            for (var index = 0; index < count; index++)
            {
                if (predicate(source[index]))
                    return source[index];
            }
            return ThrowHelper.ThrowEmptySequence<TSource>();
        }
    }
}
