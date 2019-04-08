using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static class ReadOnlyListBindings
    {
        public static int Count<TSource>(this IReadOnlyList<TSource> source)
            => source.Count;

        public static int Count<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyList.Count<IReadOnlyList<TSource>, TSource>(source, predicate);

        public static bool All<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyList.All<IReadOnlyList<TSource>, TSource>(source, predicate);

        public static bool Any<TSource>(this IReadOnlyList<TSource> source)
            => source.Count != 0;

        public static bool Any<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyList.Any<IReadOnlyList<TSource>, TSource>(source, predicate);

        public static bool Contains<TSource>(this IReadOnlyList<TSource> source, TSource value)
            => ReadOnlyList.Contains<IReadOnlyList<TSource>, TSource>(source, value);

        public static bool Contains<TSource>(this IReadOnlyList<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
            => ReadOnlyList.Contains<IReadOnlyList<TSource>, TSource>(source, value, comparer);

        public static ReadOnlyList.SelectEnumerable<IReadOnlyList<TSource>, TSource, TResult> Select<TSource, TResult>(
            this IReadOnlyList<TSource> source,
            Func<TSource, TResult> selector) 
            => ReadOnlyList.Select<IReadOnlyList<TSource>, TSource, TResult>(source, selector);

        public static ReadOnlyList.SelectManyEnumerable<IReadOnlyList<TSource>, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this IReadOnlyList<TSource> source,
            Func<TSource, TSubEnumerable> selector) 
            where TSubEnumerable : IValueReadOnlyList<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IValueEnumerator<TResult>
            => ReadOnlyList.SelectMany<IReadOnlyList<TSource>, TSource, TSubEnumerable, TSubEnumerator, TResult>(source, selector);

        public static ReadOnlyList.WhereEnumerable<IReadOnlyList<TSource>, TSource> Where<TSource>(
            this IReadOnlyList<TSource> source, 
            Func<TSource, bool> predicate) 
            => ReadOnlyList.Where<IReadOnlyList<TSource>, TSource>(source, predicate);

        public static TSource First<TSource>(this IReadOnlyList<TSource> source)
            => ReadOnlyList.First<IReadOnlyList<TSource>, TSource>(source);

        public static TSource First<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyList.First<IReadOnlyList<TSource>, TSource>(source, predicate);

        public static TSource FirstOrDefault<TSource>(this IReadOnlyList<TSource> source)
            => ReadOnlyList.FirstOrDefault<IReadOnlyList<TSource>, TSource>(source);

        public static TSource FirstOrDefault<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyList.FirstOrDefault<IReadOnlyList<TSource>, TSource>(source, predicate);

        public static TSource? FirstOrNull<TSource>(this IReadOnlyList<TSource> source)
            where TSource : struct
            => ReadOnlyList.FirstOrNull<IReadOnlyList<TSource>, TSource>(source);

        public static TSource? FirstOrNull<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
            => ReadOnlyList.FirstOrNull<IReadOnlyList<TSource>, TSource>(source, predicate);

        public static TSource Single<TSource>(this IReadOnlyList<TSource> source)
            => ReadOnlyList.Single<IReadOnlyList<TSource>, TSource>(source);

        public static TSource Single<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyList.Single<IReadOnlyList<TSource>, TSource>(source, predicate);

        public static TSource SingleOrDefault<TSource>(this IReadOnlyList<TSource> source)
            => ReadOnlyList.SingleOrDefault<IReadOnlyList<TSource>, TSource>(source);

        public static TSource SingleOrDefault<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyList.SingleOrDefault<IReadOnlyList<TSource>, TSource>(source, predicate);

        public static TSource? SingleOrNull<TSource>(this IReadOnlyList<TSource> source)
            where TSource : struct
            => ReadOnlyList.SingleOrNull<IReadOnlyList<TSource>, TSource>(source);

        public static TSource? SingleOrNull<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
            => ReadOnlyList.SingleOrNull<IReadOnlyList<TSource>, TSource>(source, predicate);

        public static IEnumerable<TSource> AsEnumerable<TSource>(this IReadOnlyList<TSource> source)
            => source;

        public static IReadOnlyCollection<TSource> AsReadOnlyCollection<TSource>(this IReadOnlyCollection<TSource> source)
            => source;

        public static IReadOnlyList<TSource> AsReadOnlyList<TSource>(this IReadOnlyList<TSource> source)
            => source;

        public static Enumerable.AsValueEnumerableEnumerable<IReadOnlyList<TSource>, IEnumerator<TSource>,  TSource> AsValueEnumerable<TSource>(this IReadOnlyList<TSource> source)
            => Enumerable.AsValueEnumerable<IReadOnlyList<TSource>, IEnumerator<TSource>,  TSource>(source);

        public static ReadOnlyList.AsValueReadOnlyListEnumerable<IReadOnlyList<TSource>, IEnumerator<TSource>,  TSource> AsValueReadOnlyCollection<TSource>(this IReadOnlyList<TSource> source)
            => ReadOnlyList.AsValueEnumerable<IReadOnlyList<TSource>, IEnumerator<TSource>,  TSource>(source);

        public static ReadOnlyCollection.AsValueReadOnlyCollectionEnumerable<IReadOnlyList<TSource>, IEnumerator<TSource>,  TSource> AsValueReadOnlyList<TSource>(this IReadOnlyList<TSource> source)
            => ReadOnlyCollection.AsValueEnumerable<IReadOnlyList<TSource>, IEnumerator<TSource>,  TSource>(source);

        public static TSource[] ToArray<TSource>(this IReadOnlyList<TSource> source)
            => ReadOnlyList.ToArray<IReadOnlyList<TSource>, TSource>(source);

        public static IReadOnlyList<TSource> ToList<TSource>(this IReadOnlyList<TSource> source)
            => source;
    }
}