using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        public static int Count<TSource>(this Stack<TSource> source)
            => source.Count;

        public static SelectReadOnlyCollection<Stack<TSource>, Stack<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this Stack<TSource> source,
            Func<TSource, TResult> selector) 
            => Select<Stack<TSource>, Stack<TSource>.Enumerator, TSource, TResult>(source, selector);

        public static Enumerable.WhereEnumerable<Stack<TSource>, Stack<TSource>.Enumerator, TSource> Where<TSource>(
            this Stack<TSource> source,
            Func<TSource, bool> predicate) 
            => Enumerable.Where<Stack<TSource>, Stack<TSource>.Enumerator, TSource>(source, predicate);

        public static TSource First<TSource>(this Stack<TSource> source)
            => First<Stack<TSource>, Stack<TSource>.Enumerator, TSource>(source);

        public static TSource FirstOrDefault<TSource>(this Stack<TSource> source)
            => FirstOrDefault<Stack<TSource>, Stack<TSource>.Enumerator, TSource>(source);

        public static TSource Single<TSource>(this Stack<TSource> source)
            => Single<Stack<TSource>, Stack<TSource>.Enumerator, TSource>(source);

        public static TSource SingleOrDefault<TSource>(this Stack<TSource> source)
            => SingleOrDefault<Stack<TSource>, Stack<TSource>.Enumerator, TSource>(source);
    }
}
