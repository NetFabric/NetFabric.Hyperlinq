using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class LinkedListExtensions
    {
        public static int Count<TSource>(this LinkedList<TSource> source)
            => source.Count;

        public static int Count<TSource>(this LinkedList<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.Count<LinkedList<TSource>, LinkedList<TSource>.Enumerator, TSource>(source, predicate);

        public static bool All<TSource>(this LinkedList<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.All<LinkedList<TSource>, LinkedList<TSource>.Enumerator, TSource>(source, predicate);

        public static bool Any<TSource>(this LinkedList<TSource> source)
            => source.Count != 0;

        public static bool Any<TSource>(this LinkedList<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.Any<LinkedList<TSource>, LinkedList<TSource>.Enumerator, TSource>(source, predicate);

        public static bool Contains<TSource>(this LinkedList<TSource> source, TSource value)
            => source.Contains(value);

        public static bool Contains<TSource>(this LinkedList<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
            => source.Contains(value, comparer);

        public static ReadOnlyCollection.SelectEnumerable<LinkedList<TSource>, LinkedList<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
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

        public static IEnumerable<TSource> AsEnumerable<TSource>(this LinkedList<TSource> source)
            => source;

        public static IReadOnlyCollection<TSource> AsReadOnlyCollection<TSource>(this LinkedList<TSource> source)
            => source;

        public static Enumerable.AsValueEnumerableEnumerable<LinkedList<TSource>, LinkedList<TSource>.Enumerator, TSource> AsValueEnumerable<TSource>(this LinkedList<TSource> source)
            => Enumerable.AsValueEnumerable<LinkedList<TSource>, LinkedList<TSource>.Enumerator, TSource>(source);

        public static ReadOnlyCollection.AsValueReadOnlyCollectionEnumerable<LinkedList<TSource>, LinkedList<TSource>.Enumerator, TSource> AsValueReadOnlyCollection<TSource>(this LinkedList<TSource> source)
            => ReadOnlyCollection.AsValueReadOnlyCollection<LinkedList<TSource>, LinkedList<TSource>.Enumerator, TSource>(source);

        public static TSource[] ToArray<TSource>(this LinkedList<TSource> source)
            => ReadOnlyCollection.ToArray<LinkedList<TSource>, LinkedList<TSource>.Enumerator, TSource>(source);

        public static List<TSource> ToList<TSource>(this LinkedList<TSource> source)
            => ReadOnlyCollection.ToList<LinkedList<TSource>, LinkedList<TSource>.Enumerator, TSource>(source);
    }
}
