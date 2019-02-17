using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static class IEnumerableExtensions
    {
        public static int Count<TSource>(this IEnumerable<TSource> source)
            => Enumerable.Count<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source);

        public static int Count<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            => Enumerable.Count<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static Enumerable.SelectEnumerable<IEnumerable<TSource>, IEnumerator<TSource>, TSource, TResult> Select<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TResult> selector) 
            => Enumerable.Select<IEnumerable<TSource>, IEnumerator<TSource>, TSource, TResult>(source, selector);

        public static Enumerable.WhereEnumerable<IEnumerable<TSource>, IEnumerator<TSource>, TSource> Where<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate) 
            => Enumerable.Where<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static TSource First<TSource>(this IEnumerable<TSource> source) 
            => Enumerable.First<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source);

        public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate) 
            => Enumerable.First<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source) 
            => Enumerable.FirstOrDefault<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source);

        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate) 
            => Enumerable.FirstOrDefault<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static TSource Single<TSource>(this IEnumerable<TSource> source) 
            => Enumerable.Single<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source);

        public static TSource Single<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate) 
            => Enumerable.Single<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source) 
            => Enumerable.SingleOrDefault<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source);

        public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate) 
            => Enumerable.SingleOrDefault<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static IEnumerable<TSource> AsEnumerable<TSource>(this IEnumerable<TSource> source) 
            => source;

        public static TSource[] ToArray<TSource>(this IEnumerable<TSource> source)
            => System.Linq.Enumerable.ToArray(source);

        public static List<TSource> ToList<TSource>(this IEnumerable<TSource> source)
            => new List<TSource>(source);
    }
}
