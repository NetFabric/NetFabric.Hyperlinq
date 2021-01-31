using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
// ReSharper disable HeapView.ObjectAllocation.Evident

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this in ArraySegment<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => source.ToDictionary(new FunctionWrapper<TSource, TKey>(keySelector), comparer);

        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey, TKeySelector>(this in ArraySegment<TSource> source, TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
        {
            var dictionary = new Dictionary<TKey, TSource>(source.Count, comparer);
            if (source.Any())
            {
                var array = source.Array!;
                var start = source.Offset;
                var end = start + source.Count;
                for (var index = start; index < end; index++)
                {
                    var item = array[index];
                    dictionary.Add(keySelector.Invoke(item), item);
                }
            }
            return dictionary;
        }
        
        static Dictionary<TKey, TSource> ToDictionary<TSource, TKey, TKeySelector, TPredicate>(this in ArraySegment<TSource> source, TKeySelector keySelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            var dictionary = new Dictionary<TKey, TSource>(source.Count, comparer);
            if (source.Any())
            {
                var array = source.Array!;
                var start = source.Offset;
                var end = start + source.Count;
                for (var index = start; index < end; index++)
                {
                    var item = array[index];
                    if (predicate.Invoke(item))
                        dictionary.Add(keySelector.Invoke(item), item);
                }
            }
            return dictionary;
        }
        
        static Dictionary<TKey, TSource> ToDictionaryAt<TSource, TKey, TKeySelector, TPredicate>(this in ArraySegment<TSource> source, TKeySelector keySelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            var dictionary = new Dictionary<TKey, TSource>(source.Count, comparer);
            if (source.Any())
            {
                var array = source.Array!;
                var start = source.Offset;
                var end = source.Count;
                if (start is 0)
                {
                    for (var index = 0; index < end; index++)
                    {
                        var item = array[index];
                        if (predicate.Invoke(item, index))
                            dictionary.Add(keySelector.Invoke(item), item);
                    }
                }
                else
                {
                    for (var index = 0; index < end; index++)
                    {
                        var item = array[index + start];
                        if (predicate.Invoke(item, index))
                            dictionary.Add(keySelector.Invoke(item), item);
                    }
                }
            }
            return dictionary;
        }
        
        static Dictionary<TKey, TResult> ToDictionary<TSource, TKey, TKeySelector, TResult, TPredicate, TSelector>(this in ArraySegment<TSource> source, TKeySelector keySelector, IEqualityComparer<TKey>? comparer, TPredicate predicate, TSelector selector)
            where TKey : notnull
            where TKeySelector : struct, IFunction<TResult, TKey>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            var dictionary = new Dictionary<TKey, TResult>(source.Count, comparer);
            if (source.Any())
            {
                var array = source.Array!;
                var start = source.Offset;
                var end = start + source.Count;
                for (var index = start; index < end; index++)
                {
                    var item = array[index];
                    if (predicate.Invoke(item))
                    {
                        var result = selector.Invoke(item);
                        dictionary.Add(keySelector.Invoke(result), result);
                    }
                }
            }
            return dictionary;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this in ArraySegment<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => source.ToDictionary<TSource, TKey, TElement, FunctionWrapper<TSource, TKey>, FunctionWrapper<TSource, TElement>>(new FunctionWrapper<TSource, TKey>(keySelector), new FunctionWrapper<TSource, TElement>(elementSelector), comparer);

        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement, TKeySelector, TElementSelector>(this in ArraySegment<TSource> source, TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            where TElementSelector : struct, IFunction<TSource, TElement>
        {
            var dictionary = new Dictionary<TKey, TElement>(source.Count, comparer);
            if (source.Any())
            {
                var array = source.Array!;
                var start = source.Offset;
                var end = start + source.Count;
                for (var index = start; index < end; index++)
                {
                    var item = array[index];
                    dictionary.Add(keySelector.Invoke(item), elementSelector.Invoke(item));
                }
            }
            return dictionary;
        }

        static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement, TKeySelector, TElementSelector, TPredicate>(this in ArraySegment<TSource> source, TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            where TElementSelector : struct, IFunction<TSource, TElement>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            var dictionary = new Dictionary<TKey, TElement>(source.Count, comparer);
            if (source.Any())
            {
                var array = source.Array!;
                var start = source.Offset;
                var end = start + source.Count;
                for (var index = start; index < end; index++)
                {
                    var item = array[index];
                    if (predicate.Invoke(item))
                        dictionary.Add(keySelector.Invoke(item), elementSelector.Invoke(item));
                }
            }
            return dictionary;
        }
        
        static Dictionary<TKey, TElement> ToDictionaryAt<TSource, TKey, TElement, TKeySelector, TElementSelector, TPredicate>(this in ArraySegment<TSource> source, TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            where TElementSelector : struct, IFunction<TSource, TElement>
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            var dictionary = new Dictionary<TKey, TElement>(source.Count, comparer);
            if (source.Any())
            {
                var array = source.Array!;
                var start = source.Offset;
                var end = source.Count;
                if (start is 0)
                {
                    for (var index = 0; index < end; index++)
                    {
                        var item = array[index];
                        if (predicate.Invoke(item, index))
                            dictionary.Add(keySelector.Invoke(item), elementSelector.Invoke(item));
                    }
                }
                else
                {
                    for (var index = 0; index < end; index++)
                    {
                        var item = array[index + start];
                        if (predicate.Invoke(item, index))
                            dictionary.Add(keySelector.Invoke(item), elementSelector.Invoke(item));
                    }
                }
            }
            return dictionary;
        }

        static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement, TKeySelector, TElementSelector, TResult, TPredicate, TSelector>(this in ArraySegment<TSource> source, TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer, TPredicate predicate, TSelector selector)
            where TKey : notnull
            where TKeySelector : struct, IFunction<TResult, TKey>
            where TElementSelector : struct, IFunction<TResult, TElement>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            var dictionary = new Dictionary<TKey, TElement>(source.Count, comparer);
            if (source.Any())
            {
                var array = source.Array!;
                var start = source.Offset;
                var end = start + source.Count;
                for (var index = start; index < end; index++)
                {
                    var item = array[index];
                    if (predicate.Invoke(item))
                    {
                        var result = selector.Invoke(item);
                        dictionary.Add(keySelector.Invoke(result), elementSelector.Invoke(result));
                    }
                }
            }
            return dictionary;
        }
    }
}

