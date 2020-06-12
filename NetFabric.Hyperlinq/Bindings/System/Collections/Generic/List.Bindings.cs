using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ListBindings
    {
        
        public static int Count<TSource>(this List<TSource> source)
            => source.Count;

        
        public static ReadOnlyListExtensions.SkipTakeEnumerable<List<TSource>, TSource> Skip<TSource>(this List<TSource> source, int count)
            => ReadOnlyListExtensions.Skip<List<TSource>, TSource>(source, count);

        
        public static ReadOnlyListExtensions.SkipTakeEnumerable<List<TSource>, TSource> Take<TSource>(this List<TSource> source, int count)
            => ReadOnlyListExtensions.Take<List<TSource>, TSource>(source, count);

        
        public static bool All<TSource>(this List<TSource> source, Predicate<TSource> predicate)
            => ReadOnlyListExtensions.All<List<TSource>, TSource>(source, predicate);
        
        public static bool All<TSource>(this List<TSource> source, PredicateAt<TSource> predicate)
            => ReadOnlyListExtensions.All<List<TSource>, TSource>(source, predicate);

        
        public static bool Any<TSource>(this List<TSource> source)
            => source.Count != 0;
        
        public static bool Any<TSource>(this List<TSource> source, Predicate<TSource> predicate)
            => ReadOnlyListExtensions.Any<List<TSource>, TSource>(source, predicate);
        
        public static bool Any<TSource>(this List<TSource> source, PredicateAt<TSource> predicate)
            => ReadOnlyListExtensions.Any<List<TSource>, TSource>(source, predicate);

        
        public static bool Contains<TSource>(this List<TSource> source, [AllowNull] TSource value)
            => source.Contains(value!);
        
        public static bool Contains<TSource>(this List<TSource> source, [AllowNull] TSource value, IEqualityComparer<TSource>? comparer)
            => ReadOnlyListExtensions.Contains<List<TSource>, TSource>(source, value, comparer);

        
        public static ReadOnlyListExtensions.SelectEnumerable<List<TSource>, TSource, TResult> Select<TSource, TResult>(
            this List<TSource> source,
            Selector<TSource, TResult> selector)
            => ReadOnlyListExtensions.Select<List<TSource>, TSource, TResult>(source, selector);
        
        public static ReadOnlyListExtensions.SelectAtEnumerable<List<TSource>, TSource, TResult> Select<TSource, TResult>(
            this List<TSource> source,
            SelectorAt<TSource, TResult> selector)
            => ReadOnlyListExtensions.Select<List<TSource>, TSource, TResult>(source, selector);

        
        public static ReadOnlyListExtensions.SelectManyEnumerable<List<TSource>, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this List<TSource> source,
            Selector<TSource, TSubEnumerable> selector)
            where TSubEnumerable : notnull, IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ReadOnlyListExtensions.SelectMany<List<TSource>, TSource, TSubEnumerable, TSubEnumerator, TResult>(source, selector);

        
        public static ReadOnlyListExtensions.WhereEnumerable<List<TSource>, TSource> Where<TSource>(
            this List<TSource> source,
            Predicate<TSource> predicate)
            => ReadOnlyListExtensions.Where<List<TSource>, TSource>(source, predicate);
        
        public static ReadOnlyListExtensions.WhereAtEnumerable<List<TSource>, TSource> Where<TSource>(
            this List<TSource> source,
            PredicateAt<TSource> predicate)
            => ReadOnlyListExtensions.Where<List<TSource>, TSource>(source, predicate);

        
        public static Option<TSource> ElementAt<TSource>(this List<TSource> source, int index)
            => ReadOnlyListExtensions.ElementAt<List<TSource>, TSource>(source, index);

        
        public static Option<TSource> First<TSource>(this List<TSource> source)
            => ReadOnlyListExtensions.First<List<TSource>, TSource>(source);

        
        public static Option<TSource> Single<TSource>(this List<TSource> source)
            => ReadOnlyListExtensions.Single<List<TSource>, TSource>(source);

        
        public static ReadOnlyListExtensions.DistinctEnumerable<List<TSource>, TSource> Distinct<TSource>(this List<TSource> source, IEqualityComparer<TSource>? comparer = default)
            => ReadOnlyListExtensions.Distinct<List<TSource>, TSource>(source, comparer);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> AsEnumerable<TSource>(this List<TSource> source)
            => source;

        
        public static ValueWrapper<TSource> AsValueEnumerable<TSource>(this List<TSource> source)
            => new ValueWrapper<TSource>(source);

        
        public static TSource[] ToArray<TSource>(this List<TSource> source)
            => ReadOnlyListExtensions.ToArray<List<TSource>, TSource>(source);

        
        public static List<TSource> ToList<TSource>(this List<TSource> source)
            => new List<TSource>(source);

        
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this List<TSource> source, Selector<TSource, TKey> keySelector)
            => ReadOnlyListExtensions.ToDictionary<List<TSource>, TSource, TKey>(source, keySelector);
        
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this List<TSource> source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
            => ReadOnlyListExtensions.ToDictionary<List<TSource>, TSource, TKey>(source, keySelector, comparer);
        
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this List<TSource> source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector)
            => ReadOnlyListExtensions.ToDictionary<List<TSource>, TSource, TKey, TElement>(source, keySelector, elementSelector);
        
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this List<TSource> source, Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer)
            => ReadOnlyListExtensions.ToDictionary<List<TSource>, TSource, TKey, TElement>(source, keySelector, elementSelector, comparer);
        
        public readonly partial struct ValueWrapper<TSource>
            : IValueReadOnlyList<TSource, List<TSource>.Enumerator>
            , IList<TSource>
        {
            readonly List<TSource> source;

            public ValueWrapper(List<TSource> source) 
                => this.source = source;

            public readonly int Count
                => source.Count;

            [MaybeNull]
            public readonly TSource this[int index] 
                => source[index];
            TSource IReadOnlyList<TSource>.this[int index]
                => source[index];
            TSource IList<TSource>.this[int index]
            {
                get => source[index];
                set => Throw.NotSupportedException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly List<TSource>.Enumerator GetEnumerator() => source.GetEnumerator();
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => source.GetEnumerator();
            readonly IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();

            bool ICollection<TSource>.IsReadOnly  
                => true;

            void ICollection<TSource>.CopyTo(TSource[] array, int arrayIndex) 
                => source.CopyTo(array, arrayIndex);
            void ICollection<TSource>.Add(TSource item) 
                => Throw.NotSupportedException();
            void ICollection<TSource>.Clear() 
                => Throw.NotSupportedException();
            bool ICollection<TSource>.Contains(TSource item) 
                => source.Contains(item);
            bool ICollection<TSource>.Remove(TSource item) 
                => Throw.NotSupportedException<bool>();
            int IList<TSource>.IndexOf(TSource item)
                => source.IndexOf(item);
            void IList<TSource>.Insert(int index, TSource item)
                => Throw.NotSupportedException();
            void IList<TSource>.RemoveAt(int index)
                => Throw.NotSupportedException();
        }    
    }
}