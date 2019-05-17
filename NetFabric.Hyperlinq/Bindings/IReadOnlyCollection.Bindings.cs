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
            => ReadOnlyCollection.Count<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
        public static int Count<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, long, bool> predicate)
            => ReadOnlyCollection.Count<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static ReadOnlyCollection.SkipTakeEnumerable<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource> Skip<TSource>(
            this IReadOnlyCollection<TSource> source,
            int count) 
            => ReadOnlyCollection.Skip<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, count);

        public static ReadOnlyCollection.SkipTakeEnumerable<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource> Take<TSource>(
            this IReadOnlyCollection<TSource> source,
            int count) 
            => ReadOnlyCollection.Take<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, count);

        public static bool All<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, long, bool> predicate)
            => ReadOnlyCollection.All<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static bool Any<TSource>(this IReadOnlyCollection<TSource> source)
            => source.Count != 0;

        public static bool Any<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, long, bool> predicate)
            => ReadOnlyCollection.Any<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static bool Contains<TSource>(this IReadOnlyCollection<TSource> source, TSource value)
            => ReadOnlyCollection.Contains<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, value);

        public static bool Contains<TSource>(this IReadOnlyCollection<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
            => ReadOnlyCollection.Contains<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, value, comparer);

        public static ReadOnlyCollection.SelectEnumerable<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource, TResult> Select<TSource, TResult>(
            this IReadOnlyCollection<TSource> source,
            Func<TSource, long, TResult> selector) 
            => ReadOnlyCollection.Select<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource, TResult>(source, selector);

        public static Enumerable.SelectManyEnumerable<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this IReadOnlyCollection<TSource> source,
            Func<TSource, TSubEnumerable> selector) 
            where TSubEnumerable : IValueReadOnlyCollection<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IValueEnumerator<TResult>
            => Enumerable.SelectMany<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource, TSubEnumerable, TSubEnumerator, TResult>(source, selector);

        public static Enumerable.WhereEnumerable<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource> Where<TSource>(
            this IReadOnlyCollection<TSource> source, 
            Func<TSource, long, bool> predicate) 
            => Enumerable.Where<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static TSource First<TSource>(this IReadOnlyCollection<TSource> source)
            => ReadOnlyCollection.First<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);

        public static TSource First<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, long, bool> predicate)
            => ReadOnlyCollection.First<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static TSource FirstOrDefault<TSource>(this IReadOnlyCollection<TSource> source)
            => ReadOnlyCollection.FirstOrDefault<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);

        public static TSource FirstOrDefault<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, long, bool> predicate)
            => ReadOnlyCollection.FirstOrDefault<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static TSource? FirstOrNull<TSource>(this IReadOnlyCollection<TSource> source)
            where TSource : struct
            => ReadOnlyCollection.FirstOrNull<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);

        public static TSource? FirstOrNull<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, long, bool> predicate)
            where TSource : struct
            => ReadOnlyCollection.FirstOrNull<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static TSource Single<TSource>(this IReadOnlyCollection<TSource> source)
            => ReadOnlyCollection.Single<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);

        public static TSource Single<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, long, bool> predicate)
            => ReadOnlyCollection.Single<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static TSource SingleOrDefault<TSource>(this IReadOnlyCollection<TSource> source)
            => ReadOnlyCollection.SingleOrDefault<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);

        public static TSource SingleOrDefault<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, long, bool> predicate)
            => ReadOnlyCollection.SingleOrDefault<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static TSource? SingleOrNull<TSource>(this IReadOnlyCollection<TSource> source)
            where TSource : struct
            => ReadOnlyCollection.SingleOrNull<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);

        public static TSource? SingleOrNull<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, long, bool> predicate)
            where TSource : struct
            => ReadOnlyCollection.SingleOrNull<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static IReadOnlyCollection<TSource> AsEnumerable<TSource>(this IReadOnlyCollection<TSource> source)
            => source;

        public static ReadOnlyCollection.AsValueEnumerableEnumerable<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource> AsValueEnumerable<TSource>(this IReadOnlyCollection<TSource> source)
            => ReadOnlyCollection.AsValueEnumerable<IReadOnlyCollection<TSource>, IEnumerator<TSource>,  TSource>(source);

        public static TSource[] ToArray<TSource>(this IReadOnlyCollection<TSource> source)
            => ReadOnlyCollection.ToArray<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);

        public static List<TSource> ToList<TSource>(this IReadOnlyCollection<TSource> source)
            => ReadOnlyCollection.ToList<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);
    }
}