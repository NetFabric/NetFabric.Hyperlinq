using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct SkipTakeEnumerable<TList, TSource>
            : IValueReadOnlyList<TSource, SkipTakeEnumerable<TList, TSource>.DisposableEnumerator>
            , IList<TSource>
            where TList : struct, IReadOnlyList<TSource>
        {
            readonly TList source;
            readonly int offset;

            internal SkipTakeEnumerable(in TList source, int offset, int count)
                => (this.source, this.offset, Count) = (source, offset, count);

            internal SkipTakeEnumerable(in TList source, (int Offset, int Count) slice)
                => (this.source, offset, Count) = (source, slice.Offset, slice.Count);

            public int Count { get; }

            public TSource this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    ThrowIfArgument.OutOfRange(index, Count, nameof(index));
                    return source[index + offset];
                }
            }

            TSource IList<TSource>.this[int index]
            {
                get => this[index];

                [ExcludeFromCodeCoverage]
                // ReSharper disable once ValueParameterNotUsed
                set => Throw.NotSupportedException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator GetEnumerator() 
                => new(in this);

            DisposableEnumerator IValueEnumerable<TSource, DisposableEnumerator>.GetEnumerator() 
                => new(in this);

            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(in this);

            IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(in this);

            bool ICollection<TSource>.IsReadOnly  
                => true;

            public void CopyTo(Span<TSource> span)
            {
                if (Count is 0)      
                    return;

                if (span.Length < Count)
                    Throw.ArgumentException(Resource.DestinationNotLongEnough, nameof(span));

                if (offset is 0)
                {
                    for(var index = 0; index < Count; index++)
                        span[index] = source[index];
                }
                else
                {
                    for(var index = 0; index < Count; index++)
                        span[index] = source[index + offset];
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void CopyTo(TSource[] array, int arrayIndex)
            {
                if (Count is 0)
                    return;

                // ReSharper disable once HeapView.PossibleBoxingAllocation
                if (offset is 0 && Count == source.Count && source is ICollection<TSource> collection)
                    collection.CopyTo(array, arrayIndex);
                else
                    CopyTo(array.AsSpan(arrayIndex));
            }

            public bool Contains(TSource item)
                => Contains(item, EqualityComparer<TSource>.Default);
            
            public int IndexOf(TSource item)
            {
                if (source.Count is 0)
                    return -1;

                // ReSharper disable once HeapView.PossibleBoxingAllocation
                if (offset is 0 && Count == source.Count && source is IList<TSource> list)
                    return list.IndexOf(item);

                return ValueReadOnlyCollectionExtensions.IndexOf<SkipTakeEnumerable<TList, TSource>, DisposableEnumerator, TSource>(this, item);
            }

            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Add(TSource item) 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Clear() 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            bool ICollection<TSource>.Remove(TSource item) 
                => Throw.NotSupportedException<bool>();

            [ExcludeFromCodeCoverage]
            void IList<TSource>.Insert(int index, TSource item)
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void IList<TSource>.RemoveAt(int index)
                => Throw.NotSupportedException();

            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator
            {
                readonly TList source; 
                readonly int end;
                int index;

                internal Enumerator(in SkipTakeEnumerable<TList, TSource> enumerable)
                {
                    source = enumerable.source;
                    index = enumerable.offset - 1;
                    end = index + enumerable.Count;
                }

                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => source[index];
                }

                public bool MoveNext()
                    => ++index <= end;
            }

            [StructLayout(LayoutKind.Auto)]
            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                readonly TList source; 
                readonly int end;
                int index;

                internal DisposableEnumerator(in SkipTakeEnumerable<TList, TSource> enumerable)
                {
                    source = enumerable.source;
                    index = enumerable.offset - 1;
                    end = index + enumerable.Count;
                }

                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => source[index];
                }
                readonly TSource IEnumerator<TSource>.Current 
                    => source[index];
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => source[index];

                public bool MoveNext()
                    => ++index <= end;
                
                [ExcludeFromCodeCoverage]
                [DoesNotReturn]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public readonly void Dispose()
                { }
            }

            #region Partitioning

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<TList, TSource> Skip(int count)
            {
                var (newOffset, newCount) = Utils.Skip(Count, count);
                return new SkipTakeEnumerable<TList, TSource>(source, offset + newOffset, newCount);
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<TList, TSource> Take(int count)
                => new(source, offset, Utils.Take(Count, count));
            
            #endregion

            #region Conversion

            public SkipTakeEnumerable<TList, TSource> AsValueEnumerable()
                => this;

            public SkipTakeEnumerable<TList, TSource> AsEnumerable()
                => this;

            #endregion
            
            #region Projection

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueReadOnlyListExtensions.SelectEnumerable<SkipTakeEnumerable<TList, TSource>, DisposableEnumerator, TSource, TResult, FunctionWrapper<TSource, TResult>> Select<TResult>(Func<TSource, TResult> selector)
                => ValueReadOnlyListExtensions.Select<SkipTakeEnumerable<TList, TSource>, DisposableEnumerator, TSource, TResult>(this, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueReadOnlyListExtensions.SelectEnumerable<SkipTakeEnumerable<TList, TSource>, DisposableEnumerator, TSource, TResult, TSelector> Select<TResult, TSelector>(TSelector selector = default)
                where TSelector : struct, IFunction<TSource, TResult>
                => ValueReadOnlyListExtensions.Select<SkipTakeEnumerable<TList, TSource>, DisposableEnumerator, TSource, TResult, TSelector>(this, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueReadOnlyListExtensions.SelectAtEnumerable<SkipTakeEnumerable<TList, TSource>, DisposableEnumerator, TSource, TResult, FunctionWrapper<TSource, int, TResult>> Select<TResult>(Func<TSource, int, TResult> selector)
                => ValueReadOnlyListExtensions.Select<SkipTakeEnumerable<TList, TSource>, DisposableEnumerator, TSource, TResult>(this, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueReadOnlyListExtensions.SelectAtEnumerable<SkipTakeEnumerable<TList, TSource>, DisposableEnumerator, TSource, TResult, TSelector> SelectAt<TResult, TSelector>(TSelector selector = default)
                where TSelector : struct, IFunction<TSource, int, TResult>
                => ValueReadOnlyListExtensions.SelectAt<SkipTakeEnumerable<TList, TSource>, DisposableEnumerator, TSource, TResult, TSelector>(this, selector);

            #endregion

            public bool Contains(TSource value, IEqualityComparer<TSource>? comparer)
            {
                if (source.Count is 0)
                    return false;

                if (comparer.UseDefaultComparer())
                {
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    // ReSharper disable once HeapView.BoxingAllocation
                    if (offset is 0 && Count == source.Count && source is ICollection<TSource> collection)
                        return collection.Contains(value);

                    return DefaultContains(source, value, offset, Count);
                }

                return ComparerContains(source, value, comparer, offset, Count);

                static bool DefaultContains(TList source, TSource value, int offset, int count)
                {
                    var end = offset + count;
                    for(var index = offset; index < end; index++)
                    {
                        if (EqualityComparer<TSource>.Default.Equals(source[index], value!))
                            return true;
                    }
                    return false;
                }

                static bool ComparerContains(TList source, TSource value, IEqualityComparer<TSource>? comparer, int offset, int count)
                {
                    comparer ??= EqualityComparer<TSource>.Default;
                    var end = offset + count;
                    for(var index = offset; index < end; index++)
                    {
                        if (comparer.Equals(source[index], value!))
                            return true;
                    }
                    return false;
                }
            }
        }
    }
}