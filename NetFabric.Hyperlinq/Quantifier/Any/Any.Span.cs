using System;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        public static bool Any<TSource>(this Span<TSource> source)
            => source.Length != 0;

        public static bool Any<TSource>(this Span<TSource> source, Func<TSource, bool> predicate)
        {
            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                    return true;
            }
            return false;
        }

        public static bool Any<TSource>(this Span<TSource> source, Func<TSource, long, bool> predicate)
        {
            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index], index))
                    return true;
            }
            return false;
        }
    }
}

