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
        static ArraySegmentSelectEnumerable<TSource, TResult, FunctionWrapper<TSource, TResult>> Select<TSource, TResult>(this in ArraySegment<TSource> source, Func<TSource, TResult> selector)
            => source.Select<TSource, TResult, FunctionWrapper<TSource, TResult>>(new FunctionWrapper<TSource, TResult>(selector));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ArraySegmentSelectEnumerable<TSource, TResult, TSelector> Select<TSource, TResult, TSelector>(this in ArraySegment<TSource> source, TSelector selector = default)
            where TSelector : struct, IFunction<TSource, TResult>
            => new(in source, selector);

        [GeneratorMapping("TSource", "TResult")]
        [StructLayout(LayoutKind.Auto)]
        public partial struct ArraySegmentSelectEnumerable<TSource, TResult, TSelector>
            : IValueReadOnlyList<TResult, ArraySegmentSelectEnumerable<TSource, TResult, TSelector>.Enumerator>
            , IList<TResult>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            internal readonly ArraySegment<TSource> source;
            internal TSelector selector;

            internal ArraySegmentSelectEnumerable(in ArraySegment<TSource> source, TSelector selector)
                => (this.source, this.selector) = (source, selector);

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

            public readonly SelectEnumerator<TSource, TResult, TSelector> GetEnumerator()
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

            public void CopyTo(Span<TResult> span)
            {
                if (Count is 0)
                    return;
                
                if (span.Length < Count)
                    Throw.ArgumentException(Resource.DestinationNotLongEnough, nameof(span)); 
                
                Copy<TSource, TResult, TSelector>(source.AsSpan(), span, selector);
            }

            void ICollection<TResult>.CopyTo(TResult[] array, int arrayIndex)
                => CopyTo(array.AsSpan(arrayIndex));

            void ICollection<TResult>.Add(TResult item)
                => Throw.NotSupportedException();
            void ICollection<TResult>.Clear()
                => Throw.NotSupportedException();
            public bool Contains(TResult item)
                => ((ReadOnlySpan<TSource>)source.AsSpan()).Contains(item, default, selector);
            bool ICollection<TResult>.Remove(TResult item)
                => Throw.NotSupportedException<bool>();

            int IList<TResult>.IndexOf(TResult item)
                => ArrayExtensions.IndexOf<TSource, TResult, TSelector>(source, item, selector);
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

                internal Enumerator(in ArraySegmentSelectEnumerable<TSource, TResult, TSelector> enumerable)
                {
                    source = enumerable.source.Array;
                    selector = enumerable.selector;
                    index = enumerable.source.Offset - 1;
                    end = index + enumerable.source.Count;
                }

                public TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector.Invoke(source![index]);
                }
                object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => selector.Invoke(source![index]);

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                    => ++index <= end;

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
            public readonly ValueEnumerableExtensions.SelectManyEnumerable<ArraySegmentSelectEnumerable<TSource, TResult, TSelector>, Enumerator, TResult, TSubEnumerable, TSubEnumerator, TResult2, FunctionWrapper<TResult, TSubEnumerable>> SelectMany<TSubEnumerable, TSubEnumerator, TResult2>(Func<TResult, TSubEnumerable> selector)
                where TSubEnumerable : IValueEnumerable<TResult2, TSubEnumerator>
                where TSubEnumerator : struct, IEnumerator<TResult2>
                => this.SelectMany<ArraySegmentSelectEnumerable<TSource, TResult, TSelector>, Enumerator, TResult, TSubEnumerable, TSubEnumerator, TResult2>(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.SelectManyEnumerable<ArraySegmentSelectEnumerable<TSource, TResult, TSelector>, Enumerator, TResult, TSubEnumerable, TSubEnumerator, TResult2, TSelector2> SelectMany<TSubEnumerable, TSubEnumerator, TResult2, TSelector2>(TSelector2 selector = default)
                where TSubEnumerable : IValueEnumerable<TResult2, TSubEnumerator>
                where TSubEnumerator : struct, IEnumerator<TResult2>
                where TSelector2 : struct, IFunction<TResult, TSubEnumerable>
                => this.SelectMany<ArraySegmentSelectEnumerable<TSource, TResult, TSelector>, Enumerator, TResult, TSubEnumerable, TSubEnumerator, TResult2, TSelector2>(selector);

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
            public ValueMemoryOwner<TResult> ToArray(ArrayPool<TResult> pool, bool clearOnDispose = default)
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ToArray(pool, clearOnDispose, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TResult> ToList()
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ToList<TSource, TResult, TSelector>(selector);
            
            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource, TResult, TSelector>(this ArraySegmentSelectEnumerable<TSource, TResult, TSelector> source)
            where TSelector : struct, IFunction<TSource, TResult>
            => source.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource, TSelector>(this ArraySegmentSelectEnumerable<TSource, int, TSelector> source)
            where TSelector : struct, IFunction<TSource, int>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).Sum<TSource, int, int, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource, TSelector>(this ArraySegmentSelectEnumerable<TSource, int?, TSelector> source)
            where TSelector : struct, IFunction<TSource, int?>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).Sum<TSource, int?, int, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TSource, TSelector>(this ArraySegmentSelectEnumerable<TSource, nint, TSelector> source)
            where TSelector : struct, IFunction<TSource, nint>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).Sum<TSource, nint, nint, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TSource, TSelector>(this ArraySegmentSelectEnumerable<TSource, nint?, TSelector> source)
            where TSelector : struct, IFunction<TSource, nint?>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).Sum<TSource, nint?, nint, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TSource, TSelector>(this ArraySegmentSelectEnumerable<TSource, nuint, TSelector> source)
            where TSelector : struct, IFunction<TSource, nuint>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).Sum<TSource, nuint, nuint, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TSource, TSelector>(this ArraySegmentSelectEnumerable<TSource, nuint?, TSelector> source)
            where TSelector : struct, IFunction<TSource, nuint?>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).Sum<TSource, nuint?, nuint, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TSelector>(this ArraySegmentSelectEnumerable<TSource, long, TSelector> source)
            where TSelector : struct, IFunction<TSource, long>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).Sum<TSource, long, long, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TSelector>(this ArraySegmentSelectEnumerable<TSource, long?, TSelector> source)
            where TSelector : struct, IFunction<TSource, long?>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).Sum<TSource, long?, long, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TSelector>(this ArraySegmentSelectEnumerable<TSource, float, TSelector> source)
            where TSelector : struct, IFunction<TSource, float>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).Sum<TSource, float, float, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TSelector>(this ArraySegmentSelectEnumerable<TSource, float?, TSelector> source)
            where TSelector : struct, IFunction<TSource, float?>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).Sum<TSource, float?, float, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TSelector>(this ArraySegmentSelectEnumerable<TSource, double, TSelector> source)
            where TSelector : struct, IFunction<TSource, double>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).Sum<TSource, double, double, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TSelector>(this ArraySegmentSelectEnumerable<TSource, double?, TSelector> source)
            where TSelector : struct, IFunction<TSource, double?>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).Sum<TSource, double?, double, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TSelector>(this ArraySegmentSelectEnumerable<TSource, decimal, TSelector> source)
            where TSelector : struct, IFunction<TSource, decimal>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).Sum<TSource, decimal, decimal, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TSelector>(this ArraySegmentSelectEnumerable<TSource, decimal?, TSelector> source)
            where TSelector : struct, IFunction<TSource, decimal?>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).Sum<TSource, decimal?, decimal, TSelector>(source.selector);

    }
}

