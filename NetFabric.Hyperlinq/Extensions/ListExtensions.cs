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

        public static bool All<TSource>(this List<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.All<List<TSource>, List<TSource>.Enumerator, TSource>(source, predicate);

        public static bool Any<TSource>(this List<TSource> source)
            => source.Count != 0;

        public static bool Any<TSource>(this List<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.Any<List<TSource>, List<TSource>.Enumerator, TSource>(source, predicate);

        public static bool Contains<TSource>(this List<TSource> source, TSource value)
            => ReadOnlyList.Contains<List<TSource>, List<TSource>.Enumerator, TSource>(source, value);

        public static bool Contains<TSource>(this List<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
            => ReadOnlyList.Contains<List<TSource>, List<TSource>.Enumerator, TSource>(source, value, comparer);

        public static ReadOnlyList.SelectEnumerable<List<TSource>, List<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this List<TSource> source,
            Func<TSource, TResult> selector) 
            => ReadOnlyList.Select<List<TSource>, List<TSource>.Enumerator, TSource, TResult>(source, selector);

        public static ReadOnlyList.WhereEnumerable<List<TSource>, List<TSource>.Enumerator, TSource> Where<TSource>(
            this List<TSource> source, 
            Func<TSource, bool> predicate) 
            => ReadOnlyList.Where<List<TSource>, List<TSource>.Enumerator, TSource>(source, predicate);

        public static TSource First<TSource, TValue>(this List<TSource> source)
            => ReadOnlyCollection.First<List<TSource>, List<TSource>.Enumerator, TSource>(source);

        public static TSource First<TSource, TValue>(this List<TSource> source, Func<TSource, bool> predicate)
            => Enumerable.First<List<TSource>, List<TSource>.Enumerator, TSource>(source, predicate);

        public static TSource FirstOrDefault<TSource, TValue>(this List<TSource> source)
            => ReadOnlyCollection.FirstOrDefault<List<TSource>, List<TSource>.Enumerator, TSource>(source);

        public static TSource FirstOrDefault<TSource, TValue>(this List<TSource> source, Func<TSource, bool> predicate)
            => Enumerable.FirstOrDefault<List<TSource>, List<TSource>.Enumerator, TSource>(source, predicate);

        public static TSource? FirstOrNull<TSource, TValue>(this List<TSource> source)
            where TSource : struct
            => ReadOnlyCollection.FirstOrNull<List<TSource>, List<TSource>.Enumerator, TSource>(source);

        public static TSource? FirstOrNull<TSource, TValue>(this List<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
            => Enumerable.FirstOrNull<List<TSource>, List<TSource>.Enumerator, TSource>(source, predicate);

        public static TSource Single<TSource, TValue>(this List<TSource> source)
            => ReadOnlyCollection.Single<List<TSource>, List<TSource>.Enumerator, TSource>(source);

        public static TSource Single<TSource, TValue>(this List<TSource> source, Func<TSource, bool> predicate)
            => Enumerable.Single<List<TSource>, List<TSource>.Enumerator, TSource>(source, predicate);

        public static TSource SingleOrDefault<TSource, TValue>(this List<TSource> source)
            => ReadOnlyCollection.SingleOrDefault<List<TSource>, List<TSource>.Enumerator, TSource>(source);

        public static TSource SingleOrDefault<TSource, TValue>(this List<TSource> source, Func<TSource, bool> predicate)
            => Enumerable.SingleOrDefault<List<TSource>, List<TSource>.Enumerator, TSource>(source, predicate);

        public static TSource? SingleOrNull<TSource, TValue>(this List<TSource> source)
            where TSource : struct
            => ReadOnlyCollection.SingleOrNull<List<TSource>, List<TSource>.Enumerator, TSource>(source);

        public static TSource? SingleOrNull<TSource, TValue>(this List<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
            => Enumerable.SingleOrNull<List<TSource>, List<TSource>.Enumerator, TSource>(source, predicate);

        public static IEnumerable<TSource> AsEnumerable<TSource>(this List<TSource> source)
            => source;

        public static IReadOnlyCollection<TSource> AsReadOnlyCollection<TSource>(this List<TSource> source)
            => source;

        public static IReadOnlyList<TSource> AsReadOnlyList<TSource>(this List<TSource> source)
            => source;

        public static Enumerable.AsValueEnumerableEnumerable<List<TSource>, List<TSource>.Enumerator, TSource> AsValueEnumerable<TSource>(this List<TSource> source)
            => Enumerable.AsValueEnumerable<List<TSource>, List<TSource>.Enumerator, TSource>(source);

        public static ReadOnlyCollection.AsValueReadOnlyCollectionEnumerable<List<TSource>, List<TSource>.Enumerator, TSource> AsValueReadOnlyCollection<TSource>(this List<TSource> source)
            => ReadOnlyCollection.AsValueReadOnlyCollection<List<TSource>, List<TSource>.Enumerator, TSource>(source);

        public static ReadOnlyList.AsValueReadOnlyListEnumerable<List<TSource>, List<TSource>.Enumerator, TSource> AsValueReadOnlyList<TSource>(this List<TSource> source)
            => ReadOnlyList.AsValueReadOnlyList<List<TSource>, List<TSource>.Enumerator, TSource>(source);

        public static TSource[] ToArray<TSource>(this List<TSource> source)
            => ReadOnlyList.ToArray<List<TSource>, List<TSource>.Enumerator, TSource>(source);

        public static List<TSource> ToList<TSource>(this List<TSource> source)
            => source;
    }
}
