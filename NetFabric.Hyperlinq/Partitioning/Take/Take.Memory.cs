using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Memory<TSource> Take<TSource>(this Memory<TSource> source, int count) 
            => source.Slice(0, Utils.Take(source.Length, count));
    }
}
