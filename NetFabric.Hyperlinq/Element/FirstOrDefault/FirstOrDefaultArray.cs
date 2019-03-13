using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static ref readonly TSource FirstOrDefault<TSource>(this TSource[] source)
        {
            if (source is null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (source.Length == 0) return ref Default<TSource>.Value;

            return ref source[0];
        }

        public static ref readonly TSource FirstOrDefault<TSource>(this TSource[] source, Func<TSource, bool> predicate) 
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var count = source.Length;
            if (count == 0) return ref Default<TSource>.Value;

            for (var index = 0; index < count; index++)
            {
                if (predicate(source[index]))
                    return ref source[index];
            }
            return ref Default<TSource>.Value;
        }
    }
}
