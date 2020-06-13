using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static MemoryWhereSelectEnumerable<TSource, TResult> WhereSelect<TSource, TResult>(this Memory<TSource> source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector)
            => WhereSelect((ReadOnlyMemory<TSource>)source, predicate, selector);
    }
}

