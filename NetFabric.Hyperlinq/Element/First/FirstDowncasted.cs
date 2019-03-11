using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    static class FirstDowncasted<TEnumerable, TSource>
        where TEnumerable : IEnumerable<TSource>
    {
        const string methodName = "First";

        static readonly TypeDictionary<Func<TEnumerable, TSource>> first = 
            new TypeDictionary<Func<TEnumerable, TSource>>(
                enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, TSource>(methodName, enumerableType));

        static readonly TypeDictionary<Func<TEnumerable, Func<TSource, bool>, TSource>> firstPredicate = 
            new TypeDictionary<Func<TEnumerable, Func<TSource, bool>, TSource>>(
                enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, Func<TSource, bool>, TSource>(methodName, enumerableType));

        public static TSource First(TEnumerable source)
            => first.GetOrAdd(source.GetType())(source);

        public static TSource First(TEnumerable source, Func<TSource, bool> predicate)
            => firstPredicate.GetOrAdd(source.GetType())(source, predicate);
    }
}