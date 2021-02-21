using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ListValueEnumerable<TSource> AsValueEnumerable<TSource>(this IReadOnlyList<TSource> source)
            => new(source, 0, source.Count);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ListValueEnumerable<TSource>
            : IValueReadOnlyList<TSource, ListValueEnumerable<TSource>.DisposableEnumerator>
            , IList<TSource>
        {
            internal readonly IReadOnlyList<TSource> source;
            internal readonly int offset;

            internal ListValueEnumerable(IReadOnlyList<TSource> source, int offset, int count)
                => (this.source, this.offset, Count) = (source, offset, count);

            public readonly int Count { get;  }

            public readonly TSource this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    if (index < 0 || index >= Count) Throw.IndexOutOfRangeException();
                    
                    return source[index + offset];
                }
            }
            TSource IReadOnlyList<TSource>.this[int index]
                => this[index];
            TSource IList<TSource>.this[int index]
            {
                get => this[index];
                
                [ExcludeFromCodeCoverage]
                // ReSharper disable once ValueParameterNotUsed
                set => Throw.NotSupportedException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() 
                => new(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, DisposableEnumerator>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(in this);


            bool ICollection<TSource>.IsReadOnly
                => true;

            public void CopyTo(Span<TSource> span)
            {
                if (span.Length < Count)
                    Throw.ArgumentException(Resource.DestinationNotLongEnough, nameof(span));

                Copy(this, 0, span, Count);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void CopyTo(TSource[] array, int arrayIndex)
                => CopyTo(array.AsSpan().Slice(arrayIndex));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource item)
            {
                var end = offset + Count;
                for (var index = offset; index < end; index++)
                {
                    if (EqualityComparer<TSource>.Default.Equals(source[index], item))
                        return true;
                }
                return false;
            }

            public int IndexOf(TSource item)
                => ReadOnlyListExtensions.IndexOf(source, item, offset, Count);

            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Add(TSource item)
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            bool ICollection<TSource>.Remove(TSource item)
                => Throw.NotSupportedException<bool>();
            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Clear()
                => Throw.NotSupportedException();

            [ExcludeFromCodeCoverage]
            void IList<TSource>.Insert(int index, TSource item)
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void IList<TSource>.RemoveAt(int index)
                => Throw.NotSupportedException();

            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator
            {
                readonly IReadOnlyList<TSource> source;
                readonly int end;
                int index;

                internal Enumerator(in ListValueEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    index = enumerable.offset - 1;
                    end = index + enumerable.Count;
                }

                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => source[index];
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                    => ++index <= end;
            }

            [StructLayout(LayoutKind.Auto)]
            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                readonly IReadOnlyList<TSource> source;
                readonly int end;
                int index;

                internal DisposableEnumerator(in ListValueEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    index = enumerable.offset - 1;
                    end = index + enumerable.Count;
                }

                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => source[index];
                }
                readonly TSource IEnumerator<TSource>.Current
                    => source[index];
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => source[index];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                    => ++index <= end;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                [ExcludeFromCodeCoverage]
                public void Reset()
                    => Throw.NotSupportedException();

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public readonly void Dispose() { }
            }

            #region Aggregation

            #endregion

            #region Conversion

            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public ListValueEnumerable<TSource> AsEnumerable()
            //     => this;
            //
            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public ListValueEnumerable<TSource> AsValueEnumerable()
            //     => this;
            //
            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public TSource[] ToArray()
            //     => ReadOnlyListExtensions.ToArray<TList, TSource>(source, offset, Count);
            //
            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public IMemoryOwner<TSource> ToArray(MemoryPool<TSource> memoryPool)
            //     => ReadOnlyListExtensions.ToArray(source, offset, Count, memoryPool);
            //
            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public List<TSource> ToList()
            //     => ReadOnlyListExtensions.ToList<TList, TSource>(source, offset, Count);
            //
            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public Dictionary<TKey, TSource> ToDictionary<TKey>(Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
            //     where TKey : notnull
            //     => ReadOnlyListExtensions.ToDictionary(source, keySelector, comparer, offset, Count);
            //
            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public Dictionary<TKey, TSource> ToDictionary<TKey, TKeySelector>(TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
            //     where TKey : notnull
            //     where TKeySelector : struct, IFunction<TSource, TKey>
            //     => ReadOnlyListExtensions.ToDictionary<TList, TSource, TKey, TKeySelector>(source, keySelector, comparer, offset, Count);
            //
            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
            //     where TKey : notnull
            //     => ReadOnlyListExtensions.ToDictionary(source, keySelector, elementSelector, comparer, offset, Count);
            //
            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public Dictionary<TKey, TElement> ToDictionary<TKey, TElement, TKeySelector, TElementSelector>(TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default)
            //     where TKey : notnull
            //     where TKeySelector : struct, IFunction<TSource, TKey>
            //     where TElementSelector : struct, IFunction<TSource, TElement>
            //     => ReadOnlyListExtensions.ToDictionary<TList, TSource, TKey, TElement, TKeySelector, TElementSelector>(source, keySelector, elementSelector, comparer, offset, Count);

            #endregion
    
            #region Element

            // public Option<TSource> ElementAt(int index)
            //     => ReadOnlyListExtensions.ElementAt<TList, TSource>(source, index, offset, Count);
            //
            // public Option<TSource> First()
            //     => ReadOnlyListExtensions.First<TList, TSource>(source, offset, Count);
            //
            // public Option<TSource> Single()
            //     => ReadOnlyListExtensions.Single<TList, TSource>(source, offset, Count);

            #endregion
            
            #region Filtering

            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public WhereEnumerable<TList, TSource, FunctionWrapper<TSource, bool>> Where(Func<TSource, bool> predicate)
            //     => ReadOnlyListExtensions.Where(source, predicate, offset, Count);
            //
            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public WhereEnumerable<TList, TSource, TPredicate> Where<TPredicate>(TPredicate predicate = default)
            //     where TPredicate : struct, IFunction<TSource, bool>
            //     => ReadOnlyListExtensions.Where<TList, TSource, TPredicate>(source, predicate, offset, Count);
            //
            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public WhereAtEnumerable<TList, TSource, FunctionWrapper<TSource, int, bool>> Where(Func<TSource, int, bool> predicate)
            //     => ReadOnlyListExtensions.Where(source, predicate, offset, Count);
            //
            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public WhereAtEnumerable<TList, TSource, TPredicate> WhereAt<TPredicate>(TPredicate predicate = default)
            //     where TPredicate : struct, IFunction<TSource, int, bool>
            //     => ReadOnlyListExtensions.WhereAt<TList, TSource, TPredicate>(source, predicate, offset, Count);

            #endregion
            
            #region Partitioning

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ListValueEnumerable<TSource> Skip(int count)
            {
                var (skipCount, takeCount) = Utils.Skip(Count, count);
                return new ListValueEnumerable<TSource>(source, offset + skipCount, takeCount);
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ListValueEnumerable<TSource> Take(int count)
                => new(source, offset, Utils.Take(Count, count));

            #endregion

            #region Projection

            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public SelectEnumerable<TList, TSource, TResult, FunctionWrapper<TSource, TResult>> Select<TResult>(Func<TSource, TResult> selector)
            //     => ReadOnlyListExtensions.Select(source, selector, offset, Count);
            //
            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public SelectEnumerable<TList, TSource, TResult, TSelector> Select<TResult, TSelector>(TSelector selector = default)
            //     where TSelector : struct, IFunction<TSource, TResult>
            //     => ReadOnlyListExtensions.Select<TList, TSource, TResult, TSelector>(source, selector, offset, Count);
            //
            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public SelectAtEnumerable<TList, TSource, TResult, FunctionWrapper<TSource, int, TResult>> Select<TResult>(Func<TSource, int, TResult> selector)
            //     => ReadOnlyListExtensions.Select(source, selector, offset, Count);
            //
            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public SelectAtEnumerable<TList, TSource, TResult, TSelector> SelectAt<TResult, TSelector>(TSelector selector = default)
            //     where TSelector : struct, IFunction<TSource, int, TResult>
            //     => ReadOnlyListExtensions.SelectAt<TList, TSource, TResult, TSelector>(source, selector, offset, Count);
            //
            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, FunctionWrapper<TSource, TSubEnumerable>> SelectMany<TSubEnumerable, TSubEnumerator, TResult>(Func<TSource, TSubEnumerable> selector)
            //     where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            //     where TSubEnumerator : struct, IEnumerator<TResult>
            //     => ReadOnlyListExtensions.SelectMany<TList, TSource, TSubEnumerable, TSubEnumerator, TResult>(source, selector, offset, Count);
            //
            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector> SelectMany<TSubEnumerable, TSubEnumerator, TResult, TSelector>(TSelector selector = default)
            //     where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            //     where TSubEnumerator : struct, IEnumerator<TResult>
            //     where TSelector : struct, IFunction<TSource, TSubEnumerable>
            //     => ReadOnlyListExtensions.SelectMany<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>(source, selector, offset, Count);

            #endregion
            
            #region Quantifier

            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public bool All(Func<TSource, bool> predicate)
            //     => ReadOnlyListExtensions.All(source, predicate, offset, Count);
            //
            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public bool All<TPredicate>(TPredicate predicate)
            //     where TPredicate : struct, IFunction<TSource, bool>
            //     => ReadOnlyListExtensions.All<TList, TSource, TPredicate>(source, predicate, offset, Count);
            //
            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public bool All(Func<TSource, int, bool> predicate)
            //     => ReadOnlyListExtensions.All(source, predicate, offset, Count);
            //
            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public bool AllAt<TPredicate>(TPredicate predicate)
            //     where TPredicate : struct, IFunction<TSource, int, bool>
            //     => ReadOnlyListExtensions.AllAt<TList, TSource, TPredicate>(source, predicate, offset, Count);
            //
            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public bool Any()
            //     => ReadOnlyListExtensions.Any<TList, TSource>(source, offset, Count);
            //
            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public bool Any(Func<TSource, bool> predicate)
            //     => ReadOnlyListExtensions.Any(source, predicate, offset, Count);
            //
            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public bool Any<TPredicate>(TPredicate predicate)
            //     where TPredicate : struct, IFunction<TSource, bool>
            //     => ReadOnlyListExtensions.Any<TList, TSource, TPredicate>(source, predicate, offset, Count);
            //
            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public bool Any(Func<TSource, int, bool> predicate)
            //     => ReadOnlyListExtensions.Any(source, predicate, offset, Count);
            //
            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public bool AnyAt<TPredicate>(TPredicate predicate)
            //     where TPredicate : struct, IFunction<TSource, int, bool>
            //     => ReadOnlyListExtensions.AnyAt<TList, TSource, TPredicate>(source, predicate, offset, Count);
            //
            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public bool Contains(TSource value, IEqualityComparer<TSource>? comparer)
            //     => ReadOnlyListExtensions.Contains(source, value, comparer, offset, Count);

            #endregion

            #region Set

            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public DistinctEnumerable<TList, TSource> Distinct(IEqualityComparer<TSource>? comparer = default)
            //     => ReadOnlyListExtensions.Distinct(source, comparer, offset, Count);

            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this in ListValueEnumerable<TSource> source)
            => source.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this ListValueEnumerable<int> source)
            => source.Sum<ListValueEnumerable<int>, int, int>(source.offset, source.Count);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this ListValueEnumerable<int?> source)
            => source.Sum<ListValueEnumerable<int?>, int?, int>(source.offset, source.Count);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this ListValueEnumerable<long> source)
            => source.Sum<ListValueEnumerable<long>, long, long>(source.offset, source.Count);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this ListValueEnumerable<long?> source)
            => source.Sum<ListValueEnumerable<long?>, long?, long>(source.offset, source.Count);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this ListValueEnumerable<float> source)
            => source.Sum<ListValueEnumerable<float>, float, int>(source.offset, source.Count);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this ListValueEnumerable<float?> source)
            => source.Sum<ListValueEnumerable<float?>, float?, float>(source.offset, source.Count);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this ListValueEnumerable<double> source)
            => source.Sum<ListValueEnumerable<double>, double, double>(source.offset, source.Count);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this ListValueEnumerable<double?> source)
            => source.Sum<ListValueEnumerable<double?>, double?, double>(source.offset, source.Count);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this ListValueEnumerable<decimal> source)
            => source.Sum<ListValueEnumerable<decimal>, decimal, decimal>(source.offset, source.Count);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this ListValueEnumerable<decimal?> source)
            => source.Sum<ListValueEnumerable<decimal?>, decimal?, decimal>(source.offset, source.Count);
    }
}