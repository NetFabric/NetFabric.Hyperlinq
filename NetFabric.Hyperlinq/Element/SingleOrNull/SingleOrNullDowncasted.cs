using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    static class SingleOrNullDowncasted<TEnumerable, TSource>
        where TEnumerable : IEnumerable<TSource>
    {
        const string methodName = "SingleOrNull";

        static readonly TypeDictionary<Func<TEnumerable, TSource>> singleOrNull = 
            new TypeDictionary<Func<TEnumerable, TSource>>(
                enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, TSource>(methodName, enumerableType));

        static readonly TypeDictionary<Func<TEnumerable, Func<TSource, bool>, TSource>> singleOrNullPredicate = 
            new TypeDictionary<Func<TEnumerable, Func<TSource, bool>, TSource>>(
                enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, Func<TSource, bool>, TSource>(methodName, enumerableType));

        public static TSource SingleOrNull(TEnumerable source)
            => singleOrNull.GetOrAdd(source.GetType())(source);

        public static TSource SingleOrNull(TEnumerable source, Func<TSource, bool> predicate)
            => singleOrNullPredicate.GetOrAdd(source.GetType())(source, predicate);
    }
}