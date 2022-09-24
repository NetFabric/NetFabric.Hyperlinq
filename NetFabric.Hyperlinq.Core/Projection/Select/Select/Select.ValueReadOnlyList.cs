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
        public static SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, FunctionWrapper<TSource, TResult>> Select<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Func<TSource, TResult> selector)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => Select<TEnumerable, TEnumerator, TSource, TResult, FunctionWrapper<TSource, TResult>>(source, selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector> Select<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector = default)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
            => new(in source, selector);

        [StructLayout(LayoutKind.Auto)]
        public partial struct SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>
            : IValueReadOnlyList<TResult, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>.Enumerator>
            , IList<TResult>
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            internal TEnumerable source;
            internal TSelector selector;

            internal SelectEnumerable(in TEnumerable source, TSelector selector)
                => (this.source, this.selector) = (source, selector);

            public readonly int Count 
                => source.Count;

            public TResult this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    ThrowIfArgument.OutOfRange(index, Count, nameof(index));
                    return selector.Invoke(source[index]);
                }
            }
            TResult IList<TResult>.this[int index]
            {
                get => this[index];

                [ExcludeFromCodeCoverage]
                // ReSharper disable once ValueParameterNotUsed
                set => Throw.NotSupportedException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() 
                => new(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => GetEnumerator();
            readonly IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => GetEnumerator();

            bool ICollection<TResult>.IsReadOnly  
                => true;

            public readonly void CopyTo(Span<TResult> span)
            {
                if (span.Length < Count)
                    Throw.ArgumentException(Resource.DestinationNotLongEnough, nameof(span));

                ValueReadOnlyCollectionExtensions.Copy<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, span, selector);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly void CopyTo(TResult[] array, int arrayIndex)
                => CopyTo(array.AsSpan(arrayIndex));

            public readonly bool Contains(TResult item)
                => ValueReadOnlyCollectionExtensions.Contains<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, item, default, selector);

            public readonly int IndexOf(TResult item)
                => ValueReadOnlyCollectionExtensions.IndexOf<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, item, selector);

            [ExcludeFromCodeCoverage]
            readonly void ICollection<TResult>.Add(TResult item) 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            readonly void ICollection<TResult>.Clear() 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            readonly bool ICollection<TResult>.Remove(TResult item) 
                => Throw.NotSupportedException<bool>();

            [ExcludeFromCodeCoverage]
            readonly void IList<TResult>.Insert(int index, TResult item)
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            readonly void IList<TResult>.RemoveAt(int index)
                => Throw.NotSupportedException();

            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator
                : IEnumerator<TResult>
            {
#pragma warning disable IDE0044 // Add readonly modifier
                TEnumerator enumerator;
                TSelector selector;
#pragma warning restore IDE0044 // Add readonly modifier

                internal Enumerator(in SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    selector = enumerable.selector;
                }

                public TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector.Invoke(enumerator.Current);
                }
                object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => selector.Invoke(enumerator.Current);

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                    => enumerator.MoveNext();

                [ExcludeFromCodeCoverage]
                [DoesNotReturn]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

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
            public SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult2, SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>> Select<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, TResult2>
                => ValueReadOnlyListExtensions.Select<TEnumerable, TEnumerator, TSource, TResult2, SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(source, new SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult2, SelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>> SelectAt<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, int, TResult2>
                => ValueReadOnlyListExtensions.SelectAt<TEnumerable, TEnumerator, TSource, TResult2, SelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(source, new SelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));

            #endregion
            #region Element

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Option<TResult> ElementAt(int index)
                => source.ElementAt<TEnumerable, TSource, TResult, TSelector>(index, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Option<TResult> First()
                => source.First<TEnumerable, TSource, TResult, TSelector>(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Option<TResult> Single()
                => source.Single<TEnumerable, TSource, TResult, TSelector>(selector);
            
            #endregion
            #region Conversion
            
            public readonly SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector> AsValueEnumerable()
                => this;

            public readonly SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector> AsEnumerable()
                => this;
 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly TResult[] ToArray()
                => source.ToArray<TEnumerable, TEnumerator, TSource, TResult, TSelector>(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Lease<TResult> ToArray(ArrayPool<TResult> pool, bool clearOnDispose = default)
                => source.ToArray<TEnumerable, TEnumerator, TSource, TResult, TSelector>(pool, clearOnDispose, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly List<TResult> ToList()
                => source.ToList<TEnumerable, TEnumerator, TSource, TResult, TSelector>(selector);
           
            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TEnumerable, TEnumerator, TSource, TResult, TSelector, TPredicate>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector> source, TPredicate predicate = default)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
            where TPredicate : struct, IFunction<TResult, bool>
            => ValueReadOnlyCollectionExtensions.Count<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>.Enumerator, TResult, TPredicate>(source, predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CountAt<TEnumerable, TEnumerator, TSource, TResult, TSelector, TPredicate>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector> source, TPredicate predicate = default)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
            where TPredicate : struct, IFunction<TResult, int, bool>
            => ValueReadOnlyCollectionExtensions.CountAt<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>.Enumerator, TResult, TPredicate>(source, predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, int, TSelector> source)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int>
            => ValueReadOnlyCollectionExtensions.Sum<TEnumerable, TEnumerator, TSource, int, int, TSelector>(source.source, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, int?, TSelector> source)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int?>
            => ValueReadOnlyCollectionExtensions.Sum<TEnumerable, TEnumerator, TSource, int?, int, TSelector>(source.source, source.selector);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, nint, TSelector> source)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, nint>
            => ValueReadOnlyCollectionExtensions.Sum<TEnumerable, TEnumerator, TSource, nint, nint, TSelector>(source.source, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, nint?, TSelector> source)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, nint?>
            => ValueReadOnlyCollectionExtensions.Sum<TEnumerable, TEnumerator, TSource, nint?, nint, TSelector>(source.source, source.selector);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, nuint, TSelector> source)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, nuint>
            => ValueReadOnlyCollectionExtensions.Sum<TEnumerable, TEnumerator, TSource, nuint, nuint, TSelector>(source.source, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, nuint?, TSelector> source)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, nuint?>
            => ValueReadOnlyCollectionExtensions.Sum<TEnumerable, TEnumerator, TSource, nuint?, nuint, TSelector>(source.source, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, long, TSelector> source)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, long>
            => ValueReadOnlyCollectionExtensions.Sum<TEnumerable, TEnumerator, TSource, long, long, TSelector>(source.source, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, long?, TSelector> source)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, long?>
            => ValueReadOnlyCollectionExtensions.Sum<TEnumerable, TEnumerator, TSource, long?, long, TSelector>(source.source, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, float, TSelector> source)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, float>
            => ValueReadOnlyCollectionExtensions.Sum<TEnumerable, TEnumerator, TSource, float, float, TSelector>(source.source, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, float?, TSelector> source)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, float?>
            => ValueReadOnlyCollectionExtensions.Sum<TEnumerable, TEnumerator, TSource, float?, float, TSelector>(source.source, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, double, TSelector> source)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, double>
            => ValueReadOnlyCollectionExtensions.Sum<TEnumerable, TEnumerator, TSource, double, double, TSelector>(source.source, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, double?, TSelector> source)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, double?>
            => ValueReadOnlyCollectionExtensions.Sum<TEnumerable, TEnumerator, TSource, double?, double, TSelector>(source.source, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, decimal, TSelector> source)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, decimal>
            => ValueReadOnlyCollectionExtensions.Sum<TEnumerable, TEnumerator, TSource, decimal, decimal, TSelector>(source.source, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, decimal?, TSelector> source)
            where TEnumerable : struct, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, decimal?>
            => ValueReadOnlyCollectionExtensions.Sum<TEnumerable, TEnumerator, TSource, decimal?, decimal, TSelector>(source.source, source.selector);
    }
}
