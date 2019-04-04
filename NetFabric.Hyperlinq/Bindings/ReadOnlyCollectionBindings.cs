using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static class ReadOnlyCollectionBindings
    {
        public static int Count<TSource>(this IReadOnlyCollection<TSource> source)
            => ReadOnlyCollection.Count<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);

        public static int Count<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.Count<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static bool All<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.All<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static bool Any<TSource>(this IReadOnlyCollection<TSource> source)
            => ReadOnlyCollection.Any<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);

        public static bool Any<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.Any<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static bool Contains<TSource>(this IReadOnlyCollection<TSource> source, TSource value)
            => source.Contains(value);

        public static bool Contains<TSource>(this IReadOnlyCollection<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
            => ReadOnlyCollection.Contains<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, value, comparer);

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
            => ReadOnlyCollection.First<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);

        public static TSource First<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.First<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static TSource FirstOrDefault<TSource>(this IReadOnlyCollection<TSource> source)
            => ReadOnlyCollection.FirstOrDefault<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);

        public static TSource FirstOrDefault<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.FirstOrDefault<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static TSource? FirstOrNull<TSource>(this IReadOnlyCollection<TSource> source)
            where TSource : struct
            => ReadOnlyCollection.FirstOrNull<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);

        public static TSource? FirstOrNull<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
            => ReadOnlyCollection.FirstOrNull<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static TSource Single<TSource>(this IReadOnlyCollection<TSource> source)
            => ReadOnlyCollection.Single<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);

        public static TSource Single<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.Single<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static TSource SingleOrDefault<TSource>(this IReadOnlyCollection<TSource> source)
            => ReadOnlyCollection.SingleOrDefault<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);

        public static TSource SingleOrDefault<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.SingleOrDefault<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static TSource? SingleOrNull<TSource>(this IReadOnlyCollection<TSource> source)
            where TSource : struct
            => ReadOnlyCollection.SingleOrNull<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);

        public static TSource? SingleOrNull<TSource>(this IReadOnlyCollection<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
            => ReadOnlyCollection.SingleOrNull<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static IEnumerable<TSource> AsEnumerable<TSource>(this IReadOnlyCollection<TSource> source)
            => source;

        public static IReadOnlyCollection<TSource> AsReadOnlyCollection<TSource>(this IReadOnlyCollection<TSource> source)
            => source;

        public static Enumerable.AsValueEnumerableEnumerable<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource> AsValueEnumerable<TSource>(this IReadOnlyCollection<TSource> source)
            => Enumerable.AsValueEnumerable<IReadOnlyCollection<TSource>, IEnumerator<TSource>,  TSource>(source);

        public static ReadOnlyCollection.AsValueReadOnlyCollectionEnumerable<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource> AsValueReadOnlyCollection<TSource>(this IReadOnlyCollection<TSource> source)
            => ReadOnlyCollection.AsValueEnumerable<IReadOnlyCollection<TSource>, IEnumerator<TSource>,  TSource>(source);

        public static TSource[] ToArray<TSource>(this IReadOnlyCollection<TSource> source)
            => ReadOnlyCollection.ToArray<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);

        public static IReadOnlyCollection<TSource> ToList<TSource>(this IReadOnlyCollection<TSource> source)
            => source;
    }
}