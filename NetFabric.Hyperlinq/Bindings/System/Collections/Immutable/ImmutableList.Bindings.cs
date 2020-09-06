using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    [GeneratorIgnore]
    public static partial class ImmutableListBindings
    {
        
        public static int Count<TSource>(this ImmutableList<TSource> source)
            => source.Count;

        
        public static ReadOnlyListExtensions.SkipTakeEnumerable<ImmutableList<TSource>, TSource> Skip<TSource>(this ImmutableList<TSource> source, int count)
            => ReadOnlyListExtensions.Skip<ImmutableList<TSource>, TSource>(source, count);

        
        public static ReadOnlyListExtensions.SkipTakeEnumerable<ImmutableList<TSource>, TSource> Take<TSource>(this ImmutableList<TSource> source, int count)
            => ReadOnlyListExtensions.Take<ImmutableList<TSource>, TSource>(source, count);

        
        public static bool All<TSource>(this ImmutableList<TSource> source, Predicate<TSource> predicate)
            => ReadOnlyListExtensions.All<ImmutableList<TSource>, TSource>(source, predicate);
        
        public static bool All<TSource>(this ImmutableList<TSource> source, PredicateAt<TSource> predicate)
            => ReadOnlyListExtensions.All<ImmutableList<TSource>, TSource>(source, predicate);

        
        public static bool Any<TSource>(this ImmutableList<TSource> source)
            => source.Count != 0;

        
        public static bool Contains<TSource>(this ImmutableList<TSource> source, [AllowNull] TSource value)
            => source.Contains(value);
        
        public static bool Contains<TSource>(this ImmutableList<TSource> source, [AllowNull] TSource value, IEqualityComparer<TSource>? comparer)
            => ReadOnlyListExtensions.Contains<ImmutableList<TSource>, TSource>(source, value, comparer);

        
        public static ReadOnlyListExtensions.SelectEnumerable<ImmutableList<TSource>, TSource, TResult> Select<TSource, TResult>(
            this ImmutableList<TSource> source,
            NullableSelector<TSource, TResult> selector)
            => ReadOnlyListExtensions.Select<ImmutableList<TSource>, TSource, TResult>(source, selector);
        
        public static ReadOnlyListExtensions.SelectAtEnumerable<ImmutableList<TSource>, TSource, TResult> Select<TSource, TResult>(
            this ImmutableList<TSource> source,
            NullableSelectorAt<TSource, TResult> selector)
            => ReadOnlyListExtensions.Select<ImmutableList<TSource>, TSource, TResult>(source, selector);

        
        public static ReadOnlyListExtensions.SelectManyEnumerable<ImmutableList<TSource>, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this ImmutableList<TSource> source,
            Selector<TSource, TSubEnumerable> selector)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ReadOnlyListExtensions.SelectMany<ImmutableList<TSource>, TSource, TSubEnumerable, TSubEnumerator, TResult>(source, selector);

        
        public static ReadOnlyListExtensions.WhereEnumerable<ImmutableList<TSource>, TSource, ValuePredicate<TSource>> Where<TSource>(
            this ImmutableList<TSource> source,
            Predicate<TSource> predicate)
            => ReadOnlyListExtensions.Where<ImmutableList<TSource>, TSource>(source, predicate);
        
        public static ReadOnlyListExtensions.WhereAtEnumerable<ImmutableList<TSource>, TSource, ValuePredicateAt<TSource>> Where<TSource>(
            this ImmutableList<TSource> source,
            PredicateAt<TSource> predicate)
            => ReadOnlyListExtensions.Where<ImmutableList<TSource>, TSource>(source, predicate);

        
        public static Option<TSource> ElementAt<TSource>(this ImmutableList<TSource> source, int index)
            => ReadOnlyListExtensions.ElementAt<ImmutableList<TSource>, TSource>(source, index);

        
        public static Option<TSource> First<TSource>(this ImmutableList<TSource> source)
            => ReadOnlyListExtensions.First<ImmutableList<TSource>, TSource>(source);

        
        public static Option<TSource> Single<TSource>(this ImmutableList<TSource> source)
            => ReadOnlyListExtensions.Single<ImmutableList<TSource>, TSource>(source);

        
        public static ReadOnlyListExtensions.DistinctEnumerable<ImmutableList<TSource>, TSource> Distinct<TSource>(this ImmutableList<TSource> source, IEqualityComparer<TSource>? comparer = null)
            => ReadOnlyListExtensions.Distinct<ImmutableList<TSource>, TSource>(source, comparer);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ImmutableList<TSource> AsEnumerable<TSource>(this ImmutableList<TSource> source)
            => source;

        
        public static ValueWrapper<TSource> AsValueEnumerable<TSource>(this ImmutableList<TSource> source)
            => new ValueWrapper<TSource>(source);

        
        public static TSource[] ToArray<TSource>(this ImmutableList<TSource> source)
            => ReadOnlyListExtensions.ToArray<ImmutableList<TSource>, TSource>(source);

        
        public static List<TSource> ToList<TSource>(this ImmutableList<TSource> source)
            => new List<TSource>(source);

        
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this ImmutableList<TSource> source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => ReadOnlyListExtensions.ToDictionary<ImmutableList<TSource>, TSource, TKey>(source, keySelector, comparer);
        
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this ImmutableList<TSource> source, Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => ReadOnlyListExtensions.ToDictionary<ImmutableList<TSource>, TSource, TKey, TElement>(source, keySelector, elementSelector, comparer);

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
            TSource IReadOnlyList<TSource>.this[int index]
                => source[index];
            TSource IList<TSource>.this[int index]
            {
                get => source[index];
                set => throw new NotSupportedException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ImmutableList<TSource>.Enumerator GetEnumerator() => source.GetEnumerator();
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => source.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();

            bool ICollection<TSource>.IsReadOnly  
                => true;

            void ICollection<TSource>.CopyTo(TSource[] array, int arrayIndex) 
                => source.CopyTo(array, arrayIndex);
            void ICollection<TSource>.Add(TSource item) 
                => throw new NotSupportedException();
            void ICollection<TSource>.Clear() 
                => throw new NotSupportedException();
            bool ICollection<TSource>.Contains(TSource item) 
                => source.Contains(item);
            bool ICollection<TSource>.Remove(TSource item) 
                => throw new NotSupportedException();
            int IList<TSource>.IndexOf(TSource item)
                => source.IndexOf(item);
            void IList<TSource>.Insert(int index, TSource item)
                => throw new NotSupportedException();
            void IList<TSource>.RemoveAt(int index)
                => throw new NotSupportedException();
        }

        public static int Count<TSource>(this ValueWrapper<TSource> source)
            => source.Count;
    }
}