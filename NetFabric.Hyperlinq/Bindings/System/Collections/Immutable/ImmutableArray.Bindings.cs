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
    public static class ImmutableArrayBindings
    {
        [Pure]
        public static int Count<TSource>(this ImmutableArray<TSource> source)
            => source.Length;
        [Pure]
        public static int Count<TSource>(this ImmutableArray<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyList.Count<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static int Count<TSource>(this ImmutableArray<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyList.Count<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static long LongCount<TSource>(this ImmutableArray<TSource> source)
            => ValueEnumerable.LongCount<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        [Pure]
        public static long LongCount<TSource>(this ImmutableArray<TSource> source, Func<TSource, bool> predicate)
            => ValueEnumerable.LongCount<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static ValueReadOnlyList.SkipTakeEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource> Skip<TSource>(this ImmutableArray<TSource> source, int count)
            => ValueReadOnlyList.Skip<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        [Pure]
        public static ValueReadOnlyList.SkipTakeEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource> Take<TSource>(this ImmutableArray<TSource> source, int count)
            => ValueReadOnlyList.Take<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        [Pure]
        public static bool All<TSource>(this ImmutableArray<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyList.All<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static bool Any<TSource>(this ImmutableArray<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyList.Any<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static bool Contains<TSource>(this ImmutableArray<TSource> source, TSource value)
            => source.Contains(value);
        [Pure]
        public static bool Contains<TSource>(this ImmutableArray<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
            => ValueReadOnlyList.Contains<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), value, comparer);

        [Pure]
        public static ValueReadOnlyList.SelectEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TResult> SelectHyper<TSource, TResult>(
            this ImmutableArray<TSource> source,
            Func<TSource, TResult> selector)
            => ValueReadOnlyList.Select<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);
        [Pure]
        public static ValueReadOnlyList.SelectIndexEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TResult> SelectHyper<TSource, TResult>(
            this ImmutableArray<TSource> source,
            Func<TSource, int, TResult> selector)
            => ValueReadOnlyList.Select<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);

        [Pure]
        public static ValueReadOnlyList.SelectManyEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this ImmutableArray<TSource> source,
            Func<TSource, TSubEnumerable> selector)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ValueReadOnlyList.SelectMany<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TSource>(source), selector);

        [Pure]
        public static ValueReadOnlyList.WhereEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource> WhereHyper<TSource>(
            this ImmutableArray<TSource> source,
            Func<TSource, bool> predicate)
            => ValueReadOnlyList.Where<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static ValueReadOnlyList.WhereIndexEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource> HyperWhere<TSource>(
            this ImmutableArray<TSource> source,
            Func<TSource, int, bool> predicate)
            => ValueReadOnlyList.Where<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static TSource ElementAt<TSource>(this ImmutableArray<TSource> source, int index)
            => ValueReadOnlyList.ElementAt<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), index);
        [Pure]
        public static TSource ElementAtOrDefault<TSource>(this ImmutableArray<TSource> source, int index)
            => ValueReadOnlyList.ElementAtOrDefault<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), index);
        [Pure]
        public static Maybe<TSource> TryElementAt<TSource>(this ImmutableArray<TSource> source, int index)
            => ValueReadOnlyList.TryElementAt<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), index);

        [Pure]
        public static Maybe<TSource> TryFirst<TSource>(this ImmutableArray<TSource> source)
            => ValueReadOnlyList.TryFirst<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        [Pure]
        public static Maybe<TSource> TryFirst<TSource>(this ImmutableArray<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyList.TryFirst<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static MaybeAt<TSource> TryFirst<TSource>(this ImmutableArray<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyList.TryFirst<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static ValueReadOnlyList.DistinctEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource> Distinct<TSource>(this ImmutableArray<TSource> source, IEqualityComparer<TSource> comparer = null)
            => ValueReadOnlyList.Distinct<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), comparer);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ImmutableArray<TSource> AsEnumerable<TSource>(this ImmutableArray<TSource> source)
            => source;

        [Pure]
        public static ValueWrapper<TSource> AsValueEnumerable<TSource>(this ImmutableArray<TSource> source)
            => new ValueWrapper<TSource>(source);

        public readonly struct ValueWrapper<TSource>
            : IValueReadOnlyList<TSource, ValueWrapper<TSource>.Enumerator>
        {
            readonly ImmutableArray<TSource> source;

            public ValueWrapper(ImmutableArray<TSource> source)
            {
                this.source = source;
            }

            public int Count
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source.Length;
            }
            public TSource this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source[index];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(source);
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(source);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(source);

            public struct Enumerator
                : IEnumerator<TSource>
            {
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                ImmutableArray<TSource>.Enumerator enumerator; // do not make readonly

                internal Enumerator(ImmutableArray<TSource> enumerable)
                {
                    enumerator = enumerable.GetEnumerator();
                }

                public TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => enumerator.Current;
                }
                object IEnumerator.Current => enumerator.Current;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public readonly bool MoveNext() => enumerator.MoveNext();

                public readonly void Reset() => throw new NotSupportedException();

                public readonly void Dispose() { }
            }
        }
    }
}