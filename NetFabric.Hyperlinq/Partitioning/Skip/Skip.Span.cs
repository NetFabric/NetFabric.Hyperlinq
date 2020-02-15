using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Span<TSource> Skip<TSource>(this Span<TSource> source, int count)
        {
            var (skipCount, takeCount) = Utils.Skip(source.Length, count);
            return source.Slice(skipCount, takeCount);
        }
    }
}
