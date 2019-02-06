using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        public static int Count<TSource>(this HashSet<TSource> source)
            => source.Count;

        public static SelectReadOnlyCollection<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this HashSet<TSource> source,
            Func<TSource, TResult> selector) 
            => Select<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource, TResult>(source, selector);

        public static Enumerable.WhereEnumerable<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource> Where<TSource>(
            this HashSet<TSource> source,
            Func<TSource, bool> predicate) 
            => Enumerable.Where<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource>(source, predicate);

        public static TSource First<TSource>(this HashSet<TSource> source) 
            => First<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource>(source);

        public static TSource FirstOrDefault<TSource>(this HashSet<TSource> source)
            => FirstOrDefault<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource>(source);

        public static TSource Single<TSource>(this HashSet<TSource> source)
            => Single<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource>(source);

        public static TSource SingleOrDefault<TSource>(this HashSet<TSource> source)
            => SingleOrDefault<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource>(source);
    }
}
