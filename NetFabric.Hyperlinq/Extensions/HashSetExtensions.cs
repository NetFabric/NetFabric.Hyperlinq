using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class HashSetExtensions
    {
        public static int Count<TSource>(this HashSet<TSource> source)
            => source.Count;

        public static int Count<TSource>(this HashSet<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.Count<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource>(source, predicate);

        public static ReadOnlyCollection.SelectReadOnlyCollection<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this HashSet<TSource> source,
            Func<TSource, TResult> selector) 
            => ReadOnlyCollection.Select<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource, TResult>(source, selector);

        public static Enumerable.WhereEnumerable<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource> Where<TSource>(
            this HashSet<TSource> source,
            Func<TSource, bool> predicate) 
            => Enumerable.Where<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource>(source, predicate);

        public static TSource First<TSource>(this HashSet<TSource> source) 
            => ReadOnlyCollection.First<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource>(source);

        public static TSource FirstOrDefault<TSource>(this HashSet<TSource> source)
            => ReadOnlyCollection.FirstOrDefault<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource>(source);

        public static TSource Single<TSource>(this HashSet<TSource> source)
            => ReadOnlyCollection.Single<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource>(source);

        public static TSource SingleOrDefault<TSource>(this HashSet<TSource> source)
            => ReadOnlyCollection.SingleOrDefault<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource>(source);

        public static IEnumerable<TSource> AsEnumerable<TSource>(this HashSet<TSource> source)
            => source;

        public static IReadOnlyCollection<TSource> AsReadOnlyCollection<TSource>(this HashSet<TSource> source)
            => source;

        public static Enumerable.AsValueEnumerableEnumerable<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource> AsValueEnumerable<TSource>(this HashSet<TSource> source)
            => Enumerable.AsValueEnumerable<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource>(source);

        public static ReadOnlyCollection.AsValueReadOnlyCollectionEnumerable<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource> AsValueReadOnlyCollection<TSource>(this HashSet<TSource> source)
            => ReadOnlyCollection.AsValueReadOnlyCollection<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource>(source);

        public static TSource[] ToArray<TSource>(this HashSet<TSource> source)
            => ReadOnlyCollection.ToArray<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource>(source);

        public static List<TSource> ToList<TSource>(this HashSet<TSource> source)
            => ReadOnlyCollection.ToList<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource>(source);
    }
}
