using System;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static int Count<TSource>(this TSource[] source)
            => source.Length;

        public static int Count<TSource>(this TSource[] source, Func<TSource, bool> predicate)
        {
            if (source is null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            if (length == 0) return 0;

            var count = 0;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                    count++;
            }
            return count;
        }
    }
}

