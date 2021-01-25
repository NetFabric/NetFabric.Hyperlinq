using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [GeneratorMapping("TSelector", "NetFabric.Hyperlinq.FunctionWrapper<TSource, int, TResult>")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanSelectAtEnumerable<TSource, TResult, FunctionWrapper<TSource, int, TResult>> Select<TSource, TResult>(this ReadOnlySpan<TSource> source, Func<TSource, int, TResult> selector)
            => source.SelectAt<TSource, TResult, FunctionWrapper<TSource, int, TResult>>(new FunctionWrapper<TSource, int, TResult>(selector));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanSelectAtEnumerable<TSource, TResult, TSelector> SelectAt<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector = default)
            where TSelector : struct, IFunction<TSource, int, TResult>
            => new(source, selector);

        [GeneratorMapping("TSource", "TResult")]
        [StructLayout(LayoutKind.Auto)]
        public ref struct SpanSelectAtEnumerable<TSource, TResult, TSelector>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            readonly ReadOnlySpan<TSource> source;
            TSelector selector;

            internal SpanSelectAtEnumerable(ReadOnlySpan<TSource> source, TSelector selector)
            {
                this.source = source;
                this.selector = selector;
            }

            
            public readonly Enumerator GetEnumerator() 
                => new Enumerator(in this);

            public readonly int Count 
                => source.Length;

            public readonly TResult this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => selector.Invoke(source[index], index);
            }

            [StructLayout(LayoutKind.Sequential)]
            public ref struct Enumerator
            {
                int index;
                readonly int end;
                readonly ReadOnlySpan<TSource> source;
                TSelector selector;

                internal Enumerator(in SpanSelectAtEnumerable<TSource, TResult, TSelector> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    index = -1;
                    end = index + source.Length;
                }

                public readonly TResult Current 
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector.Invoke(source[index], index);
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++index <= end;
            }

            #region Aggregation
            
            #endregion
            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.Length is not 0;
            
            #endregion
            #region Filtering
            
            #endregion
            #region Projection
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SpanSelectAtEnumerable<TSource, TResult2, SelectorAtSelectorCombination<TSelector, FunctionWrapper<TResult, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, TResult2> selector)
                => Select<TResult2, FunctionWrapper<TResult, TResult2>>(new FunctionWrapper<TResult, TResult2>(selector));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SpanSelectAtEnumerable<TSource, TResult2, SelectorAtSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>> Select<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, TResult2>
                => source.SelectAt<TSource, TResult2, SelectorAtSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(new SelectorAtSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SpanSelectAtEnumerable<TSource, TResult2, SelectorAtSelectorAtCombination<TSelector, FunctionWrapper<TResult, int, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, int, TResult2> selector)
                => SelectAt<TResult2, FunctionWrapper<TResult, int, TResult2>>(new FunctionWrapper<TResult, int, TResult2>(selector));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SpanSelectAtEnumerable<TSource, TResult2, SelectorAtSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>> SelectAt<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, int, TResult2>
                => source.SelectAt<TSource, TResult2, SelectorAtSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(new SelectorAtSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));
            
            #endregion
            #region Element

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> ElementAt(int index)
                => source.ElementAtAt<TSource, TResult, TSelector>(index, selector);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> First()
                => source.FirstAt<TSource, TResult, TSelector>(selector);


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> Single()
                => source.SingleAt<TSource, TResult, TSelector>(selector);
            
            #endregion
            #region Conversion

            public TResult[] ToArray()
                => source.ToArrayAt<TSource, TResult, TSelector>(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public IMemoryOwner<TResult> ToArray(MemoryPool<TResult> pool)
                => source.ToArrayAt(selector, pool);

            public List<TResult> ToList()
                => source.ToListAt<TSource, TResult, TSelector>(selector);
            
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
        public static int Count<TSource, TResult, TSelector>(this SpanSelectAtEnumerable<TSource, TResult, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, TResult>
            => source.Count;
    }
}

