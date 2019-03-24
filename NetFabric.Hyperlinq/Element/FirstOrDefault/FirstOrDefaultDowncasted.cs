using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    static class FirstOrDefaultDowncasted<TEnumerable, TSource>
        where TEnumerable : IEnumerable<TSource>
    {
        const string methodName = "FirstOrDefault";

        static readonly TypeDictionary<Func<IEnumerable<TSource>, TSource>> methods = 
            new TypeDictionary<Func<IEnumerable<TSource>, TSource>>(
                enumerableType => Dynamic.GetEnumerableHandler<TSource, TSource>(methodName, enumerableType));

        static readonly TypeDictionary<Func<IEnumerable<TSource>, Func<TSource, bool>, TSource>> predicateMethods = 
            new TypeDictionary<Func<IEnumerable<TSource>, Func<TSource, bool>, TSource>>(
                enumerableType => Dynamic.GetEnumerableHandler<TSource, Func<TSource, bool>, TSource>(methodName, enumerableType));

        public static TSource FirstOrDefault(TEnumerable source)
            => methods.GetOrAdd(source.GetType())(source);

        public static TSource FirstOrDefault(TEnumerable source, Func<TSource, bool> predicate)
            => predicateMethods.GetOrAdd(source.GetType())(source, predicate);
    }
}