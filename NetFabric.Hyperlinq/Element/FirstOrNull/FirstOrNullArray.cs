using System;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static TSource? FirstOrNull<TSource>(this TSource[] source)
            where TSource : struct
        {
            if (source is null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (source.Length == 0) return null;

            return source[0];
        }

        public static TSource? FirstOrNull<TSource>(this TSource[] source, Func<TSource, bool> predicate) 
            where TSource : struct
        {
            if (source is null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var count = source.Length;
            if (count == 0) return null;
            
            for (var index = 0; index < count; index++)
            {
                if (predicate(source[index]))
                    return source[index];
            }
            return null;
        }
    }
}
