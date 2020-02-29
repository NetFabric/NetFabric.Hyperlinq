using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Memory<TSource> Take<TSource>(this TSource[] source, int count)
            => Take(source.AsMemory(), count);
    }
}
