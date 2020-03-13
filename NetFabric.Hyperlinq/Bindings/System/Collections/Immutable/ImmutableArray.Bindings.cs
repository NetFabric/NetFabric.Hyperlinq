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
    public static partial class ImmutableArrayBindings
    {
        [Pure]
        public static int Count<TSource>(this ImmutableArray<TSource> source)
            => source.Length;

        [Pure]
        public static ReadOnlyList.SkipTakeEnumerable<ImmutableArray<TSource>, TSource> Skip<TSource>(this ImmutableArray<TSource> source, int count)
            => ReadOnlyList.Skip<ImmutableArray<TSource>, TSource>(source, count);

        [Pure]
        public static ReadOnlyList.SkipTakeEnumerable<ImmutableArray<TSource>, TSource> Take<TSource>(this ImmutableArray<TSource> source, int count)
            => ReadOnlyList.Take<ImmutableArray<TSource>, TSource>(source, count);

        [Pure]
        public static bool All<TSource>(this ImmutableArray<TSource> source, PredicateAt<TSource> predicate)
            => ReadOnlyList.All<ImmutableArray<TSource>, TSource>(source, predicate);

        [Pure]
        public static bool Any<TSource>(this ImmutableArray<TSource> source, PredicateAt<TSource> predicate)
            => ReadOnlyList.Any<ImmutableArray<TSource>, TSource>(source, predicate);

        [Pure]
        public static bool Contains<TSource>(this ImmutableArray<TSource> source, TSource value)
            => source.Contains(value);
        [Pure]
        public static bool Contains<TSource>(this ImmutableArray<TSource> source, TSource value, IEqualityComparer<TSource>? comparer)
            => ReadOnlyList.Contains<ImmutableArray<TSource>, TSource>(source, value, comparer);

        [Pure]
        public static ReadOnlyList.SelectEnumerable<ImmutableArray<TSource>, TSource, TResult> SelectHyper<TSource, TResult>(
            this ImmutableArray<TSource> source,
            Selector<TSource, TResult> selector)
            => ReadOnlyList.Select<ImmutableArray<TSource>, TSource, TResult>(source, selector);
        [Pure]
        public static ReadOnlyList.SelectIndexEnumerable<ImmutableArray<TSource>, TSource, TResult> SelectHyper<TSource, TResult>(
            this ImmutableArray<TSource> source,
            SelectorAt<TSource, TResult> selector)
            => ReadOnlyList.Select<ImmutableArray<TSource>, TSource, TResult>(source, selector);

        [Pure]
        public static ReadOnlyList.SelectManyEnumerable<ImmutableArray<TSource>, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this ImmutableArray<TSource> source,
            Selector<TSource, TSubEnumerable> selector)
            where TSubEnumerable : notnull, IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ReadOnlyList.SelectMany<ImmutableArray<TSource>, TSource, TSubEnumerable, TSubEnumerator, TResult>(source, selector);

        [Pure]
        public static ReadOnlyList.WhereEnumerable<ImmutableArray<TSource>, TSource> WhereHyper<TSource>(
            this ImmutableArray<TSource> source,
            Predicate<TSource> predicate)
            => ReadOnlyList.Where<ImmutableArray<TSource>, TSource>(source, predicate);
        [Pure]
        public static ReadOnlyList.WhereIndexEnumerable<ImmutableArray<TSource>, TSource> HyperWhere<TSource>(
            this ImmutableArray<TSource> source,
            PredicateAt<TSource> predicate)
            => ReadOnlyList.Where<ImmutableArray<TSource>, TSource>(source, predicate);

        [Pure]
        public static TSource ElementAt<TSource>(this ImmutableArray<TSource> source, int index)
            => ReadOnlyList.ElementAt<ImmutableArray<TSource>, TSource>(source, index);
        [Pure]
        [return: MaybeNull]
        public static TSource ElementAtOrDefault<TSource>(this ImmutableArray<TSource> source, int index)
            => ReadOnlyList.ElementAtOrDefault<ImmutableArray<TSource>, TSource>(source, index);

        [Pure]
        public static ReadOnlyList.DistinctEnumerable<ImmutableArray<TSource>, TSource> Distinct<TSource>(this ImmutableArray<TSource> source, IEqualityComparer<TSource>? comparer = null)
            => ReadOnlyList.Distinct<ImmutableArray<TSource>, TSource>(source, comparer);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ImmutableArray<TSource> AsEnumerable<TSource>(this ImmutableArray<TSource> source)
            => source;

        [Pure]
        public static ValueWrapper<TSource> AsValueEnumerable<TSource>(this ImmutableArray<TSource> source)
            => new ValueWrapper<TSource>(source);

        public static void ForEach<TSource>(this ImmutableArray<TSource> source, Action<TSource> action)
            => ReadOnlyList.ForEach<ImmutableArray<TSource>, TSource>(source, action);
        public static void ForEach<TSource>(this ImmutableArray<TSource> source, ActionAt<TSource> action)
            => ReadOnlyList.ForEach<ImmutableArray<TSource>, TSource>(source, action);

        public readonly partial struct ValueWrapper<TSource>
            : IValueReadOnlyList<TSource, ValueWrapper<TSource>.Enumerator>
            , IList<TSource>
        {
            readonly ImmutableArray<TSource> source;

            public ValueWrapper(ImmutableArray<TSource> source) 
                => this.source = source;

            public int Count
                => source.Length;

            [MaybeNull]
            public TSource this[int index]
                => source[index];

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(source);
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(source);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(source);

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

            public struct Enumerator
                : IEnumerator<TSource>
            {
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                ImmutableArray<TSource>.Enumerator enumerator; // do not make readonly

                internal Enumerator(ImmutableArray<TSource> enumerable) 
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

        public static int Count<TSource>(this ValueWrapper<TSource> source)
            => source.Count;
    }
}