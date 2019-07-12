using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static class ReadOnlyListBindings
    {
        public static int Count<TSource>(this IReadOnlyList<TSource> source)
            => source.Count;
        public static int Count<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyList.Count<IReadOnlyList<TSource>, TSource>(source, predicate);
        public static int Count<TSource>(this IReadOnlyList<TSource> source, Func<TSource, int, bool> predicate)
            => ReadOnlyList.Count<IReadOnlyList<TSource>, TSource>(source, predicate);

        public static ReadOnlyList.SkipTakeEnumerable<IReadOnlyList<TSource>, TSource> Skip<TSource>(
            this IReadOnlyList<TSource> source,
            int count) 
            => ReadOnlyList.Skip<IReadOnlyList<TSource>, TSource>(source, count);

        public static ReadOnlyList.SkipTakeEnumerable<IReadOnlyList<TSource>, TSource> Take<TSource>(
            this IReadOnlyList<TSource> source,
            int count) 
            => ReadOnlyList.Take<IReadOnlyList<TSource>, TSource>(source, count);

        public static bool All<TSource>(this IReadOnlyList<TSource> source, Func<TSource, int, bool> predicate)
            => ReadOnlyList.All<IReadOnlyList<TSource>, TSource>(source, predicate);

        public static bool Any<TSource>(this IReadOnlyList<TSource> source)
            => source.Count != 0;

        public static bool Any<TSource>(this IReadOnlyList<TSource> source, Func<TSource, int, bool> predicate)
            => ReadOnlyList.Any<IReadOnlyList<TSource>, TSource>(source, predicate);

        public static bool Contains<TSource>(this IReadOnlyList<TSource> source, TSource value)
            => ReadOnlyList.Contains<IReadOnlyList<TSource>, TSource>(source, value);

        public static bool Contains<TSource>(this IReadOnlyList<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
            => ReadOnlyList.Contains<IReadOnlyList<TSource>, TSource>(source, value, comparer);

        public static ReadOnlyList.SelectEnumerable<IReadOnlyList<TSource>, TSource, TResult> Select<TSource, TResult>(
            this IReadOnlyList<TSource> source,
            Func<TSource, TResult> selector) 
            => ReadOnlyList.Select<IReadOnlyList<TSource>, TSource, TResult>(source, selector);
        public static ReadOnlyList.SelectIndexEnumerable<IReadOnlyList<TSource>, TSource, TResult> Select<TSource, TResult>(
            this IReadOnlyList<TSource> source,
            Func<TSource, int, TResult> selector)
            => ReadOnlyList.Select<IReadOnlyList<TSource>, TSource, TResult>(source, selector);

        public static ReadOnlyList.SelectManyEnumerable<IReadOnlyList<TSource>, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this IReadOnlyList<TSource> source,
            Func<TSource, TSubEnumerable> selector) 
            where TSubEnumerable : IValueReadOnlyList<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ReadOnlyList.SelectMany<IReadOnlyList<TSource>, TSource, TSubEnumerable, TSubEnumerator, TResult>(source, selector);

        public static ReadOnlyList.WhereEnumerable<IReadOnlyList<TSource>, TSource> Where<TSource>(
            this IReadOnlyList<TSource> source, 
            Func<TSource, bool> predicate) 
            => ReadOnlyList.Where<IReadOnlyList<TSource>, TSource>(source, predicate);
        public static ReadOnlyList.WhereIndexEnumerable<IReadOnlyList<TSource>, TSource> Where<TSource>(
            this IReadOnlyList<TSource> source,
            Func<TSource, int, bool> predicate)
            => ReadOnlyList.Where<IReadOnlyList<TSource>, TSource>(source, predicate);

        public static TSource First<TSource>(this IReadOnlyList<TSource> source) 
            => ReadOnlyCollection.First<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source);
        public static TSource First<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.First<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
        public static TSource FirstOrDefault<TSource>(this IReadOnlyList<TSource> source)
            => ReadOnlyCollection.FirstOrDefault<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source);
        public static TSource FirstOrDefault<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.FirstOrDefault<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
        public static (ElementResult Success, TSource Value) TryFirst<TSource>(this IReadOnlyList<TSource> source)
            => ReadOnlyCollection.TryFirst<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source);
        public static (ElementResult Success, TSource Value) TryFirst<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.TryFirst<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
        public static (int Index, TSource Value) TryFirst<TSource>(this IReadOnlyList<TSource> source, Func<TSource, int, bool> predicate)
            => ReadOnlyCollection.TryFirst<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static TSource Single<TSource>(this IReadOnlyList<TSource> source) 
            => ReadOnlyCollection.Single<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source);
        public static TSource Single<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.Single<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
        public static TSource SingleOrDefault<TSource>(this IReadOnlyList<TSource> source)
            => ReadOnlyCollection.SingleOrDefault<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source);
        public static TSource SingleOrDefault<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.SingleOrDefault<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
        public static (ElementResult Success, TSource Value) TrySingle<TSource>(this IReadOnlyList<TSource> source)
            => ReadOnlyCollection.TrySingle<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source);
        public static (ElementResult Success, TSource Value) TrySingle<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.TrySingle<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
        public static (int Index, TSource Value) TrySingle<TSource>(this IReadOnlyList<TSource> source, Func<TSource, int, bool> predicate)
            => ReadOnlyCollection.TrySingle<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static IReadOnlyList<TSource> AsEnumerable<TSource>(this IReadOnlyList<TSource> source)
            => source;

        public static ReadOnlyList.AsValueEnumerableEnumerable<IReadOnlyList<TSource>, IEnumerator<TSource>,  TSource> AsValueEnumerable<TSource>(this IReadOnlyList<TSource> source)
            => ReadOnlyList.AsValueEnumerable<IReadOnlyList<TSource>, IEnumerator<TSource>,  TSource>(source);

        public static TSource[] ToArray<TSource>(this IReadOnlyList<TSource> source)
            => ReadOnlyList.ToArray<IReadOnlyList<TSource>, TSource>(source);

        public static List<TSource> ToList<TSource>(this IReadOnlyList<TSource> source)
            => ReadOnlyList.ToList<IReadOnlyList<TSource>, TSource>(source);
    }
}