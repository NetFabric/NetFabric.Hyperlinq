using System;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static int Count<TSource>(this TSource[] source)
            => source.Length;

        public static int Count<TSource>(this TSource[] source, Func<TSource, bool> predicate)
            => Count<TSource>(source, predicate, 0, source.Length);

        static int Count<TSource>(this TSource[] source, Func<TSource, bool> predicate, int skipCount, int takeCount)
        {
            var count = 0;
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                    count++;
            }
            return count;
        }

        public static int Count<TSource>(this TSource[] source, Func<TSource, int, bool> predicate)
            => Count<TSource>(source, predicate, 0, source.Length);

        static int Count<TSource>(this TSource[] source, Func<TSource, int, bool> predicate, int skipCount, int takeCount)
        {
            var count = 0;
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index], index))
                    count++;
            }
            return count;
        }
    }
}

