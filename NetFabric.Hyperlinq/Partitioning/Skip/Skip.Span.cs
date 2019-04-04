using System;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        public static Span<TSource> Skip<TSource>(this Span<TSource> source, int count)
        {
            if (count <= 0)
                return source;

            var length = source.Length;
            var start = count < length ? count : length;
            var newCount = length - count;
            if (newCount < 0)
                newCount = 0;
            return source.Slice(start, newCount);
        }

        public static ReadOnlySpan<TSource> Skip<TSource>(this ReadOnlySpan<TSource> source, int count)
        {
            if (count <= 0)
                return source;

            var length = source.Length;
            var start = count < length ? count : length;
            var newCount = length - count;
            if (newCount < 0)
                newCount = 0;
            return source.Slice(start, newCount);
        }
    }
}
