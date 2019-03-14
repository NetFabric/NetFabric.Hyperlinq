using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    static class AllDowncasted<TEnumerable, TSource>
        where TEnumerable : IEnumerable<TSource>
    {
        const string methodName = "All";

        static readonly TypeDictionary<Func<TEnumerable, Func<TSource, bool>, bool>> methods = 
            new TypeDictionary<Func<TEnumerable, Func<TSource, bool>, bool>>(
                enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, Func<TSource, bool>, bool>(methodName, enumerableType));

        public static bool All(TEnumerable source, Func<TSource, bool> predicate)
            => methods.GetOrAdd(source.GetType())(source, predicate);
    }
}