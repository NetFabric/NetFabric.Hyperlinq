using System;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static bool Any<TSource>(this TSource[] source)
            => source.Length != 0;

        static bool Any<TSource>(this TSource[] source, int skipCount, int takeCount)
            => takeCount != 0;

        public static bool Any<TSource>(this TSource[] source, Func<TSource, bool> predicate)
            => Any<TSource>(source, predicate, 0, source.Length);

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

        public static bool Any<TSource>(this TSource[] source, Func<TSource, int, bool> predicate)
            => Any<TSource>(source, predicate, 0, source.Length);

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

