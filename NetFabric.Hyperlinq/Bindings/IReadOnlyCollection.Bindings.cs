using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static class ReadOnlyCollectionBindings
    {
        public static int Count<TSource>(this IReadOnlyCollection<TSource> source)
            => source.Count;

        public static int Count<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, bool> predicate)
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.Count<IReadOnlyList<TSource>, TSource>(list, predicate);
                default:
                    return ReadOnlyCollection.Count<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            }
        }

        public static bool All<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, bool> predicate)
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.All<IReadOnlyList<TSource>, TSource>(list, predicate);
                default:
                    return ReadOnlyCollection.All<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            }
        }

        public static bool Any<TSource>(this IReadOnlyCollection<TSource> source)
            => source.Count != 0;

        public static bool Any<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, bool> predicate)
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.Any<IReadOnlyList<TSource>, TSource>(list, predicate);
                default:
                    return ReadOnlyCollection.Any<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            }
        }

        public static bool Contains<TSource>(this IReadOnlyCollection<TSource> source, TSource value)
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.Contains<IReadOnlyList<TSource>, TSource>(list, value);
                default:
                    return ReadOnlyCollection.Contains<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, value);
            }
        }

        public static bool Contains<TSource>(this IReadOnlyCollection<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.Contains<IReadOnlyList<TSource>, TSource>(list, value, comparer);
                default:
                    return ReadOnlyCollection.Contains<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, value, comparer);
            }
        }

        public static ReadOnlyCollection.SelectEnumerable<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource, TResult> Select<TSource, TResult>(
            this IReadOnlyCollection<TSource> source,
            Func<TSource, TResult> selector) 
            => ReadOnlyCollection.Select<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource, TResult>(source, selector);

        public static Enumerable.SelectManyEnumerable<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this IReadOnlyCollection<TSource> source,
            Func<TSource, TSubEnumerable> selector) 
            where TSubEnumerable : IValueReadOnlyCollection<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IValueEnumerator<TResult>
            => Enumerable.SelectMany<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource, TSubEnumerable, TSubEnumerator, TResult>(source, selector);

        public static Enumerable.WhereEnumerable<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource> Where<TSource>(
            this IReadOnlyCollection<TSource> source, 
            Func<TSource, bool> predicate) 
            => Enumerable.Where<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static TSource First<TSource>(this IReadOnlyCollection<TSource> source)
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.First<IReadOnlyList<TSource>, TSource>(list);
                default:
                    return ReadOnlyCollection.First<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }

        public static TSource First<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, bool> predicate)
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.First<IReadOnlyList<TSource>, TSource>(list, predicate);
                default:
                    return ReadOnlyCollection.First<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            }
        }

        public static TSource FirstOrDefault<TSource>(this IReadOnlyCollection<TSource> source)
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.FirstOrDefault<IReadOnlyList<TSource>, TSource>(list);
                default:
                    return ReadOnlyCollection.FirstOrDefault<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }

        public static TSource FirstOrDefault<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, bool> predicate)
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.FirstOrDefault<IReadOnlyList<TSource>, TSource>(list, predicate);
                default:
                    return ReadOnlyCollection.FirstOrDefault<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            }
        }

        public static TSource? FirstOrNull<TSource>(this IReadOnlyCollection<TSource> source)
            where TSource : struct
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.FirstOrNull<IReadOnlyList<TSource>, TSource>(list);
                default:
                    return ReadOnlyCollection.FirstOrNull<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }

        public static TSource? FirstOrNull<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.FirstOrNull<IReadOnlyList<TSource>, TSource>(list, predicate);
                default:
                    return ReadOnlyCollection.FirstOrNull<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            }
        }

        public static TSource Single<TSource>(this IReadOnlyCollection<TSource> source)
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.Single<IReadOnlyList<TSource>, TSource>(list);
                default:
                    return ReadOnlyCollection.Single<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }

        public static TSource Single<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, bool> predicate)
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.Single<IReadOnlyList<TSource>, TSource>(list, predicate);
                default:
                    return ReadOnlyCollection.Single<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            }
        }

        public static TSource SingleOrDefault<TSource>(this IReadOnlyCollection<TSource> source)
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.SingleOrDefault<IReadOnlyList<TSource>, TSource>(list);
                default:
                    return ReadOnlyCollection.SingleOrDefault<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }

        public static TSource SingleOrDefault<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, bool> predicate)
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.SingleOrDefault<IReadOnlyList<TSource>, TSource>(list, predicate);
                default:
                    return ReadOnlyCollection.SingleOrDefault<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            }
        }

        public static TSource? SingleOrNull<TSource>(this IReadOnlyCollection<TSource> source)
            where TSource : struct
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.SingleOrNull<IReadOnlyList<TSource>, TSource>(list);
                default:
                    return ReadOnlyCollection.SingleOrNull<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }

        public static TSource? SingleOrNull<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.SingleOrNull<IReadOnlyList<TSource>, TSource>(list, predicate);
                default:
                    return ReadOnlyCollection.SingleOrNull<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            }
        }

        public static IReadOnlyCollection<TSource> AsEnumerable<TSource>(this IReadOnlyCollection<TSource> source)
            => source;

        public static Enumerable.AsValueEnumerableEnumerable<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource> AsValueEnumerable<TSource>(this IReadOnlyCollection<TSource> source)
            => Enumerable.AsValueEnumerable<IReadOnlyCollection<TSource>, IEnumerator<TSource>,  TSource>(source);

        public static ReadOnlyCollection.AsValueReadOnlyCollectionEnumerable<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource> AsValueReadOnlyCollection<TSource>(this IReadOnlyCollection<TSource> source)
            => ReadOnlyCollection.AsValueEnumerable<IReadOnlyCollection<TSource>, IEnumerator<TSource>,  TSource>(source);

        public static TSource[] ToArray<TSource>(this IReadOnlyCollection<TSource> source)
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.ToArray<IReadOnlyList<TSource>, TSource>(list);
                default:
                    return ReadOnlyCollection.ToArray<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }

        public static List<TSource> ToList<TSource>(this IReadOnlyCollection<TSource> source)
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.ToList<IReadOnlyList<TSource>, TSource>(list);
                default:
                    return ReadOnlyCollection.ToList<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }
    }
}