using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    [GeneratorIgnore]
    public static partial class ImmutableQueueBindings
    {
        [Pure]
        public static int Count<TSource>(this ImmutableQueue<TSource> source)
            => ValueEnumerable.Count<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        [Pure]
        public static ValueEnumerable.SkipEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource> Skip<TSource>(this ImmutableQueue<TSource> source, int count)
            => ValueEnumerable.Skip<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        [Pure]
        public static ValueEnumerable.TakeEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource> Take<TSource>(this ImmutableQueue<TSource> source, int count)
            => ValueEnumerable.Take<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        [Pure]
        public static bool All<TSource>(this ImmutableQueue<TSource> source, Predicate<TSource> predicate)
            => ValueEnumerable.All<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static bool All<TSource>(this ImmutableQueue<TSource> source, PredicateAt<TSource> predicate)
            => ValueEnumerable.All<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static bool Any<TSource>(this ImmutableQueue<TSource> source)
            => ValueEnumerable.Any<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        [Pure]
        public static bool Any<TSource>(this ImmutableQueue<TSource> source, Predicate<TSource> predicate)
            => ValueEnumerable.Any<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static bool Any<TSource>(this ImmutableQueue<TSource> source, PredicateAt<TSource> predicate)
            => ValueEnumerable.Any<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static bool Contains<TSource>(this ImmutableQueue<TSource> source, TSource value)
            => source.Contains(value);
        [Pure]
        public static bool Contains<TSource>(this ImmutableQueue<TSource> source, TSource value, IEqualityComparer<TSource>? comparer)
            => ValueEnumerable.Contains<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), value, comparer);

        [Pure]
        public static ValueEnumerable.SelectEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this ImmutableQueue<TSource> source,
            Selector<TSource, TResult> selector)
            => ValueEnumerable.Select<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);
        [Pure]
        public static ValueEnumerable.SelectIndexEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this ImmutableQueue<TSource> source,
            SelectorAt<TSource, TResult> selector)
            => ValueEnumerable.Select<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);

        [Pure]
        public static ValueEnumerable.SelectManyEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this ImmutableQueue<TSource> source,
            Selector<TSource, TSubEnumerable> selector)
            where TSubEnumerable : notnull, IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ValueEnumerable.SelectMany<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TSource>(source), selector);

        [Pure]
        public static ValueEnumerable.WhereEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource> Where<TSource>(
            this ImmutableQueue<TSource> source,
            Predicate<TSource> predicate)
            => ValueEnumerable.Where<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static ValueEnumerable.WhereIndexEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource> Where<TSource>(
            this ImmutableQueue<TSource> source,
            PredicateAt<TSource> predicate)
            => ValueEnumerable.Where<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static TSource ElementAt<TSource>(this ImmutableQueue<TSource> source, int index)
            => ValueEnumerable.ElementAt<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), index);
        [Pure]
        [return: MaybeNull]
        public static TSource ElementAtOrDefault<TSource>(this ImmutableQueue<TSource> source, int index)
            => ValueEnumerable.ElementAtOrDefault<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), index);

        [Pure]
        public static TSource First<TSource>(this ImmutableQueue<TSource> source)
            => ValueEnumerable.First<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        [Pure]
        [return: MaybeNull]
        public static TSource FirstOrDefault<TSource>(this ImmutableQueue<TSource> source)
            => ValueEnumerable.FirstOrDefault<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        [Pure]
        public static TSource Single<TSource>(this ImmutableQueue<TSource> source)
            => ValueEnumerable.Single<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        [Pure]
        [return: MaybeNull]
        public static TSource SingleOrDefault<TSource>(this ImmutableQueue<TSource> source)
            => ValueEnumerable.SingleOrDefault<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        [Pure]
        public static ValueEnumerable.DistinctEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource> Distinct<TSource>(this ImmutableQueue<TSource> source, IEqualityComparer<TSource>? comparer = null)
            => ValueEnumerable.Distinct<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), comparer);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ImmutableQueue<TSource> AsEnumerable<TSource>(this ImmutableQueue<TSource> source)
            => source;

        [Pure]
        public static ValueWrapper<TSource> AsValueEnumerable<TSource>(this ImmutableQueue<TSource> source)
            => new ValueWrapper<TSource>(source);

        [Pure]
        public static TSource[] ToArray<TSource>(this ImmutableQueue<TSource> source)
            => ValueEnumerable.ToArray<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        [Pure]
        public static List<TSource> ToList<TSource>(this ImmutableQueue<TSource> source)
            => new List<TSource>(source);

        [Pure]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this ImmutableQueue<TSource> source, Selector<TSource, TKey> keySelector)
            => ValueEnumerable.ToDictionary<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TKey>(new ValueWrapper<TSource>(source), keySelector);
        [Pure]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this ImmutableQueue<TSource> source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
            => ValueEnumerable.ToDictionary<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TKey>(new ValueWrapper<TSource>(source), keySelector, comparer);
        [Pure]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this ImmutableQueue<TSource> source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector)
            => ValueEnumerable.ToDictionary<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TKey, TElement>(new ValueWrapper<TSource>(source), keySelector, elementSelector);
        [Pure]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this ImmutableQueue<TSource> source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer)
            => ValueEnumerable.ToDictionary<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TKey, TElement>(new ValueWrapper<TSource>(source), keySelector, elementSelector, comparer);

        public static void ForEach<TSource>(this ImmutableQueue<TSource> source, Action<TSource> action)
            => ValueEnumerable.ForEach<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), action);
        public static void ForEach<TSource>(this ImmutableQueue<TSource> source, ActionAt<TSource> action)
            => ValueEnumerable.ForEach<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), action);

        public readonly partial struct ValueWrapper<TSource>
            : IValueEnumerable<TSource, ValueWrapper<TSource>.Enumerator>
        {
            readonly ImmutableQueue<TSource> source;

            public ValueWrapper(ImmutableQueue<TSource> source) 
                => this.source = source;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(source);
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(source);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(source);

            public struct Enumerator
                : IEnumerator<TSource>
            {
                ImmutableQueue<TSource>.Enumerator enumerator;

                internal Enumerator(ImmutableQueue<TSource> enumerable) 
                    => enumerator = enumerable.GetEnumerator();

                [MaybeNull]
                public readonly TSource Current 
                    => enumerator.Current;
                readonly object? IEnumerator.Current 
                    => enumerator.Current;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public readonly bool MoveNext() 
                    => enumerator.MoveNext();

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => throw new NotSupportedException();

                public readonly void Dispose() { }
            }
        }
    }
}