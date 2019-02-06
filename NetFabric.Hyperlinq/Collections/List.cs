using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static SelectReadOnlyList<List<TSource>, TSource, TResult> Select<TSource, TResult>(
            this List<TSource> source,
            Func<TSource, TResult> selector) 
            => Select<List<TSource>, TSource, TResult>(source, selector);

        public static WhereReadOnlyList<List<TSource>, TSource> Where<TSource>(
            this List<TSource> source, 
            Func<TSource, bool> predicate) 
            => Where<List<TSource>, TSource>(source, predicate);

        public static TSource First<TSource>(this List<TSource> source) =>
            First<List<TSource>, TSource>(source);

        public static TSource FirstOrDefault<TSource>(this List<TSource> source) =>
            FirstOrDefault<List<TSource>, TSource>(source);

        public static TSource Single<TSource>(this List<TSource> source) =>
            Single<List<TSource>, TSource>(source);

        public static TSource SingleOrDefault<TSource>(this List<TSource> source) =>
            SingleOrDefault<List<TSource>, TSource>(source);
    }
}
