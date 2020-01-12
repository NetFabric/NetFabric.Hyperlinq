using System;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        [Pure]
        public static ReadOnlyMemory<TSource> Take<TSource>(this ReadOnlyMemory<TSource> source, int count)
        {
            return source.Slice(0, Utils.Take(source.Length, count));
        }
    }
}
