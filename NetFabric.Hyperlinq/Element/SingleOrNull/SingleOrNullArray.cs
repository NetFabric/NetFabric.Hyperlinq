using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static TSource? SingleOrNull<TSource>(this TSource[] source)
            where TSource : struct
        {
            if (source is null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            var length = source.Length;
            if (length == 0) return null;
            if (length > 1) ThrowHelper.ThrowNotSingleSequence<TSource>();

            return source[0];
        }

        public static TSource? SingleOrNull<TSource>(this TSource[] source, Func<TSource, bool> predicate)
            where TSource : struct
        {
            if (source is null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                {
                    var first = source[index];

                    for (index++; index < length; index++)
                    {
                        if (predicate(source[index]))
                            ThrowHelper.ThrowNotSingleSequence<TSource>();
                    }

                    return first;
                }
            }
            return null;
        }
    }
}
