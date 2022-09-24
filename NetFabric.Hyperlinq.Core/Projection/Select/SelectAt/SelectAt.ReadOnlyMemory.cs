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
        static MemorySelectAtEnumerable<TSource, TResult, FunctionWrapper<TSource, int, TResult>> Select<TSource, TResult>(this ReadOnlyMemory<TSource> source, Func<TSource, int, TResult> selector)
            => source.SelectAt<TSource, TResult, FunctionWrapper<TSource, int, TResult>>(new FunctionWrapper<TSource, int, TResult>(selector));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static MemorySelectAtEnumerable<TSource, TResult, TSelector> SelectAt<TSource, TResult, TSelector>(this ReadOnlyMemory<TSource> source, TSelector selector = default)
            where TSelector : struct, IFunction<TSource, int, TResult>
            => new(source, selector);

        [StructLayout(LayoutKind.Auto)]
        public partial struct MemorySelectAtEnumerable<TSource, TResult, TSelector>
            : IValueReadOnlyList<TResult, MemorySelectAtEnumerable<TSource, TResult, TSelector>.Enumerator>
            , IList<TResult>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            internal readonly ReadOnlyMemory<TSource> source;
            internal TSelector selector;

            internal MemorySelectAtEnumerable(ReadOnlyMemory<TSource> source, TSelector selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public readonly int Count 
                => source.Length;

            public TResult this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => selector.Invoke(source.Span[index], index);
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

            public readonly SelectAtEnumerator<TSource, TResult, TSelector> GetEnumerator() 
                => new(source.Span, selector);
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

            void ICollection<TResult>.CopyTo(TResult[] array, int arrayAt) 
            {
                var span = source.Span;
                for (var index = 0; index < span.Length; index++)
                    array[index + arrayAt] = selector.Invoke(span[index], index);
            }

            readonly void ICollection<TResult>.Add(TResult item)
                => Throw.NotSupportedException();
            readonly void ICollection<TResult>.Clear() 
                => Throw.NotSupportedException();
            public readonly bool Contains(TResult item)
                => source.Span.ContainsAt(item, default, selector);
            readonly bool ICollection<TResult>.Remove(TResult item) 
                => Throw.NotSupportedException<bool>();
            readonly int IList<TResult>.IndexOf(TResult item)
                => IndexOfAt(source.Span, item, selector);
            readonly void IList<TResult>.Insert(int index, TResult item)
                => Throw.NotSupportedException();
            readonly void IList<TResult>.RemoveAt(int index)
                => Throw.NotSupportedException();

            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator
                : IEnumerator<TResult>
            {
                readonly ReadOnlyMemory<TSource> source;
#pragma warning disable IDE0044 // Add readonly modifier
                TSelector selector;
#pragma warning restore IDE0044 // Add readonly modifier
                int index;

                internal Enumerator(in MemorySelectAtEnumerable<TSource, TResult, TSelector> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    index = -1;
                }
 
                public readonly TResult Current 
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector.Invoke(source.Span[index], index);
                }
                object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => selector.Invoke(source.Span[index], index);

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++index < source.Length;

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
                => source.Length is not 0;
            
            #endregion
            #region Filtering
            
            #endregion
            #region Projection
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public MemorySelectAtEnumerable<TSource, TResult2, SelectorAtSelectorCombination<TSelector, FunctionWrapper<TResult, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, TResult2> selector)
                => Select<TResult2, FunctionWrapper<TResult, TResult2>>(new FunctionWrapper<TResult, TResult2>(selector));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public MemorySelectAtEnumerable<TSource, TResult2, SelectorAtSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>> Select<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, TResult2>
                => source.SelectAt<TSource, TResult2, SelectorAtSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(new SelectorAtSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public MemorySelectAtEnumerable<TSource, TResult2, SelectorAtSelectorAtCombination<TSelector, FunctionWrapper<TResult, int, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, int, TResult2> selector)
                => SelectAt<TResult2, FunctionWrapper<TResult, int, TResult2>>(new FunctionWrapper<TResult, int, TResult2>(selector));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public MemorySelectAtEnumerable<TSource, TResult2, SelectorAtSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>> SelectAt<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, int, TResult2>
                => source.SelectAt<TSource, TResult2, SelectorAtSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(new SelectorAtSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));

            #endregion
            #region Element

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> ElementAt(int index)
                => source.Span.ElementAtAt<TSource, TResult, TSelector>(index, selector);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> First()
                => source.Span.FirstAt<TSource, TResult, TSelector>(selector);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> Single()
                => source.Span.SingleAt<TSource, TResult, TSelector>(selector);
            
            #endregion
            #region Conversion

            public TResult[] ToArray()
                => source.Span.ToArrayAt<TSource, TResult, TSelector>(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Lease<TResult> ToArray(ArrayPool<TResult> pool, bool clearOnDispose = default)
                => source.Span.ToArrayAt(pool, clearOnDispose, selector);

            public List<TResult> ToList()
                => source.Span.ToListAt<TSource, TResult, TSelector>(selector);
            
            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource, TResult, TSelector, TPredicate>(this MemorySelectAtEnumerable<TSource, TResult, TSelector> source, TPredicate predicate = default)
            where TSelector : struct, IFunction<TSource, int, TResult>
            where TPredicate : struct, IFunction<TResult, bool>
            => source.Count(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CountAt<TSource, TResult, TSelector, TPredicate>(this MemorySelectAtEnumerable<TSource, TResult, TSelector> source, TPredicate predicate = default)
            where TSelector : struct, IFunction<TSource, int, TResult>
            where TPredicate : struct, IFunction<TResult, int, bool>
            => source.CountAt(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource, TSelector>(this MemorySelectAtEnumerable<TSource, int, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, int>
            => source.source.Span.SumAt<TSource, int, int, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource, TSelector>(this MemorySelectAtEnumerable<TSource, int?, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, int?>
            => source.source.Span.SumAt<TSource, int?, int, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TSource, TSelector>(this MemorySelectAtEnumerable<TSource, nint, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, nint>
            => source.source.Span.SumAt<TSource, nint, nint, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TSource, TSelector>(this MemorySelectAtEnumerable<TSource, nint?, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, nint?>
            => source.source.Span.SumAt<TSource, nint?, nint, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TSource, TSelector>(this MemorySelectAtEnumerable<TSource, nuint, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, nuint>
            => source.source.Span.SumAt<TSource, nuint, nuint, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TSource, TSelector>(this MemorySelectAtEnumerable<TSource, nuint?, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, nuint?>
            => source.source.Span.SumAt<TSource, nuint?, nuint, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TSelector>(this MemorySelectAtEnumerable<TSource, long, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, long>
            => source.source.Span.SumAt<TSource, long, long, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TSelector>(this MemorySelectAtEnumerable<TSource, long?, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, long?>
            => source.source.Span.SumAt<TSource, long?, long, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TSelector>(this MemorySelectAtEnumerable<TSource, float, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, float>
            => source.source.Span.SumAt<TSource, float, float, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TSelector>(this MemorySelectAtEnumerable<TSource, float?, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, float?>
            => source.source.Span.SumAt<TSource, float?, float, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TSelector>(this MemorySelectAtEnumerable<TSource, double, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, double>
            => source.source.Span.SumAt<TSource, double, double, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TSelector>(this MemorySelectAtEnumerable<TSource, double?, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, double?>
            => source.source.Span.SumAt<TSource, double?, double, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TSelector>(this MemorySelectAtEnumerable<TSource, decimal, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, decimal>
            => source.source.Span.SumAt<TSource, decimal, decimal, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TSelector>(this MemorySelectAtEnumerable<TSource, decimal?, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, decimal?>
            => source.source.Span.SumAt<TSource, decimal?, decimal, TSelector>(source.selector);
    }
}

