using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class SortedSetExtensions
    {
        public static int Count<TSource>(this SortedSet<TSource> source)
            => source.Count;

        public static int Count<TSource>(this SortedSet<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.Count<SortedSet<TSource>, SortedSet<TSource>.Enumerator, TSource>(source, predicate);

        public static ReadOnlyCollection.SelectReadOnlyCollection<SortedSet<TSource>, SortedSet<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this SortedSet<TSource> source,
            Func<TSource, TResult> selector) 
            => ReadOnlyCollection.Select<SortedSet<TSource>, SortedSet<TSource>.Enumerator, TSource, TResult>(source, selector);

        public static Enumerable.WhereEnumerable<SortedSet<TSource>, SortedSet<TSource>.Enumerator, TSource> Where<TSource>(
            this SortedSet<TSource> source,
            Func<TSource, bool> predicate) 
            => Enumerable.Where<SortedSet<TSource>, SortedSet<TSource>.Enumerator, TSource>(source, predicate);

        public static TSource First<TSource>(this SortedSet<TSource> source)
            => ReadOnlyCollection.First<SortedSet<TSource>, SortedSet<TSource>.Enumerator, TSource>(source);

        public static TSource FirstOrDefault<TSource>(this SortedSet<TSource> source)
            => ReadOnlyCollection.FirstOrDefault<SortedSet<TSource>, SortedSet<TSource>.Enumerator, TSource>(source);

        public static TSource Single<TSource>(this SortedSet<TSource> source)
            => ReadOnlyCollection.Single<SortedSet<TSource>, SortedSet<TSource>.Enumerator, TSource>(source);

        public static TSource SingleOrDefault<TSource>(this SortedSet<TSource> source)
            => ReadOnlyCollection.SingleOrDefault<SortedSet<TSource>, SortedSet<TSource>.Enumerator, TSource>(source);

        public static IEnumerable<TSource> AsEnumerable<TSource>(this SortedSet<TSource> source)
            => source;

        public static IReadOnlyCollection<TSource> AsReadOnlyCollection<TSource>(this SortedSet<TSource> source)
            => source;

        public static Enumerable.AsValueEnumerableEnumerable<SortedSet<TSource>, SortedSet<TSource>.Enumerator, TSource> AsValueEnumerable<TSource>(this SortedSet<TSource> source)
            => Enumerable.AsValueEnumerable<SortedSet<TSource>, SortedSet<TSource>.Enumerator, TSource>(source);

        public static ReadOnlyCollection.AsValueReadOnlyCollectionEnumerable<SortedSet<TSource>, SortedSet<TSource>.Enumerator, TSource> AsValueReadOnlyCollection<TSource>(this SortedSet<TSource> source)
            => ReadOnlyCollection.AsValueReadOnlyCollection<SortedSet<TSource>, SortedSet<TSource>.Enumerator, TSource>(source);

        public static TSource[] ToArray<TSource>(this SortedSet<TSource> source)
            => ReadOnlyCollection.ToArray<SortedSet<TSource>, SortedSet<TSource>.Enumerator, TSource>(source);

        public static List<TSource> ToList<TSource>(this SortedSet<TSource> source)
            => ReadOnlyCollection.ToList<SortedSet<TSource>, SortedSet<TSource>.Enumerator, TSource>(source);
    }
}
