using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    [Ignore]
    public static class ImmutableHashSetBindings
    {
        [Pure]
        public static int Count<TSource>(this ImmutableHashSet<TSource> source)
            => source.Count;
        [Pure]
        public static int Count<TSource>(this ImmutableHashSet<TSource> source, Predicate<TSource> predicate)
            => ValueReadOnlyCollection.Count<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static int Count<TSource>(this ImmutableHashSet<TSource> source, PredicateAt<TSource> predicate)
            => ValueReadOnlyCollection.Count<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static long LongCount<TSource>(this ImmutableHashSet<TSource> source)
            => ValueEnumerable.LongCount<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        [Pure]
        public static long LongCount<TSource>(this ImmutableHashSet<TSource> source, Predicate<TSource> predicate)
            => ValueEnumerable.LongCount<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource> Skip<TSource>(this ImmutableHashSet<TSource> source, int count)
            => ValueReadOnlyCollection.Skip<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        [Pure]
        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource> Take<TSource>(this ImmutableHashSet<TSource> source, int count)
            => ValueReadOnlyCollection.Take<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        [Pure]
        public static bool All<TSource>(this ImmutableHashSet<TSource> source, Predicate<TSource> predicate)
            => ValueReadOnlyCollection.All<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static bool All<TSource>(this ImmutableHashSet<TSource> source, PredicateAt<TSource> predicate)
            => ValueReadOnlyCollection.All<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static bool Any<TSource>(this ImmutableHashSet<TSource> source)
            => source.Count != 0;
        [Pure]
        public static bool Any<TSource>(this ImmutableHashSet<TSource> source, Predicate<TSource> predicate)
            => ValueReadOnlyCollection.Any<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static bool Any<TSource>(this ImmutableHashSet<TSource> source, PredicateAt<TSource> predicate)
            => ValueReadOnlyCollection.Any<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static bool Contains<TSource>(this ImmutableHashSet<TSource> source, TSource value)
            => source.Contains(value);
        [Pure]
        public static bool Contains<TSource>(this ImmutableHashSet<TSource> source, TSource value, IEqualityComparer<TSource>? comparer)
            => ValueReadOnlyCollection.Contains<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), value, comparer);

        [Pure]
        public static ValueReadOnlyCollection.SelectEnumerable<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this ImmutableHashSet<TSource> source,
            Selector<TSource, TResult> selector)
            => ValueReadOnlyCollection.Select<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);
        [Pure]
        public static ValueReadOnlyCollection.SelectIndexEnumerable<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this ImmutableHashSet<TSource> source,
            SelectorAt<TSource, TResult> selector)
            => ValueReadOnlyCollection.Select<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);

        [Pure]
        public static ValueEnumerable.SelectManyEnumerable<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this ImmutableHashSet<TSource> source,
            Selector<TSource, TSubEnumerable> selector)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ValueEnumerable.SelectMany<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TSource>(source), selector);

        [Pure]
        public static ValueEnumerable.WhereEnumerable<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource> Where<TSource>(
            this ImmutableHashSet<TSource> source,
            Predicate<TSource> predicate)
            => ValueEnumerable.Where<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static ValueEnumerable.WhereIndexEnumerable<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource> Where<TSource>(
            this ImmutableHashSet<TSource> source,
            PredicateAt<TSource> predicate)
            => ValueEnumerable.Where<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static TSource ElementAt<TSource>(this ImmutableHashSet<TSource> source, int index)
            => ValueReadOnlyCollection.ElementAt<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), index);
        [Pure]
        [return: MaybeNull]
        public static TSource ElementAtOrDefault<TSource>(this ImmutableHashSet<TSource> source, int index)
            => ValueReadOnlyCollection.ElementAtOrDefault<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), index);
        [Pure]
        public static Maybe<TSource> TryElementAt<TSource>(this ImmutableHashSet<TSource> source, int index)
            => ValueReadOnlyCollection.TryElementAt<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), index);

        [Pure]
        public static TSource First<TSource>(this ImmutableHashSet<TSource> source)
            => ValueReadOnlyCollection.First<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        [Pure]
        public static TSource First<TSource>(this ImmutableHashSet<TSource> source, Predicate<TSource> predicate)
            => ValueReadOnlyCollection.First<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        [return: MaybeNull]
        public static TSource FirstOrDefault<TSource>(this ImmutableHashSet<TSource> source)
            => ValueReadOnlyCollection.FirstOrDefault<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        [Pure]
        [return: MaybeNull]
        public static TSource FirstOrDefault<TSource>(this ImmutableHashSet<TSource> source, Predicate<TSource> predicate)
            => ValueReadOnlyCollection.FirstOrDefault<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static Maybe<TSource> TryFirst<TSource>(this ImmutableHashSet<TSource> source)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        [Pure]
        public static Maybe<TSource> TryFirst<TSource>(this ImmutableHashSet<TSource> source, Predicate<TSource> predicate)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static MaybeAt<TSource> TryFirst<TSource>(this ImmutableHashSet<TSource> source, PredicateAt<TSource> predicate)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static TSource Single<TSource>(this ImmutableHashSet<TSource> source)
            => ValueReadOnlyCollection.Single<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        [Pure]
        public static TSource Single<TSource>(this ImmutableHashSet<TSource> source, Predicate<TSource> predicate)
            => ValueReadOnlyCollection.Single<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        [return: MaybeNull]
        public static TSource SingleOrDefault<TSource>(this ImmutableHashSet<TSource> source)
            => ValueReadOnlyCollection.SingleOrDefault<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        [Pure]
        [return: MaybeNull]
        public static TSource SingleOrDefault<TSource>(this ImmutableHashSet<TSource> source, Predicate<TSource> predicate)
            => ValueReadOnlyCollection.SingleOrDefault<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static ValueEnumerable.DistinctEnumerable<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource> Distinct<TSource>(this ImmutableHashSet<TSource> source, IEqualityComparer<TSource>? comparer = null)
            => ValueEnumerable.Distinct<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), comparer);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ImmutableHashSet<TSource> AsEnumerable<TSource>(this ImmutableHashSet<TSource> source)
            => source;

        [Pure]
        public static ValueWrapper<TSource> AsValueEnumerable<TSource>(this ImmutableHashSet<TSource> source)
            => new ValueWrapper<TSource>(source);

        [Pure]
        public static TSource[] ToArray<TSource>(this ImmutableHashSet<TSource> source)
            => ValueReadOnlyCollection.ToArray<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        [Pure]
        public static List<TSource> ToList<TSource>(this ImmutableHashSet<TSource> source)
            => new List<TSource>(source);

        [Pure]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this ImmutableHashSet<TSource> source, Selector<TSource, TKey> keySelector)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TKey>(new ValueWrapper<TSource>(source), keySelector);
        [Pure]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this ImmutableHashSet<TSource> source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TKey>(new ValueWrapper<TSource>(source), keySelector, comparer);
        [Pure]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this ImmutableHashSet<TSource> source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TKey, TElement>(new ValueWrapper<TSource>(source), keySelector, elementSelector);
        [Pure]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this ImmutableHashSet<TSource> source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TKey, TElement>(new ValueWrapper<TSource>(source), keySelector, elementSelector, comparer);

        public static void ForEach<TSource>(this ImmutableHashSet<TSource> source, Action<TSource> action)
            => ValueReadOnlyCollection.ForEach<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), action);
        public static void ForEach<TSource>(this ImmutableHashSet<TSource> source, ActionAt<TSource> action)
            => ValueReadOnlyCollection.ForEach<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), action);

        public readonly struct ValueWrapper<TSource>
            : IValueReadOnlyCollection<TSource, ImmutableHashSet<TSource>.Enumerator>
        {
            readonly ImmutableHashSet<TSource> source;

            public ValueWrapper(ImmutableHashSet<TSource> source)
            {
                this.source = source;
            }

            public int Count
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source.Count;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ImmutableHashSet<TSource>.Enumerator GetEnumerator() => source.GetEnumerator();
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => source.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();
        }
    }
}