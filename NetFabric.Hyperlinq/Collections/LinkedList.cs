using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        public static SelectReadOnlyCollection<LinkedList<TSource>, LinkedList<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this LinkedList<TSource> source,
            Func<TSource, TResult> selector) 
            => Select<LinkedList<TSource>, LinkedList<TSource>.Enumerator, TSource, TResult>(source, selector);

        public static Enumerable.WhereEnumerable<LinkedList<TSource>, LinkedList<TSource>.Enumerator, TSource> Where<TSource>(
            this LinkedList<TSource> source,
            Func<TSource, bool> predicate) 
            => Enumerable.Where<LinkedList<TSource>, LinkedList<TSource>.Enumerator, TSource>(source, predicate);

        public static TSource First<TSource>(this LinkedList<TSource> source) 
            => First<LinkedList<TSource>, LinkedList<TSource>.Enumerator, TSource>(source);

        public static TSource FirstOrDefault<TSource>(this LinkedList<TSource> source)
            => FirstOrDefault<LinkedList<TSource>, LinkedList<TSource>.Enumerator, TSource>(source);

        public static TSource Single<TSource>(this LinkedList<TSource> source)
            => Single<LinkedList<TSource>, LinkedList<TSource>.Enumerator, TSource>(source);

        public static TSource SingleOrDefault<TSource>(this LinkedList<TSource> source)
            => SingleOrDefault<LinkedList<TSource>, LinkedList<TSource>.Enumerator, TSource>(source);
    }
}
