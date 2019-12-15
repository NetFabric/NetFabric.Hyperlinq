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
    public static class ImmutableListBindings
    {
        [Pure]
        public static int Count<TSource>(this ImmutableList<TSource> source)
            => source.Count;
        [Pure]
        public static int Count<TSource>(this ImmutableList<TSource> source, Predicate<TSource> predicate)
            => ValueReadOnlyList.Count<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static int Count<TSource>(this ImmutableList<TSource> source, PredicateAt<TSource> predicate)
            => ValueReadOnlyList.Count<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static long LongCount<TSource>(this ImmutableList<TSource> source)
            => ValueEnumerable.LongCount<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        [Pure]
        public static long LongCount<TSource>(this ImmutableList<TSource> source, Predicate<TSource> predicate)
            => ValueEnumerable.LongCount<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static ValueReadOnlyList.SkipTakeEnumerable<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource> Skip<TSource>(this ImmutableList<TSource> source, int count)
            => ValueReadOnlyList.Skip<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        [Pure]
        public static ValueReadOnlyList.SkipTakeEnumerable<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource> Take<TSource>(this ImmutableList<TSource> source, int count)
            => ValueReadOnlyList.Take<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        [Pure]
        public static bool All<TSource>(this ImmutableList<TSource> source, Predicate<TSource> predicate)
            => ValueReadOnlyList.All<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static bool All<TSource>(this ImmutableList<TSource> source, PredicateAt<TSource> predicate)
            => ValueReadOnlyList.All<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static bool Any<TSource>(this ImmutableList<TSource> source)
            => source.Count != 0;
        [Pure]
        public static bool Any<TSource>(this ImmutableList<TSource> source, Predicate<TSource> predicate)
            => ValueReadOnlyList.Any<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static bool Any<TSource>(this ImmutableList<TSource> source, PredicateAt<TSource> predicate)
            => ValueReadOnlyList.Any<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static bool Contains<TSource>(this ImmutableList<TSource> source, TSource value)
            => source.Contains(value);
        [Pure]
        public static bool Contains<TSource>(this ImmutableList<TSource> source, TSource value, IEqualityComparer<TSource>? comparer)
            => ValueReadOnlyList.Contains<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), value, comparer);

        [Pure]
        public static ValueReadOnlyList.SelectEnumerable<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this ImmutableList<TSource> source,
            Func<TSource, TResult> selector)
            => ValueReadOnlyList.Select<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);
        [Pure]
        public static ValueReadOnlyList.SelectIndexEnumerable<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this ImmutableList<TSource> source,
            Func<TSource, int, TResult> selector)
            => ValueReadOnlyList.Select<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);

        [Pure]
        public static ValueReadOnlyList.SelectManyEnumerable<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this ImmutableList<TSource> source,
            Func<TSource, TSubEnumerable> selector)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ValueReadOnlyList.SelectMany<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TSource>(source), selector);

        [Pure]
        public static ValueReadOnlyList.WhereEnumerable<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource> Where<TSource>(
            this ImmutableList<TSource> source,
            Predicate<TSource> predicate)
            => ValueReadOnlyList.Where<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static ValueReadOnlyList.WhereIndexEnumerable<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource> Where<TSource>(
            this ImmutableList<TSource> source,
            PredicateAt<TSource> predicate)
            => ValueReadOnlyList.Where<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static TSource ElementAt<TSource>(this ImmutableList<TSource> source, int index)
            => ValueReadOnlyList.ElementAt<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), index);
        [Pure]
        [return: MaybeNull]
        public static TSource ElementAtOrDefault<TSource>(this ImmutableList<TSource> source, int index)
            => ValueReadOnlyList.ElementAtOrDefault<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), index);
        [Pure]
        public static Maybe<TSource> TryElementAt<TSource>(this ImmutableList<TSource> source, int index)
            => ValueReadOnlyList.TryElementAt<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), index);

        [Pure]
        public static TSource First<TSource>(this ImmutableList<TSource> source)
            => ValueReadOnlyList.First<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        [Pure]
        public static TSource First<TSource>(this ImmutableList<TSource> source, Predicate<TSource> predicate)
            => ValueReadOnlyList.First<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        [return: MaybeNull]
        public static TSource FirstOrDefault<TSource>(this ImmutableList<TSource> source)
            => ValueReadOnlyList.FirstOrDefault<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        [Pure]
        [return: MaybeNull]
        public static TSource FirstOrDefault<TSource>(this ImmutableList<TSource> source, Predicate<TSource> predicate)
            => ValueReadOnlyList.FirstOrDefault<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static Maybe<TSource> TryFirst<TSource>(this ImmutableList<TSource> source)
            => ValueReadOnlyList.TryFirst<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        [Pure]
        public static Maybe<TSource> TryFirst<TSource>(this ImmutableList<TSource> source, Predicate<TSource> predicate)
            => ValueReadOnlyList.TryFirst<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static MaybeAt<TSource> TryFirst<TSource>(this ImmutableList<TSource> source, PredicateAt<TSource> predicate)
            => ValueReadOnlyList.TryFirst<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static TSource Single<TSource>(this ImmutableList<TSource> source)
            => ValueReadOnlyList.Single<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        [Pure]
        public static TSource Single<TSource>(this ImmutableList<TSource> source, Predicate<TSource> predicate)
            => ValueReadOnlyList.Single<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        [return: MaybeNull]
        public static TSource SingleOrDefault<TSource>(this ImmutableList<TSource> source)
            => ValueReadOnlyList.SingleOrDefault<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        [Pure]
        [return: MaybeNull]
        public static TSource SingleOrDefault<TSource>(this ImmutableList<TSource> source, Predicate<TSource> predicate)
            => ValueReadOnlyList.SingleOrDefault<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static ValueReadOnlyList.DistinctEnumerable<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource> Distinct<TSource>(this ImmutableList<TSource> source, IEqualityComparer<TSource>? comparer = null)
            => ValueReadOnlyList.Distinct<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), comparer);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ImmutableList<TSource> AsEnumerable<TSource>(this ImmutableList<TSource> source)
            => source;

        [Pure]
        public static ValueWrapper<TSource> AsValueEnumerable<TSource>(this ImmutableList<TSource> source)
            => new ValueWrapper<TSource>(source);

        [Pure]
        public static TSource[] ToArray<TSource>(this ImmutableList<TSource> source)
            => ValueReadOnlyList.ToArray<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        [Pure]
        public static List<TSource> ToList<TSource>(this ImmutableList<TSource> source)
            => new List<TSource>(source);

        [Pure]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this ImmutableList<TSource> source, Func<TSource, TKey> keySelector)
            => ValueReadOnlyList.ToDictionary<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource, TKey>(new ValueWrapper<TSource>(source), keySelector);
        [Pure]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this ImmutableList<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
            => ValueReadOnlyList.ToDictionary<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource, TKey>(new ValueWrapper<TSource>(source), keySelector, comparer);
        [Pure]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this ImmutableList<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
            => ValueReadOnlyList.ToDictionary<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource, TKey, TElement>(new ValueWrapper<TSource>(source), keySelector, elementSelector);
        [Pure]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this ImmutableList<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer)
            => ValueReadOnlyList.ToDictionary<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource, TKey, TElement>(new ValueWrapper<TSource>(source), keySelector, elementSelector, comparer);

        public static void ForEach<TSource>(this ImmutableList<TSource> source, Action<TSource> action)
            => ValueReadOnlyList.ForEach<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), action);
        public static void ForEach<TSource>(this ImmutableList<TSource> source, Action<TSource, int> action)
            => ValueReadOnlyList.ForEach<ValueWrapper<TSource>, ImmutableList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), action);

        public readonly struct ValueWrapper<TSource>
            : IValueReadOnlyList<TSource, ImmutableList<TSource>.Enumerator>
        {
            readonly ImmutableList<TSource> source;

            public ValueWrapper(ImmutableList<TSource> source)
            {
                this.source = source;
            }

            public int Count
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source.Count;
            }
            public TSource this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source[index];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ImmutableList<TSource>.Enumerator GetEnumerator() => source.GetEnumerator();
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => source.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();
        }
    }
}