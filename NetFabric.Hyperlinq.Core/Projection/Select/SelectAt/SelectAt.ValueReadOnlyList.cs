using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyListExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult, FunctionWrapper<TSource, int, TResult>> Select<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Func<TSource, int, TResult> selector)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => SelectAt<TEnumerable, TEnumerator, TSource, TResult, FunctionWrapper<TSource, int, TResult>>(source, selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector> SelectAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector = default)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
            => new(in source, selector);

        [StructLayout(LayoutKind.Auto)]
        public partial struct SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>
            : IValueReadOnlyList<TResult, SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>.Enumerator>
            , IList<TResult>
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            internal TEnumerable source;
            internal TSelector selector;

            internal SelectAtEnumerable(in TEnumerable source, TSelector selector)
                => (this.source, this.selector) = (source, selector);

            public int Count 
                => source.Count;

            public TResult this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    ThrowIfArgument.OutOfRange(index, Count, nameof(index));
                    return selector.Invoke(source[index], index);
                }
            }
            TResult IList<TResult>.this[int index]
            {
                get => this[index];

                [ExcludeFromCodeCoverage]
                readonly
                // ReSharper disable once ValueParameterNotUsed
                set => Throw.NotSupportedException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() 
                => new (in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => GetEnumerator();
            readonly IEnumerator IEnumerable.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => GetEnumerator();

            bool ICollection<TResult>.IsReadOnly  
                => true;

            public void CopyTo(Span<TResult> span) 
            {
                if (span.Length < Count)
                    Throw.ArgumentException(Resource.DestinationNotLongEnough, nameof(span));

                var end = Count;
                for (var index = 0; index < end; index++)
                {
                    var item = source[index];
                    span[index] = selector.Invoke(item, index);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void CopyTo(TResult[] array, int arrayIndex)
                => CopyTo(array.AsSpan(arrayIndex));

            public readonly bool Contains(TResult item)
                => ValueReadOnlyCollectionExtensions.ContainsAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, item, default, selector);

            public readonly int IndexOf(TResult item)
                => ValueReadOnlyCollectionExtensions.IndexOfAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, item, selector);

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
                : IEnumerator<TResult>
            {
#pragma warning disable IDE0044 // Add readonly modifier
                TEnumerator enumerator;
                TSelector selector;
#pragma warning restore IDE0044 // Add readonly modifier
                int index;

                internal Enumerator(in SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    selector = enumerable.selector;
                    index = -1;
                }

                public TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector.Invoke(enumerator.Current, index);
                }
                object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => selector.Invoke(enumerator.Current, index);

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    if (enumerator.MoveNext())
                    {
                        checked { index++; }
                        return true;
                    }
                    return false;
                }

                [ExcludeFromCodeCoverage]
                [DoesNotReturn]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                // ReSharper disable once MA0102
                public void Dispose() 
                    => enumerator.Dispose();
            }


            #region Partitioning
            
            #endregion
            #region Aggregation

            #endregion
            #region Quantifier

            #endregion
            #region Filtering

            #endregion
            #region Projection
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult2, SelectorAtSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>> Select<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, TResult2>
                => ValueReadOnlyListExtensions.SelectAt<TEnumerable, TEnumerator, TSource, TResult2, SelectorAtSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(source, new SelectorAtSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult2, SelectorAtSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>> SelectAt<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, int, TResult2>
                => ValueReadOnlyListExtensions.SelectAt<TEnumerable, TEnumerator, TSource, TResult2, SelectorAtSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(source, new SelectorAtSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));

            #endregion
            #region Element

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Option<TResult> ElementAt(int index)
                => source.ElementAtAt<TEnumerable, TSource, TResult, TSelector>(index, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Option<TResult> First()
                => source.FirstAt<TEnumerable, TSource, TResult, TSelector>(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Option<TResult> Single()
                => source.SingleAt<TEnumerable, TSource, TResult, TSelector>(selector);
            
            #endregion
            #region Conversion

            public readonly SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector> AsValueEnumerable()
                => this;

            public readonly SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector> AsEnumerable()
                => this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly TResult[] ToArray()
                => ValueReadOnlyCollectionExtensions.ToArrayAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Lease<TResult> ToArray(ArrayPool<TResult> pool, bool clearOnDispose = default)
                => ValueReadOnlyCollectionExtensions.ToArrayAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, pool, clearOnDispose, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly List<TResult> ToList()
                => ValueReadOnlyCollectionExtensions.ToListAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, selector);
            
            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TEnumerable, TEnumerator, TSource, TResult, TSelector, TPredicate>(this SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector> source, TPredicate predicate = default)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
            where TPredicate : struct, IFunction<TResult, bool>
            => ValueReadOnlyCollectionExtensions.Count<SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>, SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>.Enumerator, TResult, TPredicate>(source, predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CountAt<TEnumerable, TEnumerator, TSource, TResult, TSelector, TPredicate>(this SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector> source, TPredicate predicate = default)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
            where TPredicate : struct, IFunction<TResult, int, bool>
            => ValueReadOnlyCollectionExtensions.CountAt<SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>, SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>.Enumerator, TResult, TPredicate>(source, predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectAtEnumerable<TEnumerable, TEnumerator, TSource, int, TSelector> source)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, int>
            => ValueReadOnlyCollectionExtensions.SumAt<TEnumerable, TEnumerator, TSource, int, int, TSelector>(source.source, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectAtEnumerable<TEnumerable, TEnumerator, TSource, int?, TSelector> source)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, int?>
            => ValueReadOnlyCollectionExtensions.SumAt<TEnumerable, TEnumerator, TSource, int?, int, TSelector>(source.source, source.selector);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectAtEnumerable<TEnumerable, TEnumerator, TSource, nint, TSelector> source)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, nint>
            => ValueReadOnlyCollectionExtensions.SumAt<TEnumerable, TEnumerator, TSource, nint, nint, TSelector>(source.source, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectAtEnumerable<TEnumerable, TEnumerator, TSource, nint?, TSelector> source)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, nint?>
            => ValueReadOnlyCollectionExtensions.SumAt<TEnumerable, TEnumerator, TSource, nint?, nint, TSelector>(source.source, source.selector);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectAtEnumerable<TEnumerable, TEnumerator, TSource, nuint, TSelector> source)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, nuint>
            => ValueReadOnlyCollectionExtensions.SumAt<TEnumerable, TEnumerator, TSource, nuint, nuint, TSelector>(source.source, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectAtEnumerable<TEnumerable, TEnumerator, TSource, nuint?, TSelector> source)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, nuint?>
            => ValueReadOnlyCollectionExtensions.SumAt<TEnumerable, TEnumerator, TSource, nuint?, nuint, TSelector>(source.source, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectAtEnumerable<TEnumerable, TEnumerator, TSource, long, TSelector> source)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, long>
            => ValueReadOnlyCollectionExtensions.SumAt<TEnumerable, TEnumerator, TSource, long, long, TSelector>(source.source, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectAtEnumerable<TEnumerable, TEnumerator, TSource, long?, TSelector> source)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, long?>
            => ValueReadOnlyCollectionExtensions.SumAt<TEnumerable, TEnumerator, TSource, long?, long, TSelector>(source.source, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectAtEnumerable<TEnumerable, TEnumerator, TSource, float, TSelector> source)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, float>
            => ValueReadOnlyCollectionExtensions.SumAt<TEnumerable, TEnumerator, TSource, float, float, TSelector>(source.source, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectAtEnumerable<TEnumerable, TEnumerator, TSource, float?, TSelector> source)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, float?>
            => ValueReadOnlyCollectionExtensions.SumAt<TEnumerable, TEnumerator, TSource, float?, float, TSelector>(source.source, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectAtEnumerable<TEnumerable, TEnumerator, TSource, double, TSelector> source)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, double>
            => ValueReadOnlyCollectionExtensions.SumAt<TEnumerable, TEnumerator, TSource, double, double, TSelector>(source.source, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectAtEnumerable<TEnumerable, TEnumerator, TSource, double?, TSelector> source)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, double?>
            => ValueReadOnlyCollectionExtensions.SumAt<TEnumerable, TEnumerator, TSource, double?, double, TSelector>(source.source, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectAtEnumerable<TEnumerable, TEnumerator, TSource, decimal, TSelector> source)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, decimal>
            => ValueReadOnlyCollectionExtensions.SumAt<TEnumerable, TEnumerator, TSource, decimal, decimal, TSelector>(source.source, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectAtEnumerable<TEnumerable, TEnumerator, TSource, decimal?, TSelector> source)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, decimal?>
            => ValueReadOnlyCollectionExtensions.SumAt<TEnumerable, TEnumerator, TSource, decimal?, decimal, TSelector>(source.source, source.selector);
    }
}
