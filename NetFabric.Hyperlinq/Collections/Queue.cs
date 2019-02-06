using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        public static int Count<TSource>(this Queue<TSource> source)
            => source.Count;

        public static SelectReadOnlyCollection<Queue<TSource>, Queue<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this Queue<TSource> source,
            Func<TSource, TResult> selector) 
            => Select<Queue<TSource>, Queue<TSource>.Enumerator, TSource, TResult>(source, selector);

        public static Enumerable.WhereEnumerable<Queue<TSource>, Queue<TSource>.Enumerator, TSource> Where<TSource>(
            this Queue<TSource> source,
            Func<TSource, bool> predicate) 
            => Enumerable.Where<Queue<TSource>, Queue<TSource>.Enumerator, TSource>(source, predicate);

        public static TSource First<TSource>(this Queue<TSource> source)
            => First<Queue<TSource>, Queue<TSource>.Enumerator, TSource>(source);

        public static TSource FirstOrDefault<TSource>(this Queue<TSource> source)
            => FirstOrDefault<Queue<TSource>, Queue<TSource>.Enumerator, TSource>(source);

        public static TSource Single<TSource>(this Queue<TSource> source)
            => Single<Queue<TSource>, Queue<TSource>.Enumerator, TSource>(source);

        public static TSource SingleOrDefault<TSource>(this Queue<TSource> source)
            => SingleOrDefault<Queue<TSource>, Queue<TSource>.Enumerator, TSource>(source);
    }
}
