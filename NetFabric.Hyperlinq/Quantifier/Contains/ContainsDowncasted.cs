using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    static class ContainsDowncasted<TEnumerable, TSource>
        where TEnumerable : IEnumerable<TSource>
    {
        const string methodName = "Contains";

        static readonly TypeDictionary<Func<TEnumerable, TSource, IEqualityComparer<TSource>, bool>> containsComparer =
            new TypeDictionary<Func<TEnumerable, TSource, IEqualityComparer<TSource>, bool>>(
                enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, TSource, IEqualityComparer<TSource>, bool>(methodName, enumerableType));

        public static bool Contains(TEnumerable source, TSource value, IEqualityComparer<TSource> comparer = null)
            => containsComparer.GetOrAdd(source.GetType())(source, value, comparer);
    }
}