using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class FirstOrDefaultExtensions
    {
        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.FirstOrDefault<TSource>(array);
                case IReadOnlyList<TSource> list:
                    return FirstOrDefaultDowncasted<IReadOnlyList<TSource>, TSource>.FirstOrDefault(list);
                case IReadOnlyCollection<TSource> collection:
                    return FirstOrDefaultDowncasted<IReadOnlyCollection<TSource>, TSource>.FirstOrDefault(collection);
                default:
                    return FirstOrDefaultDowncasted<IEnumerable<TSource>, TSource>.FirstOrDefault(source);
            }
        }

        public static TSource FirstOrDefault<TSource>(this IReadOnlyCollection<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.FirstOrDefault<TSource>(array);
                case IReadOnlyList<TSource> list:
                    return FirstOrDefaultDowncasted<IReadOnlyList<TSource>, TSource>.FirstOrDefault(list);
                default:
                    return FirstOrDefaultDowncasted<IReadOnlyCollection<TSource>, TSource>.FirstOrDefault(source);
            }
        }

        public static TSource FirstOrDefault<TSource>(this IReadOnlyList<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.FirstOrDefault<TSource>(array);
                default:
                    return FirstOrDefaultDowncasted<IReadOnlyList<TSource>, TSource>.FirstOrDefault(source);
            }
        }

        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.FirstOrDefault<TSource>(array, predicate);
                case IReadOnlyList<TSource> list:
                    return FirstOrDefaultDowncasted<IReadOnlyList<TSource>, TSource>.FirstOrDefault(list, predicate);
                case IReadOnlyCollection<TSource> collection:
                    return FirstOrDefaultDowncasted<IReadOnlyCollection<TSource>, TSource>.FirstOrDefault(collection, predicate);
                default:
                    return FirstOrDefaultDowncasted<IEnumerable<TSource>, TSource>.FirstOrDefault(source, predicate);
            }
        }

        public static TSource FirstOrDefault<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.FirstOrDefault<TSource>(array, predicate);
                case IReadOnlyList<TSource> list:
                    return FirstOrDefaultDowncasted<IReadOnlyList<TSource>, TSource>.FirstOrDefault(list, predicate);
                default:
                    return FirstOrDefaultDowncasted<IReadOnlyCollection<TSource>, TSource>.FirstOrDefault(source, predicate);
            }
        }

        public static TSource FirstOrDefault<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.FirstOrDefault<TSource>(array, predicate);
                default:
                    return FirstOrDefaultDowncasted<IReadOnlyList<TSource>, TSource>.FirstOrDefault(source, predicate);
            }
        }

        static class FirstOrDefaultDowncasted<TEnumerable, TSource>
            where TEnumerable : IEnumerable<TSource>
        {
            const string methodName = "FirstOrDefault";

            static readonly TypeDictionary<Func<TEnumerable, TSource>> methods = 
                new TypeDictionary<Func<TEnumerable, TSource>>(
                    enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, TSource>(methodName, enumerableType));

            static readonly TypeDictionary<Func<TEnumerable, Func<TSource, bool>, TSource>> predicateMethods = 
                new TypeDictionary<Func<TEnumerable, Func<TSource, bool>, TSource>>(
                    enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, Func<TSource, bool>, TSource>(methodName, enumerableType));

            public static TSource FirstOrDefault(TEnumerable source)
                => methods.GetOrAdd(source.GetType())(source);

            public static TSource FirstOrDefault(TEnumerable source, Func<TSource, bool> predicate)
                => predicateMethods.GetOrAdd(source.GetType())(source, predicate);
        }
    }
}