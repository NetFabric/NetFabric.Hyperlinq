using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class FirstExtensions
    {
        public static TSource First<TSource>(this IEnumerable<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.First<TSource>(array);
                case IReadOnlyList<TSource> list:
                    return FirstDowncasted<IReadOnlyList<TSource>, TSource>.First(list);
                case IReadOnlyCollection<TSource> collection:
                    return FirstDowncasted<IReadOnlyCollection<TSource>, TSource>.First(collection);
                default:
                    return FirstDowncasted<IEnumerable<TSource>, TSource>.First(source);
            }
        }

        public static TSource First<TSource>(this IReadOnlyCollection<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.First<TSource>(array);
                case IReadOnlyList<TSource> list:
                    return FirstDowncasted<IReadOnlyList<TSource>, TSource>.First(list);
                default:
                    return FirstDowncasted<IReadOnlyCollection<TSource>, TSource>.First(source);
            }
        }

        public static TSource First<TSource>(this IReadOnlyList<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.First<TSource>(array);
                default:
                    return FirstDowncasted<IReadOnlyList<TSource>, TSource>.First(source);
            }
        }

        public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.First<TSource>(array, predicate);
                case IReadOnlyList<TSource> list:
                    return FirstDowncasted<IReadOnlyList<TSource>, TSource>.First(list, predicate);
                case IReadOnlyCollection<TSource> collection:
                    return FirstDowncasted<IReadOnlyCollection<TSource>, TSource>.First(collection, predicate);
                default:
                    return FirstDowncasted<IEnumerable<TSource>, TSource>.First(source, predicate);
            }
        }

        public static TSource First<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.First<TSource>(array, predicate);
                case IReadOnlyList<TSource> list:
                    return FirstDowncasted<IReadOnlyList<TSource>, TSource>.First(list, predicate);
                default:
                    return FirstDowncasted<IReadOnlyCollection<TSource>, TSource>.First(source, predicate);
            }
        }

        public static TSource First<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.First<TSource>(array, predicate);
                default:
                    return FirstDowncasted<IReadOnlyList<TSource>, TSource>.First(source, predicate);
            }
        }

        static class FirstDowncasted<TEnumerable, TSource>
            where TEnumerable : IEnumerable<TSource>
        {
            const string methodName = "First";

            static readonly TypeDictionary<Func<TEnumerable, TSource>> methods = 
                new TypeDictionary<Func<TEnumerable, TSource>>(
                    enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, TSource>(methodName, enumerableType));

            static readonly TypeDictionary<Func<TEnumerable, Func<TSource, bool>, TSource>> predicateMethods = 
                new TypeDictionary<Func<TEnumerable, Func<TSource, bool>, TSource>>(
                    enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, Func<TSource, bool>, TSource>(methodName, enumerableType));

            public static TSource First(TEnumerable source)
                => methods.GetOrAdd(source.GetType())(source);

            public static TSource First(TEnumerable source, Func<TSource, bool> predicate)
                => predicateMethods.GetOrAdd(source.GetType())(source, predicate);
        }
    }
}