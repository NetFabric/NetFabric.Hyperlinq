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

            var dictionary = new Dictionary<TKey, TSource>(source.Count, comparer);
            if (source.Any())
            {
                if (source.IsWhole())
                {
                    foreach (var item in source.Array)
                        dictionary.Add(keySelector(item), item);
                }
                else
                {
                    var array = source.Array;
                    var offset = source.Offset;
                    var end = offset + source.Count - 1;
                    for (var index = offset; index <= end; index++)
                        dictionary.Add(keySelector(array![index]), array![index]);
                }
            }
            return dictionary;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Dictionary<TKey, TSource> ToDictionary<TSource, TKey, TPredicate>(this in ArraySegment<TSource> source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TKey : notnull
            where TPredicate : struct, IPredicate<TSource>
        {
            var dictionary = new Dictionary<TKey, TSource>(source.Count, comparer);
            if (source.Any())
            {
                if (source.IsWhole())
                {
                    foreach (var item in source.Array)
                    {
                        if (predicate.Invoke(item))
                            dictionary.Add(keySelector(item), item);
                    }
                }
                else
                {
                    var array = source.Array;
                    var offset = source.Offset;
                    var end = offset + source.Count - 1;
                    for (var index = offset; index <= end; index++)
                    {
                        var item = array![index];
                        if (predicate.Invoke(item))
                            dictionary.Add(keySelector(item), item);
                    }
                }
            }
            return dictionary;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Dictionary<TKey, TSource> ToDictionaryAt<TSource, TKey, TPredicate>(this in ArraySegment<TSource> source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TKey : notnull
            where TPredicate : struct, IPredicateAt<TSource>
        {
            var dictionary = new Dictionary<TKey, TSource>(source.Count, comparer);
            if (source.Any())
            {
                if (source.IsWhole())
                {
                    var index = 0;
                    foreach (var item in source.Array)
                    {
                        if (predicate.Invoke(item, index))
                            dictionary.Add(keySelector(item), item);

                        index++;
                    }
                }
                else
                {
                    if (source.Offset == 0)
                    {
                        var array = source.Array;
                        var end = source.Count - 1;
                        for (var index = 0; index <= end; index++)
                        {
                            var item = array![index];
                            if (predicate.Invoke(item, index))
                                dictionary.Add(keySelector(item), item);
                        }
                    }
                    else
                    {
                        var array = source.Array;
                        var offset = source.Offset;
                        var end = source.Count - 1;
                        for (var index = 0; index <= end; index++)
                        {
                            var item = array![index + offset];
                            if (predicate.Invoke(item, index))
                                dictionary.Add(keySelector(item), item);
                        }
                    }
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

            var dictionary = new Dictionary<TKey, TElement>(source.Count, comparer);
            if (source.Any())
            {
                if (source.IsWhole())
                {
                    foreach (var item in source.Array)
                        dictionary.Add(keySelector(item), elementSelector(item)!);
                }
                else
                {
                    var array = source.Array;
                    var offset = source.Offset;
                    var end = offset + source.Count - 1;
                    for (var index = offset; index <= end; index++)
                    {
                        var item = array![index];
                        dictionary.Add(keySelector(item), elementSelector(item)!);
                    }
                }
            }
            return dictionary;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement, TPredicate>(this in ArraySegment<TSource> source, Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TKey : notnull
            where TPredicate : struct, IPredicate<TSource>
        {
            var dictionary = new Dictionary<TKey, TElement>(source.Count, comparer);
            if (source.Any())
            {
                if (source.IsWhole())
                {
                    foreach (var item in source.Array)
                    {
                        if (predicate.Invoke(item))
                            dictionary.Add(keySelector(item), elementSelector(item)!);
                    }
                }
                else
                {
                    var array = source.Array;
                    var offset = source.Offset;
                    var end = offset + source.Count - 1;
                    for (var index = offset; index <= end; index++)
                    {
                        var item = array![index];
                        if (predicate.Invoke(item))
                            dictionary.Add(keySelector(item), elementSelector(item)!);
                    }
                }
            }
            return dictionary;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Dictionary<TKey, TElement> ToDictionaryAt<TSource, TKey, TElement, TPredicate>(this in ArraySegment<TSource> source, Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TKey : notnull
            where TPredicate : struct, IPredicateAt<TSource>
        {
            var dictionary = new Dictionary<TKey, TElement>(source.Count, comparer);
            if (source.Any())
            {
                if (source.IsWhole())
                {
                    var index = 0;
                    foreach (var item in source.Array)
                    {
                        if (predicate.Invoke(item, index))
                            dictionary.Add(keySelector(item), elementSelector(item)!);

                        index++;
                    }
                }
                else
                {
                    if (source.Offset == 0)
                    {
                        var array = source.Array;
                        var end = source.Count - 1;
                        for (var index = 0; index <= end; index++)
                        {
                            var item = array![index];
                            if (predicate.Invoke(item, index))
                                dictionary.Add(keySelector(item), elementSelector(item)!);
                        }
                    }
                    else
                    {
                        var array = source.Array;
                        var offset = source.Offset;
                        var end = source.Count - 1;
                        for (var index = 0; index <= end; index++)
                        {
                            var item = array![index + offset];
                            if (predicate.Invoke(item, index))
                                dictionary.Add(keySelector(item), elementSelector(item)!);
                        }
                    }
                }
            }
            return dictionary;
        }
    }
}

