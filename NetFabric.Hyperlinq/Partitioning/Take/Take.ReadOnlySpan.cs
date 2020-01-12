using System;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        [Pure]
        public static ReadOnlySpan<TSource> Take<TSource>(this ReadOnlySpan<TSource> source, int count)
        {
            return source.Slice(0, Utils.Take(source.Length, count));
        }
    }
}
