using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    static class CountDowncasted<TSource>
    {
        const string methodName = "Count";

        static readonly TypeDictionary<Func<IEnumerable<TSource>, int>> methods = 
            new TypeDictionary<Func<IEnumerable<TSource>, int>>(
                enumerableType => Dynamic.GetEnumerableHandler<TSource, int>(methodName, enumerableType));

        static readonly TypeDictionary<Func<IEnumerable<TSource>, Func<TSource, bool>, int>> predicateMethods = 
            new TypeDictionary<Func<IEnumerable<TSource>, Func<TSource, bool>, int>>(
                enumerableType => Dynamic.GetEnumerableHandler<TSource, Func<TSource, bool>, int>(methodName, enumerableType));

        public static int Count(IEnumerable<TSource> source)
            => methods.GetOrAdd(source.GetType())(source);

        public static int Count(IEnumerable<TSource> source, Func<TSource, bool> predicate)
            => predicateMethods.GetOrAdd(source.GetType())(source, predicate);
    }
}