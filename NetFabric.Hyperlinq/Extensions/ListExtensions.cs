using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static class ListExtensions
    {
        public static int Count<TSource>(this List<TSource> source)
            => source.Count;

        public static int Count<TSource>(this List<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyList.Count<List<TSource>, TSource>(source, predicate);

        public static bool All<TSource>(this List<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyList.All<List<TSource>, TSource>(source, predicate);

        public static bool Any<TSource>(this List<TSource> source)
            => source.Count != 0;

        public static bool Any<TSource>(this List<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyList.Any<List<TSource>, TSource>(source, predicate);

        public static bool Contains<TSource>(this List<TSource> source, TSource value)
            => source.Contains(value);

        public static bool Contains<TSource>(this List<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
            => ReadOnlyList.Contains<List<TSource>, TSource>(source, value, comparer);

        public static ReadOnlyList.SelectEnumerable<List<TSource>, TSource, TResult> Select<TSource, TResult>(
            this List<TSource> source,
            Func<TSource, TResult> selector) 
            => ReadOnlyList.Select<List<TSource>, TSource, TResult>(source, selector);

        public static ReadOnlyList.SelectManyEnumerable<List<TSource>, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this List<TSource> source,
            Func<TSource, TSubEnumerable> selector) 
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IValueEnumerator<TResult>
            => ReadOnlyList.SelectMany<List<TSource>, TSource, TSubEnumerable, TSubEnumerator, TResult>(source, selector);

        public static ReadOnlyList.WhereEnumerable<List<TSource>, TSource> Where<TSource>(
            this List<TSource> source, 
            Func<TSource, bool> predicate) 
            => ReadOnlyList.Where<List<TSource>, TSource>(source, predicate);

        public static TSource First<TSource>(this List<TSource> source)
            => ReadOnlyList.First<List<TSource>, TSource>(source);

        public static TSource First<TSource>(this List<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyList.First<List<TSource>, TSource>(source, predicate);

        public static TSource FirstOrDefault<TSource>(this List<TSource> source)
            => ReadOnlyList.FirstOrDefault<List<TSource>, TSource>(source);

        public static TSource FirstOrDefault<TSource>(this List<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyList.FirstOrDefault<List<TSource>, TSource>(source, predicate);

        public static TSource? FirstOrNull<TSource>(this List<TSource> source)
            where TSource : struct
            => ReadOnlyList.FirstOrNull<List<TSource>, TSource>(source);

        public static TSource? FirstOrNull<TSource>(this List<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
            => ReadOnlyList.FirstOrNull<List<TSource>, TSource>(source, predicate);

        public static TSource Single<TSource>(this List<TSource> source)
            => ReadOnlyList.Single<List<TSource>, TSource>(source);

        public static TSource Single<TSource>(this List<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyList.Single<List<TSource>, TSource>(source, predicate);

        public static TSource SingleOrDefault<TSource>(this List<TSource> source)
            => ReadOnlyList.SingleOrDefault<List<TSource>, TSource>(source);

        public static TSource SingleOrDefault<TSource>(this List<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyList.SingleOrDefault<List<TSource>, TSource>(source, predicate);

        public static TSource? SingleOrNull<TSource>(this List<TSource> source)
            where TSource : struct
            => ReadOnlyList.SingleOrNull<List<TSource>, TSource>(source);

        public static TSource? SingleOrNull<TSource>(this List<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
            => ReadOnlyList.SingleOrNull<List<TSource>, TSource>(source, predicate);

        public static IEnumerable<TSource> AsEnumerable<TSource>(this List<TSource> source)
            => source;

        public static IReadOnlyCollection<TSource> AsReadOnlyCollection<TSource>(this List<TSource> source)
            => source;

        public static IReadOnlyList<TSource> AsReadOnlyList<TSource>(this List<TSource> source)
            => source;

        public static Enumerable.AsValueEnumerableEnumerable<List<TSource>, List<TSource>.Enumerator, TSource> AsValueEnumerable<TSource>(this List<TSource> source)
            => Enumerable.AsValueEnumerable<List<TSource>, List<TSource>.Enumerator, TSource>(source);

        public static ReadOnlyCollection.AsValueReadOnlyCollectionEnumerable<List<TSource>, List<TSource>.Enumerator, TSource> AsValueReadOnlyCollection<TSource>(this List<TSource> source)
            => ReadOnlyCollection.AsValueReadOnlyCollection<List<TSource>, List<TSource>.Enumerator, TSource>(source);

        public static ReadOnlyList.AsValueReadOnlyListEnumerable<List<TSource>, TSource> AsValueReadOnlyList<TSource>(this List<TSource> source)
            => ReadOnlyList.AsValueReadOnlyList<List<TSource>, TSource>(source);

        public static TSource[] ToArray<TSource>(this List<TSource> source)
            => ReadOnlyList.ToArray<List<TSource>, TSource>(source);

        public static List<TSource> ToList<TSource>(this List<TSource> source)
            => source;
    }
}
