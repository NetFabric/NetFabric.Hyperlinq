using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NetFabric.Hyperlinq
{
    static partial class CountDowncasted<TSource>
    {
        static readonly TypeDictionary<Func<IEnumerable<TSource>, int>> count = 
            new TypeDictionary<Func<IEnumerable<TSource>, int>>(
                enumerableType => Dynamic.GetEnumerableHandler<TSource, int>("Count", enumerableType));

        static readonly TypeDictionary<Func<IEnumerable<TSource>, Func<TSource, bool>, int>> countPredicate = 
            new TypeDictionary<Func<IEnumerable<TSource>, Func<TSource, bool>, int>>(
                enumerableType => Dynamic.GetEnumerablePredicateHandler<TSource, int>("Count", enumerableType));

        public static int Count<TEnumerable>(TEnumerable source)
            where TEnumerable : IEnumerable<TSource>
            => count.GetOrAdd(source.GetType())(source);

        public static int Count<TEnumerable>(TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IEnumerable<TSource>
            => countPredicate.GetOrAdd(source.GetType())(source, predicate);
    }
}