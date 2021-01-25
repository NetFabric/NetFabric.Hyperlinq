using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    [GeneratorIgnore]
    public static partial class ImmutableArrayBindings
    {
        
        #region Aggregation
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this ImmutableArray<TSource> source)
            => ReadOnlyListExtensions.Count<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source));
            
        #endregion
        #region Partitioning

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyListExtensions.SkipTakeEnumerable<ValueWrapper<TSource>, TSource> Skip<TSource>(this ImmutableArray<TSource> source, int count)
            => ReadOnlyListExtensions.Skip<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source), count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyListExtensions.SkipTakeEnumerable<ValueWrapper<TSource>, TSource> Take<TSource>(this ImmutableArray<TSource> source, int count)
            => ReadOnlyListExtensions.Take<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source), count);
            
        #endregion
        #region Quantifier

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this ImmutableArray<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyListExtensions.All<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource, TPredicate>(this ImmutableArray<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, bool>
            => ReadOnlyListExtensions.All<ValueWrapper<TSource>, TSource, TPredicate>(new ValueWrapper<TSource>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this ImmutableArray<TSource> source, Func<TSource, int, bool> predicate)
            => ReadOnlyListExtensions.All<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AllAt<TSource, TPredicate>(this ImmutableArray<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, int, bool>
            => ReadOnlyListExtensions.AllAt<ValueWrapper<TSource>, TSource, TPredicate>(new ValueWrapper<TSource>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this ImmutableArray<TSource> source)
            => ReadOnlyListExtensions.Any<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this ImmutableArray<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyListExtensions.Any<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource, TPredicate>(this ImmutableArray<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, bool>
            => ReadOnlyListExtensions.Any<ValueWrapper<TSource>, TSource, TPredicate>(new ValueWrapper<TSource>(source), predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this ImmutableArray<TSource> source, Func<TSource, int, bool> predicate)
            => ReadOnlyListExtensions.Any<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source), predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AnyAt<TSource, TPredicate>(this ImmutableArray<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, int, bool>
            => ReadOnlyListExtensions.AnyAt<ValueWrapper<TSource>, TSource, TPredicate>(new ValueWrapper<TSource>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<TSource>(this ImmutableArray<TSource> source, TSource value, IEqualityComparer<TSource>? comparer = default)
            => ReadOnlyListExtensions.Contains<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source), value, comparer);
            
        #endregion
        #region Projection

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyListExtensions.SelectEnumerable<ValueWrapper<TSource>, TSource, TResult, FunctionWrapper<TSource, TResult>> Select<TSource, TResult>(
            this ImmutableArray<TSource> source,
            Func<TSource, TResult> selector)
            => ReadOnlyListExtensions.Select<ValueWrapper<TSource>, TSource, TResult>(new ValueWrapper<TSource>(source), selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyListExtensions.SelectEnumerable<ValueWrapper<TSource>, TSource, TResult, TSelector> Select<TSource, TResult, TSelector>(
            this ImmutableArray<TSource> source,
            TSelector selector)
            where TSelector : struct, IFunction<TSource, TResult>
            => ReadOnlyListExtensions.Select<ValueWrapper<TSource>, TSource, TResult, TSelector>(new ValueWrapper<TSource>(source), selector);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyListExtensions.SelectAtEnumerable<ValueWrapper<TSource>, TSource, TResult, FunctionWrapper<TSource, int, TResult>> Select<TSource, TResult>(
            this ImmutableArray<TSource> source,
            Func<TSource, int, TResult> selector)
            => ReadOnlyListExtensions.Select<ValueWrapper<TSource>, TSource, TResult>(new ValueWrapper<TSource>(source), selector);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyListExtensions.SelectAtEnumerable<ValueWrapper<TSource>, TSource, TResult, TSelector> SelectAt<TSource, TResult, TSelector>(
            this ImmutableArray<TSource> source,
            TSelector selector)
            where TSelector : struct, IFunction<TSource, int, TResult>
            => ReadOnlyListExtensions.SelectAt<ValueWrapper<TSource>, TSource, TResult, TSelector>(new ValueWrapper<TSource>(source), selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyListExtensions.SelectManyEnumerable<ValueWrapper<TSource>, TSource, TSubEnumerable, TSubEnumerator, TResult, FunctionWrapper<TSource, TSubEnumerable>> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this ImmutableArray<TSource> source,
            Func<TSource, TSubEnumerable> selector)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ReadOnlyListExtensions.SelectMany<ValueWrapper<TSource>, TSource, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TSource>(source), selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyListExtensions.SelectManyEnumerable<ValueWrapper<TSource>, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>(
            this ImmutableArray<TSource> source,
            TSelector selector)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
            => ReadOnlyListExtensions.SelectMany<ValueWrapper<TSource>, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>(new ValueWrapper<TSource>(source), selector);
            
        #endregion
        #region Filtering

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyListExtensions.WhereEnumerable<ValueWrapper<TSource>, TSource, FunctionWrapper<TSource, bool>> Where<TSource>(
            this ImmutableArray<TSource> source,
            Func<TSource, bool> predicate)
            => ReadOnlyListExtensions.Where<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyListExtensions.WhereEnumerable<ValueWrapper<TSource>, TSource, TPredicate> Where<TSource, TPredicate>(
            this ImmutableArray<TSource> source,
            TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, bool>
            => ReadOnlyListExtensions.Where<ValueWrapper<TSource>, TSource, TPredicate>(new ValueWrapper<TSource>(source), predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyListExtensions.WhereAtEnumerable<ValueWrapper<TSource>, TSource, FunctionWrapper<TSource, int, bool>> Where<TSource>(
            this ImmutableArray<TSource> source,
            Func<TSource, int, bool> predicate)
            => ReadOnlyListExtensions.Where<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyListExtensions.WhereAtEnumerable<ValueWrapper<TSource>, TSource, TPredicate> WhereAt<TSource, TPredicate>(
            this ImmutableArray<TSource> source,
            TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, int, bool>
            => ReadOnlyListExtensions.WhereAt<ValueWrapper<TSource>, TSource, TPredicate>(new ValueWrapper<TSource>(source), predicate);
            
        #endregion
        #region Element

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> ElementAt<TSource>(this ImmutableArray<TSource> source, int index)
            => ReadOnlyListExtensions.ElementAt<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source), index);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> First<TSource>(this ImmutableArray<TSource> source)
            => ReadOnlyListExtensions.First<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> Single<TSource>(this ImmutableArray<TSource> source)
#pragma warning disable HLQ005 // Avoid Single() and SingleOrDefault()
            => ReadOnlyListExtensions.Single<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source));
#pragma warning restore HLQ005 // Avoid Single() and SingleOrDefault()
            
        #endregion
        #region Set

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyListExtensions.DistinctEnumerable<ValueWrapper<TSource>, TSource> Distinct<TSource>(this ImmutableArray<TSource> source, IEqualityComparer<TSource>? comparer = default)
            => ReadOnlyListExtensions.Distinct<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source), comparer);
            
        #endregion
        #region Conversion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ImmutableArray<TSource> AsEnumerable<TSource>(this ImmutableArray<TSource> source)
            => source;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueWrapper<TSource> AsValueEnumerable<TSource>(this ImmutableArray<TSource> source)
            => new(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource[] ToArray<TSource>(this ImmutableArray<TSource> source)
            => ReadOnlyListExtensions.ToArray<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> ToList<TSource>(this ImmutableArray<TSource> source)
            => ReadOnlyListExtensions.ToList<ValueWrapper<TSource>, TSource>(new ValueWrapper<TSource>(source));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this ImmutableArray<TSource> source, Func<TSource, TKey> keyFunc, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => ReadOnlyListExtensions.ToDictionary<ValueWrapper<TSource>, TSource, TKey>(new ValueWrapper<TSource>(source), keyFunc, comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey, TKeySelector>(this ImmutableArray<TSource> source, TKeySelector keyFunc, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            => ReadOnlyListExtensions.ToDictionary<ValueWrapper<TSource>, TSource, TKey, TKeySelector>(new ValueWrapper<TSource>(source), keyFunc, comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this ImmutableArray<TSource> source, Func<TSource, TKey> keyFunc, Func<TSource, TElement> elementFunc, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => ReadOnlyListExtensions.ToDictionary<ValueWrapper<TSource>, TSource, TKey, TElement>(new ValueWrapper<TSource>(source), keyFunc, elementFunc, comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement, TKeySelector, TElementSelector>(this ImmutableArray<TSource> source, TKeySelector keyFunc, TElementSelector elementFunc, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            where TElementSelector : struct, IFunction<TSource, TElement>
            => ReadOnlyListExtensions.ToDictionary<ValueWrapper<TSource>, TSource, TKey, TElement, TKeySelector, TElementSelector>(new ValueWrapper<TSource>(source), keyFunc, elementFunc, comparer);
            
        #endregion

        public readonly partial struct ValueWrapper<TSource>
            : IValueReadOnlyList<TSource, ValueWrapper<TSource>.Enumerator>
            , IList<TSource>
        {
            readonly ImmutableArray<TSource> source;

            public ValueWrapper(ImmutableArray<TSource> source) 
                => this.source = source;

            public int Count
                => source.Length;

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
            public readonly Enumerator GetEnumerator() 
                => new(source);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(source);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(source);

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

            public struct Enumerator
                : IEnumerator<TSource>
            {
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                ImmutableArray<TSource>.Enumerator enumerator; // do not make readonly

                internal Enumerator(ImmutableArray<TSource> enumerable) 
                    => enumerator = enumerable.GetEnumerator();

                public readonly TSource Current 
                    => enumerator.Current;
                readonly TSource IEnumerator<TSource>.Current 
                    => enumerator.Current;
                readonly object IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
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