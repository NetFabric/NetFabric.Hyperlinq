using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this ReadOnlyMemory<TSource> source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = null)
            where TKey : notnull
            => ToDictionary(source.Span, keySelector, comparer);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this ReadOnlyMemory<TSource> source, Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = null)
            where TKey : notnull
            => ToDictionary(source.Span, keySelector, elementSelector, comparer);
    }
}

