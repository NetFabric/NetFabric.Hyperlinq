using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace NetFabric.Hyperlinq
{
    public static class IEnumerableExtensions
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

        public static int Count<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            => CountDowncasted<IEnumerable<TSource>, TSource>.Count(source, predicate);

        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            => AllDowncasted<IEnumerable<TSource>, TSource>.All(source, predicate);

        public static bool Any<TSource>(this IEnumerable<TSource> source)
        { 
            switch (source)
            {
                case TSource[] array:
                    return array.Length != 0;
                case IReadOnlyCollection<TSource> collection:
                    return collection.Count != 0;
                default:
                    return AnyDowncasted<IEnumerable<TSource>, TSource>.Any(source);
            }
        }

        public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            => AnyDowncasted<IEnumerable<TSource>, TSource>.Any(source, predicate);

        public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.Contains<TSource>(array, value);
                case ICollection<TSource> collection:
                    return collection.Contains(value);
                default:
                    return ContainsDowncasted<IEnumerable<TSource>, TSource>.Contains(source, value);
            }
        }

        public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
        {
            switch (source) 
            {
                case TSource[] array:
                    return array.Contains(value, comparer);
                default:
                    return ContainsDowncasted<IEnumerable<TSource>, TSource>.Contains(source, value, comparer);
            }
        }

        public static Enumerable.SelectEnumerable<IEnumerable<TSource>, IEnumerator<TSource>, TSource, TResult> Select<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TResult> selector) 
            => Enumerable.Select<IEnumerable<TSource>, IEnumerator<TSource>, TSource, TResult>(source, selector);

        public static Enumerable.WhereEnumerable<IEnumerable<TSource>, IEnumerator<TSource>, TSource> Where<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate) 
            => Enumerable.Where<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static TSource First<TSource>(this IEnumerable<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.First<TSource>(array);
                default:
                    return FirstDowncasted<IEnumerable<TSource>, TSource>.First(source);
            }
        }

        public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.First<TSource>(array, predicate);
                default:
                    return FirstDowncasted<IEnumerable<TSource>, TSource>.First(source);
            }
        }

        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.FirstOrDefault<TSource>(array);
                default:
                    return FirstOrDefaultDowncasted<IEnumerable<TSource>, TSource>.FirstOrDefault(source);
            }
        }

        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.FirstOrDefault<TSource>(array, predicate);
                default:
                    return FirstOrDefaultDowncasted<IEnumerable<TSource>, TSource>.FirstOrDefault(source);
            }
        }

        public static TSource? FirstOrNull<TSource>(this IEnumerable<TSource> source)
            where TSource : struct
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.FirstOrNull<TSource>(array);
                default:
                    return FirstOrNullDowncasted<IEnumerable<TSource>, TSource>.FirstOrNull(source);
            }
        }

        public static TSource? FirstOrNull<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.FirstOrNull<TSource>(array, predicate);
                default:
                    return FirstOrNullDowncasted<IEnumerable<TSource>, TSource>.FirstOrNull(source);
            }
        }

        public static TSource Single<TSource>(this IEnumerable<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.Single<TSource>(array);
                default:
                    return SingleDowncasted<IEnumerable<TSource>, TSource>.Single(source);
            }
        }

        public static TSource Single<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.Single<TSource>(array, predicate);
                default:
                    return SingleDowncasted<IEnumerable<TSource>, TSource>.Single(source);
            }
        }

        public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.SingleOrDefault<TSource>(array);
                default:
                    return SingleOrDefaultDowncasted<IEnumerable<TSource>, TSource>.SingleOrDefault(source);
            }
        }

        public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.SingleOrDefault<TSource>(array, predicate);
                default:
                    return SingleOrDefaultDowncasted<IEnumerable<TSource>, TSource>.SingleOrDefault(source);
            }
        }

        public static TSource? SingleOrNull<TSource>(this IEnumerable<TSource> source)
            where TSource : struct
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.SingleOrNull<TSource>(array);
                default:
                    return SingleOrNullDowncasted<IEnumerable<TSource>, TSource>.SingleOrNull(source);
            }
        }

        public static TSource? SingleOrNull<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.SingleOrNull<TSource>(array, predicate);
                default:
                    return SingleOrNullDowncasted<IEnumerable<TSource>, TSource>.SingleOrNull(source);
            }
        }

        public static IEnumerable<TSource> AsEnumerable<TSource>(this IEnumerable<TSource> source) 
            => source;

        public static Enumerable.AsValueEnumerableEnumerable<IEnumerable<TSource>, IEnumerator<TSource>, TSource> AsValueEnumerable<TSource>(this IEnumerable<TSource> source)
            => Enumerable.AsValueEnumerable<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source);

        public static TSource[] ToArray<TSource>(this IEnumerable<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return array;
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.ToArray<IReadOnlyList<TSource>, TSource>(list);
                case IReadOnlyCollection<TSource> collection:
                    return ReadOnlyCollection.ToArray<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(collection);
                default:
                    return Enumerable.ToArray<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }

        public static List<TSource> ToList<TSource>(this IEnumerable<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.ToList<TSource>(array);
                case IReadOnlyCollection<TSource> collection:
                    return ReadOnlyCollection.ToList<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(collection);
                default:
                    return Enumerable.ToList<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }
    }
}
