using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    static class AnyDowncasted<TEnumerable, TSource>
        where TEnumerable : IEnumerable<TSource>
    {
        const string methodName = "Any";

        static readonly TypeDictionary<Func<TEnumerable, bool>> any = 
            new TypeDictionary<Func<TEnumerable, bool>>(
                enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, bool>(methodName, enumerableType));

        static readonly TypeDictionary<Func<TEnumerable, Func<TSource, bool>, bool>> anyPredicate = 
            new TypeDictionary<Func<TEnumerable, Func<TSource, bool>, bool>>(
                enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, Func<TSource, bool>, bool>(methodName, enumerableType));

        public static bool Any(TEnumerable source)
            => any.GetOrAdd(source.GetType())(source);

        public static bool Any(TEnumerable source, Func<TSource, bool> predicate)
            => anyPredicate.GetOrAdd(source.GetType())(source, predicate);
    }
}