using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SelectEnumerable<TList, TSource, TResult, FunctionWrapper<TSource, TResult>> Select<TList, TSource, TResult>(this TList source, Func<TSource, TResult> selector)
            where TList : IReadOnlyList<TSource>
            => source.Select<TList, TSource, TResult, FunctionWrapper<TSource, TResult>>(new FunctionWrapper<TSource, TResult>(selector));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SelectEnumerable<TList, TSource, TResult, TSelector> Select<TList, TSource, TResult, TSelector>(this TList source, TSelector selector)
            where TList : IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
            => source.Select<TList, TSource, TResult, TSelector>(selector, 0, source.Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static SelectEnumerable<TList, TSource, TResult, TSelector> Select<TList, TSource, TResult, TSelector>(this TList source, TSelector selector, int offset, int count)
            where TList : IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
            => new(in source, selector, offset, count);

        [GeneratorMapping("TSource", "TResult")]
        [GeneratorMapping("TResult", "TResult2")]
        [StructLayout(LayoutKind.Auto)]
        public partial struct SelectEnumerable<TList, TSource, TResult, TSelector>
            : IValueReadOnlyList<TResult, SelectEnumerable<TList, TSource, TResult, TSelector>.DisposableEnumerator>
            , IList<TResult>
            where TList : IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            readonly int offset;
            readonly TList source;
            TSelector selector;

            internal SelectEnumerable(in TList source, TSelector selector, int offset, int count)
            {
                this.source = source;
                this.selector = selector;
                (this.offset, Count) = Utils.SkipTake(source.Count, offset, count);
            }

            public readonly int Count { get; } 

            public readonly TResult this[int index]
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

            public void CopyTo(TResult[] array, int arrayIndex)
                => Copy<TList, TSource, TResult, TSelector>(source, offset, array, arrayIndex, Count, selector);

            public bool Contains(TResult item)
                => source.Contains<TList, TSource, TResult, TSelector>(item, selector, offset, Count);

            public int IndexOf(TResult item)
            {
                var end = offset + Count - 1;
                if (Utils.IsValueType<TResult>())
                {
                    for (var index = offset; index <= end; index++)
                    {
                        if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(source[index]), item))
                            return index - offset;
                    }
                }
                else
                {
                    var defaultComparer = EqualityComparer<TResult>.Default;
                    for (var index = offset; index <= end; index++)
                    {
                        if (defaultComparer.Equals(selector.Invoke(source[index]), item))
                            return index - offset;
                    }
                }
                return -1;
            }

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

            [StructLayout(LayoutKind.Sequential)]
            public struct Enumerator
            {
                int index;
                readonly int end;
                readonly TList source;
                TSelector selector;

                internal Enumerator(in SelectEnumerable<TList, TSource, TResult, TSelector> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    index = enumerable.offset - 1;
                    end = index + enumerable.Count;
                }

                public readonly TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector.Invoke(source[index]);
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
                readonly TList source;
                TSelector selector;

                internal DisposableEnumerator(in SelectEnumerable<TList, TSource, TResult, TSelector> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    index = enumerable.offset - 1;
                    end = index + enumerable.Count;
                }

                public readonly TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector.Invoke(source[index]);
                }
                readonly TResult IEnumerator<TResult>.Current 
                    => selector.Invoke(source[index]);
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => selector.Invoke(source[index])!;

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
                => new(source, selector, offset + count, Count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectEnumerable<TList, TSource, TResult, TSelector> Take(int count)
                => new(source, selector, offset, Math.Min(Count, count));
            
            #endregion
            #region Aggregation
            
            #endregion
            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => Count != 0;
            
            #endregion
            #region Filtering
            
            #endregion
            #region Projection

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectEnumerable<TList, TSource, TResult2, SelectorSelectorCombination<TSelector, FunctionWrapper<TResult, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, TResult2> selector)
                => Select<TResult2, FunctionWrapper<TResult, TResult2>>(new FunctionWrapper<TResult, TResult2>(selector));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectEnumerable<TList, TSource, TResult2, SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>> Select<TResult2, TSelector2>(TSelector2 selector)
                where TSelector2 : struct, IFunction<TResult, TResult2>
                => source.Select<TList, TSource, TResult2, SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(new SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectAtEnumerable<TList, TSource, TResult2, SelectorSelectorAtCombination<TSelector, FunctionWrapper<TResult, int, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, int, TResult2> selector)
                => SelectAt<TResult2, FunctionWrapper<TResult, int, TResult2>>(new FunctionWrapper<TResult, int, TResult2>(selector));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectAtEnumerable<TList, TSource, TResult2, SelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>> SelectAt<TResult2, TSelector2>(TSelector2 selector)
                where TSelector2 : struct, IFunction<TResult, int, TResult2>
                => source.SelectAt<TList, TSource, TResult2, SelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(new SelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));
            
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
                => source.ToArray<TList, TSource, TResult, TSelector>(selector, offset, Count, pool);


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
            where TList : IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
            => source.Count;
    }
}

