using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemorySelectEnumerable<TSource, TResult> Select<TSource, TResult>(this Memory<TSource> source, Selector<TSource, TResult> selector)
            => Select((ReadOnlyMemory<TSource>)source, selector);
    }
}

