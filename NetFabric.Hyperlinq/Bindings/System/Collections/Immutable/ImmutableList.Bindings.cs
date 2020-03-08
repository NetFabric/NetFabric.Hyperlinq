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
    public static partial class ImmutableListBindings
    {
        [Pure]
        public static int Count<TSource>(this ImmutableList<TSource> source)
            => source.Count;

        [Pure]
        public static ReadOnlyList.SkipTakeEnumerable<ImmutableList<TSource>, TSource> Skip<TSource>(this ImmutableList<TSource> source, int count)
            => ReadOnlyList.Skip<ImmutableList<TSource>, TSource>(source, count);

        [Pure]
        public static ReadOnlyList.SkipTakeEnumerable<ImmutableList<TSource>, TSource> Take<TSource>(this ImmutableList<TSource> source, int count)
            => ReadOnlyList.Take<ImmutableList<TSource>, TSource>(source, count);

        [Pure]
        public static bool All<TSource>(this ImmutableList<TSource> source, Predicate<TSource> predicate)
            => ReadOnlyList.All<ImmutableList<TSource>, TSource>(source, predicate);
        [Pure]
        public static bool All<TSource>(this ImmutableList<TSource> source, PredicateAt<TSource> predicate)
            => ReadOnlyList.All<ImmutableList<TSource>, TSource>(source, predicate);

        [Pure]
        public static bool Any<TSource>(this ImmutableList<TSource> source)
            => source.Count != 0;
        [Pure]
        public static bool Any<TSource>(this ImmutableList<TSource> source, Predicate<TSource> predicate)
            => ReadOnlyList.Any<ImmutableList<TSource>, TSource>(source, predicate);
        [Pure]
        public static bool Any<TSource>(this ImmutableList<TSource> source, PredicateAt<TSource> predicate)
            => ReadOnlyList.Any<ImmutableList<TSource>, TSource>(source, predicate);

        [Pure]
        public static bool Contains<TSource>(this ImmutableList<TSource> source, TSource value)
            => source.Contains(value);
        [Pure]
        public static bool Contains<TSource>(this ImmutableList<TSource> source, TSource value, IEqualityComparer<TSource>? comparer)
            => ReadOnlyList.Contains<ImmutableList<TSource>, TSource>(source, value, comparer);

        [Pure]
        public static ReadOnlyList.SelectEnumerable<ImmutableList<TSource>, TSource, TResult> Select<TSource, TResult>(
            this ImmutableList<TSource> source,
            Selector<TSource, TResult> selector)
            => ReadOnlyList.Select<ImmutableList<TSource>, TSource, TResult>(source, selector);
        [Pure]
        public static ReadOnlyList.SelectIndexEnumerable<ImmutableList<TSource>, TSource, TResult> Select<TSource, TResult>(
            this ImmutableList<TSource> source,
            SelectorAt<TSource, TResult> selector)
            => ReadOnlyList.Select<ImmutableList<TSource>, TSource, TResult>(source, selector);

        [Pure]
        public static ReadOnlyList.SelectManyEnumerable<ImmutableList<TSource>, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this ImmutableList<TSource> source,
            Selector<TSource, TSubEnumerable> selector)
            where TSubEnumerable : notnull, IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ReadOnlyList.SelectMany<ImmutableList<TSource>, TSource, TSubEnumerable, TSubEnumerator, TResult>(source, selector);

        [Pure]
        public static ReadOnlyList.WhereEnumerable<ImmutableList<TSource>, TSource> Where<TSource>(
            this ImmutableList<TSource> source,
            Predicate<TSource> predicate)
            => ReadOnlyList.Where<ImmutableList<TSource>, TSource>(source, predicate);
        [Pure]
        public static ReadOnlyList.WhereIndexEnumerable<ImmutableList<TSource>, TSource> Where<TSource>(
            this ImmutableList<TSource> source,
            PredicateAt<TSource> predicate)
            => ReadOnlyList.Where<ImmutableList<TSource>, TSource>(source, predicate);

        [Pure]
        public static TSource ElementAt<TSource>(this ImmutableList<TSource> source, int index)
            => ReadOnlyList.ElementAt<ImmutableList<TSource>, TSource>(source, index);
        [Pure]
        [return: MaybeNull]
        public static TSource ElementAtOrDefault<TSource>(this ImmutableList<TSource> source, int index)
            => ReadOnlyList.ElementAtOrDefault<ImmutableList<TSource>, TSource>(source, index);

        [Pure]
        public static TSource First<TSource>(this ImmutableList<TSource> source)
            => ReadOnlyList.First<ImmutableList<TSource>, TSource>(source);
        [Pure]
        [return: MaybeNull]
        public static TSource FirstOrDefault<TSource>(this ImmutableList<TSource> source)
            => ReadOnlyList.FirstOrDefault<ImmutableList<TSource>, TSource>(source);

        [Pure]
        public static TSource Single<TSource>(this ImmutableList<TSource> source)
            => ReadOnlyList.Single<ImmutableList<TSource>, TSource>(source);
        [Pure]
        [return: MaybeNull]
        public static TSource SingleOrDefault<TSource>(this ImmutableList<TSource> source)
            => ReadOnlyList.SingleOrDefault<ImmutableList<TSource>, TSource>(source);

        [Pure]
        public static ReadOnlyList.DistinctEnumerable<ImmutableList<TSource>, TSource> Distinct<TSource>(this ImmutableList<TSource> source, IEqualityComparer<TSource>? comparer = null)
            => ReadOnlyList.Distinct<ImmutableList<TSource>, TSource>(source, comparer);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ImmutableList<TSource> AsEnumerable<TSource>(this ImmutableList<TSource> source)
            => source;

        [Pure]
        public static ValueWrapper<TSource> AsValueEnumerable<TSource>(this ImmutableList<TSource> source)
            => new ValueWrapper<TSource>(source);

        [Pure]
        public static TSource[] ToArray<TSource>(this ImmutableList<TSource> source)
            => ReadOnlyList.ToArray<ImmutableList<TSource>, TSource>(source);

        [Pure]
        public static List<TSource> ToList<TSource>(this ImmutableList<TSource> source)
            => new List<TSource>(source);

        [Pure]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this ImmutableList<TSource> source, Selector<TSource, TKey> keySelector)
            => ReadOnlyList.ToDictionary<ImmutableList<TSource>, TSource, TKey>(source, keySelector);
        [Pure]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this ImmutableList<TSource> source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
            => ReadOnlyList.ToDictionary<ImmutableList<TSource>, TSource, TKey>(source, keySelector, comparer);
        [Pure]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this ImmutableList<TSource> source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector)
            => ReadOnlyList.ToDictionary<ImmutableList<TSource>, TSource, TKey, TElement>(source, keySelector, elementSelector);
        [Pure]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this ImmutableList<TSource> source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer)
            => ReadOnlyList.ToDictionary<ImmutableList<TSource>, TSource, TKey, TElement>(source, keySelector, elementSelector, comparer);

        public static void ForEach<TSource>(this ImmutableList<TSource> source, Action<TSource> action)
            => ReadOnlyList.ForEach<ImmutableList<TSource>, TSource>(source, action);
        public static void ForEach<TSource>(this ImmutableList<TSource> source, ActionAt<TSource> action)
            => ReadOnlyList.ForEach<ImmutableList<TSource>, TSource>(source, action);

        public readonly partial struct ValueWrapper<TSource>
            : IValueReadOnlyList<TSource, ImmutableList<TSource>.Enumerator>
            , IList<TSource>
        {
            readonly ImmutableList<TSource> source;

            public ValueWrapper(ImmutableList<TSource> source) 
                => this.source = source;

            public int Count
                => source.Count;

            [MaybeNull]
            public TSource this[int index]
                => source[index];

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ImmutableList<TSource>.Enumerator GetEnumerator() => source.GetEnumerator();
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => source.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();

            [MaybeNull]
            TSource IList<TSource>.this[int index]
            {
                get => source[index];
                set => throw new NotImplementedException();
            }

            bool ICollection<TSource>.IsReadOnly  
                => true;

            void ICollection<TSource>.CopyTo(TSource[] array, int arrayIndex) 
                => source.CopyTo(array, arrayIndex);
            void ICollection<TSource>.Add(TSource item) 
                => throw new NotImplementedException();
            void ICollection<TSource>.Clear() 
                => throw new NotImplementedException();
            bool ICollection<TSource>.Contains(TSource item) 
                => source.Contains(item);
            bool ICollection<TSource>.Remove(TSource item) 
                => throw new NotImplementedException();
            int IList<TSource>.IndexOf(TSource item)
                => source.IndexOf(item);
            void IList<TSource>.Insert(int index, TSource item)
                => throw new NotImplementedException();
            void IList<TSource>.RemoveAt(int index)
                => throw new NotImplementedException();
        }

        public static int Count<TSource>(this ValueWrapper<TSource> source)
            => source.Count;
    }
}