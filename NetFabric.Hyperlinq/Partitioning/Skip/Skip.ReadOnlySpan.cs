using System;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        [Pure]
        public static ReadOnlySpan<TSource> Skip<TSource>(this ReadOnlySpan<TSource> source, int count)
        {
            var (skipCount, takeCount) = Utils.Skip(source.Length, count);
            return source.Slice(skipCount, takeCount);
        }
    }
}
