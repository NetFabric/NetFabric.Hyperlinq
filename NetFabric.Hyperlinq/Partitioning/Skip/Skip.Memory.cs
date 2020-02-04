using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyMemory<TSource> Skip<TSource>(this Memory<TSource> source, int count)
            => Skip((ReadOnlyMemory<TSource>)source, count);
    }
}
