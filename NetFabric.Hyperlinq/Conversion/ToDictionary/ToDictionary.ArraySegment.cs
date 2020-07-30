using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this in ArraySegment<TSource> source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
        {
            if (keySelector is null) Throw.ArgumentNullException(nameof(keySelector));

            if (source.Array is null)
                return new Dictionary<TKey, TSource>();

            var dictionary = new Dictionary<TKey, TSource>(source.Count, comparer);
            if (source.Count != 0)
            {
                var array = source.Array;
                if (source.Count == array!.Length)
                {
                    for (var index = 0; index < array.Length; index++)
                    {
                        var item = array![index];
                        dictionary.Add(keySelector(item), item);
                    }
                }
                else
                {
                    var end = source.Count - 1;
                    for (var index = source.Offset; index <= end; index++)
                        dictionary.Add(keySelector(array![index]), array![index]);
                }
            }
            return dictionary;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this in ArraySegment<TSource> source, Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
        {
            if (keySelector is null) Throw.ArgumentNullException(nameof(keySelector));
            if (elementSelector is null) Throw.ArgumentNullException(nameof(elementSelector));

            if (source.Array is null)
                return new Dictionary<TKey, TElement>();

            var dictionary = new Dictionary<TKey, TElement>(source.Count, comparer);
            if (source.Count != 0)
            {
                var array = source.Array;
                if (source.Count == array!.Length)
                {
                    for (var index = 0; index < array.Length; index++)
                    {
                        var item = array![index];
                        dictionary.Add(keySelector(item), elementSelector(item)!);
                    }
                }
                else
                {
                    var end = source.Count - 1;
                    for (var index = source.Offset; index <= end; index++)
                    {
                        var item = array![index];
                        dictionary.Add(keySelector(item), elementSelector(item)!);
                    }
                }
            }
            return dictionary;
        }
    }
}

