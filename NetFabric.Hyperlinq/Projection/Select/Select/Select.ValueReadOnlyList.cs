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

        [GeneratorIgnore(false)]
        [GeneratorMapping("TSelector", "NetFabric.Hyperlinq.FunctionWrapper<TSource, TResult>")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static SelectEnumerable<TList, TSource, TResult, FunctionWrapper<TSource, TResult>> Select<TList, TSource, TResult>(this TList source, Func<TSource, TResult> selector)
            where TList : struct, IReadOnlyList<TSource>
            => source.Select(selector, 0, source.Count);

        [GeneratorMapping("TSelector", "NetFabric.Hyperlinq.FunctionWrapper<TSource, TResult>")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static SelectEnumerable<TList, TSource, TResult, FunctionWrapper<TSource, TResult>> Select<TList, TSource, TResult>(this TList source, Func<TSource, TResult> selector, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            => source.Select<TList, TSource, TResult, FunctionWrapper<TSource, TResult>>(new FunctionWrapper<TSource, TResult>(selector), offset, count);

        [GeneratorIgnore(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static SelectEnumerable<TList, TSource, TResult, TSelector> Select<TList, TSource, TResult, TSelector>(this TList source, TSelector selector = default)
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
            => source.Select<TList, TSource, TResult, TSelector>(selector, 0, source.Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static SelectEnumerable<TList, TSource, TResult, TSelector> Select<TList, TSource, TResult, TSelector>(this TList source, TSelector selector, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
            => new(in source, selector, offset, count);

        [GeneratorMapping("TSource", "TResult")]
        [StructLayout(LayoutKind.Auto)]
        public partial struct SelectEnumerable<TList, TSource, TResult, TSelector>
            : IValueReadOnlyList<TResult, SelectEnumerable<TList, TSource, TResult, TSelector>.DisposableEnumerator>
            , IList<TResult>
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            internal int offset;
            internal TList source;
            internal TSelector selector;

            internal SelectEnumerable(in TList source, TSelector selector, int offset, int count)
                => (this.source, this.offset, Count, this.selector) = (source, offset, count, selector);

            public readonly int Count { get; } 

            public TResult this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    if (index < 0 || index >= Count) Throw.IndexOutOfRangeException();

                    return selector.Invoke(source[index + offset]);
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
                => new(in this);
            readonly DisposableEnumerator IValueEnumerable<TResult, DisposableEnumerator>.GetEnumerator() 
                => new(in this);
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

                Copy<TList, TSource, TResult, TSelector>(source, offset, span, Count, selector);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void CopyTo(TResult[] array, int arrayIndex)
                => CopyTo(array.AsSpan().Slice(arrayIndex));

            public bool Contains(TResult item)
                => source.Contains<TList, TSource, TResult, TSelector>(item, default, selector, offset, Count);

            public int IndexOf(TResult item)
                => IndexOf<TList, TSource, TResult, TSelector>(source, item, selector, offset, Count);

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
                readonly int end;
                int index;

                internal Enumerator(in SelectEnumerable<TList, TSource, TResult, TSelector> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    index = enumerable.offset - 1;
                    end = index + enumerable.Count;
                }

                public TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector.Invoke(source[index]);
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
                readonly int end;
                int index;

                internal DisposableEnumerator(in SelectEnumerable<TList, TSource, TResult, TSelector> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    index = enumerable.offset - 1;
                    end = index + enumerable.Count;
                }

                public TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector.Invoke(source[index]);
                }
                TResult IEnumerator<TResult>.Current 
                    => selector.Invoke(source[index]);
                object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => selector.Invoke(source[index]);

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
            public SelectEnumerable<TList, TSource, TResult, TSelector> Skip(int count)
            {
                var (skipCount, takeCount) = Utils.Skip(Count, count);
                return new SelectEnumerable<TList, TSource, TResult, TSelector>(source, selector, offset + skipCount, takeCount);
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectEnumerable<TList, TSource, TResult, TSelector> Take(int count)
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
            public SelectEnumerable<TList, TSource, TResult2, SelectorSelectorCombination<TSelector, FunctionWrapper<TResult, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, TResult2> selector)
                => Select<TResult2, FunctionWrapper<TResult, TResult2>>(new FunctionWrapper<TResult, TResult2>(selector));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectEnumerable<TList, TSource, TResult2, SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>> Select<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, TResult2>
                => source.Select<TList, TSource, TResult2, SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(new SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector), offset, Count);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectAtEnumerable<TList, TSource, TResult2, SelectorSelectorAtCombination<TSelector, FunctionWrapper<TResult, int, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, int, TResult2> selector)
                => SelectAt<TResult2, FunctionWrapper<TResult, int, TResult2>>(new FunctionWrapper<TResult, int, TResult2>(selector));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectAtEnumerable<TList, TSource, TResult2, SelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>> SelectAt<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, int, TResult2>
                => source.SelectAt<TList, TSource, TResult2, SelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(new SelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector), offset, Count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly SelectManyEnumerable<SelectEnumerable<TList, TSource, TResult, TSelector>, TResult, TSubEnumerable, TSubEnumerator, TResult2, FunctionWrapper<TResult, TSubEnumerable>> SelectMany<TSubEnumerable, TSubEnumerator, TResult2>(Func<TResult, TSubEnumerable> selector)
                where TSubEnumerable : IValueEnumerable<TResult2, TSubEnumerator>
                where TSubEnumerator : struct, IEnumerator<TResult2>
                => this.SelectMany<SelectEnumerable<TList, TSource, TResult, TSelector>, TResult, TSubEnumerable, TSubEnumerator, TResult2>(selector, offset, Count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly SelectManyEnumerable<SelectEnumerable<TList, TSource, TResult, TSelector>, TResult, TSubEnumerable, TSubEnumerator, TResult2, TSelector2> SelectMany<TSubEnumerable, TSubEnumerator, TResult2, TSelector2>(TSelector2 selector = default)
                where TSubEnumerable : IValueEnumerable<TResult2, TSubEnumerator>
                where TSubEnumerator : struct, IEnumerator<TResult2>
                where TSelector2 : struct, IFunction<TResult, TSubEnumerable>
                => this.SelectMany<SelectEnumerable<TList, TSource, TResult, TSelector>, TResult, TSubEnumerable, TSubEnumerator, TResult2, TSelector2>(selector, offset, Count);

            #endregion
            #region Element

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> ElementAt(int index)
                => source.ElementAt<TList, TSource, TResult, TSelector>(index, selector, offset, Count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> First()
                => source.First<TList, TSource, TResult, TSelector>(selector, offset, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> Single()
                => source.Single<TList, TSource, TResult, TSelector>(selector, offset, Count);
            
            #endregion
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult[] ToArray()
                => source.ToArray<TList, TSource, TResult, TSelector>(selector, offset, Count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public IMemoryOwner<TResult> ToArray(MemoryPool<TResult> pool)
                => source.ToArray<TList, TSource, TResult, TSelector>(pool, selector, offset, Count);


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TResult> ToList()
                => source.ToList<TList, TSource, TResult, TSelector>(selector, offset, Count);
            
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
        public static int Count<TList, TSource, TResult, TSelector>(this in SelectEnumerable<TList, TSource, TResult, TSelector> source)
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
            => source.Count;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TList, TSource, TSelector>(this SelectEnumerable<TList, TSource, int, TSelector> source)
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, int>
            => source.source.Sum<TList, TSource, int, int, TSelector>(source.selector, source.offset, source.Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TList, TSource, TSelector>(this SelectEnumerable<TList, TSource, int?, TSelector> source)
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, int?>
            => source.source.Sum<TList, TSource, int?, int, TSelector>(source.selector, source.offset, source.Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TList, TSource, TSelector>(this SelectEnumerable<TList, TSource, long, TSelector> source)
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, long>
            => source.source.Sum<TList, TSource, long, long, TSelector>(source.selector, source.offset, source.Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TList, TSource, TSelector>(this SelectEnumerable<TList, TSource, long?, TSelector> source)
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, long?>
            => source.source.Sum<TList, TSource, long?, long, TSelector>(source.selector, source.offset, source.Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TList, TSource, TSelector>(this SelectEnumerable<TList, TSource, float, TSelector> source)
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, float>
            => source.source.Sum<TList, TSource, float, float, TSelector>(source.selector, source.offset, source.Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TList, TSource, TSelector>(this SelectEnumerable<TList, TSource, float?, TSelector> source)
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, float?>
            => source.source.Sum<TList, TSource, float?, float, TSelector>(source.selector, source.offset, source.Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TList, TSource, TSelector>(this SelectEnumerable<TList, TSource, double, TSelector> source)
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, double>
            => source.source.Sum<TList, TSource, double, double, TSelector>(source.selector, source.offset, source.Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TList, TSource, TSelector>(this SelectEnumerable<TList, TSource, double?, TSelector> source)
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, double?>
            => source.source.Sum<TList, TSource, double?, double, TSelector>(source.selector, source.offset, source.Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TList, TSource, TSelector>(this SelectEnumerable<TList, TSource, decimal, TSelector> source)
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, decimal>
            => source.source.Sum<TList, TSource, decimal, decimal, TSelector>(source.selector, source.offset, source.Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TList, TSource, TSelector>(this SelectEnumerable<TList, TSource, decimal?, TSelector> source)
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, decimal?>
            => source.source.Sum<TList, TSource, decimal?, decimal, TSelector>(source.selector, source.offset, source.Count);
    }
}

