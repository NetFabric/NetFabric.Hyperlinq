using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class StackExtensions
    {
        public static int Count<TSource>(this Stack<TSource> source)
            => source.Count;

        public static ReadOnlyCollection.SelectReadOnlyCollection<Stack<TSource>, Stack<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this Stack<TSource> source,
            Func<TSource, TResult> selector) 
            => ReadOnlyCollection.Select<Stack<TSource>, Stack<TSource>.Enumerator, TSource, TResult>(source, selector);

        public static Enumerable.WhereEnumerable<Stack<TSource>, Stack<TSource>.Enumerator, TSource> Where<TSource>(
            this Stack<TSource> source,
            Func<TSource, bool> predicate) 
            => Enumerable.Where<Stack<TSource>, Stack<TSource>.Enumerator, TSource>(source, predicate);

        public static TSource First<TSource>(this Stack<TSource> source)
            => ReadOnlyCollection.First<Stack<TSource>, Stack<TSource>.Enumerator, TSource>(source);

        public static TSource FirstOrDefault<TSource>(this Stack<TSource> source)
            => ReadOnlyCollection.FirstOrDefault<Stack<TSource>, Stack<TSource>.Enumerator, TSource>(source);

        public static TSource Single<TSource>(this Stack<TSource> source)
            => ReadOnlyCollection.Single<Stack<TSource>, Stack<TSource>.Enumerator, TSource>(source);

        public static TSource SingleOrDefault<TSource>(this Stack<TSource> source)
            => ReadOnlyCollection.SingleOrDefault<Stack<TSource>, Stack<TSource>.Enumerator, TSource>(source);
    }
}
