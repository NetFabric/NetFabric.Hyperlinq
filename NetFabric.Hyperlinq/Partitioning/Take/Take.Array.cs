using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SkipTakeEnumerable<TSource> Take<TSource>(this TSource[] source, int count)
            => SkipTake<TSource>(source, 0, count);
    }
}