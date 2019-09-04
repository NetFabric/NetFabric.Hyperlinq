using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static class HashSetBindings
    {
        [Pure]
        public static int Count<TSource>(this HashSet<TSource> source)
            => source.Count;
        [Pure]
        public static int Count<TSource>(this HashSet<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.Count<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static int Count<TSource>(this HashSet<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyCollection.Count<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static long LongCount<TSource>(this HashSet<TSource> source)
            => ValueEnumerable.LongCount<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        [Pure]
        public static long LongCount<TSource>(this HashSet<TSource> source, Func<TSource, bool> predicate)
            => ValueEnumerable.LongCount<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource> Skip<TSource>(this HashSet<TSource> source, int count)
            => ValueReadOnlyCollection.Skip<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        [Pure]
        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource> Take<TSource>(this HashSet<TSource> source, int count)
            => ValueReadOnlyCollection.Take<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        [Pure]
        public static bool All<TSource>(this HashSet<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyCollection.All<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static bool All<TSource>(this HashSet<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.All<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static bool Any<TSource>(this HashSet<TSource> source)
            => source.Count != 0;
        [Pure]
        public static bool Any<TSource>(this HashSet<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.Any<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static bool Any<TSource>(this HashSet<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyCollection.Any<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static bool Contains<TSource>(this HashSet<TSource> source, TSource value)
            => source.Contains(value);

        [Pure]
        public static bool Contains<TSource>(this HashSet<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
            => ValueReadOnlyCollection.Contains<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), value, comparer);

        [Pure]
        public static ValueReadOnlyCollection.SelectEnumerable<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this HashSet<TSource> source,
            Func<TSource, TResult> selector)
            => ValueReadOnlyCollection.Select<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);
        [Pure]
        public static ValueReadOnlyCollection.SelectIndexEnumerable<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this HashSet<TSource> source,
            Func<TSource, int, TResult> selector)
            => ValueReadOnlyCollection.Select<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);

        [Pure]
        public static ValueEnumerable.SelectManyEnumerable<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this HashSet<TSource> source,
            Func<TSource, TSubEnumerable> selector)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ValueEnumerable.SelectMany<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TSource>(source), selector);

        [Pure]
        public static ValueEnumerable.WhereEnumerable<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource> Where<TSource>(
            this HashSet<TSource> source,
            Func<TSource, bool> predicate)
            => ValueEnumerable.Where<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static ValueEnumerable.WhereIndexEnumerable<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource> Where<TSource>(
            this HashSet<TSource> source,
            Func<TSource, int, bool> predicate)
            => ValueEnumerable.Where<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static TSource ElementAt<TSource>(this HashSet<TSource> source, int index)
            => ValueReadOnlyCollection.ElementAt<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), index);
        [Pure]
        public static TSource ElementAtOrDefault<TSource>(this HashSet<TSource> source, int index)
            => ValueReadOnlyCollection.ElementAtOrDefault<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), index);
        [Pure]
        public static Maybe<TSource> TryElementAt<TSource>(this HashSet<TSource> source, int index)
            => ValueReadOnlyCollection.TryElementAt<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), index);

        [Pure]
        public static TSource First<TSource>(this HashSet<TSource> source)
            => ValueReadOnlyCollection.First<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        [Pure]
        public static TSource First<TSource>(this HashSet<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.First<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static TSource FirstOrDefault<TSource>(this HashSet<TSource> source)
            => ValueReadOnlyCollection.FirstOrDefault<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        [Pure]
        public static TSource FirstOrDefault<TSource>(this HashSet<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.FirstOrDefault<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static Maybe<TSource> TryFirst<TSource>(this HashSet<TSource> source)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        [Pure]
        public static Maybe<TSource> TryFirst<TSource>(this HashSet<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static MaybeAt<TSource> TryFirst<TSource>(this HashSet<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static TSource Single<TSource>(this HashSet<TSource> source)
            => ValueReadOnlyCollection.Single<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        [Pure]
        public static TSource Single<TSource>(this HashSet<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.Single<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static TSource SingleOrDefault<TSource>(this HashSet<TSource> source)
            => ValueReadOnlyCollection.SingleOrDefault<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        [Pure]
        public static TSource SingleOrDefault<TSource>(this HashSet<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.SingleOrDefault<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static ValueEnumerable.DistinctEnumerable<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource> Distinct<TSource>(this HashSet<TSource> source, IEqualityComparer<TSource> comparer = null)
            => ValueEnumerable.Distinct<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), comparer);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static HashSet<TSource> AsEnumerable<TSource>(this HashSet<TSource> source)
            => source;

        [Pure]
        public static ValueWrapper<TSource> AsValueEnumerable<TSource>(this HashSet<TSource> source)
            => new ValueWrapper<TSource>(source);

        [Pure]
        public static TSource[] ToArray<TSource>(this HashSet<TSource> source)
            => ValueReadOnlyCollection.ToArray<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        [Pure]
        public static List<TSource> ToList<TSource>(this HashSet<TSource> source)
            => ValueReadOnlyCollection.ToList<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        [Pure]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this HashSet<TSource> source, Func<TSource, TKey> keySelector)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource, TKey>(new ValueWrapper<TSource>(source), keySelector);
        [Pure]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this HashSet<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource, TKey>(new ValueWrapper<TSource>(source), keySelector, comparer);
        [Pure]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this HashSet<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource, TKey, TElement>(new ValueWrapper<TSource>(source), keySelector, elementSelector);
        [Pure]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this HashSet<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource, TKey, TElement>(new ValueWrapper<TSource>(source), keySelector, elementSelector, comparer);

        public readonly struct ValueWrapper<TSource>
            : IValueReadOnlyCollection<TSource, HashSet<TSource>.Enumerator>
        {
            readonly HashSet<TSource> source;

            public ValueWrapper(HashSet<TSource> source)
            {
                this.source = source;
            }

            public readonly int Count
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source.Count;
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly HashSet<TSource>.Enumerator GetEnumerator() => source.GetEnumerator();
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => source.GetEnumerator();
            readonly IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();
        }
    }
}