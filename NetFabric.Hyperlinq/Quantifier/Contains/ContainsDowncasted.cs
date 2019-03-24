using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    static class ContainsDowncasted<TEnumerable, TSource>
        where TEnumerable : IEnumerable<TSource>
    {
        const string methodName = "Contains";

        static readonly TypeDictionary<Func<IEnumerable<TSource>, TSource, IEqualityComparer<TSource>, bool>> methods =
            new TypeDictionary<Func<IEnumerable<TSource>, TSource, IEqualityComparer<TSource>, bool>>(
                enumerableType => Dynamic.GetEnumerableHandler<TSource, TSource, IEqualityComparer<TSource>, bool>(methodName, enumerableType));

        public static bool Contains(TEnumerable source, TSource value, IEqualityComparer<TSource> comparer = null)
            => methods.GetOrAdd(source.GetType())(source, value, comparer);
    }
}