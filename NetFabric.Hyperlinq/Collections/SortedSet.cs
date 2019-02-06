using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        public static SelectReadOnlyCollection<SortedSet<TSource>, SortedSet<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this SortedSet<TSource> source,
            Func<TSource, TResult> selector) 
            => Select<SortedSet<TSource>, SortedSet<TSource>.Enumerator, TSource, TResult>(source, selector);

        public static Enumerable.WhereEnumerable<SortedSet<TSource>, SortedSet<TSource>.Enumerator, TSource> Where<TSource>(
            this SortedSet<TSource> source,
            Func<TSource, bool> predicate) 
            => Enumerable.Where<SortedSet<TSource>, SortedSet<TSource>.Enumerator, TSource>(source, predicate);

        public static TSource First<TSource>(this SortedSet<TSource> source)
            => First<SortedSet<TSource>, SortedSet<TSource>.Enumerator, TSource>(source);

        public static TSource FirstOrDefault<TSource>(this SortedSet<TSource> source)
            => FirstOrDefault<SortedSet<TSource>, SortedSet<TSource>.Enumerator, TSource>(source);

        public static TSource Single<TSource>(this SortedSet<TSource> source)
            => Single<SortedSet<TSource>, SortedSet<TSource>.Enumerator, TSource>(source);

        public static TSource SingleOrDefault<TSource>(this SortedSet<TSource> source)
            => SingleOrDefault<SortedSet<TSource>, SortedSet<TSource>.Enumerator, TSource>(source);
    }
}
