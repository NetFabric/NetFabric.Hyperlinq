﻿using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerableExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TEnumerable AsAsyncEnumerable<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            => source;
    }
}
