using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemorySelectEnumerable<TSource, TResult> Select<TSource, TResult>(this TSource[] source, Selector<TSource, TResult> selector)
            => Select(source.AsMemory(), selector);
    }
}

