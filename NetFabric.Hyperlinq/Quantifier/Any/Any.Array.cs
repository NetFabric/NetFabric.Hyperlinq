using System;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        public static bool Any<TSource>(this TSource[] source)
            => source.Length != 0;

        [Pure]
        static bool Any<TSource>(this TSource[] source, int skipCount, int takeCount)
            => takeCount != 0;

        [Pure]
        public static bool Any<TSource>(this TSource[] source, Func<TSource, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return Any<TSource>(source, predicate, 0, source.Length);
        }

        [Pure]
        static bool Any<TSource>(this TSource[] source, Func<TSource, bool> predicate, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                    return true;
            }
            return false;
        }

        [Pure]
        public static bool Any<TSource>(this TSource[] source, Func<TSource, int, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return Any<TSource>(source, predicate, 0, source.Length);
        }

        [Pure]
        static bool Any<TSource>(this TSource[] source, Func<TSource, int, bool> predicate, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index], index))
                    return true;
            }
            return false;
        }
    }
}

