using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ToArrayExtensions
    {
        public static TSource[] ToArray<TSource>(this IEnumerable<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return array;
                case ICollection<TSource> collection:
                {
                    var array = new TSource[collection.Count];
                    collection.CopyTo(array, 0);
                    return array;
                }
                case IReadOnlyList<TSource> list:
                    return ToArrayDowncasted<IReadOnlyList<TSource>, TSource>.ToArray(list);
                case IReadOnlyCollection<TSource> collection:
                    return ToArrayDowncasted<IReadOnlyCollection<TSource>, TSource>.ToArray(collection);
                default:
                    return ToArrayDowncasted<IEnumerable<TSource>, TSource>.ToArray(source);
            }
        }

        public static TSource[] ToArray<TSource>(this IReadOnlyCollection<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return array;
                case ICollection<TSource> collection:
                {
                    var array = new TSource[collection.Count];
                    collection.CopyTo(array, 0);
                    return array;
                }
                case IReadOnlyList<TSource> list:
                    return ToArrayDowncasted<IReadOnlyList<TSource>, TSource>.ToArray(list);
                default:
                    return ToArrayDowncasted<IReadOnlyCollection<TSource>, TSource>.ToArray(source);
            }
        }

        public static TSource[] ToArray<TSource>(this IReadOnlyList<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return array;
                case ICollection<TSource> collection:
                {
                    var array = new TSource[collection.Count];
                    collection.CopyTo(array, 0);
                    return array;
                }
                default:
                    return ToArrayDowncasted<IReadOnlyList<TSource>, TSource>.ToArray(source);
            }
        }

        static class ToArrayDowncasted<TEnumerable, TSource>
            where TEnumerable : IEnumerable<TSource>
        {
            const string methodName = "ToArray";

            static readonly TypeDictionary<Func<TEnumerable, TSource[]>> methods = 
                new TypeDictionary<Func<TEnumerable, TSource[]>>(
                    enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, TSource[]>(methodName, enumerableType));

            public static TSource[] ToArray(TEnumerable source)
                => methods.GetOrAdd(source.GetType())(source);
        }
    }
}