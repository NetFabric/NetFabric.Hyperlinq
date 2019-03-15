using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    static class FirstOrNullDowncasted<TEnumerable, TSource>
        where TEnumerable : IEnumerable<TSource>
    {
        const string methodName = "FirstOrNull";

        static readonly TypeDictionary<Func<TEnumerable, TSource>> methods = 
            new TypeDictionary<Func<TEnumerable, TSource>>(
                enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, TSource>(methodName, enumerableType));

        static readonly TypeDictionary<Func<TEnumerable, Func<TSource, bool>, TSource>> predicateMethods = 
            new TypeDictionary<Func<TEnumerable, Func<TSource, bool>, TSource>>(
                enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, Func<TSource, bool>, TSource>(methodName, enumerableType));

        public static TSource FirstOrNull(TEnumerable source)
            => methods.GetOrAdd(source.GetType())(source);

        public static TSource FirstOrNull(TEnumerable source, Func<TSource, bool> predicate)
            => predicateMethods.GetOrAdd(source.GetType())(source, predicate);
    }
}