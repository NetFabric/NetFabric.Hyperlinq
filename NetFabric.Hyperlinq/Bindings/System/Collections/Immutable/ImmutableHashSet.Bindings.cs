using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    [GeneratorIgnore]
    public static partial class ImmutableHashSetBindings
    {
        
        public static int Count<TSource>(this ImmutableHashSet<TSource> source)
            => source.Count;

        
        public static ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource> Skip<TSource>(this ImmutableHashSet<TSource> source, int count)
            => ValueReadOnlyCollectionExtensions.Skip<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        
        public static ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource> Take<TSource>(this ImmutableHashSet<TSource> source, int count)
            => ValueReadOnlyCollectionExtensions.Take<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        
        public static bool All<TSource>(this ImmutableHashSet<TSource> source, Predicate<TSource> predicate)
            => ValueReadOnlyCollectionExtensions.All<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        
        public static bool All<TSource>(this ImmutableHashSet<TSource> source, PredicateAt<TSource> predicate)
            => ValueReadOnlyCollectionExtensions.All<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        
        public static bool Any<TSource>(this ImmutableHashSet<TSource> source)
            => source.Count != 0;

        
        public static bool Contains<TSource>(this ImmutableHashSet<TSource> source, [AllowNull] TSource value)
            => source.Contains(value);
        
        public static bool Contains<TSource>(this ImmutableHashSet<TSource> source, [AllowNull] TSource value, IEqualityComparer<TSource>? comparer)
            => ValueReadOnlyCollectionExtensions.Contains<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), value, comparer);

        
        public static ValueReadOnlyCollectionExtensions.SelectEnumerable<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this ImmutableHashSet<TSource> source,
            NullableSelector<TSource, TResult> selector)
            => ValueReadOnlyCollectionExtensions.Select<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);
        
        public static ValueReadOnlyCollectionExtensions.SelectAtEnumerable<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this ImmutableHashSet<TSource> source,
            NullableSelectorAt<TSource, TResult> selector)
            => ValueReadOnlyCollectionExtensions.Select<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);

        
        public static ValueEnumerableExtensions.SelectManyEnumerable<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this ImmutableHashSet<TSource> source,
            Selector<TSource, TSubEnumerable> selector)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ValueEnumerableExtensions.SelectMany<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TSource>(source), selector);

        
        public static ValueEnumerableExtensions.WhereEnumerable<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, ValuePredicate<TSource>> Where<TSource>(
            this ImmutableHashSet<TSource> source,
            Predicate<TSource> predicate)
            => ValueEnumerableExtensions.Where<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        
        public static ValueEnumerableExtensions.WhereAtEnumerable<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, ValuePredicateAt<TSource>> Where<TSource>(
            this ImmutableHashSet<TSource> source,
            PredicateAt<TSource> predicate)
            => ValueEnumerableExtensions.Where<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        
        public static Option<TSource> ElementAt<TSource>(this ImmutableHashSet<TSource> source, int index)
            => ValueReadOnlyCollectionExtensions.ElementAt<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), index);

        
        public static Option<TSource> First<TSource>(this ImmutableHashSet<TSource> source)
            => ValueReadOnlyCollectionExtensions.First<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        
        public static Option<TSource> Single<TSource>(this ImmutableHashSet<TSource> source)
            => ValueReadOnlyCollectionExtensions.Single<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        
        public static ValueEnumerableExtensions.DistinctEnumerable<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource> Distinct<TSource>(this ImmutableHashSet<TSource> source, IEqualityComparer<TSource>? comparer = null)
            => ValueEnumerableExtensions.Distinct<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), comparer);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ImmutableHashSet<TSource> AsEnumerable<TSource>(this ImmutableHashSet<TSource> source)
            => source;

        
        public static ValueWrapper<TSource> AsValueEnumerable<TSource>(this ImmutableHashSet<TSource> source)
            => new ValueWrapper<TSource>(source);

        
        public static TSource[] ToArray<TSource>(this ImmutableHashSet<TSource> source)
            => ValueReadOnlyCollectionExtensions.ToArray<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        
        public static List<TSource> ToList<TSource>(this ImmutableHashSet<TSource> source)
            => new List<TSource>(source);

        
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this ImmutableHashSet<TSource> source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.ToDictionary<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TKey>(new ValueWrapper<TSource>(source), keySelector, comparer);
        
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this ImmutableHashSet<TSource> source, Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.ToDictionary<ValueWrapper<TSource>, ImmutableHashSet<TSource>.Enumerator, TSource, TKey, TElement>(new ValueWrapper<TSource>(source), keySelector, elementSelector, comparer);

        public readonly partial struct ValueWrapper<TSource>
            : IValueReadOnlyCollection<TSource, ImmutableHashSet<TSource>.Enumerator>
            , ICollection<TSource>
        {
            readonly ImmutableHashSet<TSource> source;

            public ValueWrapper(ImmutableHashSet<TSource> source) 
                => this.source = source;

            public int Count 
                => source.Count;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ImmutableHashSet<TSource>.Enumerator GetEnumerator() => source.GetEnumerator();
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => source.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();

            bool ICollection<TSource>.IsReadOnly  
                => true;

            void ICollection<TSource>.CopyTo(TSource[] array, int arrayIndex) 
                => ((ICollection<TSource>)source).CopyTo(array, arrayIndex);

            void ICollection<TSource>.Add(TSource item) 
                => throw new NotSupportedException();
            void ICollection<TSource>.Clear() 
                => throw new NotSupportedException();
            bool ICollection<TSource>.Contains(TSource item) 
                => throw new NotSupportedException();
            bool ICollection<TSource>.Remove(TSource item) 
                => throw new NotSupportedException();
        }

        public static int Count<TSource>(this ValueWrapper<TSource> source)
            => source.Count;
    }
}