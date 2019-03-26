using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static class AnyExtensions
    {
        public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.Any<TSource>(array, predicate);
                case IReadOnlyList<TSource> list:
                    return AnyDowncasted<IReadOnlyList<TSource>, TSource>.Any(list, predicate);
                case IReadOnlyCollection<TSource> collections:
                    return AnyDowncasted<IReadOnlyCollection<TSource>, TSource>.Any(collections, predicate);
                default:
                    return AnyDowncasted<IEnumerable<TSource>, TSource>.Any(source, predicate);
            }
        }

        public static bool Any<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.Any<TSource>(array, predicate);
                case IReadOnlyList<TSource> list:
                    return AnyDowncasted<IReadOnlyList<TSource>, TSource>.Any(list, predicate);
                default:
                    return AnyDowncasted<IReadOnlyCollection<TSource>, TSource>.Any(source, predicate);
            }
        }

        public static bool Any<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.Any<TSource>(array, predicate);
                default:
                    return AnyDowncasted<IReadOnlyList<TSource>, TSource>.Any(source, predicate);
            }
        }

        static class AnyDowncasted<TEnumerable, TSource>
            where TEnumerable : IEnumerable<TSource>
        {
            const string methodName = "Any";

            static readonly TypeDictionary<Func<TEnumerable, Func<TSource, bool>, bool>> methods = 
                new TypeDictionary<Func<TEnumerable, Func<TSource, bool>, bool>>(
                    enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, Func<TSource, bool>, bool>(methodName, enumerableType));

            public static bool Any(TEnumerable source, Func<TSource, bool> predicate)
                => methods.GetOrAdd(source.GetType())(source, predicate);
        }
    }
}