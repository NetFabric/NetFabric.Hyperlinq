using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentSelectEnumerable<TSource, TResult> Select<TSource, TResult>(this TSource[] source, NullableSelector<TSource, TResult> selector)
            => Select(new ArraySegment<TSource>(source), selector);
    }
}

