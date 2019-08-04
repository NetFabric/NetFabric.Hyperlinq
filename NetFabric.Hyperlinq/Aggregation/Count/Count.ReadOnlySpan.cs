using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlySpanExtensions
    {
        public static int Count<TSource>(this ReadOnlySpan<TSource> source)
            => source.Length;

        public static int Count<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
        {
            var count = 0;
            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                    count++;
            }
            return count;
        }

        public static int Count<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, long, bool> predicate)
        {
            var count = 0;
            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index], index))
                    count++;
            }
            return count;
        }
    }
}

