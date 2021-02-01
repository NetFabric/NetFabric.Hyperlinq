using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [GeneratorMapping("TSelector", "NetFabric.Hyperlinq.FunctionWrapper<TSource, TResult>")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentSelectEnumerable<TSource, TResult, FunctionWrapper<TSource, TResult>> Select<TSource, TResult>(this in ArraySegment<TSource> source, Func<TSource, TResult> selector)
            => source.Select<TSource, TResult, FunctionWrapper<TSource, TResult>>(new FunctionWrapper<TSource, TResult>(selector));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentSelectEnumerable<TSource, TResult, TSelector> Select<TSource, TResult, TSelector>(this in ArraySegment<TSource> source, TSelector selector = default)
            where TSelector : struct, IFunction<TSource, TResult>
            => new(in source, selector);

        [GeneratorMapping("TSource", "TResult")]
        [StructLayout(LayoutKind.Auto)]
        public partial struct ArraySegmentSelectEnumerable<TSource, TResult, TSelector>
            : IValueReadOnlyList<TResult, ArraySegmentSelectEnumerable<TSource, TResult, TSelector>.DisposableEnumerator>
            , IList<TResult>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            readonly ArraySegment<TSource> source;
            TSelector selector;

            internal ArraySegmentSelectEnumerable(in ArraySegment<TSource> source, TSelector selector)
                => (this.source, this.selector) = (source, selector);

            public readonly int Count
                => source.Count;

            public readonly TResult this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    if (index < 0 || index >= source.Count) Throw.IndexOutOfRangeException();

                    return selector.Invoke(source.Array![index + source.Offset]);
                }
            }
            TResult IReadOnlyList<TResult>.this[int index]
                => this[index];
            TResult IList<TResult>.this[int index]
            {
                get => this[index];
                
                // ReSharper disable once ValueParameterNotUsed
                set => Throw.NotSupportedException();
            }

            public readonly Enumerator GetEnumerator()
                => new (in this);
            readonly DisposableEnumerator IValueEnumerable<TResult, DisposableEnumerator>.GetEnumerator()
                => new(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(in this);


            bool ICollection<TResult>.IsReadOnly
                => true;

            void ICollection<TResult>.CopyTo(TResult[] array, int arrayIndex)
                => Copy<TSource, TResult, TSelector>(source.AsSpan(), array.AsSpan(arrayIndex), selector);
            void ICollection<TResult>.Add(TResult item)
                => Throw.NotSupportedException();
            void ICollection<TResult>.Clear()
                => Throw.NotSupportedException();
            public bool Contains(TResult item)
                => ((ReadOnlySpan<TSource>)source.AsSpan()).Contains(item, selector);
            bool ICollection<TResult>.Remove(TResult item)
                => Throw.NotSupportedException<bool>();
            int IList<TResult>.IndexOf(TResult item)
            {
                if (source.Any())
                {
                    var array = source.Array!;
                    var start = source.Offset;
                    var end = start + source.Count;
                    if (Utils.IsValueType<TResult>())
                    {
                        for (var index = start; index < end; index++)
                        {
                            var arrayItem = array[index];
                            if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(arrayItem), item))
                                return index - source.Offset;
                        }
                    }
                    else
                    {
                        var defaultComparer = EqualityComparer<TResult>.Default;
                        for (var index = start; index < end; index++)
                        {
                            var arrayItem = array[index];
                            if (defaultComparer.Equals(selector.Invoke(arrayItem), item))
                                return index - source.Offset;
                        }
                    }
                }
                return -1;
            }
            void IList<TResult>.Insert(int index, TResult item)
                => Throw.NotSupportedException();
            void IList<TResult>.RemoveAt(int index)
                => Throw.NotSupportedException();

            [StructLayout(LayoutKind.Sequential)]
            public struct Enumerator
            {
                int index;
                readonly int end;
                readonly TSource[]? source;
                TSelector selector;

                internal Enumerator(in ArraySegmentSelectEnumerable<TSource, TResult, TSelector> enumerable)
                {
                    source = enumerable.source.Array;
                    selector = enumerable.selector;
                    index = enumerable.source.Offset - 1;
                    end = index + enumerable.source.Count;
                }

                public readonly TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector.Invoke(source![index]);
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                    => ++index <= end;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct DisposableEnumerator
                : IEnumerator<TResult>
            {
                int index;
                readonly int end;
                readonly TSource[]? source;
                TSelector selector;

                internal DisposableEnumerator(in ArraySegmentSelectEnumerable<TSource, TResult, TSelector> enumerable)
                {
                    source = enumerable.source.Array;
                    selector = enumerable.selector;
                    index = enumerable.source.Offset - 1;
                    end = index + enumerable.source.Count;
                }

                public readonly TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector.Invoke(source![index]);
                }
                readonly TResult IEnumerator<TResult>.Current
                    => selector.Invoke(source![index]);
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => selector.Invoke(source![index]);

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                    => ++index <= end;

                [ExcludeFromCodeCoverage]
                public readonly void Reset()
                    => Throw.NotSupportedException();

                public void Dispose() { }
            }

            #region Aggregation
            
            #endregion
            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.Count is not 0;
            
            #endregion
            #region Filtering
            
            #endregion
            #region Projection
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentSelectEnumerable<TSource, TResult2, SelectorSelectorCombination<TSelector, FunctionWrapper<TResult, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, TResult2> selector)
                => Select<TResult2, FunctionWrapper<TResult, TResult2>>(new FunctionWrapper<TResult, TResult2>(selector));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentSelectEnumerable<TSource, TResult2, SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>> Select<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, TResult2>
                => source.Select<TSource, TResult2, SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(new SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentSelectAtEnumerable<TSource, TResult2, SelectorSelectorAtCombination<TSelector, FunctionWrapper<TResult, int, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, int, TResult2> selector)
                => SelectAt<TResult2, FunctionWrapper<TResult, int, TResult2>>(new FunctionWrapper<TResult, int, TResult2>(selector));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentSelectAtEnumerable<TSource, TResult2, SelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>> SelectAt<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, int, TResult2>
                => source.SelectAt<TSource, TResult2, SelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(new SelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ReadOnlyListExtensions.SelectManyEnumerable<ArraySegmentSelectEnumerable<TSource, TResult, TSelector>, TResult, TSubEnumerable, TSubEnumerator, TResult2, FunctionWrapper<TResult, TSubEnumerable>> SelectMany<TSubEnumerable, TSubEnumerator, TResult2>(Func<TResult, TSubEnumerable> selector)
                where TSubEnumerable : IValueEnumerable<TResult2, TSubEnumerator>
                where TSubEnumerator : struct, IEnumerator<TResult2>
                => this.SelectMany<ArraySegmentSelectEnumerable<TSource, TResult, TSelector>, TResult, TSubEnumerable, TSubEnumerator, TResult2>(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ReadOnlyListExtensions.SelectManyEnumerable<ArraySegmentSelectEnumerable<TSource, TResult, TSelector>, TResult, TSubEnumerable, TSubEnumerator, TResult2, TSelector2> SelectMany<TSubEnumerable, TSubEnumerator, TResult2, TSelector2>(TSelector2 selector = default)
                where TSubEnumerable : IValueEnumerable<TResult2, TSubEnumerator>
                where TSubEnumerator : struct, IEnumerator<TResult2>
                where TSelector2 : struct, IFunction<TResult, TSubEnumerable>
                => this.SelectMany<ArraySegmentSelectEnumerable<TSource, TResult, TSelector>, TResult, TSubEnumerable, TSubEnumerator, TResult2, TSelector2>(selector);

            #endregion
            #region Element

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> ElementAt(int index)
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ElementAt<TSource, TResult, TSelector>(index, selector);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> First()
                => ((ReadOnlySpan<TSource>)source.AsSpan()).First<TSource, TResult, TSelector>(selector);


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> Single()
                => ((ReadOnlySpan<TSource>)source.AsSpan()).Single<TSource, TResult, TSelector>(selector);
            
            #endregion
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult[] ToArray()
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ToArray<TSource, TResult, TSelector>(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public IMemoryOwner<TResult> ToArray(MemoryPool<TResult> pool)
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ToArray(selector, pool);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TResult> ToList()
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ToList<TSource, TResult, TSelector>(selector);
            
            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource, TResult, TSelector>(this ArraySegmentSelectEnumerable<TSource, TResult, TSelector> source)
            where TSelector : struct, IFunction<TSource, TResult>
            => source.Count;
    }
}

