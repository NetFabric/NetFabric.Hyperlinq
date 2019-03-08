using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NetFabric.Hyperlinq
{
    static partial class AllDowncasted<TSource>
    {
        static readonly TypeDictionary<Func<IEnumerable<TSource>, Func<TSource, bool>, bool>> all = 
            new TypeDictionary<Func<IEnumerable<TSource>, Func<TSource, bool>, bool>>(
                enumerableType => Dynamic.GetEnumerablePredicateHandler<TSource, bool>("All", enumerableType));

        public static bool All<TEnumerable>(TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IEnumerable<TSource>
            => all.GetOrAdd(source.GetType())(source, predicate);
    }
}