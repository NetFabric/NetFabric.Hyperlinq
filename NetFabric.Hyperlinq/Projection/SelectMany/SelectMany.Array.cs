using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if SPAN_SUPPORTED
        public static MemorySelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this TSource[] source,
            Selector<TSource, TSubEnumerable> selector)
            where TSubEnumerable : notnull, IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>((ReadOnlyMemory<TSource>)source, selector);
#else
        public static ReadOnlyList.SelectManyEnumerable<TSource[], TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this TSource[] source,
            Selector<TSource, TSubEnumerable> selector)
            where TSubEnumerable : notnull, IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ReadOnlyList.SelectMany<TSource[], TSource, TSubEnumerable, TSubEnumerator, TResult>(source, selector);
#endif
    }
}

