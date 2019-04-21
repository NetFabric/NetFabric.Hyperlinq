using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static class ListBindings
    {
        public static int Count<TSource>(this List<TSource> source)
            => source.Count;

        public static int Count<TSource>(this List<TSource> source, Func<TSource, int, bool> predicate)
            => ReadOnlyList.Count<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static ReadOnlyList.SkipTakeEnumerable<ValueWrapper<TSource>, TSource> Skip<TSource>(this List<TSource> source, int count)
            => ReadOnlyList.Skip<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source), count);

        public static ReadOnlyList.SkipTakeEnumerable<ValueWrapper<TSource>, TSource> Take<TSource>(this List<TSource> source, int count)
            => ReadOnlyList.Take<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source), count);

        public static bool All<TSource>(this List<TSource> source, Func<TSource, int, bool> predicate)
            => ReadOnlyList.All<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static bool Any<TSource>(this List<TSource> source)
            => source.Count != 0;

        public static bool Any<TSource>(this List<TSource> source, Func<TSource, int, bool> predicate)
            => ReadOnlyList.Any<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static bool Contains<TSource>(this List<TSource> source, TSource value)
            => source.Contains(value);

        public static bool Contains<TSource>(this List<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
            => ReadOnlyList.Contains<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source), value, comparer);

        public static ReadOnlyList.SelectEnumerable<ValueWrapper<TSource>, TSource, TResult> Select<TSource, TResult>(
            this List<TSource> source,
            Func<TSource, int, TResult> selector) 
            => ReadOnlyList.Select<ValueWrapper<TSource>, TSource, TResult>(new ValueWrapper<TSource>(source), selector);

        public static ReadOnlyList.SelectManyEnumerable<ValueWrapper<TSource>, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this List<TSource> source,
            Func<TSource, TSubEnumerable> selector) 
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IValueEnumerator<TResult>
            => ReadOnlyList.SelectMany<ValueWrapper<TSource>, TSource, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TSource>(source), selector);

        public static ReadOnlyList.WhereEnumerable<ValueWrapper<TSource>, TSource> Where<TSource>(
            this List<TSource> source, 
            Func<TSource, int, bool> predicate) 
            => ReadOnlyList.Where<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource First<TSource>(this List<TSource> source)
            => ReadOnlyList.First<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source));

        public static TSource First<TSource>(this List<TSource> source, Func<TSource, int, bool> predicate)
            => ReadOnlyList.First<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource FirstOrDefault<TSource>(this List<TSource> source)
            => ReadOnlyList.FirstOrDefault<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source));

        public static TSource FirstOrDefault<TSource>(this List<TSource> source, Func<TSource, int, bool> predicate)
            => ReadOnlyList.FirstOrDefault<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource? FirstOrNull<TSource>(this List<TSource> source)
            where TSource : struct
            => ReadOnlyList.FirstOrNull<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source));

        public static TSource? FirstOrNull<TSource>(this List<TSource> source, Func<TSource, int, bool> predicate)
            where TSource : struct
            => ReadOnlyList.FirstOrNull<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource Single<TSource>(this List<TSource> source)
            => ReadOnlyList.Single<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source));

        public static TSource Single<TSource>(this List<TSource> source, Func<TSource, int, bool> predicate)
            => ReadOnlyList.Single<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource SingleOrDefault<TSource>(this List<TSource> source)
            => ReadOnlyList.SingleOrDefault<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source));

        public static TSource SingleOrDefault<TSource>(this List<TSource> source, Func<TSource, int, bool> predicate)
            => ReadOnlyList.SingleOrDefault<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource? SingleOrNull<TSource>(this List<TSource> source)
            where TSource : struct
            => ReadOnlyList.SingleOrNull<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source));

        public static TSource? SingleOrNull<TSource>(this List<TSource> source, Func<TSource, int, bool> predicate)
            where TSource : struct
            => ReadOnlyList.SingleOrNull<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static IReadOnlyList<TSource> AsEnumerable<TSource>(this List<TSource> source)
            => source;

        public static ReadOnlyList.AsValueEnumerableEnumerable<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource> AsValueEnumerable<TSource>(this List<TSource> source)
            => ReadOnlyList.AsValueEnumerable<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public static TSource[] ToArray<TSource>(this List<TSource> source)
            => ReadOnlyList.ToArray<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source));

        public static List<TSource> ToList<TSource>(this List<TSource> source)
            => source;

        public readonly struct ValueWrapper<TSource> : IReadOnlyList<TSource>
        {
            readonly List<TSource> source;

            public ValueWrapper(List<TSource> source)
            {
                this.source = source;
            }

            IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => source.GetEnumerator();
            int IReadOnlyCollection<TSource>.Count => source.Count;
            TSource IReadOnlyList<TSource>.this[int index] => source[index];
        }
    }
}