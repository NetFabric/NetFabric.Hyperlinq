using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class LinkedListExtensions
    {
        public static int Count<TSource>(this LinkedList<TSource> source)
            => source.Count;

        public static ReadOnlyCollection.SelectReadOnlyCollection<LinkedList<TSource>, LinkedList<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this LinkedList<TSource> source,
            Func<TSource, TResult> selector) 
            => ReadOnlyCollection.Select<LinkedList<TSource>, LinkedList<TSource>.Enumerator, TSource, TResult>(source, selector);

        public static Enumerable.WhereEnumerable<LinkedList<TSource>, LinkedList<TSource>.Enumerator, TSource> Where<TSource>(
            this LinkedList<TSource> source,
            Func<TSource, bool> predicate) 
            => Enumerable.Where<LinkedList<TSource>, LinkedList<TSource>.Enumerator, TSource>(source, predicate);

        public static TSource First<TSource>(this LinkedList<TSource> source) 
            => ReadOnlyCollection.First<LinkedList<TSource>, LinkedList<TSource>.Enumerator, TSource>(source);

        public static TSource FirstOrDefault<TSource>(this LinkedList<TSource> source)
            => ReadOnlyCollection.FirstOrDefault<LinkedList<TSource>, LinkedList<TSource>.Enumerator, TSource>(source);

        public static TSource Single<TSource>(this LinkedList<TSource> source)
            => ReadOnlyCollection.Single<LinkedList<TSource>, LinkedList<TSource>.Enumerator, TSource>(source);

        public static TSource SingleOrDefault<TSource>(this LinkedList<TSource> source)
            => ReadOnlyCollection.SingleOrDefault<LinkedList<TSource>, LinkedList<TSource>.Enumerator, TSource>(source);

        public static List<TSource> ToList<TSource>(this LinkedList<TSource> source)
            => ReadOnlyCollection.ToList<LinkedList<TSource>, LinkedList<TSource>.Enumerator, TSource>(source);
    }
}
