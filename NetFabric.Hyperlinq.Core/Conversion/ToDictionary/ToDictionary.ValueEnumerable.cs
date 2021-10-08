using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
// ReSharper disable HeapView.ObjectAllocation.Evident

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {

        public static Dictionary<TKey, TSource> ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TKeySelector>(this TEnumerable source, TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
        {
            using var enumerator = source.GetEnumerator();
            var dictionary = new Dictionary<TKey, TSource>(0, comparer);
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                dictionary.Add(keySelector.Invoke(item), item);
            }
            return dictionary;
        }


        internal static Dictionary<TKey, TSource> ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TKeySelector, TPredicate>(this TEnumerable source, TKeySelector keySelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            using var enumerator = source.GetEnumerator();
            var dictionary = new Dictionary<TKey, TSource>(0, comparer);
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (predicate.Invoke(item))
                    dictionary.Add(keySelector.Invoke(item), item);
            }
            return dictionary;
        }

        

        internal static Dictionary<TKey, TSource> ToDictionaryAt<TEnumerable, TEnumerator, TSource, TKey, TKeySelector, TPredicate>(this TEnumerable source, TKeySelector keySelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            using var enumerator = source.GetEnumerator();
            checked
            {
                var dictionary = new Dictionary<TKey, TSource>(0, comparer);
                for (var index = 0; enumerator.MoveNext(); index++)
                {
                    var item = enumerator.Current;
                    if (predicate.Invoke(item, index))
                        dictionary.Add(keySelector.Invoke(item), item);
                }
                return dictionary;
            }
        }


        internal static Dictionary<TKey, TResult> ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TKeySelector, TResult, TPredicate, TSelector>(this TEnumerable source, TKeySelector keySelector, IEqualityComparer<TKey>? comparer, TPredicate predicate, TSelector selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TKey : notnull
            where TKeySelector : struct, IFunction<TResult, TKey>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            using var enumerator = source.GetEnumerator();
            var dictionary = new Dictionary<TKey, TResult>(0, comparer);
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (predicate.Invoke(item))
                {
                    var result = selector.Invoke(item);
                    dictionary.Add(keySelector.Invoke(result), result);
                }
            }
            return dictionary;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        public static Dictionary<TKey, TElement> ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement, TKeySelector, TElementSelector>(this TEnumerable source, TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            where TElementSelector : struct, IFunction<TSource, TElement>
        {
            var dictionary = new Dictionary<TKey, TElement>(0, comparer);

            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                dictionary.Add(keySelector.Invoke(item), elementSelector.Invoke(item)!);
            }

            return dictionary;
        }
        

        internal static Dictionary<TKey, TElement> ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement, TKeySelector, TElementSelector, TPredicate>(this TEnumerable source, TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            where TElementSelector : struct, IFunction<TSource, TElement>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            using var enumerator = source.GetEnumerator();
            var dictionary = new Dictionary<TKey, TElement>(0, comparer);
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (predicate.Invoke(item))
                    dictionary.Add(keySelector.Invoke(item), elementSelector.Invoke(item)!);
            }
            return dictionary;
        }
        

        internal static Dictionary<TKey, TElement> ToDictionaryAt<TEnumerable, TEnumerator, TSource, TKey, TElement, TKeySelector, TElementSelector, TPredicate>(this TEnumerable source, TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            where TElementSelector : struct, IFunction<TSource, TElement>
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            using var enumerator = source.GetEnumerator();
            checked
            {
                var dictionary = new Dictionary<TKey, TElement>(0, comparer);
                for (var index = 0; enumerator.MoveNext(); index++)
                {
                    var item = enumerator.Current;
                    if (predicate.Invoke(item, index))
                        dictionary.Add(keySelector.Invoke(item), elementSelector.Invoke(item));
                }
                return dictionary;
            }
        }
        

        internal static Dictionary<TKey, TElement> ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement, TKeySelector, TElementSelector, TResult, TPredicate, TSelector>(this TEnumerable source, TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer, TPredicate predicate, TSelector selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TKey : notnull
            where TKeySelector : struct, IFunction<TResult, TKey>
            where TElementSelector : struct, IFunction<TResult, TElement>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            using var enumerator = source.GetEnumerator();
            var dictionary = new Dictionary<TKey, TElement>(0, comparer);
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
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
