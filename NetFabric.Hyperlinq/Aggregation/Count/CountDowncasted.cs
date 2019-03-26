using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class CountExtensions
    {
        public static int Count<TSource>(this IEnumerable<TSource> source)
        { 
            switch (source)
            {
                case TSource[] array:
                    return array.Length;
                case IReadOnlyCollection<TSource> collection:
                    return collection.Count;
                default:
                    return CountDowncasted<IEnumerable<TSource>, TSource>.Count(source);
            }
        }

        public static int Count<TSource>(this IReadOnlyCollection<TSource> source)
        { 
            switch (source)
            {
                case TSource[] array:
                    return array.Length;
                default:
                    return source.Count;
            }
        }

        public static int Count<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        { 
            switch (source)
            {
                case TSource[] array:
                    return Array.Count(array, predicate);
                case IReadOnlyList<TSource> list:
                    return CountDowncasted<IReadOnlyList<TSource>, TSource>.Count(list, predicate);
                case IReadOnlyCollection<TSource> collection:
                    return CountDowncasted<IReadOnlyCollection<TSource>, TSource>.Count(collection, predicate);
                default:
                    return CountDowncasted<IEnumerable<TSource>, TSource>.Count(source, predicate);
            }
        }

        public static int Count<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, bool> predicate)
        { 
            switch (source)
            {
                case TSource[] array:
                    return Array.Count(array, predicate);
                case IReadOnlyList<TSource> list:
                    return CountDowncasted<IReadOnlyList<TSource>, TSource>.Count(list, predicate);
                default:
                    return CountDowncasted<IReadOnlyCollection<TSource>, TSource>.Count(source, predicate);
            }
        }

        public static int Count<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
        { 
            switch (source)
            {
                case TSource[] array:
                    return Array.Count(array, predicate);
                default:
                    return CountDowncasted<IReadOnlyList<TSource>, TSource>.Count(source, predicate);
            }
        }

        static class CountDowncasted<TEnumerable, TSource>
            where TEnumerable : IEnumerable<TSource>
        {
            const string methodName = "Count";

            static readonly TypeDictionary<Func<TEnumerable, int>> methods = 
                new TypeDictionary<Func<TEnumerable, int>>(
                    enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, int>(methodName, enumerableType));

            static readonly TypeDictionary<Func<TEnumerable, Func<TSource, bool>, int>> predicateMethods = 
                new TypeDictionary<Func<TEnumerable, Func<TSource, bool>, int>>(
                    enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, Func<TSource, bool>, int>(methodName, enumerableType));

            public static int Count(TEnumerable source)
                => methods.GetOrAdd(source.GetType())(source);

            public static int Count(TEnumerable source, Func<TSource, bool> predicate)
                => predicateMethods.GetOrAdd(source.GetType())(source, predicate);
        }
    }
}