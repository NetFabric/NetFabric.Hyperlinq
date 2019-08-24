using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static class StackBindings
    {
        [Pure]
        public static int Count<TSource>(this Stack<TSource> source)
            => source.Count;
        [Pure]
        public static int Count<TSource>(this Stack<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.Count<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static int Count<TSource>(this Stack<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyCollection.Count<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource> Skip<TSource>(this Stack<TSource> source, int count)
            => ValueReadOnlyCollection.Skip<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        [Pure]
        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource> Take<TSource>(this Stack<TSource> source, int count)
            => ValueReadOnlyCollection.Take<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        [Pure]
        public static bool All<TSource>(this Stack<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.All<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static bool All<TSource>(this Stack<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyCollection.All<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static bool Any<TSource>(this Stack<TSource> source)
            => source.Count != 0;
        [Pure]
        public static bool Any<TSource>(this Stack<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.Any<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static bool Any<TSource>(this Stack<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyCollection.Any<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static bool Contains<TSource>(this Stack<TSource> source, TSource value)
            => source.Contains(value);

        [Pure]
        public static bool Contains<TSource>(this Stack<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
            => ValueReadOnlyCollection.Contains<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), value, comparer);

        [Pure]
        public static ValueReadOnlyCollection.SelectEnumerable<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this Stack<TSource> source,
            Func<TSource, TResult> selector)
            => ValueReadOnlyCollection.Select<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);
        [Pure]
        public static ValueReadOnlyCollection.SelectIndexEnumerable<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this Stack<TSource> source,
            Func<TSource, int, TResult> selector)
            => ValueReadOnlyCollection.Select<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);

        [Pure]
        public static ValueEnumerable.SelectManyEnumerable<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this Stack<TSource> source,
            Func<TSource, TSubEnumerable> selector)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ValueEnumerable.SelectMany<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TSource>(source), selector);

        [Pure]
        public static ValueEnumerable.WhereEnumerable<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource> Where<TSource>(
            this Stack<TSource> source,
            Func<TSource, bool> predicate)
            => ValueEnumerable.Where<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static ValueEnumerable.WhereIndexEnumerable<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource> Where<TSource>(
            this Stack<TSource> source,
            Func<TSource, int, bool> predicate)
            => ValueEnumerable.Where<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static TSource First<TSource>(this Stack<TSource> source)
            => ValueReadOnlyCollection.First<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        [Pure]
        public static TSource First<TSource>(this Stack<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.First<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static TSource FirstOrDefault<TSource>(this Stack<TSource> source)
            => ValueReadOnlyCollection.FirstOrDefault<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        [Pure]
        public static TSource FirstOrDefault<TSource>(this Stack<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.FirstOrDefault<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static (ElementResult Success, TSource Value) TryFirst<TSource>(this Stack<TSource> source)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        [Pure]
        public static (ElementResult Success, TSource Value) TryFirst<TSource>(this Stack<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static (int Index, TSource Value) TryFirst<TSource>(this Stack<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static TSource Single<TSource>(this Stack<TSource> source)
            => ValueReadOnlyCollection.Single<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        [Pure]
        public static TSource Single<TSource>(this Stack<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.Single<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static TSource SingleOrDefault<TSource>(this Stack<TSource> source)
            => ValueReadOnlyCollection.SingleOrDefault<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        [Pure]
        public static TSource SingleOrDefault<TSource>(this Stack<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.SingleOrDefault<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static (ElementResult Success, TSource Value) TrySingle<TSource>(this Stack<TSource> source)
            => ValueReadOnlyCollection.TrySingle<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        [Pure]
        public static (ElementResult Success, TSource Value) TrySingle<TSource>(this Stack<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.TrySingle<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        [Pure]
        public static (int Index, TSource Value) TrySingle<TSource>(this Stack<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyCollection.TrySingle<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        [Pure]
        public static ValueEnumerable.DistinctEnumerable<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource> Distinct<TSource>(this Stack<TSource> source, IEqualityComparer<TSource> comparer = null)
            => ValueEnumerable.Distinct<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), comparer);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Stack<TSource> AsEnumerable<TSource>(this Stack<TSource> source)
            => source;

        [Pure]
        public static ValueWrapper<TSource> AsValueEnumerable<TSource>(this Stack<TSource> source)
            => new ValueWrapper<TSource>(source);

        [Pure]
        public static TSource[] ToArray<TSource>(this Stack<TSource> source)
            => ValueReadOnlyCollection.ToArray<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        [Pure]
        public static List<TSource> ToList<TSource>(this Stack<TSource> source)
            => ValueReadOnlyCollection.ToList<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        [Pure]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this Stack<TSource> source, Func<TSource, TKey> keySelector)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource, TKey>(new ValueWrapper<TSource>(source), keySelector);
        [Pure]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this Stack<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource, TKey>(new ValueWrapper<TSource>(source), keySelector, comparer);
        [Pure]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this Stack<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource, TKey, TElement>(new ValueWrapper<TSource>(source), keySelector, elementSelector);
        [Pure]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this Stack<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource, TKey, TElement>(new ValueWrapper<TSource>(source), keySelector, elementSelector, comparer);

        public readonly struct ValueWrapper<TSource>
            : IValueReadOnlyCollection<TSource, Stack<TSource>.Enumerator>
        {
            readonly Stack<TSource> source;

            public ValueWrapper(Stack<TSource> source)
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
            public readonly Stack<TSource>.Enumerator GetEnumerator() => source.GetEnumerator();
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => source.GetEnumerator();
            readonly IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();
        }
    }
}