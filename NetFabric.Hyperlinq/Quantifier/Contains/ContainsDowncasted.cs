using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static class ContainsExtensions
    {
        public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value, IEqualityComparer<TSource> comparer = null)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.Contains<TSource>(array, value, comparer);
                case IReadOnlyList<TSource> list:
                    return ContainsDowncasted<IReadOnlyList<TSource>, TSource>.Contains(list, value, comparer);
                case IReadOnlyCollection<TSource> collections:
                    return ContainsDowncasted<IReadOnlyCollection<TSource>, TSource>.Contains(collections, value, comparer);
                default:
                    return ContainsDowncasted<IEnumerable<TSource>, TSource>.Contains(source, value, comparer);
            }
        }    

        public static bool Contains<TSource>(this IReadOnlyCollection<TSource> source, TSource value, IEqualityComparer<TSource> comparer = null)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.Contains<TSource>(array, value, comparer);
                case IReadOnlyList<TSource> list:
                    return ContainsDowncasted<IReadOnlyList<TSource>, TSource>.Contains(list, value, comparer);
                default:
                    return ContainsDowncasted<IReadOnlyCollection<TSource>, TSource>.Contains(source, value, comparer);
            }
        }    

        public static bool Contains<TSource>(this IReadOnlyList<TSource> source, TSource value, IEqualityComparer<TSource> comparer = null)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.Contains<TSource>(array, value, comparer);
                default:
                    return ContainsDowncasted<IReadOnlyList<TSource>, TSource>.Contains(source, value, comparer);
            }
        }    

        static class ContainsDowncasted<TEnumerable, TSource>
            where TEnumerable : IEnumerable<TSource>
        {
            const string methodName = "Contains";

            static readonly TypeDictionary<Func<TEnumerable, TSource, IEqualityComparer<TSource>, bool>> methods =
                new TypeDictionary<Func<TEnumerable, TSource, IEqualityComparer<TSource>, bool>>(
                    enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, TSource, IEqualityComparer<TSource>, bool>(methodName, enumerableType));

            public static bool Contains(TEnumerable source, TSource value, IEqualityComparer<TSource> comparer)
                => methods.GetOrAdd(source.GetType())(source, value, comparer);
        }
    }
}