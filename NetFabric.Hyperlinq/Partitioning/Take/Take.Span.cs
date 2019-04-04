using System;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        public static Span<TSource> Take<TSource>(this Span<TSource> source, int count)
        {
            if (count <= 0)
                return source.Slice(0, 0);

            var length = source.Length;
            return source.Slice(0, (count < length) ? count : length);
        }

        public static ReadOnlySpan<TSource> Take<TSource>(this ReadOnlySpan<TSource> source, int count)
        {
            if (count <= 0)
                return source.Slice(0, 0);

            var length = source.Length;
            return source.Slice(0, (count < length) ? count : length);
        }
    }
}
