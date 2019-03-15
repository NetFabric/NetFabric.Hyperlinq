using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class StackExtensions
    {
        public static int Count<TSource>(this Stack<TSource> source)
            => source.Count;

        public static int Count<TSource>(this Stack<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.Count<Stack<TSource>, Stack<TSource>.Enumerator, TSource>(source, predicate);

        public static bool All<TSource>(this Stack<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.All<Stack<TSource>, Stack<TSource>.Enumerator, TSource>(source, predicate);

        public static bool Any<TSource>(this Stack<TSource> source)
            => source.Count != 0;

        public static bool Any<TSource>(this Stack<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.Any<Stack<TSource>, Stack<TSource>.Enumerator, TSource>(source, predicate);

        public static bool Contains<TSource>(this Stack<TSource> source, TSource value)
            => source.Contains(value);

        public static bool Contains<TSource>(this Stack<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
            => ReadOnlyCollection.Contains<Stack<TSource>, Stack<TSource>.Enumerator, TSource>(source, value, comparer);

        public static ReadOnlyCollection.SelectEnumerable<Stack<TSource>, Stack<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this Stack<TSource> source,
            Func<TSource, TResult> selector) 
            => ReadOnlyCollection.Select<Stack<TSource>, Stack<TSource>.Enumerator, TSource, TResult>(source, selector);

        public static Enumerable.WhereEnumerable<Stack<TSource>, Stack<TSource>.Enumerator, TSource> Where<TSource>(
            this Stack<TSource> source,
            Func<TSource, bool> predicate) 
            => Enumerable.Where<Stack<TSource>, Stack<TSource>.Enumerator, TSource>(source, predicate);

        public static TSource First<TSource, TValue>(this Stack<TSource> source)
            => ReadOnlyCollection.First<Stack<TSource>, Stack<TSource>.Enumerator, TSource>(source);

        public static TSource First<TSource, TValue>(this Stack<TSource> source, Func<TSource, bool> predicate)
            => Enumerable.First<Stack<TSource>, Stack<TSource>.Enumerator, TSource>(source, predicate);

        public static TSource FirstOrDefault<TSource, TValue>(this Stack<TSource> source)
            => ReadOnlyCollection.FirstOrDefault<Stack<TSource>, Stack<TSource>.Enumerator, TSource>(source);

        public static TSource FirstOrDefault<TSource, TValue>(this Stack<TSource> source, Func<TSource, bool> predicate)
            => Enumerable.FirstOrDefault<Stack<TSource>, Stack<TSource>.Enumerator, TSource>(source, predicate);

        public static TSource? FirstOrNull<TSource, TValue>(this Stack<TSource> source)
            where TSource : struct
            => ReadOnlyCollection.FirstOrNull<Stack<TSource>, Stack<TSource>.Enumerator, TSource>(source);

        public static TSource? FirstOrNull<TSource, TValue>(this Stack<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
            => Enumerable.FirstOrNull<Stack<TSource>, Stack<TSource>.Enumerator, TSource>(source, predicate);

        public static TSource Single<TSource, TValue>(this Stack<TSource> source)
            => ReadOnlyCollection.Single<Stack<TSource>, Stack<TSource>.Enumerator, TSource>(source);

        public static TSource Single<TSource, TValue>(this Stack<TSource> source, Func<TSource, bool> predicate)
            => Enumerable.Single<Stack<TSource>, Stack<TSource>.Enumerator, TSource>(source, predicate);

        public static TSource SingleOrDefault<TSource, TValue>(this Stack<TSource> source)
            => ReadOnlyCollection.SingleOrDefault<Stack<TSource>, Stack<TSource>.Enumerator, TSource>(source);

        public static TSource SingleOrDefault<TSource, TValue>(this Stack<TSource> source, Func<TSource, bool> predicate)
            => Enumerable.SingleOrDefault<Stack<TSource>, Stack<TSource>.Enumerator, TSource>(source, predicate);

        public static TSource? SingleOrNull<TSource, TValue>(this Stack<TSource> source)
            where TSource : struct
            => ReadOnlyCollection.SingleOrNull<Stack<TSource>, Stack<TSource>.Enumerator, TSource>(source);

        public static TSource? SingleOrNull<TSource, TValue>(this Stack<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
            => Enumerable.SingleOrNull<Stack<TSource>, Stack<TSource>.Enumerator, TSource>(source, predicate);

        public static IEnumerable<TSource> AsEnumerable<TSource>(this Stack<TSource> source)
            => source;

        public static IReadOnlyCollection<TSource> AsReadOnlyCollection<TSource>(this Stack<TSource> source)
            => source;

        public static Enumerable.AsValueEnumerableEnumerable<Stack<TSource>, Stack<TSource>.Enumerator, TSource> AsValueEnumerable<TSource>(this Stack<TSource> source)
            => Enumerable.AsValueEnumerable<Stack<TSource>, Stack<TSource>.Enumerator, TSource>(source);

        public static ReadOnlyCollection.AsValueReadOnlyCollectionEnumerable<Stack<TSource>, Stack<TSource>.Enumerator, TSource> AsValueReadOnlyCollection<TSource>(this Stack<TSource> source)
            => ReadOnlyCollection.AsValueReadOnlyCollection<Stack<TSource>, Stack<TSource>.Enumerator, TSource>(source);

        public static TSource[] ToArray<TSource>(this Stack<TSource> source)
            => ReadOnlyCollection.ToArray<Stack<TSource>, Stack<TSource>.Enumerator, TSource>(source);

        public static List<TSource> ToList<TSource>(this Stack<TSource> source)
            => ReadOnlyCollection.ToList<Stack<TSource>, Stack<TSource>.Enumerator, TSource>(source);
    }
}
