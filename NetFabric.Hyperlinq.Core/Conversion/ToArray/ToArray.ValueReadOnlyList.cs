using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyListExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource[] ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => ValueReadOnlyCollectionExtensions.ToArray<TEnumerable, TEnumerator, TSource>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Lease<TSource> ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source, ArrayPool<TSource> pool, bool clearOnDispose = default)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => ValueReadOnlyCollectionExtensions.ToArray<TEnumerable, TEnumerator, TSource>(source, pool, clearOnDispose);
    }
}
