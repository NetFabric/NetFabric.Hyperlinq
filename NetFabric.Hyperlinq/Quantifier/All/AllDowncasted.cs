using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static class AllExtensions
    {
        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.All<TSource>(array, predicate);
                case IReadOnlyList<TSource> list:
                    return AllDowncasted<IReadOnlyList<TSource>, TSource>.All(list, predicate);
                case IReadOnlyCollection<TSource> collections:
                    return AllDowncasted<IReadOnlyCollection<TSource>, TSource>.All(collections, predicate);
                default:
                    return AllDowncasted<IEnumerable<TSource>, TSource>.All(source, predicate);
            }
        }

        public static bool All<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.All<TSource>(array, predicate);
                case IReadOnlyList<TSource> list:
                    return AllDowncasted<IReadOnlyList<TSource>, TSource>.All(list, predicate);
                default:
                    return AllDowncasted<IReadOnlyCollection<TSource>, TSource>.All(source, predicate);
            }
        }

        public static bool All<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.All<TSource>(array, predicate);
                default:
                    return AllDowncasted<IReadOnlyList<TSource>, TSource>.All(source, predicate);
            }
        }

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
}