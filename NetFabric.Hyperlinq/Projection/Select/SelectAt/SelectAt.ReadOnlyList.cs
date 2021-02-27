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

        [GeneratorMapping("TSelector", "NetFabric.Hyperlinq.FunctionWrapper<TSource, TResult>")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SelectAtEnumerable<TList, TSource, TResult, FunctionWrapper<TSource, int, TResult>> Select<TList, TSource, TResult>(this TList source, Func<TSource, int, TResult> selector)
            where TList : struct, IReadOnlyList<TSource>
            => source.Select(selector, 0, source.Count);

        [GeneratorMapping("TSelector", "NetFabric.Hyperlinq.FunctionWrapper<TSource, int, TResult>")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static SelectAtEnumerable<TList, TSource, TResult, FunctionWrapper<TSource, int, TResult>> Select<TList, TSource, TResult>(this TList source, Func<TSource, int, TResult> selector, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            => source.SelectAt<TList, TSource, TResult, FunctionWrapper<TSource, int, TResult>>(new FunctionWrapper<TSource, int, TResult>(selector), offset, count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SelectAtEnumerable<TList, TSource, TResult, TSelector> SelectAt<TList, TSource, TResult, TSelector>(this TList source, TSelector selector = default)
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
            => source.SelectAt<TList, TSource, TResult, TSelector>(selector, 0, source.Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static SelectAtEnumerable<TList, TSource, TResult, TSelector> SelectAt<TList, TSource, TResult, TSelector>(this TList source, TSelector selector, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
            => new(in source, selector, offset, count);

        [GeneratorMapping("TSource", "TResult")]
        [StructLayout(LayoutKind.Auto)]
        public partial struct SelectAtEnumerable<TList, TSource, TResult, TSelector>
            : IValueReadOnlyList<TResult, SelectAtEnumerable<TList, TSource, TResult, TSelector>.DisposableEnumerator>
            , IList<TResult>
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            readonly int offset;
            readonly TList source;
            TSelector selector;

            internal SelectAtEnumerable(in TList source, TSelector selector, int offset, int count)
                => (this.source, this.offset, Count, this.selector) = (source, offset, count, selector);

            public readonly int Count { get; }

            public TResult this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    if (index < 0 || index >= Count) Throw.IndexOutOfRangeException();

                    return selector.Invoke(source[index + offset], index);
                }
            }
            TResult IReadOnlyList<TResult>.this[int index]
                => this[index];
            TResult IList<TResult>.this[int index]
            {
                get => this[index];
                
                [ExcludeFromCodeCoverage]
                // ReSharper disable once ValueParameterNotUsed
                set => Throw.NotSupportedException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() 
                => new (in this);
            readonly DisposableEnumerator IValueEnumerable<TResult, DisposableEnumerator>.GetEnumerator() 
                => new (in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => 
                // ReSharper disable once HeapView.BoxingAllocation
                new DisposableEnumerator(in this);

            bool ICollection<TResult>.IsReadOnly  
                => true;

            public void CopyTo(Span<TResult> span) 
            {
                if (span.Length < Count)
                    Throw.ArgumentException(Resource.DestinationNotLongEnough, nameof(span));

                var end = Count;
                if (offset is 0)
                {
                    for (var index = 0; index < end; index++)
                    {
                        var item = source[index];
                        span[index] = selector.Invoke(item, index);
                    }
                }
                else
                {
                    for (var index = 0; index < end; index++)
                    {
                        var item = source[index + offset];
                        span[index] = selector.Invoke(item, index);
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void CopyTo(TResult[] array, int arrayIndex)
                => CopyTo(array.AsSpan().Slice(arrayIndex));

            public bool Contains(TResult item)
                => source.ContainsAt<TList, TSource, TResult, TSelector>(item, default, selector, offset, Count);

            public int IndexOf(TResult item)
                => ReadOnlyListExtensions.IndexOfAt(source, item, selector, offset, Count);

            [ExcludeFromCodeCoverage]
            void ICollection<TResult>.Add(TResult item) 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void ICollection<TResult>.Clear() 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            bool ICollection<TResult>.Remove(TResult item) 
                => Throw.NotSupportedException<bool>();

            [ExcludeFromCodeCoverage]
            void IList<TResult>.Insert(int index, TResult item)
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void IList<TResult>.RemoveAt(int index)
                => Throw.NotSupportedException();

            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator
            {
                readonly TList source;
                TSelector selector;
                readonly int offset;
                readonly int end;
                int index;

                internal Enumerator(in SelectAtEnumerable<TList, TSource, TResult, TSelector> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    offset = enumerable.offset;
                    index = -1;
                    end = index + enumerable.Count;
                }

                public readonly TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector.Invoke(source[index + offset], index);
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++index <= end;
            }

            [StructLayout(LayoutKind.Auto)]
            public struct DisposableEnumerator
                : IEnumerator<TResult>
            {
                readonly TList source;
                TSelector selector;
                readonly int offset;
                readonly int end;
                int index;

                internal DisposableEnumerator(in SelectAtEnumerable<TList, TSource, TResult, TSelector> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    offset = enumerable.offset;
                    index = -1;
                    end = index + enumerable.Count;
                }

                public readonly TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector.Invoke(source[index + offset], index);
                }
                readonly TResult IEnumerator<TResult>.Current 
                    => selector.Invoke(source[index + offset], index);
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => selector.Invoke(source[index + offset], index);

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++index <= end;

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public readonly void Dispose() { }
            }

            
            #region Partitioning

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectAtEnumerable<TList, TSource, TResult, TSelector> Skip(int count)
            {
                var (skipCount, takeCount) = Utils.Skip(Count, count);
                return new SelectAtEnumerable<TList, TSource, TResult, TSelector>(source, selector, offset + skipCount, takeCount);
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectAtEnumerable<TList, TSource, TResult, TSelector> Take(int count)
                => new(source, selector, offset, Utils.Take(Count, count));
            
            #endregion
            #region Aggregation
            
            #endregion
            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => Count is not 0;
            
            #endregion
            #region Filtering
            
            #endregion
            #region Projection

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectAtEnumerable<TList, TSource, TResult2, SelectorAtSelectorCombination<TSelector, FunctionWrapper<TResult, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, TResult2> selector)
                => Select<TResult2, FunctionWrapper<TResult, TResult2>>(new FunctionWrapper<TResult, TResult2>(selector));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectAtEnumerable<TList, TSource, TResult2, SelectorAtSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>> Select<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, TResult2>
                => source.SelectAt<TList, TSource, TResult2, SelectorAtSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(new SelectorAtSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector), offset, Count);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectAtEnumerable<TList, TSource, TResult2, SelectorAtSelectorAtCombination<TSelector, FunctionWrapper<TResult, int, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, int, TResult2> selector)
                => SelectAt<TResult2, FunctionWrapper<TResult, int, TResult2>>(new FunctionWrapper<TResult, int, TResult2>(selector));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectAtEnumerable<TList, TSource, TResult2, SelectorAtSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>> SelectAt<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, int, TResult2>
                => source.SelectAt<TList, TSource, TResult2, SelectorAtSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(new SelectorAtSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector), offset, Count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly SelectManyEnumerable<SelectAtEnumerable<TList, TSource, TResult, TSelector>, TResult, TSubEnumerable, TSubEnumerator, TResult2, FunctionWrapper<TResult, TSubEnumerable>> SelectMany<TSubEnumerable, TSubEnumerator, TResult2>(Func<TResult, TSubEnumerable> selector)
                where TSubEnumerable : IValueEnumerable<TResult2, TSubEnumerator>
                where TSubEnumerator : struct, IEnumerator<TResult2>
                => this.SelectMany<SelectAtEnumerable<TList, TSource, TResult, TSelector>, TResult, TSubEnumerable, TSubEnumerator, TResult2>(selector, offset, Count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly SelectManyEnumerable<SelectAtEnumerable<TList, TSource, TResult, TSelector>, TResult, TSubEnumerable, TSubEnumerator, TResult2, TSelector2> SelectMany<TSubEnumerable, TSubEnumerator, TResult2, TSelector2>(TSelector2 selector = default)
                where TSubEnumerable : IValueEnumerable<TResult2, TSubEnumerator>
                where TSubEnumerator : struct, IEnumerator<TResult2>
                where TSelector2 : struct, IFunction<TResult, TSubEnumerable>
                => this.SelectMany<SelectAtEnumerable<TList, TSource, TResult, TSelector>, TResult, TSubEnumerable, TSubEnumerator, TResult2, TSelector2>(selector, offset, Count);

            #endregion
            #region Element

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> ElementAt(int index)
                => source.ElementAtAt<TList, TSource, TResult, TSelector>(index, selector, offset, Count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> First()
                => source.FirstAt<TList, TSource, TResult, TSelector>(selector, offset, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> Single()
                => source.SingleAt<TList, TSource, TResult, TSelector>(selector, offset, Count);
            
            #endregion
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult[] ToArray()
                => source.ToArrayAt<TList, TSource, TResult, TSelector>(selector, offset, Count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public IMemoryOwner<TResult> ToArray(MemoryPool<TResult> pool)
                => source.ToArrayAt<TList, TSource, TResult, TSelector>(selector, offset, Count, pool);


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TResult> ToList()
                => source.ToListAt<TList, TSource, TResult, TSelector>(selector, offset, Count);
            
            #endregion

            public readonly bool SequenceEqual(IEnumerable<TResult> other, IEqualityComparer<TResult>? comparer = default)
            {
                comparer ??= EqualityComparer<TResult>.Default;

                var enumerator = GetEnumerator();
                using var otherEnumerator = other.GetEnumerator();
                while (true)
                {
                    var thisEnded = !enumerator.MoveNext();
                    var otherEnded = !otherEnumerator.MoveNext();

                    if (thisEnded != otherEnded)
                        return false;

                    if (thisEnded)
                        return true;

                    if (!comparer.Equals(enumerator.Current, otherEnumerator.Current))
                        return false;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TList, TSource, TResult, TSelector>(this in SelectAtEnumerable<TList, TSource, TResult, TSelector> source)
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
            => source.Count;
    }
}

