using System;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        public static Span<TSource> Take<TSource>(this Span<TSource> source, int count)
        {
            return source.Slice(0, Utils.Take(source.Length, count));
        }

        public static ReadOnlySpan<TSource> Take<TSource>(this ReadOnlySpan<TSource> source, int count)
        {
            return source.Slice(0, Utils.Take(source.Length, count));
        }
    }
}
