using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class SingleExtensions
    {
        public static TSource Single<TSource>(this IEnumerable<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.Single<TSource>(array);
                case IReadOnlyList<TSource> list:
                    return SingleDowncasted<IReadOnlyList<TSource>, TSource>.Single(list);
                case IReadOnlyCollection<TSource> collection:
                    return SingleDowncasted<IReadOnlyCollection<TSource>, TSource>.Single(collection);
                default:
                    return SingleDowncasted<IEnumerable<TSource>, TSource>.Single(source);
            }
        }

        public static TSource Single<TSource>(this IReadOnlyCollection<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.Single<TSource>(array);
                case IReadOnlyList<TSource> list:
                    return SingleDowncasted<IReadOnlyList<TSource>, TSource>.Single(list);
                default:
                    return SingleDowncasted<IReadOnlyCollection<TSource>, TSource>.Single(source);
            }
        }

        public static TSource Single<TSource>(this IReadOnlyList<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.Single<TSource>(array);
                default:
                    return SingleDowncasted<IReadOnlyList<TSource>, TSource>.Single(source);
            }
        }

        public static TSource Single<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.Single<TSource>(array, predicate);
                case IReadOnlyList<TSource> list:
                    return SingleDowncasted<IReadOnlyList<TSource>, TSource>.Single(list, predicate);
                case IReadOnlyCollection<TSource> collection:
                    return SingleDowncasted<IReadOnlyCollection<TSource>, TSource>.Single(collection, predicate);
                default:
                    return SingleDowncasted<IEnumerable<TSource>, TSource>.Single(source, predicate);
            }
        }

        public static TSource Single<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.Single<TSource>(array, predicate);
                case IReadOnlyList<TSource> list:
                    return SingleDowncasted<IReadOnlyList<TSource>, TSource>.Single(list, predicate);
                default:
                    return SingleDowncasted<IReadOnlyCollection<TSource>, TSource>.Single(source, predicate);
            }
        }

        public static TSource Single<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.Single<TSource>(array, predicate);
                default:
                    return SingleDowncasted<IReadOnlyList<TSource>, TSource>.Single(source, predicate);
            }
        }

        static class SingleDowncasted<TEnumerable, TSource>
            where TEnumerable : IEnumerable<TSource>
        {
            const string methodName = "Single";

            static readonly TypeDictionary<Func<TEnumerable, TSource>> methods = 
                new TypeDictionary<Func<TEnumerable, TSource>>(
                    enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, TSource>(methodName, enumerableType));

            static readonly TypeDictionary<Func<TEnumerable, Func<TSource, bool>, TSource>> predicateMethods = 
                new TypeDictionary<Func<TEnumerable, Func<TSource, bool>, TSource>>(
                    enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, Func<TSource, bool>, TSource>(methodName, enumerableType));

            public static TSource Single(TEnumerable source)
                => methods.GetOrAdd(source.GetType())(source);

            public static TSource Single(TEnumerable source, Func<TSource, bool> predicate)
                => predicateMethods.GetOrAdd(source.GetType())(source, predicate);
        }
    }
}