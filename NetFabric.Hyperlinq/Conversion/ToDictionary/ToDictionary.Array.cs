using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
#if SPAN_SUPPORTED

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this TSource[] source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = null)
            => ToDictionary((ReadOnlySpan<TSource>)source.AsSpan(), keySelector, comparer);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this TSource[] source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = null)
            => ToDictionary((ReadOnlySpan<TSource>)source.AsSpan(), keySelector, elementSelector, comparer);

#else
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this TSource[] source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = null)
        {
            if (keySelector is null) Throw.ArgumentNullException(nameof(keySelector));

            return ToDictionary<TSource, TKey>(source, keySelector, comparer, 0, source.Length);
        }
        
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this TSource[] source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = null)
        {
            if (keySelector is null) Throw.ArgumentNullException(nameof(keySelector));
            if (elementSelector is null) Throw.ArgumentNullException(nameof(elementSelector));

            return ToDictionary<TSource, TKey, TElement>(source, keySelector, elementSelector, comparer, 0, source.Length);
        }


        static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this TSource[] source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer, int skipCount, int takeCount)
        {
            var dictionary = new Dictionary<TKey, TSource>(source.Length, comparer);
            if (skipCount == 0 && takeCount == source.Length)
            {
                for (var index = 0; index < source.Length; index++)
                    dictionary.Add(keySelector(source[index]), source[index]);
            }
            else
            {
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                    dictionary.Add(keySelector(source[index]), source[index]);
            }
            return dictionary;
        }


        static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this TSource[] source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer, int skipCount, int takeCount)
        {
            var dictionary = new Dictionary<TKey, TElement>(source.Length, comparer);
            if (skipCount == 0 && takeCount == source.Length)
            {
                for (var index = 0; index < source.Length; index++)
                    dictionary.Add(keySelector(source[index]), elementSelector(source[index]));
            }
            else
            {
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                    dictionary.Add(keySelector(source[index]), elementSelector(source[index]));
            }
            return dictionary;
        }


        static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this TSource[] source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer, Predicate<TSource> predicate, int skipCount, int takeCount)
        {
            var dictionary = new Dictionary<TKey, TSource>(source.Length, comparer);
            if (skipCount == 0 && takeCount == source.Length)
            {
                for (var index = 0; index < source.Length; index++)
                {
                    if (predicate(source[index]))
                        dictionary.Add(keySelector(source[index]), source[index]);
                }
            }
            else
            {
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    if (predicate(source[index]))
                        dictionary.Add(keySelector(source[index]), source[index]);
                }
            }
            return dictionary;
        }


        static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this TSource[] source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer, Predicate<TSource> predicate, int skipCount, int takeCount)
        {
            var dictionary = new Dictionary<TKey, TElement>(source.Length, comparer);
            if (skipCount == 0 && takeCount == source.Length)
            {
                for (var index = 0; index < source.Length; index++)
                {
                    if (predicate(source[index]))
                        dictionary.Add(keySelector(source[index]), elementSelector(source[index]));
                }
            }
            else
            {
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    if (predicate(source[index]))
                        dictionary.Add(keySelector(source[index]), elementSelector(source[index]));
                }
            }
            return dictionary;
        }


        static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this TSource[] source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer, PredicateAt<TSource> predicate, int skipCount, int takeCount)
        {
            var dictionary = new Dictionary<TKey, TSource>(source.Length, comparer);
            if (skipCount == 0 && takeCount == source.Length)
            {
                for (var index = 0; index < source.Length; index++)
                {
                    if (predicate(source[index], index))
                        dictionary.Add(keySelector(source[index]), source[index]);
                }
            }
            else
            {
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    if (predicate(source[index], index))
                        dictionary.Add(keySelector(source[index]), source[index]);
                }
            }
            return dictionary;
        }


        static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this TSource[] source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer, PredicateAt<TSource> predicate, int skipCount, int takeCount)
        {
            var dictionary = new Dictionary<TKey, TElement>(source.Length, comparer);
            var end = skipCount + takeCount;
            if (skipCount == 0 && takeCount == source.Length)
            {
                for (var index = 0; index < source.Length; index++)
                {
                    if (predicate(source[index], index))
                        dictionary.Add(keySelector(source[index]), elementSelector(source[index]));
                }
            }
            else
            {
                for (var index = skipCount; index < end; index++)
                {
                    if (predicate(source[index], index))
                        dictionary.Add(keySelector(source[index]), elementSelector(source[index]));
                }
            }
            return dictionary;
        }

#endif
    }
}

