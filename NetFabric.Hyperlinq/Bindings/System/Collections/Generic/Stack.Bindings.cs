using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class StackBindings
    {
        
        public static int Count<TSource>(this Stack<TSource> source)
            => source.Count;

        
        public static ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource> Skip<TSource>(this Stack<TSource> source, int count)
            => ValueReadOnlyCollectionExtensions.Skip<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        
        public static ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource> Take<TSource>(this Stack<TSource> source, int count)
            => ValueReadOnlyCollectionExtensions.Take<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        
        public static bool All<TSource>(this Stack<TSource> source, Predicate<TSource> predicate)
            => ValueReadOnlyCollectionExtensions.All<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        
        public static bool All<TSource>(this Stack<TSource> source, PredicateAt<TSource> predicate)
            => ValueReadOnlyCollectionExtensions.All<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        
        public static bool Any<TSource>(this Stack<TSource> source)
            => source.Count != 0;

        
        public static bool Contains<TSource>(this Stack<TSource> source, [AllowNull] TSource value)
            => source.Contains(value!);

        
        public static bool Contains<TSource>(this Stack<TSource> source, [AllowNull] TSource value, IEqualityComparer<TSource>? comparer)
            => ValueReadOnlyCollectionExtensions.Contains<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), value, comparer);

        
        public static ValueReadOnlyCollectionExtensions.SelectEnumerable<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this Stack<TSource> source,
            NullableSelector<TSource, TResult> selector)
            => ValueReadOnlyCollectionExtensions.Select<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);
        
        public static ValueReadOnlyCollectionExtensions.SelectAtEnumerable<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this Stack<TSource> source,
            NullableSelectorAt<TSource, TResult> selector)
            => ValueReadOnlyCollectionExtensions.Select<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);

        
        public static ValueEnumerableExtensions.SelectManyEnumerable<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this Stack<TSource> source,
            Selector<TSource, TSubEnumerable> selector)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ValueEnumerableExtensions.SelectMany<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TSource>(source), selector);

        
        public static ValueEnumerableExtensions.WhereEnumerable<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource, ValuePredicate<TSource>> Where<TSource>(
            this Stack<TSource> source,
            Predicate<TSource> predicate)
            => ValueEnumerableExtensions.Where<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        
        public static ValueEnumerableExtensions.WhereAtEnumerable<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource, ValuePredicateAt<TSource>> Where<TSource>(
            this Stack<TSource> source,
            PredicateAt<TSource> predicate)
            => ValueEnumerableExtensions.Where<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        
        public static Option<TSource> ElementAt<TSource>(this Stack<TSource> source, int index)
            => ValueReadOnlyCollectionExtensions.ElementAt<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), index);

        
        public static Option<TSource> First<TSource>(this Stack<TSource> source)
            => ValueReadOnlyCollectionExtensions.First<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        
        public static Option<TSource> Single<TSource>(this Stack<TSource> source)
            => ValueReadOnlyCollectionExtensions.Single<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        
        public static ValueEnumerableExtensions.DistinctEnumerable<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource> Distinct<TSource>(this Stack<TSource> source, IEqualityComparer<TSource>? comparer = default)
            => ValueEnumerableExtensions.Distinct<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), comparer);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Stack<TSource> AsEnumerable<TSource>(this Stack<TSource> source)
            => source;

        
        public static ValueWrapper<TSource> AsValueEnumerable<TSource>(this Stack<TSource> source)
            => new ValueWrapper<TSource>(source);

        
        public static TSource[] ToArray<TSource>(this Stack<TSource> source)
            => ValueReadOnlyCollectionExtensions.ToArray<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        
        public static List<TSource> ToList<TSource>(this Stack<TSource> source)
            => ValueReadOnlyCollectionExtensions.ToList<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this Stack<TSource> source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.ToDictionary<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource, TKey>(new ValueWrapper<TSource>(source), keySelector, comparer);
        
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this Stack<TSource> source, Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.ToDictionary<ValueWrapper<TSource>, Stack<TSource>.Enumerator, TSource, TKey, TElement>(new ValueWrapper<TSource>(source), keySelector, elementSelector, comparer);

        public readonly partial struct ValueWrapper<TSource>
            : IValueReadOnlyCollection<TSource, Stack<TSource>.Enumerator>
            , ICollection<TSource>
        {
            readonly Stack<TSource> source;

            public ValueWrapper(Stack<TSource> source) 
                => this.source = source;

            public readonly int Count
                => source.Count;

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Stack<TSource>.Enumerator GetEnumerator() => source.GetEnumerator();
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