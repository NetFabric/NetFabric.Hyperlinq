using System;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyMemoryExtensions
    {
        [Pure]
        public static ReadOnlyMemory<TSource> Skip<TSource>(this ReadOnlyMemory<TSource> source, int count)
        {
            var (skipCount, takeCount) = Utils.Skip(source.Length, count);
            return source.Slice(skipCount, takeCount);
        }
    }
}
