using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class SingleOrDefaultExtensions
    {
        public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.SingleOrDefault<TSource>(array);
                case IReadOnlyList<TSource> list:
                    return SingleOrDefaultDowncasted<IReadOnlyList<TSource>, TSource>.SingleOrDefault(list);
                case IReadOnlyCollection<TSource> collection:
                    return SingleOrDefaultDowncasted<IReadOnlyCollection<TSource>, TSource>.SingleOrDefault(collection);
                default:
                    return SingleOrDefaultDowncasted<IEnumerable<TSource>, TSource>.SingleOrDefault(source);
            }
        }

        public static TSource SingleOrDefault<TSource>(this IReadOnlyCollection<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.SingleOrDefault<TSource>(array);
                case IReadOnlyList<TSource> list:
                    return SingleOrDefaultDowncasted<IReadOnlyList<TSource>, TSource>.SingleOrDefault(list);
                default:
                    return SingleOrDefaultDowncasted<IReadOnlyCollection<TSource>, TSource>.SingleOrDefault(source);
            }
        }

        public static TSource SingleOrDefault<TSource>(this IReadOnlyList<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.SingleOrDefault<TSource>(array);
                default:
                    return SingleOrDefaultDowncasted<IReadOnlyList<TSource>, TSource>.SingleOrDefault(source);
            }
        }

        public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.SingleOrDefault<TSource>(array, predicate);
                case IReadOnlyList<TSource> list:
                    return SingleOrDefaultDowncasted<IReadOnlyList<TSource>, TSource>.SingleOrDefault(list, predicate);
                case IReadOnlyCollection<TSource> collection:
                    return SingleOrDefaultDowncasted<IReadOnlyCollection<TSource>, TSource>.SingleOrDefault(collection, predicate);
                default:
                    return SingleOrDefaultDowncasted<IEnumerable<TSource>, TSource>.SingleOrDefault(source, predicate);
            }
        }

        public static TSource SingleOrDefault<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.SingleOrDefault<TSource>(array, predicate);
                case IReadOnlyList<TSource> list:
                    return SingleOrDefaultDowncasted<IReadOnlyList<TSource>, TSource>.SingleOrDefault(list, predicate);
                default:
                    return SingleOrDefaultDowncasted<IReadOnlyCollection<TSource>, TSource>.SingleOrDefault(source, predicate);
            }
        }

        public static TSource SingleOrDefault<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.SingleOrDefault<TSource>(array, predicate);
                default:
                    return SingleOrDefaultDowncasted<IReadOnlyList<TSource>, TSource>.SingleOrDefault(source, predicate);
            }
        }

        static class SingleOrDefaultDowncasted<TEnumerable, TSource>
            where TEnumerable : IEnumerable<TSource>
        {
            const string methodName = "SingleOrDefault";

            static readonly TypeDictionary<Func<TEnumerable, TSource>> methods = 
                new TypeDictionary<Func<TEnumerable, TSource>>(
                    enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, TSource>(methodName, enumerableType));

            static readonly TypeDictionary<Func<TEnumerable, Func<TSource, bool>, TSource>> predicateMethods = 
                new TypeDictionary<Func<TEnumerable, Func<TSource, bool>, TSource>>(
                    enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, Func<TSource, bool>, TSource>(methodName, enumerableType));

            public static TSource SingleOrDefault(TEnumerable source)
                => methods.GetOrAdd(source.GetType())(source);

            public static TSource SingleOrDefault(TEnumerable source, Func<TSource, bool> predicate)
                => predicateMethods.GetOrAdd(source.GetType())(source, predicate);
        }
    }
}