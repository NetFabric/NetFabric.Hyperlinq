using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollectionExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TEnumerable, TEnumerator, TSource, TKey>(this TEnumerable source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TKey : notnull
            => ToDictionary<TEnumerable, TEnumerator, TSource, TKey, FunctionWrapper<TSource, TKey>>(source, new FunctionWrapper<TSource, TKey>(keySelector), comparer);

        public static Dictionary<TKey, TSource> ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TKeySelector>(this TEnumerable source, TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            => source.Count is 0
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                ? new Dictionary<TKey, TSource>()
                : ValueEnumerableExtensions.ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TKeySelector>(source, keySelector, comparer);

        [GeneratorIgnore]
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


        [GeneratorIgnore]
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
        
        [GeneratorIgnore]
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
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement>(this TEnumerable source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TKey : notnull
            => ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement, FunctionWrapper<TSource, TKey>, FunctionWrapper<TSource, TElement>>(source, new FunctionWrapper<TSource, TKey>(keySelector), new FunctionWrapper<TSource, TElement>(elementSelector), comparer);

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


        [GeneratorIgnore]
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


        [GeneratorIgnore]
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
        
        [GeneratorIgnore]
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

