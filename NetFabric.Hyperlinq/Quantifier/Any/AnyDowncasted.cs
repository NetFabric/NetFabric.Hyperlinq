using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NetFabric.Hyperlinq
{
    static partial class AnyDowncasted<TSource>
    {
        static readonly TypeDictionary<Func<IEnumerable<TSource>, bool>> any = 
            new TypeDictionary<Func<IEnumerable<TSource>, bool>>(
                enumerableType => Dynamic.GetEnumerableHandler<TSource, bool>("Any", enumerableType));

        static readonly TypeDictionary<Func<IEnumerable<TSource>, Func<TSource, bool>, bool>> anyPredicate = 
            new TypeDictionary<Func<IEnumerable<TSource>, Func<TSource, bool>, bool>>(
                enumerableType => Dynamic.GetEnumerableHandler<TSource, Func<TSource, bool>, bool>("Any", enumerableType));

        public static bool Any<TEnumerable>(TEnumerable source)
            where TEnumerable : IEnumerable<TSource>
            => any.GetOrAdd(source.GetType())(source);

        public static bool Any<TEnumerable>(TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IEnumerable<TSource>
            => anyPredicate.GetOrAdd(source.GetType())(source, predicate);
    }
}