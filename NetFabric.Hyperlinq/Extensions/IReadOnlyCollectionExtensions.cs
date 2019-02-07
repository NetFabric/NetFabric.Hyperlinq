using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static class IReadOnlyCollectionExtensions
    {
        public static int Count<TSource>(this IReadOnlyCollection<TSource> source)
            => source.Count;

        public static ReadOnlyCollection.SelectReadOnlyCollection<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource, TResult> Select<TSource, TResult>(
            this IReadOnlyCollection<TSource> source,
            Func<TSource, TResult> selector) 
            => ReadOnlyCollection.Select<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource, TResult>(source, selector);

        public static TSource First<TSource>(this IReadOnlyCollection<TSource> source) 
            => ReadOnlyCollection.First<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);

        public static TSource FirstOrDefault<TSource>(this IReadOnlyCollection<TSource> source) 
            => ReadOnlyCollection.FirstOrDefault<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);

        public static TSource Single<TSource>(this IReadOnlyCollection<TSource> source) 
            => ReadOnlyCollection.Single<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);

        public static TSource SingleOrDefault<TSource>(this IReadOnlyCollection<TSource> source) 
            => ReadOnlyCollection.SingleOrDefault<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);

    }
}
