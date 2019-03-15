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

        public static bool All<TSource>(this Queue<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.All<Queue<TSource>, Queue<TSource>.Enumerator, TSource>(source, predicate);

        public static bool Any<TSource>(this Queue<TSource> source)
            => source.Count != 0;

        public static bool Any<TSource>(this Queue<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.Any<Queue<TSource>, Queue<TSource>.Enumerator, TSource>(source, predicate);

        public static bool Contains<TSource>(this Queue<TSource> source, TSource value)
            => source.Contains(value);

        public static bool Contains<TSource>(this Queue<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
            => ReadOnlyCollection.Contains<Queue<TSource>, Queue<TSource>.Enumerator, TSource>(source, value, comparer);

        public static ReadOnlyCollection.SelectEnumerable<Queue<TSource>, Queue<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this Queue<TSource> source,
            Func<TSource, TResult> selector) 
            => ReadOnlyCollection.Select<Queue<TSource>, Queue<TSource>.Enumerator, TSource, TResult>(source, selector);

        public static Enumerable.WhereEnumerable<Queue<TSource>, Queue<TSource>.Enumerator, TSource> Where<TSource>(
            this Queue<TSource> source,
            Func<TSource, bool> predicate) 
            => Enumerable.Where<Queue<TSource>, Queue<TSource>.Enumerator, TSource>(source, predicate);

        public static TSource First<TSource, TValue>(this Queue<TSource> source)
            => ReadOnlyCollection.First<Queue<TSource>, Queue<TSource>.Enumerator, TSource>(source);

        public static TSource First<TSource, TValue>(this Queue<TSource> source, Func<TSource, bool> predicate)
            => Enumerable.First<Queue<TSource>, Queue<TSource>.Enumerator, TSource>(source, predicate);

        public static TSource FirstOrDefault<TSource, TValue>(this Queue<TSource> source)
            => ReadOnlyCollection.FirstOrDefault<Queue<TSource>, Queue<TSource>.Enumerator, TSource>(source);

        public static TSource FirstOrDefault<TSource, TValue>(this Queue<TSource> source, Func<TSource, bool> predicate)
            => Enumerable.FirstOrDefault<Queue<TSource>, Queue<TSource>.Enumerator, TSource>(source, predicate);

        public static TSource? FirstOrNull<TSource, TValue>(this Queue<TSource> source)
            where TSource : struct
            => ReadOnlyCollection.FirstOrNull<Queue<TSource>, Queue<TSource>.Enumerator, TSource>(source);

        public static TSource? FirstOrNull<TSource, TValue>(this Queue<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
            => Enumerable.FirstOrNull<Queue<TSource>, Queue<TSource>.Enumerator, TSource>(source, predicate);

        public static TSource Single<TSource, TValue>(this Queue<TSource> source)
            => ReadOnlyCollection.Single<Queue<TSource>, Queue<TSource>.Enumerator, TSource>(source);

        public static TSource Single<TSource, TValue>(this Queue<TSource> source, Func<TSource, bool> predicate)
            => Enumerable.Single<Queue<TSource>, Queue<TSource>.Enumerator, TSource>(source, predicate);

        public static TSource SingleOrDefault<TSource, TValue>(this Queue<TSource> source)
            => ReadOnlyCollection.SingleOrDefault<Queue<TSource>, Queue<TSource>.Enumerator, TSource>(source);

        public static TSource SingleOrDefault<TSource, TValue>(this Queue<TSource> source, Func<TSource, bool> predicate)
            => Enumerable.SingleOrDefault<Queue<TSource>, Queue<TSource>.Enumerator, TSource>(source, predicate);

        public static TSource? SingleOrNull<TSource, TValue>(this Queue<TSource> source)
            where TSource : struct
            => ReadOnlyCollection.SingleOrNull<Queue<TSource>, Queue<TSource>.Enumerator, TSource>(source);

        public static TSource? SingleOrNull<TSource, TValue>(this Queue<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
            => Enumerable.SingleOrNull<Queue<TSource>, Queue<TSource>.Enumerator, TSource>(source, predicate);

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
