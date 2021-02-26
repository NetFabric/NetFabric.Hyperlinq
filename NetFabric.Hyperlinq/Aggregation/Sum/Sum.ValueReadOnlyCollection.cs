using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollectionExtensions
    {
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

    }
}

