using System;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static bool All<TSource>(this TSource[] source, Func<TSource, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var index = 0;
            var length = source.Length;
            while (index < length && predicate(source[index]))
            {
                index++;
            }
            return index == length;
        }

        public static bool All<TSource>(this TSource[] source, Func<TSource, long, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var index = 0;
            var length = source.Length;
            while (index < length && predicate(source[index], index))
            {
                index++;
            }
            return index == length;
        }
    }
}

