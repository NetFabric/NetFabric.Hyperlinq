using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class FirstOrNullExtensions
    {
        public static TSource? FirstOrNull<TSource>(this IEnumerable<TSource> source)
            where TSource : struct
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.FirstOrNull<TSource>(array);
                case IReadOnlyList<TSource> list:
                    return FirstOrNullDowncasted<IReadOnlyList<TSource>, TSource>.FirstOrNull(list);
                case IReadOnlyCollection<TSource> collection:
                    return FirstOrNullDowncasted<IReadOnlyCollection<TSource>, TSource>.FirstOrNull(collection);
                default:
                    return FirstOrNullDowncasted<IEnumerable<TSource>, TSource>.FirstOrNull(source);
            }
        }

        public static TSource? FirstOrNull<TSource>(this IReadOnlyCollection<TSource> source)
            where TSource : struct
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.FirstOrNull<TSource>(array);
                case IReadOnlyList<TSource> list:
                    return FirstOrNullDowncasted<IReadOnlyList<TSource>, TSource>.FirstOrNull(list);
                default:
                    return FirstOrNullDowncasted<IReadOnlyCollection<TSource>, TSource>.FirstOrNull(source);
            }
        }

        public static TSource? FirstOrNull<TSource>(this IReadOnlyList<TSource> source)
            where TSource : struct
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.FirstOrNull<TSource>(array);
                default:
                    return FirstOrNullDowncasted<IReadOnlyList<TSource>, TSource>.FirstOrNull(source);
            }
        }

        public static TSource? FirstOrNull<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.FirstOrNull<TSource>(array, predicate);
                case IReadOnlyList<TSource> list:
                    return FirstOrNullDowncasted<IReadOnlyList<TSource>, TSource>.FirstOrNull(list, predicate);
                case IReadOnlyCollection<TSource> collection:
                    return FirstOrNullDowncasted<IReadOnlyCollection<TSource>, TSource>.FirstOrNull(collection, predicate);
                default:
                    return FirstOrNullDowncasted<IEnumerable<TSource>, TSource>.FirstOrNull(source, predicate);
            }
        }

        public static TSource? FirstOrNull<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.FirstOrNull<TSource>(array, predicate);
                case IReadOnlyList<TSource> list:
                    return FirstOrNullDowncasted<IReadOnlyList<TSource>, TSource>.FirstOrNull(list, predicate);
                default:
                    return FirstOrNullDowncasted<IReadOnlyCollection<TSource>, TSource>.FirstOrNull(source, predicate);
            }
        }

        public static TSource? FirstOrNull<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.FirstOrNull<TSource>(array, predicate);
                default:
                    return FirstOrNullDowncasted<IReadOnlyList<TSource>, TSource>.FirstOrNull(source, predicate);
            }
        }

        static class FirstOrNullDowncasted<TEnumerable, TSource>
            where TEnumerable : IEnumerable<TSource>
            where TSource : struct
        {
            const string methodName = "FirstOrNull";

            static readonly TypeDictionary<Func<TEnumerable, TSource?>> methods = 
                new TypeDictionary<Func<TEnumerable, TSource?>>(
                    enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, TSource?>(methodName, enumerableType));

            static readonly TypeDictionary<Func<TEnumerable, Func<TSource, bool>, TSource?>> predicateMethods = 
                new TypeDictionary<Func<TEnumerable, Func<TSource, bool>, TSource?>>(
                    enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, Func<TSource, bool>, TSource?>(methodName, enumerableType));

            public static TSource? FirstOrNull(TEnumerable source)
                => methods.GetOrAdd(source.GetType())(source);

            public static TSource? FirstOrNull(TEnumerable source, Func<TSource, bool> predicate)
                => predicateMethods.GetOrAdd(source.GetType())(source, predicate);
        }
    }
}