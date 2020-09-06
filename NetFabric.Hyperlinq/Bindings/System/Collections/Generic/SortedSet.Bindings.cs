using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class SortedSetBindings
    {
        
        public static int Count<TSource>(this SortedSet<TSource> source)
            => source.Count;

        
        public static ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource> Skip<TSource>(this SortedSet<TSource> source, int count)
            => ValueReadOnlyCollectionExtensions.Skip<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        
        public static ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource> Take<TSource>(this SortedSet<TSource> source, int count)
            => ValueReadOnlyCollectionExtensions.Take<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        
        public static bool All<TSource>(this SortedSet<TSource> source, Predicate<TSource> predicate)
            => ValueReadOnlyCollectionExtensions.All<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        
        public static bool All<TSource>(this SortedSet<TSource> source, PredicateAt<TSource> predicate)
            => ValueReadOnlyCollectionExtensions.All<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        
        public static bool Any<TSource>(this SortedSet<TSource> source)
            => source.Count != 0;

        
        public static bool Contains<TSource>(this SortedSet<TSource> source, [AllowNull] TSource value)
            => source.Contains(value!);

        
        public static bool Contains<TSource>(this SortedSet<TSource> source, [AllowNull] TSource value, IEqualityComparer<TSource>? comparer)
            => ValueReadOnlyCollectionExtensions.Contains<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), value, comparer);

        
        public static ValueReadOnlyCollectionExtensions.SelectEnumerable<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this SortedSet<TSource> source,
            NullableSelector<TSource, TResult> selector)
            => ValueReadOnlyCollectionExtensions.Select<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);
        
        public static ValueReadOnlyCollectionExtensions.SelectAtEnumerable<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this SortedSet<TSource> source,
            NullableSelectorAt<TSource, TResult> selector)
            => ValueReadOnlyCollectionExtensions.Select<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);

        
        public static ValueEnumerableExtensions.SelectManyEnumerable<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this SortedSet<TSource> source,
            Selector<TSource, TSubEnumerable> selector)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ValueEnumerableExtensions.SelectMany<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TSource>(source), selector);

        
        public static ValueEnumerableExtensions.WhereEnumerable<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource, ValuePredicate<TSource>> Where<TSource>(
            this SortedSet<TSource> source,
            Predicate<TSource> predicate)
            => ValueEnumerableExtensions.Where<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        
        public static ValueEnumerableExtensions.WhereAtEnumerable<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource, ValuePredicateAt<TSource>> Where<TSource>(
            this SortedSet<TSource> source,
            PredicateAt<TSource> predicate)
            => ValueEnumerableExtensions.Where<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        
        public static Option<TSource> ElementAt<TSource>(this SortedSet<TSource> source, int index)
            => ValueReadOnlyCollectionExtensions.ElementAt<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), index);

        
        public static Option<TSource> First<TSource>(this SortedSet<TSource> source)
            => ValueReadOnlyCollectionExtensions.First<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        
        public static Option<TSource> Single<TSource>(this SortedSet<TSource> source)
            => ValueReadOnlyCollectionExtensions.Single<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        
        public static ValueEnumerableExtensions.DistinctEnumerable<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource> Distinct<TSource>(this SortedSet<TSource> source, IEqualityComparer<TSource>? comparer = default)
            => ValueEnumerableExtensions.Distinct<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), comparer);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SortedSet<TSource> AsEnumerable<TSource>(this SortedSet<TSource> source)
            => source;

        
        public static ValueWrapper<TSource> AsValueEnumerable<TSource>(this SortedSet<TSource> source)
            => new ValueWrapper<TSource>(source);

        
        public static TSource[] ToArray<TSource>(this SortedSet<TSource> source)
            => ValueReadOnlyCollectionExtensions.ToArray<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        
        public static List<TSource> ToList<TSource>(this SortedSet<TSource> source)
            => ValueReadOnlyCollectionExtensions.ToList<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this SortedSet<TSource> source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.ToDictionary<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource, TKey>(new ValueWrapper<TSource>(source), keySelector, comparer);
        
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this SortedSet<TSource> source, Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.ToDictionary<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource, TKey, TElement>(new ValueWrapper<TSource>(source), keySelector, elementSelector, comparer);

        public readonly partial struct ValueWrapper<TSource>
            : IValueReadOnlyCollection<TSource, SortedSet<TSource>.Enumerator>
            , ICollection<TSource>
        {
            readonly SortedSet<TSource> source;

            public ValueWrapper(SortedSet<TSource> source) 
                => this.source = source;

            public readonly int Count
                => source.Count;

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly SortedSet<TSource>.Enumerator GetEnumerator() => source.GetEnumerator();
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => source.GetEnumerator();
            readonly IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();

            bool ICollection<TSource>.IsReadOnly  
                => true;

            void ICollection<TSource>.CopyTo(TSource[] array, int arrayIndex) 
                => ((ICollection<TSource>)source).CopyTo(array, arrayIndex);

            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Add(TSource item) 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Clear() 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            bool ICollection<TSource>.Contains(TSource item) 
                => Throw.NotSupportedException<bool>();
            [ExcludeFromCodeCoverage]
            bool ICollection<TSource>.Remove(TSource item) 
                => Throw.NotSupportedException<bool>();
        }

        public static int Count<TSource>(this ValueWrapper<TSource> source)
            => source.Count;
    }
}