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
            => ContainsDowncasted<IEnumerable<TSource>, TSource>.Contains(source, value);

        public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
            => ContainsDowncasted<IEnumerable<TSource>, TSource>.Contains(source, value, comparer);

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
                    return ArrayExtensions.First<TSource>(array);
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.First<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(list);
                case IReadOnlyCollection<TSource> collection:
                    return ReadOnlyCollection.First<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(collection);
                default:
                    return Enumerable.First<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }

        public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return ArrayExtensions.First<TSource>(array, predicate);
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.First<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(list, predicate);
                default:
                    return Enumerable.First<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            }
        }

        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return ArrayExtensions.FirstOrDefault<TSource>(array);
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.FirstOrDefault<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(list);
                case IReadOnlyCollection<TSource> collection:
                    return ReadOnlyCollection.FirstOrDefault<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(collection);
                default:
                    return Enumerable.FirstOrDefault<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }

        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return ArrayExtensions.FirstOrDefault<TSource>(array, predicate);
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.FirstOrDefault<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(list, predicate);
                default:
                    return Enumerable.FirstOrDefault<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            }
        }

        public static TSource? FirstOrNull<TSource>(this IEnumerable<TSource> source)
            where TSource : struct
        {
            switch (source)
            {
                case TSource[] array:
                    return ArrayExtensions.FirstOrNull<TSource>(array);
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.FirstOrNull<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(list);
                case IReadOnlyCollection<TSource> collection:
                    return ReadOnlyCollection.FirstOrNull<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(collection);
                default:
                    return Enumerable.FirstOrNull<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }

        public static TSource? FirstOrNull<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
        {
            switch (source)
            {
                case TSource[] array:
                    return ArrayExtensions.FirstOrNull<TSource>(array, predicate);
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.FirstOrNull<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(list, predicate);
                default:
                    return Enumerable.FirstOrNull<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            }
        }

        public static TSource Single<TSource>(this IEnumerable<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return ArrayExtensions.Single<TSource>(array);
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.Single<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(list);
                case IReadOnlyCollection<TSource> collection:
                    return ReadOnlyCollection.Single<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(collection);
                default:
                    return Enumerable.Single<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }

        public static TSource Single<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return ArrayExtensions.Single<TSource>(array, predicate);
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.Single<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(list, predicate);
                default:
                    return Enumerable.Single<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            }
        }

        public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return ArrayExtensions.SingleOrDefault<TSource>(array);
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.SingleOrDefault<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(list);
                case IReadOnlyCollection<TSource> collection:
                    return ReadOnlyCollection.SingleOrDefault<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(collection);
                default:
                    return Enumerable.SingleOrDefault<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }

        public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return ArrayExtensions.SingleOrDefault<TSource>(array, predicate);
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.SingleOrDefault<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(list, predicate);
                default:
                    return Enumerable.SingleOrDefault<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            }
        }

        public static TSource? SingleOrNull<TSource>(this IEnumerable<TSource> source)
            where TSource : struct
        {
            switch (source)
            {
                case TSource[] array:
                    return ArrayExtensions.SingleOrNull<TSource>(array);
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.SingleOrNull<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(list);
                case IReadOnlyCollection<TSource> collection:
                    return ReadOnlyCollection.SingleOrNull<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(collection);
                default:
                    return Enumerable.SingleOrNull<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }

        public static TSource? SingleOrNull<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
        {
            switch (source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.SingleOrNull<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(list, predicate);
                default:
                    return Enumerable.SingleOrNull<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
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
                    return ReadOnlyList.ToArray<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(list);
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
                    return ArrayExtensions.ToList<TSource>(array);
                case IReadOnlyCollection<TSource> collection:
                    return ReadOnlyCollection.ToList<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(collection);
                default:
                    return Enumerable.ToList<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }
    }
}
