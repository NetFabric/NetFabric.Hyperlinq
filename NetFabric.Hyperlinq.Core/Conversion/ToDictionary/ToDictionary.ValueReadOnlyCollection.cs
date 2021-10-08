using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollectionExtensions
    {

        public static Dictionary<TKey, TSource> ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TKeySelector>(this TEnumerable source, TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            => source.Count is 0
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                ? new Dictionary<TKey, TSource>()
                : ValueEnumerableExtensions.ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TKeySelector>(source, keySelector, comparer);


        static Dictionary<TKey, TSource> ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TKeySelector, TPredicate>(this TEnumerable source, TKeySelector keySelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            where TPredicate : struct, IFunction<TSource, bool>
            => source.Count is 0
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                ? new Dictionary<TKey, TSource>()
                : ValueEnumerableExtensions.ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TKeySelector, TPredicate>(source, keySelector, comparer, predicate);



        static Dictionary<TKey, TSource> ToDictionaryAt<TEnumerable, TEnumerator, TSource, TKey, TKeySelector, TPredicate>(this TEnumerable source, TKeySelector keySelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source.Count is 0
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                ? new Dictionary<TKey, TSource>()
                : ValueEnumerableExtensions.ToDictionaryAt<TEnumerable, TEnumerator, TSource, TKey, TKeySelector, TPredicate>(source, keySelector, comparer, predicate);
        

        static Dictionary<TKey, TResult> ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TKeySelector, TResult, TPredicate, TSelector>(this TEnumerable source, TKeySelector keySelector, IEqualityComparer<TKey>? comparer, TPredicate predicate, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TKey : notnull
            where TKeySelector : struct, IFunction<TResult, TKey>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
            => source.Count is 0
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                ? new Dictionary<TKey, TResult>()
                : ValueEnumerableExtensions.ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TKeySelector, TResult, TPredicate, TSelector>(source, keySelector, comparer, predicate, selector);


        //////////////////////////////////////////////////////////////////////////////////////////////////

        public static Dictionary<TKey, TElement> ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement, TKeySelector, TElementSelector>(this TEnumerable source, TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            where TElementSelector : struct, IFunction<TSource, TElement>
            => source.Count is 0
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                ? new Dictionary<TKey, TElement>()
                : ValueEnumerableExtensions.ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement, TKeySelector, TElementSelector>(source, keySelector, elementSelector, comparer);



        static Dictionary<TKey, TElement> ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement, TKeySelector, TElementSelector, TPredicate>(this TEnumerable source, TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            where TElementSelector : struct, IFunction<TSource, TElement>
            where TPredicate : struct, IFunction<TSource, bool>
            => source.Count is 0
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                ? new Dictionary<TKey, TElement>()
                : ValueEnumerableExtensions.ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement, TKeySelector, TElementSelector, TPredicate>(source, keySelector, elementSelector, comparer, predicate);



        static Dictionary<TKey, TElement> ToDictionaryAt<TEnumerable, TEnumerator, TSource, TKey, TElement, TKeySelector, TElementSelector, TPredicate>(this TEnumerable source, TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            where TElementSelector : struct, IFunction<TSource, TElement>
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source.Count is 0
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                ? new Dictionary<TKey, TElement>()
                : ValueEnumerableExtensions.ToDictionaryAt<TEnumerable, TEnumerator, TSource, TKey, TElement, TKeySelector, TElementSelector, TPredicate>(source, keySelector, elementSelector, comparer, predicate);
        

        static Dictionary<TKey, TElement> ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement, TKeySelector, TElementSelector, TResult, TPredicate, TSelector>(this TEnumerable source, TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer, TPredicate predicate, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TKey : notnull
            where TKeySelector : struct, IFunction<TResult, TKey>
            where TElementSelector : struct, IFunction<TResult, TElement>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
            => source.Count is 0
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                ? new Dictionary<TKey, TElement>()
                : ValueEnumerableExtensions.ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement, TKeySelector, TElementSelector, TResult, TPredicate, TSelector>(source, keySelector, elementSelector, comparer, predicate, selector);
    }
}

