using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    static class CountDowncasted<TEnumerable, TSource>
        where TEnumerable : IEnumerable<TSource>
    {
        const string methodName = "Count";

        static readonly TypeDictionary<Func<TEnumerable, int>> count = 
            new TypeDictionary<Func<TEnumerable, int>>(
                enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, int>(methodName, enumerableType));

        static readonly TypeDictionary<Func<TEnumerable, Func<TSource, bool>, int>> countPredicate = 
            new TypeDictionary<Func<TEnumerable, Func<TSource, bool>, int>>(
                enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, Func<TSource, bool>, int>(methodName, enumerableType));

        public static int Count(TEnumerable source)
            => count.GetOrAdd(source.GetType())(source);

        public static int Count(TEnumerable source, Func<TSource, bool> predicate)
            => countPredicate.GetOrAdd(source.GetType())(source, predicate);
    }
}