    using System;
using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this ReadOnlySpan<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = null)
            where TKey : notnull
            => source.ToDictionary(new FunctionWrapper<TSource, TKey>(keySelector), comparer);

        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey, TKeySelector>(this ReadOnlySpan<TSource> source, TKeySelector keySelector, IEqualityComparer<TKey>? comparer = null)
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var dictionary = new Dictionary<TKey, TSource>(source.Length, comparer);
            foreach (var item in source)
                dictionary.Add(keySelector.Invoke(item), item);
            return dictionary;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this ReadOnlySpan<TSource> source, FunctionIn<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = null)
            where TKey : notnull
            => source.ToDictionaryRef(new FunctionInWrapper<TSource, TKey>(keySelector), comparer);

        public static Dictionary<TKey, TSource> ToDictionaryRef<TSource, TKey, TKeySelector>(this ReadOnlySpan<TSource> source, TKeySelector keySelector, IEqualityComparer<TKey>? comparer = null)
            where TKey : notnull
            where TKeySelector : struct, IFunctionIn<TSource, TKey>
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var dictionary = new Dictionary<TKey, TSource>(source.Length, comparer);
            foreach (ref readonly var item in source)
                dictionary.Add(keySelector.Invoke(in item), item);
            return dictionary;
        }

        static Dictionary<TKey, TSource> ToDictionary<TSource, TKey, TKeySelector, TPredicate>(this ReadOnlySpan<TSource> source, TKeySelector keySelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var dictionary = new Dictionary<TKey, TSource>(source.Length, comparer);
            foreach (var item in source)
            {
                if (predicate.Invoke(item))
                    dictionary.Add(keySelector.Invoke(item), item);
            }
            return dictionary;
        }

        static Dictionary<TKey, TSource> ToDictionaryRef<TSource, TKey, TKeySelector, TPredicate>(this ReadOnlySpan<TSource> source, TKeySelector keySelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TKey : notnull
            where TKeySelector : struct, IFunctionIn<TSource, TKey>
            where TPredicate : struct, IFunctionIn<TSource, bool>
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var dictionary = new Dictionary<TKey, TSource>(source.Length, comparer);
            foreach (ref readonly var item in source)
            {
                if (predicate.Invoke(in item))
                    dictionary.Add(keySelector.Invoke(in item), item);
            }
            return dictionary;
        }

        static Dictionary<TKey, TSource> ToDictionaryAt<TSource, TKey, TKeySelector, TPredicate>(this ReadOnlySpan<TSource> source, TKeySelector keySelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var dictionary = new Dictionary<TKey, TSource>(source.Length, comparer);
            for (var index = 0; index < source.Length; index++)
            {
                var item = source[index];
                if (predicate.Invoke(item, index))
                    dictionary.Add(keySelector.Invoke(item), item);
            }
            return dictionary;
        }

        static Dictionary<TKey, TSource> ToDictionaryAtRef<TSource, TKey, TKeySelector, TPredicate>(this ReadOnlySpan<TSource> source, TKeySelector keySelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TKey : notnull
            where TKeySelector : struct, IFunctionIn<TSource, TKey>
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var dictionary = new Dictionary<TKey, TSource>(source.Length, comparer);
            for (var index = 0; index < source.Length; index++)
            {
                ref readonly var item = ref source[index];
                if (predicate.Invoke(in item, index))
                    dictionary.Add(keySelector.Invoke(in item), item);
            }
            return dictionary;
        }

        static Dictionary<TKey, TResult> ToDictionary<TSource, TKey, TKeySelector, TResult, TPredicate, TSelector>(this ReadOnlySpan<TSource> source, TKeySelector keySelector, IEqualityComparer<TKey>? comparer, TPredicate predicate, TSelector selector)
            where TKey : notnull
            where TKeySelector : struct, IFunction<TResult, TKey>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var dictionary = new Dictionary<TKey, TResult>(source.Length, comparer);
            foreach (var item in source)
            {
                if (predicate.Invoke(item))
                {
                    var result = selector.Invoke(item);
                    dictionary.Add(keySelector.Invoke(result), result);
                }
            }
            return dictionary;
        }

        static Dictionary<TKey, TResult> ToDictionaryRef<TSource, TKey, TKeySelector, TResult, TPredicate, TSelector>(this ReadOnlySpan<TSource> source, TKeySelector keySelector, IEqualityComparer<TKey>? comparer, TPredicate predicate, TSelector selector)
            where TKey : notnull
            where TKeySelector : struct, IFunctionIn<TResult, TKey>
            where TPredicate : struct, IFunctionIn<TSource, bool>
            where TSelector : struct, IFunctionIn<TSource, TResult>
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var dictionary = new Dictionary<TKey, TResult>(source.Length, comparer);
            foreach (ref readonly var item in source)
            {
                if (predicate.Invoke(in item))
                {
                    var result = selector.Invoke(in item);
                    dictionary.Add(keySelector.Invoke(in result), result);
                }
            }
            return dictionary;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this ReadOnlySpan<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = null)
            where TKey : notnull
            => source.ToDictionary<TSource, TKey, TElement, FunctionWrapper<TSource, TKey>, FunctionWrapper<TSource, TElement>>(new FunctionWrapper<TSource, TKey>(keySelector), new FunctionWrapper<TSource, TElement>(elementSelector), comparer);

        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement, TKeySelector, TElementSelector>(this ReadOnlySpan<TSource> source, TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = null)
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            where TElementSelector : struct, IFunction<TSource, TElement>
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var dictionary = new Dictionary<TKey, TElement>(source.Length, comparer);
            foreach (var item in source)
                dictionary.Add(keySelector.Invoke(item), elementSelector.Invoke(item));
            return dictionary;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this ReadOnlySpan<TSource> source, FunctionIn<TSource, TKey> keySelector, FunctionIn<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = null)
            where TKey : notnull
            => source.ToDictionaryRef<TSource, TKey, TElement, FunctionInWrapper<TSource, TKey>, FunctionInWrapper<TSource, TElement>>(new FunctionInWrapper<TSource, TKey>(keySelector), new FunctionInWrapper<TSource, TElement>(elementSelector), comparer);

        public static Dictionary<TKey, TElement> ToDictionaryRef<TSource, TKey, TElement, TKeySelector, TElementSelector>(this ReadOnlySpan<TSource> source, TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = null)
            where TKey : notnull
            where TKeySelector : struct, IFunctionIn<TSource, TKey>
            where TElementSelector : struct, IFunctionIn<TSource, TElement>
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var dictionary = new Dictionary<TKey, TElement>(source.Length, comparer);
            foreach (ref readonly var item in source)
                dictionary.Add(keySelector.Invoke(in item), elementSelector.Invoke(in item));
            return dictionary;
        }

        static Dictionary<TKey, TElement>
            ToDictionary<TSource, TKey, TElement, TKeySelector, TElementSelector, TPredicate>(
                this ReadOnlySpan<TSource> source, TKeySelector keySelector, TElementSelector elementSelector,
                IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            where TElementSelector : struct, IFunction<TSource, TElement>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var dictionary = new Dictionary<TKey, TElement>(source.Length, comparer);
            foreach (var item in source)
            {
                if (predicate.Invoke(item))
                    dictionary.Add(keySelector.Invoke(item), elementSelector.Invoke(item));
            }
            return dictionary;
        }

        static Dictionary<TKey, TElement>
            ToDictionaryRef<TSource, TKey, TElement, TKeySelector, TElementSelector, TPredicate>(
                this ReadOnlySpan<TSource> source, TKeySelector keySelector, TElementSelector elementSelector,
                IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TKey : notnull
            where TKeySelector : struct, IFunctionIn<TSource, TKey>
            where TElementSelector : struct, IFunctionIn<TSource, TElement>
            where TPredicate : struct, IFunctionIn<TSource, bool>
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var dictionary = new Dictionary<TKey, TElement>(source.Length, comparer);
            foreach (ref readonly var item in source)
            {
                if (predicate.Invoke(in item))
                    dictionary.Add(keySelector.Invoke(in item), elementSelector.Invoke(in item));
            }
            return dictionary;
        }

        static Dictionary<TKey, TElement>
            ToDictionaryAt<TSource, TKey, TElement, TKeySelector, TElementSelector, TPredicate>(
                this ReadOnlySpan<TSource> source, TKeySelector keySelector, TElementSelector elementSelector,
                IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            where TElementSelector : struct, IFunction<TSource, TElement>
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var dictionary = new Dictionary<TKey, TElement>(source.Length, comparer);
            for (var index = 0; index < source.Length; index++)
            {
                var item = source[index];
                if (predicate.Invoke(item, index))
                    dictionary.Add(keySelector.Invoke(item), elementSelector.Invoke(item));
            }

            return dictionary;
        }

        static Dictionary<TKey, TElement>
            ToDictionaryAtRef<TSource, TKey, TElement, TKeySelector, TElementSelector, TPredicate>(
                this ReadOnlySpan<TSource> source, TKeySelector keySelector, TElementSelector elementSelector,
                IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TKey : notnull
            where TKeySelector : struct, IFunctionIn<TSource, TKey>
            where TElementSelector : struct, IFunctionIn<TSource, TElement>
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var dictionary = new Dictionary<TKey, TElement>(source.Length, comparer);
            for (var index = 0; index < source.Length; index++)
            {
                ref readonly var item = ref source[index];
                if (predicate.Invoke(in item, index))
                    dictionary.Add(keySelector.Invoke(in item), elementSelector.Invoke(in item));
            }

            return dictionary;
        }

        static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement, TKeySelector, TElementSelector, TResult, TPredicate, TSelector>(this ReadOnlySpan<TSource> source, TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer, TPredicate predicate, TSelector selector)
            where TKey : notnull
            where TKeySelector : struct, IFunction<TResult, TKey>
            where TElementSelector : struct, IFunction<TResult, TElement>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var dictionary = new Dictionary<TKey, TElement>(source.Length, comparer);
            foreach (var item in source)
            {
                if (predicate.Invoke(item))
                {
                    var result = selector.Invoke(item);
                    dictionary.Add(keySelector.Invoke(result), elementSelector.Invoke(result));
                }
            }

            return dictionary;
        }

        static Dictionary<TKey, TElement> ToDictionaryRef<TSource, TKey, TElement, TKeySelector, TElementSelector, TResult, TPredicate, TSelector>(this ReadOnlySpan<TSource> source, TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer, TPredicate predicate, TSelector selector)
            where TKey : notnull
            where TKeySelector : struct, IFunctionIn<TResult, TKey>
            where TElementSelector : struct, IFunctionIn<TResult, TElement>
            where TPredicate : struct, IFunctionIn<TSource, bool>
            where TSelector : struct, IFunctionIn<TSource, TResult>
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var dictionary = new Dictionary<TKey, TElement>(source.Length, comparer);
            foreach (var item in source)
            {
                if (predicate.Invoke(in item))
                {
                    var result = selector.Invoke(in item);
                    dictionary.Add(keySelector.Invoke(in result), elementSelector.Invoke(in result));
                }
            }

            return dictionary;
        }
    }
}

