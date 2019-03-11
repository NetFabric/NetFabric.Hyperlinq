using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    static class AnyDowncasted<TEnumerable, TSource>
        where TEnumerable : IEnumerable<TSource>
    {
        const string methodName = "Any";

        static readonly TypeDictionary<Func<TEnumerable, bool>> methods = 
            new TypeDictionary<Func<TEnumerable, bool>>(
                enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, bool>(methodName, enumerableType));

        static readonly TypeDictionary<Func<TEnumerable, Func<TSource, bool>, bool>> predicateMethods = 
            new TypeDictionary<Func<TEnumerable, Func<TSource, bool>, bool>>(
                enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, Func<TSource, bool>, bool>(methodName, enumerableType));

        public static bool Any(TEnumerable source)
            => methods.GetOrAdd(source.GetType())(source);

        public static bool Any(TEnumerable source, Func<TSource, bool> predicate)
            => predicateMethods.GetOrAdd(source.GetType())(source, predicate);
    }
}