using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static class EnumerableBindings
    {
        public static int Count<TSource>(this IEnumerable<TSource> source)
        {
            switch(source)
            {
                case IReadOnlyCollection<TSource> collection:
                    return collection.Count;
                default:
                    return Enumerable.Count<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }

        public static int Count<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.Count<IReadOnlyList<TSource>, TSource>(list, predicate);
                case IReadOnlyCollection<TSource> collection:
                    return ReadOnlyCollection.Count<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(collection, predicate);
                default:
                    return Enumerable.Count<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            }
        }

        public static Enumerable.SkipEnumerable<IEnumerable<TSource>, IEnumerator<TSource>, TSource> Skip<TSource>(
            this IEnumerable<TSource> source,
            int count) 
            => Enumerable.Skip<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source, count);

        public static Enumerable.TakeEnumerable<IEnumerable<TSource>, IEnumerator<TSource>, TSource> Take<TSource>(
            this IEnumerable<TSource> source,
            int count) 
            => Enumerable.Take<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source, count);

        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.All<IReadOnlyList<TSource>, TSource>(list, predicate);
                case IReadOnlyCollection<TSource> collection:
                    return ReadOnlyCollection.All<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(collection, predicate);
                default:
                    return Enumerable.All<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            }
        }

        public static bool Any<TSource>(this IEnumerable<TSource> source)
        {
            switch(source)
            {
                case IReadOnlyCollection<TSource> collection:
                    return collection.Count != 0;
                default:
                    return Enumerable.Any<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }

        public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.Any<IReadOnlyList<TSource>, TSource>(list, predicate);
                case IReadOnlyCollection<TSource> collection:
                    return ReadOnlyCollection.Any<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(collection, predicate);
                default:
                    return Enumerable.Any<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            }
        }

        public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value)
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.Contains<IReadOnlyList<TSource>, TSource>(list, value);
                case IReadOnlyCollection<TSource> collection:
                    return ReadOnlyCollection.Contains<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(collection, value);
                default:
                    return Enumerable.Contains<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source, value);
            }
        }

        public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.Contains<IReadOnlyList<TSource>, TSource>(list, value, comparer);
                case IReadOnlyCollection<TSource> collection:
                    return ReadOnlyCollection.Contains<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(collection, value, comparer);
                default:
                    return Enumerable.Contains<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source, value, comparer);
            }
        }

        public static Enumerable.SelectEnumerable<IEnumerable<TSource>, IEnumerator<TSource>, TSource, TResult> Select<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TResult> selector) 
            => Enumerable.Select<IEnumerable<TSource>, IEnumerator<TSource>, TSource, TResult>(source, selector);

        public static Enumerable.SelectManyEnumerable<IEnumerable<TSource>, IEnumerator<TSource>, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TSubEnumerable> selector) 
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IValueEnumerator<TResult>
            => Enumerable.SelectMany<IEnumerable<TSource>, IEnumerator<TSource>, TSource, TSubEnumerable, TSubEnumerator, TResult>(source, selector);

        public static Enumerable.WhereEnumerable<IEnumerable<TSource>, IEnumerator<TSource>, TSource> Where<TSource>(
            this IEnumerable<TSource> source, 
            Func<TSource, bool> predicate) 
            => Enumerable.Where<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static TSource First<TSource>(this IEnumerable<TSource> source)
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.First<IReadOnlyList<TSource>, TSource>(list);
                case IReadOnlyCollection<TSource> collection:
                    return ReadOnlyCollection.First<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(collection);
                default:
                    return Enumerable.First<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }

        public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.First<IReadOnlyList<TSource>, TSource>(list, predicate);
                case IReadOnlyCollection<TSource> collection:
                    return ReadOnlyCollection.First<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(collection, predicate);
                default:
                    return Enumerable.First<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            }
        }

        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.FirstOrDefault<IReadOnlyList<TSource>, TSource>(list);
                case IReadOnlyCollection<TSource> collection:
                    return ReadOnlyCollection.FirstOrDefault<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(collection);
                default:
                    return Enumerable.FirstOrDefault<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }

        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.FirstOrDefault<IReadOnlyList<TSource>, TSource>(list, predicate);
                case IReadOnlyCollection<TSource> collection:
                    return ReadOnlyCollection.FirstOrDefault<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(collection, predicate);
                default:
                    return Enumerable.FirstOrDefault<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            }
        }

        public static TSource? FirstOrNull<TSource>(this IEnumerable<TSource> source)
            where TSource : struct
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.FirstOrNull<IReadOnlyList<TSource>, TSource>(list);
                case IReadOnlyCollection<TSource> collection:
                    return ReadOnlyCollection.FirstOrNull<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(collection);
                default:
                    return Enumerable.FirstOrNull<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }

        public static TSource? FirstOrNull<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.FirstOrNull<IReadOnlyList<TSource>, TSource>(list, predicate);
                case IReadOnlyCollection<TSource> collection:
                    return ReadOnlyCollection.FirstOrNull<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(collection, predicate);
                default:
                    return Enumerable.FirstOrNull<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            }
        }

        public static TSource Single<TSource>(this IEnumerable<TSource> source)
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.Single<IReadOnlyList<TSource>, TSource>(list);
                case IReadOnlyCollection<TSource> collection:
                    return ReadOnlyCollection.Single<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(collection);
                default:
                    return Enumerable.Single<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }

        public static TSource Single<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.Single<IReadOnlyList<TSource>, TSource>(list, predicate);
                case IReadOnlyCollection<TSource> collection:
                    return ReadOnlyCollection.Single<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(collection, predicate);
                default:
                    return Enumerable.Single<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            }
        }

        public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.SingleOrDefault<IReadOnlyList<TSource>, TSource>(list);
                case IReadOnlyCollection<TSource> collection:
                    return ReadOnlyCollection.SingleOrDefault<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(collection);
                default:
                    return Enumerable.SingleOrDefault<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }

        public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.SingleOrDefault<IReadOnlyList<TSource>, TSource>(list, predicate);
                case IReadOnlyCollection<TSource> collection:
                    return ReadOnlyCollection.SingleOrDefault<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(collection, predicate);
                default:
                    return Enumerable.SingleOrDefault<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            }
        }

        public static TSource? SingleOrNull<TSource>(this IEnumerable<TSource> source)
            where TSource : struct
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.SingleOrNull<IReadOnlyList<TSource>, TSource>(list);
                case IReadOnlyCollection<TSource> collection:
                    return ReadOnlyCollection.SingleOrNull<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(collection);
                default:
                    return Enumerable.SingleOrNull<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }

        public static TSource? SingleOrNull<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
        {
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.SingleOrNull<IReadOnlyList<TSource>, TSource>(list, predicate);
                case IReadOnlyCollection<TSource> collection:
                    return ReadOnlyCollection.SingleOrNull<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(collection, predicate);
                default:
                    return Enumerable.SingleOrNull<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            }
        }

        public static IEnumerable<TSource> AsEnumerable<TSource>(this IEnumerable<TSource> source)
            => source;

        public static Enumerable.AsValueEnumerableEnumerable<IEnumerable<TSource>, IEnumerator<TSource>, TSource> AsValueEnumerable<TSource>(this IEnumerable<TSource> source)
            => Enumerable.AsValueEnumerable<IEnumerable<TSource>, IEnumerator<TSource>,  TSource>(source);

        public static TSource[] ToArray<TSource>(this IEnumerable<TSource> source)
        {
            switch(source)
            {
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
            switch(source)
            {
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.ToList<IReadOnlyList<TSource>, TSource>(list);
                case IReadOnlyCollection<TSource> collection:
                    return ReadOnlyCollection.ToList<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(collection);
                default:
                    return Enumerable.ToList<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }    }
}