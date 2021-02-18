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
        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentSelectRefEnumerable<TSource, TResult, FunctionInWrapper<TSource, TResult>> Select<TSource, TResult>(this in ArraySegment<TSource> source, FunctionIn<TSource, TResult> selector)
            => source.SelectRef<TSource, TResult, FunctionInWrapper<TSource, TResult>>(new FunctionInWrapper<TSource, TResult>(selector));

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentSelectRefEnumerable<TSource, TResult, TSelector> SelectRef<TSource, TResult, TSelector>(this in ArraySegment<TSource> source, TSelector selector = default)
            where TSelector : struct, IFunctionIn<TSource, TResult>
            => new(in source, selector);

        [GeneratorIgnore]
        [StructLayout(LayoutKind.Auto)]
        public partial struct ArraySegmentSelectRefEnumerable<TSource, TResult, TSelector>
            : IValueReadOnlyList<TResult, ArraySegmentSelectRefEnumerable<TSource, TResult, TSelector>.Enumerator>
            , IList<TResult>
            where TSelector : struct, IFunctionIn<TSource, TResult>
        {
            internal readonly ArraySegment<TSource> source;
            internal TSelector selector;

            internal ArraySegmentSelectRefEnumerable(in ArraySegment<TSource> source, TSelector selector)
                => (this.source, this.selector) = (source, selector);

            public readonly int Count
                => source.Count;

            public TResult this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    if (index < 0 || index >= source.Count) Throw.IndexOutOfRangeException();

                    return selector.Invoke(in source.Array![index + source.Offset]);
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

            public readonly SelectRefEnumerator<TSource, TResult, TSelector> GetEnumerator()
                => new (source.AsSpan(), selector);
            readonly Enumerator IValueEnumerable<TResult, Enumerator>.GetEnumerator()
                => new(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);


            bool ICollection<TResult>.IsReadOnly
                => true;

            void ICollection<TResult>.CopyTo(TResult[] array, int arrayIndex)
                => CopyRef<TSource, TResult, TSelector>(source.AsSpan(), array.AsSpan(arrayIndex), selector);
            void ICollection<TResult>.Add(TResult item)
                => Throw.NotSupportedException();
            void ICollection<TResult>.Clear()
                => Throw.NotSupportedException();
            public bool Contains(TResult item)
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ContainsRef(item, selector);
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
                            ref readonly var arrayItem = ref array[index];
                            if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(in arrayItem), item))
                                return index - source.Offset;
                        }
                    }
                    else
                    {
                        var defaultComparer = EqualityComparer<TResult>.Default;
                        for (var index = start; index < end; index++)
                        {
                            ref readonly var arrayItem = ref array[index];
                            if (defaultComparer.Equals(selector.Invoke(in arrayItem), item))
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

            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator
                : IEnumerator<TResult>
            {
                readonly TSource[]? source;
                TSelector selector;
                readonly int end;
                int index;

                internal Enumerator(in ArraySegmentSelectRefEnumerable<TSource, TResult, TSelector> enumerable)
                {
                    source = enumerable.source.Array;
                    selector = enumerable.selector;
                    index = enumerable.source.Offset - 1;
                    end = index + enumerable.source.Count;
                }

                public readonly TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector.Invoke(in source![index]);
                }
                readonly TResult IEnumerator<TResult>.Current
                    => selector.Invoke(in source![index]);
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => selector.Invoke(in source![index]);

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
            
            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public ArraySegmentSelectEnumerable<TSource, TResult2, SelectorSelectorCombination<TSelector, FunctionWrapper<TResult, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, TResult2> selector)
            //    => Select<TResult2, FunctionWrapper<TResult, TResult2>>(new FunctionWrapper<TResult, TResult2>(selector));
            
            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public ArraySegmentSelectEnumerable<TSource, TResult2, SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>> Select<TResult2, TSelector2>(TSelector2 selector = default)
            //    where TSelector2 : struct, IFunction<TResult, TResult2>
            //    => ((ReadOnlySpan<TSource>)source.AsSpan()).SelectRef<TSource, TResult2, SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(new SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));
            
            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public ArraySegmentSelectAtEnumerable<TSource, TResult2, SelectorSelectorAtCombination<TSelector, FunctionWrapper<TResult, int, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, int, TResult2> selector)
            //    => SelectAt<TResult2, FunctionWrapper<TResult, int, TResult2>>(new FunctionWrapper<TResult, int, TResult2>(selector));
            
            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public ArraySegmentSelectAtEnumerable<TSource, TResult2, SelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>> SelectAt<TResult2, TSelector2>(TSelector2 selector = default)
            //    where TSelector2 : struct, IFunction<TResult, int, TResult2>
            //    => ((ReadOnlySpan<TSource>)source.AsSpan()).SelectAtRef<TSource, TResult2, SelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(new SelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public readonly ReadOnlyListExtensions.SelectManyEnumerable<ArraySegmentSelectEnumerable<TSource, TResult, TSelector>, TResult, TSubEnumerable, TSubEnumerator, TResult2, FunctionWrapper<TResult, TSubEnumerable>> SelectMany<TSubEnumerable, TSubEnumerator, TResult2>(Func<TResult, TSubEnumerable> selector)
            //    where TSubEnumerable : IValueEnumerable<TResult2, TSubEnumerator>
            //    where TSubEnumerator : struct, IEnumerator<TResult2>
            //    => this.SelectManyRef<ArraySegmentSelectEnumerable<TSource, TResult, TSelector>, TResult, TSubEnumerable, TSubEnumerator, TResult2>(selector);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public readonly ReadOnlyListExtensions.SelectManyEnumerable<ArraySegmentSelectEnumerable<TSource, TResult, TSelector>, TResult, TSubEnumerable, TSubEnumerator, TResult2, TSelector2> SelectMany<TSubEnumerable, TSubEnumerator, TResult2, TSelector2>(TSelector2 selector = default)
            //    where TSubEnumerable : IValueEnumerable<TResult2, TSubEnumerator>
            //    where TSubEnumerator : struct, IEnumerator<TResult2>
            //    where TSelector2 : struct, IFunction<TResult, TSubEnumerable>
            //    => this.SelectManyRef<ArraySegmentSelectEnumerable<TSource, TResult, TSelector>, TResult, TSubEnumerable, TSubEnumerator, TResult2, TSelector2>(selector);

            #endregion
            #region Element

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public Option<TResult> ElementAt(int index)
            //    => ((ReadOnlySpan<TSource>)source.AsSpan()).ElementAtRef<TSource, TResult, TSelector>(index, selector);
            
            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public Option<TResult> First()
            //    => ((ReadOnlySpan<TSource>)source.AsSpan()).FirstRef<TSource, TResult, TSelector>(selector);


            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public Option<TResult> Single()
            //    => ((ReadOnlySpan<TSource>)source.AsSpan()).SingleRef<TSource, TResult, TSelector>(selector);
            
            #endregion
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult[] ToArray()
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ToArrayRef<TSource, TResult, TSelector>(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public IMemoryOwner<TResult> ToArray(MemoryPool<TResult> pool)
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ToArrayRef(selector, pool);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TResult> ToList()
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ToListRef<TSource, TResult, TSelector>(selector);
            
            #endregion

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource, TResult, TSelector>(this ArraySegmentSelectRefEnumerable<TSource, TResult, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, TResult>
            => source.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource, TSelector>(this ArraySegmentSelectRefEnumerable<TSource, int, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, int>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumRef<TSource, int, int, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource, TSelector>(this ArraySegmentSelectRefEnumerable<TSource, int?, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, int?>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumRef<TSource, int?, int, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TSelector>(this ArraySegmentSelectRefEnumerable<TSource, long, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, long>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumRef<TSource, long, long, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TSelector>(this ArraySegmentSelectRefEnumerable<TSource, long?, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, long?>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumRef<TSource, long?, long, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TSelector>(this ArraySegmentSelectRefEnumerable<TSource, float, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, float>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumRef<TSource, float, float, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TSelector>(this ArraySegmentSelectRefEnumerable<TSource, float?, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, float?>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumRef<TSource, float?, float, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TSelector>(this ArraySegmentSelectRefEnumerable<TSource, double, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, double>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumRef<TSource, double, double, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TSelector>(this ArraySegmentSelectRefEnumerable<TSource, double?, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, double?>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumRef<TSource, double?, double, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TSelector>(this ArraySegmentSelectRefEnumerable<TSource, decimal, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, decimal>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumRef<TSource, decimal, decimal, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TSelector>(this ArraySegmentSelectRefEnumerable<TSource, decimal?, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, decimal?>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumRef<TSource, decimal?, decimal, TSelector>(source.selector);
    }
}

