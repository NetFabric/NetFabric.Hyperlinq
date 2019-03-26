using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class SingleOrNullExtensions
    {
        public static TSource? SingleOrNull<TSource>(this IEnumerable<TSource> source)
            where TSource : struct
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.SingleOrNull<TSource>(array);
                case IReadOnlyList<TSource> list:
                    return SingleOrNullDowncasted<IReadOnlyList<TSource>, TSource>.SingleOrNull(list);
                case IReadOnlyCollection<TSource> collection:
                    return SingleOrNullDowncasted<IReadOnlyCollection<TSource>, TSource>.SingleOrNull(collection);
                default:
                    return SingleOrNullDowncasted<IEnumerable<TSource>, TSource>.SingleOrNull(source);
            }
        }

        public static TSource? SingleOrNull<TSource>(this IReadOnlyCollection<TSource> source)
            where TSource : struct
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.SingleOrNull<TSource>(array);
                case IReadOnlyList<TSource> list:
                    return SingleOrNullDowncasted<IReadOnlyList<TSource>, TSource>.SingleOrNull(list);
                default:
                    return SingleOrNullDowncasted<IReadOnlyCollection<TSource>, TSource>.SingleOrNull(source);
            }
        }

        public static TSource? SingleOrNull<TSource>(this IReadOnlyList<TSource> source)
            where TSource : struct
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.SingleOrNull<TSource>(array);
                default:
                    return SingleOrNullDowncasted<IReadOnlyList<TSource>, TSource>.SingleOrNull(source);
            }
        }

        public static TSource? SingleOrNull<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.SingleOrNull<TSource>(array, predicate);
                case IReadOnlyList<TSource> list:
                    return SingleOrNullDowncasted<IReadOnlyList<TSource>, TSource>.SingleOrNull(list, predicate);
                case IReadOnlyCollection<TSource> collection:
                    return SingleOrNullDowncasted<IReadOnlyCollection<TSource>, TSource>.SingleOrNull(collection, predicate);
                default:
                    return SingleOrNullDowncasted<IEnumerable<TSource>, TSource>.SingleOrNull(source, predicate);
            }
        }

        public static TSource? SingleOrNull<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.SingleOrNull<TSource>(array, predicate);
                case IReadOnlyList<TSource> list:
                    return SingleOrNullDowncasted<IReadOnlyList<TSource>, TSource>.SingleOrNull(list, predicate);
                default:
                    return SingleOrNullDowncasted<IReadOnlyCollection<TSource>, TSource>.SingleOrNull(source, predicate);
            }
        }

        public static TSource? SingleOrNull<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.SingleOrNull<TSource>(array, predicate);
                default:
                    return SingleOrNullDowncasted<IReadOnlyList<TSource>, TSource>.SingleOrNull(source, predicate);
            }
        }

        static class SingleOrNullDowncasted<TEnumerable, TSource>
            where TEnumerable : IEnumerable<TSource>
            where TSource : struct
        {
            const string methodName = "SingleOrNull";

            static readonly TypeDictionary<Func<TEnumerable, TSource?>> methods = 
                new TypeDictionary<Func<TEnumerable, TSource?>>(
                    enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, TSource?>(methodName, enumerableType));

            static readonly TypeDictionary<Func<TEnumerable, Func<TSource, bool>, TSource?>> predicateMethods = 
                new TypeDictionary<Func<TEnumerable, Func<TSource, bool>, TSource?>>(
                    enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, Func<TSource, bool>, TSource?>(methodName, enumerableType));

            public static TSource? SingleOrNull(TEnumerable source)
                => methods.GetOrAdd(source.GetType())(source);

            public static TSource? SingleOrNull(TEnumerable source, Func<TSource, bool> predicate)
                => predicateMethods.GetOrAdd(source.GetType())(source, predicate);
        }
    }
}