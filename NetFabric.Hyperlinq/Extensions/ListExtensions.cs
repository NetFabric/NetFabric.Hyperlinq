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
            => source.Contains(value);

        public static bool Contains<TSource>(this List<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
            => source.Contains(value, comparer);

        public static ReadOnlyList.SelectEnumerable<List<TSource>, List<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this List<TSource> source,
            Func<TSource, TResult> selector) 
            => ReadOnlyList.Select<List<TSource>, List<TSource>.Enumerator, TSource, TResult>(source, selector);

        public static ReadOnlyList.WhereEnumerable<List<TSource>, List<TSource>.Enumerator, TSource> Where<TSource>(
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
