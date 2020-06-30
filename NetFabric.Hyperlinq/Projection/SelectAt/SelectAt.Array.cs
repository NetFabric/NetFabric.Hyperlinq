using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
#if SPAN_SUPPORTED
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemorySelectAtEnumerable<TSource, TResult> Select<TSource, TResult>(this TSource[] source, NullableSelectorAt<TSource, TResult> selector)
            => Select(source.AsMemory(), selector);

#else

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SelectAtEnumerable<TSource, TResult> Select<TSource, TResult>(this TSource[] source, NullableSelectorAt<TSource, TResult> selector)
            => Select(new ArraySegment<TSource>(source), selector);

#endif
    }
}

