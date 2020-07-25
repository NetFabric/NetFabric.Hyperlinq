using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this in ArraySegment<TSource> source, NullableSelector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
        {
            if (keySelector is null) Throw.ArgumentNullException(nameof(keySelector));

            var dictionary = new Dictionary<TKey, TSource>(source.Count, comparer);
            var array = source.Array;
            if (source.IsWhole())
            {
                foreach (var item in source)
                    dictionary.Add(keySelector(item), item);
            }
            else
            {
                var end = source.Count;
                for (var index = source.Offset; index < end; index++)
                    dictionary.Add(keySelector(array[index]), array[index]);
            }
            return dictionary;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this in ArraySegment<TSource> source, NullableSelector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
        {
            if (keySelector is null) Throw.ArgumentNullException(nameof(keySelector));
            if (elementSelector is null) Throw.ArgumentNullException(nameof(elementSelector));

            var dictionary = new Dictionary<TKey, TElement>(source.Count, comparer);
            var array = source.Array;
            if (source.IsWhole())
            {
                foreach (var item in source)
                    dictionary.Add(keySelector(item), elementSelector(item));
            }
            else
            {
                var end = source.Count;
                for (var index = source.Offset; index < end; index++)
                    dictionary.Add(keySelector(array[index]), elementSelector(array[index]));
            }
            return dictionary;
        }
    }
}

