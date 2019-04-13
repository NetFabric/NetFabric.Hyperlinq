using System;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        public static Span<TSource> SkipTake<TSource>(this Span<TSource> source, int skipCount, int takeCount)
        {
            (var skipCount2, var takeCount2) = Utils.SkipTake(source.Length, skipCount, takeCount);
            return source.Slice(skipCount2, takeCount2);
        }

        public static ReadOnlySpan<TSource> SkipTake<TSource>(this ReadOnlySpan<TSource> source, int skipCount, int takeCount)
        {
            (var skipCount2, var takeCount2) = Utils.SkipTake(source.Length, skipCount, takeCount);
            return source.Slice(skipCount2, takeCount2);
        }
    }
}
