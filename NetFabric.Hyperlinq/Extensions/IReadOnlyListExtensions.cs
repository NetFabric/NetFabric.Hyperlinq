using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static class IReadOnlyListExtensions
    {
        public static ReadOnlyList.SelectReadOnlyList<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource, TResult> Select<TSource, TResult>(
            this IReadOnlyList<TSource> source,
            Func<TSource, TResult> selector) 
            => ReadOnlyList.Select<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource, TResult>(source, selector);

        public static ReadOnlyList.WhereReadOnlyList<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource> Where<TSource>(
            this IReadOnlyList<TSource> source,
            Func<TSource, bool> predicate) 
            => ReadOnlyList.Where<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static TSource First<TSource>(this IReadOnlyList<TSource> source) 
            => ReadOnlyList.First<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source);

        public static TSource First<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate) 
            => ReadOnlyList.First<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static TSource FirstOrDefault<TSource>(this IReadOnlyList<TSource> source) 
            => ReadOnlyList.FirstOrDefault<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source);

        public static TSource FirstOrDefault<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate) 
            => ReadOnlyList.FirstOrDefault<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static TSource Single<TSource>(this IReadOnlyList<TSource> source) 
            => ReadOnlyList.Single<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source);

        public static TSource Single<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate) 
            => ReadOnlyList.Single<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static TSource SingleOrDefault<TSource>(this IReadOnlyList<TSource> source) 
            => ReadOnlyList.SingleOrDefault<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source);

        public static TSource SingleOrDefault<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate) 
            => ReadOnlyList.SingleOrDefault<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static TSource[] ToArray<TSource>(this IReadOnlyList<TSource> source)
            => ReadOnlyList.ToArray<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source);
    }
}
