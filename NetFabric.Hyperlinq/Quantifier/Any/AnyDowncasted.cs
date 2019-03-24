using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    static class AnyDowncasted<TEnumerable, TSource>
        where TEnumerable : IEnumerable<TSource>
    {
        const string methodName = "Any";

        static readonly TypeDictionary<Func<IEnumerable<TSource>, bool>> methods = 
            new TypeDictionary<Func<IEnumerable<TSource>, bool>>(
                enumerableType => Dynamic.GetEnumerableHandler<TSource, bool>(methodName, enumerableType));

        static readonly TypeDictionary<Func<IEnumerable<TSource>, Func<TSource, bool>, bool>> predicateMethods = 
            new TypeDictionary<Func<IEnumerable<TSource>, Func<TSource, bool>, bool>>(
                enumerableType => Dynamic.GetEnumerableHandler<TSource, Func<TSource, bool>, bool>(methodName, enumerableType));

        public static bool Any(TEnumerable source)
            => methods.GetOrAdd(source.GetType())(source);

        public static bool Any(TEnumerable source, Func<TSource, bool> predicate)
            => predicateMethods.GetOrAdd(source.GetType())(source, predicate);
    }
}