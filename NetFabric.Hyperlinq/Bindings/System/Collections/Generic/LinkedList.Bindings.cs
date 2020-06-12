using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class LinkedListBindings
    {
        
        public static int Count<TSource>(this LinkedList<TSource> source)
            => source.Count;

        
        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource> Skip<TSource>(this LinkedList<TSource> source, int count)
            => ValueReadOnlyCollection.Skip<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        
        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource> Take<TSource>(this LinkedList<TSource> source, int count)
            => ValueReadOnlyCollection.Take<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        
        public static bool All<TSource>(this LinkedList<TSource> source, Predicate<TSource> predicate)
            => ValueReadOnlyCollection.All<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        
        public static bool All<TSource>(this LinkedList<TSource> source, PredicateAt<TSource> predicate)
            => ValueReadOnlyCollection.All<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        
        public static bool Any<TSource>(this LinkedList<TSource> source)
            => source.Count != 0;
        
        public static bool Any<TSource>(this LinkedList<TSource> source, Predicate<TSource> predicate)
            => ValueReadOnlyCollection.Any<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        
        public static bool Any<TSource>(this LinkedList<TSource> source, PredicateAt<TSource> predicate)
            => ValueReadOnlyCollection.Any<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        
        public static bool Contains<TSource>(this LinkedList<TSource> source, TSource value)
            => source.Contains(value);

        
        public static bool Contains<TSource>(this LinkedList<TSource> source, TSource value, IEqualityComparer<TSource>? comparer)
            => ValueReadOnlyCollection.Contains<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), value, comparer);

        
        public static ValueReadOnlyCollection.SelectEnumerable<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this LinkedList<TSource> source,
            Selector<TSource, TResult> selector)
            => ValueReadOnlyCollection.Select<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);
        
        public static ValueReadOnlyCollection.SelectAtEnumerable<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this LinkedList<TSource> source,
            SelectorAt<TSource, TResult> selector)
            => ValueReadOnlyCollection.Select<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);

        
        public static ValueEnumerable.SelectManyEnumerable<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this LinkedList<TSource> source,
            Selector<TSource, TSubEnumerable> selector)
            where TSubEnumerable : notnull, IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ValueEnumerable.SelectMany<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TSource>(source), selector);

        
        public static ValueEnumerable.WhereEnumerable<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource> Where<TSource>(
            this LinkedList<TSource> source,
            Predicate<TSource> predicate)
            => ValueEnumerable.Where<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        
        public static ValueEnumerable.WhereAtEnumerable<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource> Where<TSource>(
            this LinkedList<TSource> source,
            PredicateAt<TSource> predicate)
            => ValueEnumerable.Where<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        
        public static Option<TSource> ElementAt<TSource>(this LinkedList<TSource> source, int index)
            => ValueReadOnlyCollection.ElementAt<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), index);

        
        public static Option<TSource> First<TSource>(this LinkedList<TSource> source)
            => ValueReadOnlyCollection.First<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        
        public static Option<TSource> Single<TSource>(this LinkedList<TSource> source)
            => ValueReadOnlyCollection.Single<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        
        public static ValueEnumerable.DistinctEnumerable<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource> Distinct<TSource>(this LinkedList<TSource> source, IEqualityComparer<TSource>? comparer = null)
            => ValueEnumerable.Distinct<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), comparer);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static LinkedList<TSource> AsEnumerable<TSource>(this LinkedList<TSource> source)
            => source;

        
        public static ValueWrapper<TSource> AsValueEnumerable<TSource>(this LinkedList<TSource> source)
            => new ValueWrapper<TSource>(source);

        
        public static TSource[] ToArray<TSource>(this LinkedList<TSource> source)
            => ValueReadOnlyCollection.ToArray<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        
        public static List<TSource> ToList<TSource>(this LinkedList<TSource> source)
            => ValueReadOnlyCollection.ToList<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this LinkedList<TSource> source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = null)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource, TKey>(new ValueWrapper<TSource>(source), keySelector, comparer);

        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this LinkedList<TSource> source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = null)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource, TKey, TElement>(new ValueWrapper<TSource>(source), keySelector, elementSelector, comparer);

        public readonly partial struct ValueWrapper<TSource>
            : IValueReadOnlyCollection<TSource, LinkedList<TSource>.Enumerator>
            , ICollection<TSource>
        {
            readonly LinkedList<TSource> source;

            public ValueWrapper(LinkedList<TSource> source) 
                => this.source = source;

            public readonly int Count
                => source.Count;

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly LinkedList<TSource>.Enumerator GetEnumerator() => source.GetEnumerator();
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => source.GetEnumerator();
            readonly IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();

            bool ICollection<TSource>.IsReadOnly  
                => true;

            void ICollection<TSource>.CopyTo(TSource[] array, int arrayIndex) 
                => ((ICollection<TSource>)source).CopyTo(array, arrayIndex);

            void ICollection<TSource>.Add(TSource item) 
                => Throw.NotSupportedException();
            void ICollection<TSource>.Clear() 
                => Throw.NotSupportedException();
            bool ICollection<TSource>.Contains(TSource item) 
                => Throw.NotSupportedException<bool>();
            bool ICollection<TSource>.Remove(TSource item) 
                => Throw.NotSupportedException<bool>();
        }

        public static int Count<TSource>(this ValueWrapper<TSource> source)
            => source.Count;
    }
}