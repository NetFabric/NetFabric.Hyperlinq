using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    static class SingleDowncasted<TEnumerable, TSource>
        where TEnumerable : IEnumerable<TSource>
    {
        const string methodName = "Single";

        static readonly TypeDictionary<Func<TEnumerable, TSource>> single = 
            new TypeDictionary<Func<TEnumerable, TSource>>(
                enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, TSource>(methodName, enumerableType));

        static readonly TypeDictionary<Func<TEnumerable, Func<TSource, bool>, TSource>> singlePredicate = 
            new TypeDictionary<Func<TEnumerable, Func<TSource, bool>, TSource>>(
                enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, Func<TSource, bool>, TSource>(methodName, enumerableType));

        public static TSource Single(TEnumerable source)
            => single.GetOrAdd(source.GetType())(source);

        public static TSource Single(TEnumerable source, Func<TSource, bool> predicate)
            => singlePredicate.GetOrAdd(source.GetType())(source, predicate);
    }
}