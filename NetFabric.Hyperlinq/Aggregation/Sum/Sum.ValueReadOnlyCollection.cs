using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollectionExtensions
    {
        [GeneratorIgnore]
        internal static TSum Sum<TEnumerable, TEnumerator, TSource, TSum>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSum : struct
            => source switch
            {
                {Count: 0} => default,
                _ => ValueEnumerableExtensions.Sum<TEnumerable, TEnumerator, TSource, TSum>(source)
            };
        
        [GeneratorIgnore]
        static TSum Sum<TEnumerable, TEnumerator, TSource, TSum, TPredicate>(this TEnumerable source, TPredicate predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate: struct, IFunction<TSource, bool>
            where TSum : struct
            => source switch
            {
                {Count: 0} => default,
                _ => ValueEnumerableExtensions.Sum<TEnumerable, TEnumerator, TSource, TSum, TPredicate>(source, predicate)
            };
        
        [GeneratorIgnore]
        static TSum SumAt<TEnumerable, TEnumerator, TSource, TSum, TPredicate>(this TEnumerable source, TPredicate predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate: struct, IFunction<TSource, int, bool>
            where TSum : struct
            => source switch
            {
                {Count: 0} => default,
                _ => ValueEnumerableExtensions.SumAt<TEnumerable, TEnumerator, TSource, TSum, TPredicate>(source, predicate)
            };
        
        [GeneratorIgnore]
        internal static TSum Sum<TEnumerable, TEnumerator, TSource, TResult, TSum, TSelector>(this TEnumerable source, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector: struct, IFunction<TSource, TResult>
            where TSum : struct
            => source switch
            {
                {Count: 0} => default,
                _ => ValueEnumerableExtensions.Sum<TEnumerable, TEnumerator, TSource, TResult, TSum, TSelector>(source, selector)
            };
        
        [GeneratorIgnore]
        internal static TSum SumAt<TEnumerable, TEnumerator, TSource, TResult, TSum, TSelector>(this TEnumerable source, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
            where TSum : struct
            => source switch
            {
                {Count: 0} => default,
                _ => ValueEnumerableExtensions.SumAt<TEnumerable, TEnumerator, TSource, TResult, TSum, TSelector>(source, selector)
            };
        
        [GeneratorIgnore]
        static TSum Sum<TEnumerable, TEnumerator, TSource, TResult, TSum, TPredicate, TSelector>(this TEnumerable source, TPredicate predicate, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate: struct, IFunction<TSource, bool>
            where TSelector: struct, IFunction<TSource, TResult>
            where TSum : struct
            => source switch
            {
                {Count: 0} => default,
                _ => ValueEnumerableExtensions.Sum<TEnumerable, TEnumerator, TSource, TResult, TSum, TPredicate, TSelector>(source, predicate, selector)
            };

    }
}

