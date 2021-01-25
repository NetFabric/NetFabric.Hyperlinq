using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TList, TSource, TKey>(this TList source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
            where TList : IReadOnlyList<TSource>
            where TKey : notnull
            => source.ToDictionary<TList, TSource, TKey, FunctionWrapper<TSource, TKey>>(new FunctionWrapper<TSource, TKey>(keySelector), comparer, 0, source.Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TList, TSource, TKey, TKeySelector>(this TList source, TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
            where TList : IReadOnlyList<TSource>
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            => source.ToDictionary<TList, TSource, TKey, TKeySelector>(keySelector, comparer, 0, source.Count);


        static Dictionary<TKey, TSource> ToDictionary<TList, TSource, TKey, TKeySelector>(this TList source, TKeySelector keySelector, IEqualityComparer<TKey>? comparer, int offset, int count)
            where TList : IReadOnlyList<TSource>
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var dictionary = new Dictionary<TKey, TSource>(source.Count, comparer);
            var end = offset + count - 1;
            for (var index = offset; index <= end; index++)
            {
                var item = source[index];
                dictionary.Add(keySelector.Invoke(item), item);
            }

            return dictionary;
        }


        static Dictionary<TKey, TSource> ToDictionary<TList, TSource, TKey, TKeySelector, TPredicate>(this TList source, TKeySelector keySelector, IEqualityComparer<TKey>? comparer, TPredicate predicate, int offset, int count)
            where TList : IReadOnlyList<TSource>
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var dictionary = new Dictionary<TKey, TSource>(source.Count, comparer);
            var end = offset + count - 1;
            for (var index = offset; index <= end; index++)
            {
                var item = source[index];
                if (predicate.Invoke(item))
                    dictionary.Add(keySelector.Invoke(item), item);
            }
            return dictionary;
        }
        

        static Dictionary<TKey, TSource> ToDictionaryAt<TList, TSource, TKey, TKeySelector, TPredicate>(this TList source, TKeySelector keySelector, IEqualityComparer<TKey>? comparer, TPredicate predicate, int offset, int count)
            where TList : IReadOnlyList<TSource>
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var dictionary = new Dictionary<TKey, TSource>(source.Count, comparer);
            var end = offset + count - 1;
            for (var index = offset; index <= end; index++)
            {
                var item = source[index];
                if (predicate.Invoke(item, index))
                    dictionary.Add(keySelector.Invoke(item), item);
            }
            return dictionary;
        }
        
        static Dictionary<TKey, TResult> ToDictionary<TList, TSource, TKey, TKeySelector, TResult, TPredicate, TSelector>(this TList source, TKeySelector keySelector, IEqualityComparer<TKey>? comparer, TPredicate predicate, TSelector selector, int offset, int count)
            where TList : IReadOnlyList<TSource>
            where TKey : notnull
            where TKeySelector : struct, IFunction<TResult, TKey>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var dictionary = new Dictionary<TKey, TResult>(source.Count, comparer);
            var end = offset + count - 1;
            for (var index = offset; index <= end; index++)
            {
                var item = source[index];
                if (predicate.Invoke(item))
                {
                    var result = selector.Invoke(item);
                    dictionary.Add(keySelector.Invoke(result), result);
                }
            }
            return dictionary;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TList, TSource, TKey, TElement>(this TList source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
            where TList : IReadOnlyList<TSource>
            where TKey : notnull
            => source.ToDictionary<TList, TSource, TKey, TElement, FunctionWrapper<TSource, TKey>, FunctionWrapper<TSource, TElement>>(new FunctionWrapper<TSource, TKey>(keySelector), new FunctionWrapper<TSource, TElement>(elementSelector), comparer, 0, source.Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TList, TSource, TKey, TElement, TKeySelector, TElementSelector>(this TList source, TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default)
            where TList : IReadOnlyList<TSource>
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            where TElementSelector : struct, IFunction<TSource, TElement>
            => source.ToDictionary<TList, TSource, TKey, TElement, TKeySelector, TElementSelector>(keySelector, elementSelector, comparer, 0, source.Count);

        static Dictionary<TKey, TElement> ToDictionary<TList, TSource, TKey, TElement, TKeySelector, TElementSelector>(this TList source, TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer, int offset, int count)
            where TList : IReadOnlyList<TSource>
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            where TElementSelector : struct, IFunction<TSource, TElement>
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var dictionary = new Dictionary<TKey, TElement>(source.Count, comparer);
            var end = offset + count - 1;
            for (var index = offset; index <= end; index++)
            {
                var item = source[index];
                dictionary.Add(keySelector.Invoke(item), elementSelector.Invoke(item));
            }

            return dictionary;
        }

        static Dictionary<TKey, TElement> ToDictionary<TList, TSource, TKey, TElement, TKeySelector, TElementSelector, TPredicate>(this TList source, TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer, TPredicate predicate, int offset, int count)
            where TList : IReadOnlyList<TSource>
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            where TElementSelector : struct, IFunction<TSource, TElement>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var dictionary = new Dictionary<TKey, TElement>(source.Count, comparer);
            var end = offset + count - 1;
            for (var index = offset; index <= end; index++)
            {
                var item = source[index];
                if (predicate.Invoke(item))
                    dictionary.Add(keySelector.Invoke(item), elementSelector.Invoke(item));
            }
            return dictionary;
        }

        static Dictionary<TKey, TElement> ToDictionaryAt<TList, TSource, TKey, TElement, TKeySelector, TElementSelector, TPredicate>(this TList source, TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer, TPredicate predicate, int offset, int count)
            where TList : IReadOnlyList<TSource>
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            where TElementSelector : struct, IFunction<TSource, TElement>
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var dictionary = new Dictionary<TKey, TElement>(source.Count, comparer);
            var end = offset + count - 1;
            for (var index = offset; index <= end; index++)
            {
                var item = source[index];
                if (predicate.Invoke(item, index))
                    dictionary.Add(keySelector.Invoke(item), elementSelector.Invoke(item));
            }
            return dictionary;
        }

        static Dictionary<TKey, TElement> ToDictionary<TList, TSource, TKey, TElement, TKeySelector, TElementSelector, TResult, TPredicate, TSelector>(this TList source, TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer, TPredicate predicate, TSelector selector, int offset, int count)
            where TList : IReadOnlyList<TSource>
            where TKey : notnull
            where TKeySelector : struct, IFunction<TResult, TKey>
            where TElementSelector : struct, IFunction<TResult, TElement>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var dictionary = new Dictionary<TKey, TElement>(source.Count, comparer);
            var end = offset + count - 1;
            for (var index = offset; index <= end; index++)
            {
                var item = source[index];
                if (predicate.Invoke(item))
                {
                    var result = selector.Invoke(item);
                    dictionary.Add(keySelector.Invoke(result), elementSelector.Invoke(result));
                }
            }
            return dictionary;
        }

    }
}

