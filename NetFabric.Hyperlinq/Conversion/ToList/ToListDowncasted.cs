using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ToListExtensions
    {
        public static List<TSource> ToList<TSource>(this IEnumerable<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.ToList<TSource>(array);
                case List<TSource> list:
                    return list;
                case IReadOnlyList<TSource> list:
                    return ToListDowncasted<IReadOnlyList<TSource>, TSource>.ToList(list);
                case IReadOnlyCollection<TSource> collection:
                    return ToListDowncasted<IReadOnlyCollection<TSource>, TSource>.ToList(collection);
                default:
                    return ToListDowncasted<IEnumerable<TSource>, TSource>.ToList(source);
            }
        }

        public static List<TSource> ToList<TSource>(this IReadOnlyCollection<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.ToList<TSource>(array);
                case List<TSource> list:
                    return list;
                case IReadOnlyList<TSource> list:
                    return ToListDowncasted<IReadOnlyList<TSource>, TSource>.ToList(list);
                default:
                    return ToListDowncasted<IReadOnlyCollection<TSource>, TSource>.ToList(source);
            }
        }

        public static List<TSource> ToList<TSource>(this IReadOnlyList<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.ToList<TSource>(array);
                case List<TSource> list:
                    return list;
                default:
                    return ToListDowncasted<IReadOnlyList<TSource>, TSource>.ToList(source);
            }
        }

        static class ToListDowncasted<TEnumerable, TSource>
            where TEnumerable : IEnumerable<TSource>
        {
            const string methodName = "ToList";

            static readonly TypeDictionary<Func<TEnumerable, List<TSource>>> methods = 
                new TypeDictionary<Func<TEnumerable, List<TSource>>>(
                    enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, List<TSource>>(methodName, enumerableType));

            public static List<TSource> ToList(TEnumerable source)
                => methods.GetOrAdd(source.GetType())(source);
        }
    }
}