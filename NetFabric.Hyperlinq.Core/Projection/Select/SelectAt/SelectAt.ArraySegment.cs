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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ArraySegmentSelectAtEnumerable<TSource, TResult, FunctionWrapper<TSource, int, TResult>> Select<TSource, TResult>(this in ArraySegment<TSource> source, Func<TSource, int, TResult> selector)
            => source.SelectAt<TSource, TResult, FunctionWrapper<TSource, int, TResult>>(new FunctionWrapper<TSource, int, TResult>(selector));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ArraySegmentSelectAtEnumerable<TSource, TResult, TSelector> SelectAt<TSource, TResult, TSelector>(this in ArraySegment<TSource> source, TSelector selector = default)
            where TSelector : struct, IFunction<TSource, int, TResult>
            => new(in source, selector);

        [StructLayout(LayoutKind.Auto)]
        public partial struct ArraySegmentSelectAtEnumerable<TSource, TResult, TSelector>
            : IValueReadOnlyList<TResult, ArraySegmentSelectAtEnumerable<TSource, TResult, TSelector>.Enumerator>
            , IList<TResult>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            internal readonly ArraySegment<TSource> source;
            internal TSelector selector;

            internal ArraySegmentSelectAtEnumerable(in ArraySegment<TSource> source, TSelector selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public readonly int Count
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source.Count;
            }

            public TResult this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    ThrowIfArgument.OutOfRange(index, Count, nameof(index));
                    return selector.Invoke(source.Array![index + source.Offset], index);
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
            public readonly SelectAtEnumerator<TSource, TResult, TSelector> GetEnumerator()
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
                => CopyAt<TSource, TResult, TSelector>(source.AsSpan(), array.AsSpan(arrayIndex), selector);
            void ICollection<TResult>.Add(TResult item)
                => Throw.NotSupportedException();
            void ICollection<TResult>.Clear()
                => Throw.NotSupportedException();
            public bool Contains(TResult item)
                => source.AsReadOnlySpan().ContainsAt(item, default, selector);
            bool ICollection<TResult>.Remove(TResult item)
                => Throw.NotSupportedException<bool>();
            int IList<TResult>.IndexOf(TResult item)
                => IndexOfAt<TSource, TResult, TSelector>(source, item, selector);
            
            void IList<TResult>.Insert(int index, TResult item)
                => Throw.NotSupportedException();
            void IList<TResult>.RemoveAt(int index)
                => Throw.NotSupportedException();

            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator
                : IEnumerator<TResult>
            {
                readonly TSource[]? source;
#pragma warning disable IDE0044 // Add readonly modifier
                TSelector selector;
#pragma warning restore IDE0044 // Add readonly modifier
                readonly int offset;
                readonly int end;
                int index;

                internal Enumerator(in ArraySegmentSelectAtEnumerable<TSource, TResult, TSelector> enumerable)
                {
                    source = enumerable.source.Array;
                    selector = enumerable.selector;
                    offset = enumerable.source.Offset;
                    index = -1;
                    end = index + enumerable.source.Count;
                }

                public TResult Current
                    => selector.Invoke(source![index + offset], index);
                object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => selector.Invoke(source![index + offset], index);

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    if (index <= end)
                    {
                        index++;
                        return index <= end;
                    }
                    return false;
                }
                
                [ExcludeFromCodeCoverage]
                [DoesNotReturn]
                public readonly void Reset()
                    => Throw.NotSupportedException();

                public readonly void Dispose() { }
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
            public ArraySegmentSelectAtEnumerable<TSource, TResult2, SelectorAtSelectorCombination<TSelector, FunctionWrapper<TResult, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, TResult2> selector)
                => Select<TResult2, FunctionWrapper<TResult, TResult2>>(new FunctionWrapper<TResult, TResult2>(selector));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentSelectAtEnumerable<TSource, TResult2, SelectorAtSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>> Select<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, TResult2>
                => source.SelectAt<TSource, TResult2, SelectorAtSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(new SelectorAtSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentSelectAtEnumerable<TSource, TResult2, SelectorAtSelectorAtCombination<TSelector, FunctionWrapper<TResult, int, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, int, TResult2> selector)
                => SelectAt<TResult2, FunctionWrapper<TResult, int, TResult2>>(new FunctionWrapper<TResult, int, TResult2>(selector));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentSelectAtEnumerable<TSource, TResult2, SelectorAtSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>> SelectAt<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, int, TResult2>
                => source.SelectAt<TSource, TResult2, SelectorAtSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(new SelectorAtSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));

            #endregion
            #region Element

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> ElementAt(int index)
                => source.AsReadOnlySpan().ElementAtAt<TSource, TResult, TSelector>(index, selector);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> First()
                => source.AsReadOnlySpan().FirstAt<TSource, TResult, TSelector>(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> Single()
                => source.AsReadOnlySpan().SingleAt<TSource, TResult, TSelector>(selector);
            
            #endregion
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult[] ToArray()
                => source.AsReadOnlySpan().ToArrayAt<TSource, TResult, TSelector>(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Lease<TResult> ToArray(ArrayPool<TResult> pool, bool clearOnDispose = default)
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ToArrayAt(pool, clearOnDispose, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TResult> ToList()
                => source.AsReadOnlySpan().ToListAt<TSource, TResult, TSelector>(selector);
            
            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource, TResult, TSelector, TPredicate>(this ArraySegmentSelectAtEnumerable<TSource, TResult, TSelector> source, TPredicate predicate = default)
            where TSelector : struct, IFunction<TSource, int, TResult>
            where TPredicate : struct, IFunction<TResult, bool>
            => ValueReadOnlyCollectionExtensions.Count<ArraySegmentSelectAtEnumerable<TSource, TResult, TSelector>, ArraySegmentSelectAtEnumerable<TSource, TResult, TSelector>.Enumerator, TResult, TPredicate>(source, predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CountAt<TSource, TResult, TSelector, TPredicate>(this ArraySegmentSelectAtEnumerable<TSource, TResult, TSelector> source, TPredicate predicate = default)
            where TSelector : struct, IFunction<TSource, int, TResult>
            where TPredicate : struct, IFunction<TResult, int, bool>
            => ValueReadOnlyCollectionExtensions.CountAt<ArraySegmentSelectAtEnumerable<TSource, TResult, TSelector>, ArraySegmentSelectAtEnumerable<TSource, TResult, TSelector>.Enumerator, TResult, TPredicate>(source, predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource, TSelector>(this ArraySegmentSelectAtEnumerable<TSource, int, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, int>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumAt<TSource, int, int, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource, TSelector>(this ArraySegmentSelectAtEnumerable<TSource, int?, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, int?>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumAt<TSource, int?, int, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TSource, TSelector>(this ArraySegmentSelectAtEnumerable<TSource, nint, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, nint>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumAt<TSource, nint, nint, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TSource, TSelector>(this ArraySegmentSelectAtEnumerable<TSource, nint?, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, nint?>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumAt<TSource, nint?, nint, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TSource, TSelector>(this ArraySegmentSelectAtEnumerable<TSource, nuint, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, nuint>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumAt<TSource, nuint, nuint, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TSource, TSelector>(this ArraySegmentSelectAtEnumerable<TSource, nuint?, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, nuint?>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumAt<TSource, nuint?, nuint, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TSelector>(this ArraySegmentSelectAtEnumerable<TSource, long, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, long>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumAt<TSource, long, long, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TSelector>(this ArraySegmentSelectAtEnumerable<TSource, long?, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, long?>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumAt<TSource, long?, long, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TSelector>(this ArraySegmentSelectAtEnumerable<TSource, float, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, float>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumAt<TSource, float, float, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TSelector>(this ArraySegmentSelectAtEnumerable<TSource, float?, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, float?>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumAt<TSource, float?, float, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TSelector>(this ArraySegmentSelectAtEnumerable<TSource, double, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, double>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumAt<TSource, double, double, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TSelector>(this ArraySegmentSelectAtEnumerable<TSource, double?, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, double?>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumAt<TSource, double?, double, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TSelector>(this ArraySegmentSelectAtEnumerable<TSource, decimal, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, decimal>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumAt<TSource, decimal, decimal, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TSelector>(this ArraySegmentSelectAtEnumerable<TSource, decimal?, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, decimal?>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumAt<TSource, decimal?, decimal, TSelector>(source.selector);
    }
}

