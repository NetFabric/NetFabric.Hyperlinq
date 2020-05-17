using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static MemoryWhereSelectEnumerable<TSource, TResult> WhereSelect<TSource, TResult>(this TSource[] source, Predicate<TSource> predicate, Selector<TSource, TResult> selector)
            => WhereSelect(source.AsMemory(), predicate, selector);
    }
}

