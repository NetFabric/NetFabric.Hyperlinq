using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class QueueExtensions
    {
        public static int Count<TSource>(this Queue<TSource> source)
            => source.Count;

        public static int Count<TSource>(this Queue<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.Count<Queue<TSource>, Queue<TSource>.Enumerator, TSource>(source, predicate);

        public static ReadOnlyCollection.SelectReadOnlyCollection<Queue<TSource>, Queue<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this Queue<TSource> source,
            Func<TSource, TResult> selector) 
            => ReadOnlyCollection.Select<Queue<TSource>, Queue<TSource>.Enumerator, TSource, TResult>(source, selector);

        public static Enumerable.WhereEnumerable<Queue<TSource>, Queue<TSource>.Enumerator, TSource> Where<TSource>(
            this Queue<TSource> source,
            Func<TSource, bool> predicate) 
            => Enumerable.Where<Queue<TSource>, Queue<TSource>.Enumerator, TSource>(source, predicate);

        public static TSource First<TSource>(this Queue<TSource> source)
            => ReadOnlyCollection.First<Queue<TSource>, Queue<TSource>.Enumerator, TSource>(source);

        public static TSource FirstOrDefault<TSource>(this Queue<TSource> source)
            => ReadOnlyCollection.FirstOrDefault<Queue<TSource>, Queue<TSource>.Enumerator, TSource>(source);

        public static TSource Single<TSource>(this Queue<TSource> source)
            => ReadOnlyCollection.Single<Queue<TSource>, Queue<TSource>.Enumerator, TSource>(source);

        public static TSource SingleOrDefault<TSource>(this Queue<TSource> source)
            => ReadOnlyCollection.SingleOrDefault<Queue<TSource>, Queue<TSource>.Enumerator, TSource>(source);

        public static IEnumerable<TSource> AsEnumerable<TSource>(this Queue<TSource> source)
            => source;

        public static IReadOnlyCollection<TSource> AsReadOnlyCollection<TSource>(this Queue<TSource> source)
            => source;

        public static Enumerable.AsValueEnumerableEnumerable<Queue<TSource>, Queue<TSource>.Enumerator, TSource> AsValueEnumerable<TSource>(this Queue<TSource> source)
            => Enumerable.AsValueEnumerable<Queue<TSource>, Queue<TSource>.Enumerator, TSource>(source);

        public static ReadOnlyCollection.AsValueReadOnlyCollectionEnumerable<Queue<TSource>, Queue<TSource>.Enumerator, TSource> AsValueReadOnlyCollection<TSource>(this Queue<TSource> source)
            => ReadOnlyCollection.AsValueReadOnlyCollection<Queue<TSource>, Queue<TSource>.Enumerator, TSource>(source);

        public static TSource[] ToArray<TSource>(this Queue<TSource> source)
            => ReadOnlyCollection.ToArray<Queue<TSource>, Queue<TSource>.Enumerator, TSource>(source);

        public static List<TSource> ToList<TSource>(this Queue<TSource> source)
            => ReadOnlyCollection.ToList<Queue<TSource>, Queue<TSource>.Enumerator, TSource>(source);
    }
}
