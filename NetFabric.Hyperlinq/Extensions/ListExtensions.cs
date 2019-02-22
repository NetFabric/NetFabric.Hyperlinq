using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ListExtensions
    {
        public static int Count<TSource>(this List<TSource> source)
            => source.Count;

        public static int Count<TSource>(this List<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyList.Count<List<TSource>, List<TSource>.Enumerator, TSource>(source, predicate);

        public static ReadOnlyList.SelectReadOnlyList<List<TSource>, List<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this List<TSource> source,
            Func<TSource, TResult> selector) 
            => ReadOnlyList.Select<List<TSource>, List<TSource>.Enumerator, TSource, TResult>(source, selector);

        public static ReadOnlyList.WhereReadOnlyList<List<TSource>, List<TSource>.Enumerator, TSource> Where<TSource>(
            this List<TSource> source, 
            Func<TSource, bool> predicate) 
            => ReadOnlyList.Where<List<TSource>, List<TSource>.Enumerator, TSource>(source, predicate);

        public static TSource First<TSource>(this List<TSource> source) 
            => ReadOnlyList.First<List<TSource>, List<TSource>.Enumerator, TSource>(source);

        public static TSource FirstOrDefault<TSource>(this List<TSource> source) 
            => ReadOnlyList.FirstOrDefault<List<TSource>, List<TSource>.Enumerator, TSource>(source);

        public static TSource Single<TSource>(this List<TSource> source) 
            => ReadOnlyList.Single<List<TSource>, List<TSource>.Enumerator, TSource>(source);

        public static TSource SingleOrDefault<TSource>(this List<TSource> source) 
            => ReadOnlyList.SingleOrDefault<List<TSource>, List<TSource>.Enumerator, TSource>(source);

        public static List<TSource> ToList<TSource>(this List<TSource> source)
            => source;
    }
}
