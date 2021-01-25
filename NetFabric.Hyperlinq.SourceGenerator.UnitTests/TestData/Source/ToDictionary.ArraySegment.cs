using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this in ArraySegment<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
        {
            if (keySelector is null) throw new ArgumentNullException(nameof(keySelector));

            return ToDictionary<TSource, TKey, FunctionWrapper<TSource, TKey>>(source, new FunctionWrapper<TSource, TKey>(keySelector), comparer);
        }

        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey, TKeySelector>(this in ArraySegment<TSource> source, TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
        {
            var dictionary = new Dictionary<TKey, TSource>(source.Count, comparer);
            return dictionary;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement, TKeySelector, TElementSelector>(this in ArraySegment<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
        {
            if (keySelector is null) throw new ArgumentNullException(nameof(keySelector));
            if (elementSelector is null) throw new ArgumentNullException(nameof(elementSelector));

            return ToDictionary<TSource, TKey, TElement, FunctionWrapper<TSource, TKey>, FunctionWrapper<TSource, TElement>>(source, new FunctionWrapper<TSource, TKey>(keySelector), new FunctionWrapper<TSource, TElement>(elementSelector), comparer);
        }

        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement, TKeySelector, TElementSelector>(this in ArraySegment<TSource> source, TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            where TElementSelector : struct, IFunction<TSource, TElement>
        {
            var dictionary = new Dictionary<TKey, TElement>(source.Count, comparer);
            return dictionary;
        }
    }
}
