using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this in ArraySegment<TSource> source, NullableSelector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
        {
            if (keySelector is null) Throw.ArgumentNullException(nameof(keySelector));

            var array = source.Array;
            var result = new Dictionary<TKey, TSource>(source.Count, comparer);
            if (source.Offset == 0 && source.Count == array.Length)
            {
                for (var index = 0; index < array.Length; index++)
                    result.Add(keySelector(array[index]), array[index]);
            }
            else
            {
                var end = source.Offset + source.Count;
                for (var index = source.Offset; index < end; index++)
                    result.Add(keySelector(array[index]), array[index]);
            }
            return result;
        }


        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this in ArraySegment<TSource> source, NullableSelector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer)
        {
            if (keySelector is null) Throw.ArgumentNullException(nameof(keySelector));
            if (elementSelector is null) Throw.ArgumentNullException(nameof(elementSelector));

            var array = source.Array;
            var dictionary = new Dictionary<TKey, TElement>(source.Count, comparer);
            if (source.Offset == 0 && source.Count == array.Length)
            {
                for (var index = 0; index < array.Length; index++)
                    dictionary.Add(keySelector(array[index]), elementSelector(array[index]));
            }
            else
            {
                var end = source.Offset + source.Count;
                for (var index = source.Offset; index < end; index++)
                    dictionary.Add(keySelector(array[index]), elementSelector(array[index]));
            }
            return dictionary;
        }


        static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this in ArraySegment<TSource> source, NullableSelector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer, Predicate<TSource> predicate)
        {
            var array = source.Array;
            var dictionary = new Dictionary<TKey, TSource>(source.Count, comparer);
            if (source.Offset == 0 && source.Count == array.Length)
            {
                for (var index = 0; index < array.Length; index++)
                {
                    if (predicate(array[index]))
                        dictionary.Add(keySelector(array[index]), array[index]);
                }
            }
            else
            {
                var end = source.Offset + source.Count;
                for (var index = source.Offset; index < end; index++)
                {
                    if (predicate(array[index]))
                        dictionary.Add(keySelector(array[index]), array[index]);
                }
            }
            return dictionary;
        }


        static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this in ArraySegment<TSource> source, NullableSelector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer, Predicate<TSource> predicate)
        {
            var array = source.Array;
            var dictionary = new Dictionary<TKey, TElement>(source.Count, comparer);
            if (source.Offset == 0 && source.Count == array.Length)
            {
                for (var index = 0; index < array.Length; index++)
                {
                    if (predicate(array[index]))
                        dictionary.Add(keySelector(array[index]), elementSelector(array[index]));
                }
            }
            else
            {
                var end = source.Offset + source.Count;
                for (var index = source.Offset; index < end; index++)
                {
                    if (predicate(array[index]))
                        dictionary.Add(keySelector(array[index]), elementSelector(array[index]));
                }
            }
            return dictionary;
        }


        static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this in ArraySegment<TSource> source, NullableSelector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer, PredicateAt<TSource> predicate)
        {
            var array = source.Array;
            var dictionary = new Dictionary<TKey, TSource>(source.Count, comparer);
            if (source.Offset == 0 && source.Count == array.Length)
            {
                for (var index = 0; index < array.Length; index++)
                {
                    if (predicate(array[index], index))
                        dictionary.Add(keySelector(array[index]), array[index]);
                }
            }
            else
            {
                var end = source.Offset + source.Count;
                for (var index = source.Offset; index < end; index++)
                {
                    if (predicate(array[index], index))
                        dictionary.Add(keySelector(array[index]), array[index]);
                }
            }
            return dictionary;
        }


        static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this in ArraySegment<TSource> source, NullableSelector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer, PredicateAt<TSource> predicate)
        {
            var array = source.Array;
            var dictionary = new Dictionary<TKey, TElement>(source.Count, comparer);
            var end = source.Offset + source.Count;
            if (source.Offset == 0 && source.Count == array.Length)
            {
                for (var index = 0; index < array.Length; index++)
                {
                    if (predicate(array[index], index))
                        dictionary.Add(keySelector(array[index]), elementSelector(array[index]));
                }
            }
            else
            {
                for (var index = source.Offset; index < end; index++)
                {
                    if (predicate(array[index], index))
                        dictionary.Add(keySelector(array[index]), elementSelector(array[index]));
                }
            }
            return dictionary;
        }
    }
}

