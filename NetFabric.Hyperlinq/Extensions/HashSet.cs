using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class HashSetExtensions
    {
        public static int Count<TSource>(this HashSet<TSource> source)
            => source.Count;

        public static ReadOnlyCollection.SelectReadOnlyCollection<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this HashSet<TSource> source,
            Func<TSource, TResult> selector) 
            => ReadOnlyCollection.Select<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource, TResult>(source, selector);

        public static Enumerable.WhereEnumerable<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource> Where<TSource>(
            this HashSet<TSource> source,
            Func<TSource, bool> predicate) 
            => Enumerable.Where<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource>(source, predicate);

        public static TSource First<TSource>(this HashSet<TSource> source) 
            => ReadOnlyCollection.First<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource>(source);

        public static TSource FirstOrDefault<TSource>(this HashSet<TSource> source)
            => ReadOnlyCollection.FirstOrDefault<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource>(source);

        public static TSource Single<TSource>(this HashSet<TSource> source)
            => ReadOnlyCollection.Single<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource>(source);

        public static TSource SingleOrDefault<TSource>(this HashSet<TSource> source)
            => ReadOnlyCollection.SingleOrDefault<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource>(source);
    }
}
