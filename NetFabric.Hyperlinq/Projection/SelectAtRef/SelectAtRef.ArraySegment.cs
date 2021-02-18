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
        public static ArraySegmentSelectAtRefEnumerable<TSource, TResult, FunctionInWrapper<TSource, int, TResult>> Select<TSource, TResult>(this in ArraySegment<TSource> source, FunctionIn<TSource, int, TResult> selector)
            => source.SelectAtRef<TSource, TResult, FunctionInWrapper<TSource, int, TResult>>(new FunctionInWrapper<TSource, int, TResult>(selector));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentSelectAtRefEnumerable<TSource, TResult, TSelector> SelectAtRef<TSource, TResult, TSelector>(this in ArraySegment<TSource> source, TSelector selector = default)
            where TSelector : struct, IFunctionIn<TSource, int, TResult>
            => new(in source, selector);

        [GeneratorIgnore]
        [StructLayout(LayoutKind.Auto)]
        public partial struct ArraySegmentSelectAtRefEnumerable<TSource, TResult, TSelector>
            : IValueReadOnlyList<TResult, ArraySegmentSelectAtRefEnumerable<TSource, TResult, TSelector>.Enumerator>
            , IList<TResult>
            where TSelector : struct, IFunctionIn<TSource, int, TResult>
        {
            internal readonly ArraySegment<TSource> source;
            internal TSelector selector;

            internal ArraySegmentSelectAtRefEnumerable(in ArraySegment<TSource> source, TSelector selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public readonly int Count
                => source.Count;

            public TResult this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    if (index < 0 || index >= source.Count) Throw.IndexOutOfRangeException();

                    return selector.Invoke(in source.Array![index + source.Offset], index);
                }
            }
            TResult IReadOnlyList<TResult>.this[int index]
                => this[index]!;
            TResult IList<TResult>.this[int index]
            {
                get => this[index];
                
                [ExcludeFromCodeCoverage]
                // ReSharper disable once ValueParameterNotUsed
                set => Throw.NotSupportedException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly SelectAtRefEnumerator<TSource, TResult, TSelector> GetEnumerator()
                => new(source.AsSpan(), selector);
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
                => CopyAtRef<TSource, TResult, TSelector>(source.AsSpan(), array.AsSpan(arrayIndex), selector);
            void ICollection<TResult>.Add(TResult item)
                => Throw.NotSupportedException();
            void ICollection<TResult>.Clear()
                => Throw.NotSupportedException();
            public bool Contains(TResult item)
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ContainsAtRef(item, selector);
            bool ICollection<TResult>.Remove(TResult item)
                => Throw.NotSupportedException<bool>();
            int IList<TResult>.IndexOf(TResult item)
            {
                if (source.Any())
                {
                    var array = source.Array!;
                    var start = source.Offset;
                    var end = source.Count;
                    if (start is 0)
                    {
                        if (Utils.IsValueType<TResult>())
                        {
                            for (var index = 0; index < end; index++)
                            {
                                ref readonly var arrayItem = ref array[index];
                                if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(in arrayItem, index), item))
                                    return index;
                            }
                        }
                        else
                        {
                            var defaultComparer = EqualityComparer<TResult>.Default;
                            for (var index = 0; index < end; index++)
                            {
                                ref readonly var arrayItem = ref array[index];
                                if (defaultComparer.Equals(selector.Invoke(in arrayItem, index), item))
                                    return index;
                            }
                        }
                    }
                    else
                    {
                        if (Utils.IsValueType<TResult>())
                        {
                            for (var index = 0; index < end; index++)
                            {
                                ref readonly var arrayItem = ref array[index + start];
                                if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(in arrayItem, index)!, item))
                                    return index;
                            }
                        }
                        else
                        {
                            var defaultComparer = EqualityComparer<TResult>.Default;
                            for (var index = 0; index < end; index++)
                            {
                                ref readonly var arrayItem = ref array[index + start];
                                if (defaultComparer.Equals(selector.Invoke(in arrayItem, index), item))
                                    return index;
                            }
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
                readonly int offset;
                readonly int end;
                int index;

                internal Enumerator(in ArraySegmentSelectAtRefEnumerable<TSource, TResult, TSelector> enumerable)
                {
                    source = enumerable.source.Array;
                    selector = enumerable.selector;
                    offset = enumerable.source.Offset;
                    index = -1;
                    end = index + enumerable.source.Count;
                }

                public readonly TResult Current
                    => selector.Invoke(in source![index + offset], index);
                readonly TResult IEnumerator<TResult>.Current
                    => selector.Invoke(in source![index + offset], index)!;
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => selector.Invoke(in source![index + offset], index);

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
            //public ArraySegmentSelectAtRefEnumerable<TSource, TResult2, SelectorAtSelectorCombination<TSelector, FunctionWrapper<TResult, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, TResult2> selector)
            //    => Select<TResult2, FunctionWrapper<TResult, TResult2>>(new FunctionWrapper<TResult, TResult2>(selector));

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public ArraySegmentSelectAtRefEnumerable<TSource, TResult2, SelectorAtSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>> Select<TResult2, TSelector2>(TSelector2 selector = default)
            //    where TSelector2 : struct, IFunction<TResult, TResult2>
            //    => source.SelectAt<TSource, TResult2, SelectorAtSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(new SelectorAtSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public ArraySegmentSelectAtRefEnumerable<TSource, TResult2, SelectorAtSelectorAtCombination<TSelector, FunctionWrapper<TResult, int, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, int, TResult2> selector)
            //    => SelectAt<TResult2, FunctionWrapper<TResult, int, TResult2>>(new FunctionWrapper<TResult, int, TResult2>(selector));

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public ArraySegmentSelectAtRefEnumerable<TSource, TResult2, SelectorAtSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>> SelectAt<TResult2, TSelector2>(TSelector2 selector = default)
            //    where TSelector2 : struct, IFunction<TResult, int, TResult2>
            //    => source.SelectAt<TSource, TResult2, SelectorAtSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(new SelectorAtSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public readonly ReadOnlyListExtensions.SelectManyEnumerable<ArraySegmentSelectAtRefEnumerable<TSource, TResult, TSelector>, TResult, TSubEnumerable, TSubEnumerator, TResult2, FunctionWrapper<TResult, TSubEnumerable>> SelectMany<TSubEnumerable, TSubEnumerator, TResult2>(Func<TResult, TSubEnumerable> selector)
            //    where TSubEnumerable : IValueEnumerable<TResult2, TSubEnumerator>
            //    where TSubEnumerator : struct, IEnumerator<TResult2>
            //    => this.SelectMany<ArraySegmentSelectAtRefEnumerable<TSource, TResult, TSelector>, TResult, TSubEnumerable, TSubEnumerator, TResult2>(selector);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public readonly ReadOnlyListExtensions.SelectManyEnumerable<ArraySegmentSelectAtRefEnumerable<TSource, TResult, TSelector>, TResult, TSubEnumerable, TSubEnumerator, TResult2, TSelector2> SelectMany<TSubEnumerable, TSubEnumerator, TResult2, TSelector2>(TSelector2 selector = default)
            //    where TSubEnumerable : IValueEnumerable<TResult2, TSubEnumerator>
            //    where TSubEnumerator : struct, IEnumerator<TResult2>
            //    where TSelector2 : struct, IFunction<TResult, TSubEnumerable>
            //    => this.SelectMany<ArraySegmentSelectAtRefEnumerable<TSource, TResult, TSelector>, TResult, TSubEnumerable, TSubEnumerator, TResult2, TSelector2>(selector);

            #endregion
            #region Element

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public Option<TResult> ElementAt(int index)
            //    => ((ReadOnlySpan<TSource>)source.AsSpan()).ElementAtAtRef<TSource, TResult, TSelector>(index, selector);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public Option<TResult> First()
            //    => ((ReadOnlySpan<TSource>)source.AsSpan()).FirstAtRef<TSource, TResult, TSelector>(selector);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public Option<TResult> Single()
            //    => ((ReadOnlySpan<TSource>)source.AsSpan()).SingleAtRef<TSource, TResult, TSelector>(selector);

            #endregion
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult[] ToArray()
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ToArrayAtRef<TSource, TResult, TSelector>(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public IMemoryOwner<TResult> ToArray(MemoryPool<TResult> pool)
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ToArrayAtRef(selector, pool);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TResult> ToList()
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ToListAtRef<TSource, TResult, TSelector>(selector);

            #endregion

            public bool SequenceEqual(IEnumerable<TResult> other, IEqualityComparer<TResult>? comparer = null)
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

                    if (!comparer.Equals(enumerator.Current!, otherEnumerator.Current))
                        return false;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource, TResult, TSelector>(this ArraySegmentSelectAtRefEnumerable<TSource, TResult, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, int, TResult>
            => source.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource, TSelector>(this ArraySegmentSelectAtRefEnumerable<TSource, int, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, int, int>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumAtRef<TSource, int, int, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource, TSelector>(this ArraySegmentSelectAtRefEnumerable<TSource, int?, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, int, int?>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumAtRef<TSource, int?, int, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TSelector>(this ArraySegmentSelectAtRefEnumerable<TSource, long, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, int, long>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumAtRef<TSource, long, long, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TSelector>(this ArraySegmentSelectAtRefEnumerable<TSource, long?, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, int, long?>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumAtRef<TSource, long?, long, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TSelector>(this ArraySegmentSelectAtRefEnumerable<TSource, float, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, int, float>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumAtRef<TSource, float, float, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TSelector>(this ArraySegmentSelectAtRefEnumerable<TSource, float?, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, int, float?>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumAtRef<TSource, float?, float, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TSelector>(this ArraySegmentSelectAtRefEnumerable<TSource, double, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, int, double>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumAtRef<TSource, double, double, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TSelector>(this ArraySegmentSelectAtRefEnumerable<TSource, double?, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, int, double?>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumAtRef<TSource, double?, double, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TSelector>(this ArraySegmentSelectAtRefEnumerable<TSource, decimal, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, int, decimal>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumAtRef<TSource, decimal, decimal, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TSelector>(this ArraySegmentSelectAtRefEnumerable<TSource, decimal?, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, int, decimal?>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumAtRef<TSource, decimal?, decimal, TSelector>(source.selector);
    }
}

