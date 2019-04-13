using System;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        public static Span<TSource> Skip<TSource>(this Span<TSource> source, int count)
        {
            if (count <= 0)
                return source;

            (var skipCount, var takeCount) = Utils.Skip(source.Length, count);
            return source.Slice(skipCount, takeCount);
        }

        public static ReadOnlySpan<TSource> Skip<TSource>(this ReadOnlySpan<TSource> source, int count)
        {
            if (count <= 0)
                return source;

            (var skipCount, var takeCount) = Utils.Skip(source.Length, count);
            return source.Slice(skipCount, takeCount);
        }
    }
}
