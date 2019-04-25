using System;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static bool Any<TSource>(this TSource[] source)
            => source.Length != 0;

        public static bool Any<TSource>(this TSource[] source, Func<TSource, long, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            if (length == 0) return false;

            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index], index))
                    return true;
            }
            return false;
        }
    }
}

