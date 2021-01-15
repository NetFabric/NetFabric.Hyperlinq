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
        static SkipTakeEnumerable<TList, TSource> SkipTake<TList, TSource>(this TList source, int offset, int count)
            where TList : IReadOnlyList<TSource>
            => new SkipTakeEnumerable<TList, TSource>(in source, offset, count);

        [StructLayout(LayoutKind.Sequential)]
        public readonly partial struct SkipTakeEnumerable<TList, TSource>
            : IValueReadOnlyList<TSource, SkipTakeEnumerable<TList, TSource>.DisposableEnumerator>
            , IList<TSource>
            where TList : IReadOnlyList<TSource>
        {
            readonly int offset;
            readonly TList source;

            internal SkipTakeEnumerable(in TList source, int offset, int count)
            {
                this.source = source;
                (this.offset, Count) = Utils.SkipTake(source.Count, offset, count);
            }

            public readonly int Count { get; }

            public readonly TSource this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    if (index < 0 || index >= Count) Throw.ArgumentOutOfRangeException(nameof(index));

                    return source[index + offset];
                }
            }
            TSource IReadOnlyList<TSource>.this[int index]
                => this[index];
            TSource IList<TSource>.this[int index]
            {
                get => this[index];
                
                [ExcludeFromCodeCoverage]
                // ReSharper disable once ValueParameterNotUsed
                set => Throw.NotSupportedException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() 
                => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, SkipTakeEnumerable<TList, TSource>.DisposableEnumerator>.GetEnumerator() 
                => new(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(in this);

            bool ICollection<TSource>.IsReadOnly  
                => true;


            public void CopyTo(TSource[] array, int arrayIndex) 
                => Copy(source, offset, array, arrayIndex, Count);


            bool ICollection<TSource>.Contains(TSource item)
            {
                // ReSharper disable once HeapView.PossibleBoxingAllocation
                if (offset == 0 && Count == source.Count && source is ICollection<TSource> collection)
                    return collection.Contains(item);

                var end = offset + Count - 1;
                if (Utils.IsValueType<TSource>())
                {
                    for (var index = offset; index <= end; index++)
                    {
                        if (EqualityComparer<TSource>.Default.Equals(source[index], item))
                            return true;
                    }
                }
                else
                {
                    var defaultComparer = EqualityComparer<TSource>.Default;
                    for (var index = offset; index <= end; index++)
                    {
                        if (defaultComparer.Equals(source[index], item))
                            return true;
                    }
                }
                return false;
            }

            public int IndexOf(TSource item)
            {
                // ReSharper disable once HeapView.PossibleBoxingAllocation
                if (offset == 0 && Count == source.Count && source is IList<TSource> list)
                    return list.IndexOf(item);

                var end = offset + Count - 1;
                if (Utils.IsValueType<TSource>())
                {
                    for (var index = offset; index <= end; index++)
                    {
                        if (EqualityComparer<TSource>.Default.Equals(source[index], item))
                            return index - offset;
                    }
                }
                else
                {
                    var defaultComparer = EqualityComparer<TSource>.Default;
                    for (var index = offset; index <= end; index++)
                    {
                        if (defaultComparer.Equals(source[index], item))
                            return index - offset;
                    }
                }
                return -1;
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

            [StructLayout(LayoutKind.Sequential)]
            public struct Enumerator
            {
                int index;
                readonly int end;
                readonly TList source;

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

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                    => ++index <= end;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                int index;
                readonly int end;
                readonly TList source;

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
            public SkipTakeEnumerable<TList, TSource> Skip(int count)
                => source.SkipTake<TList, TSource>(offset + count, Count);
 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<TList, TSource> Take(int count)
                => source.SkipTake<TList, TSource>(offset, Math.Min(count, Count));

            #endregion            
            #region Quantifier  
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TSource, bool> predicate)
                => source.All<TList, TSource, FunctionWrapper<TSource, bool>>(new FunctionWrapper<TSource, bool>(predicate));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All<TPredicate>(TPredicate predicate)
                where TPredicate : struct, IFunction<TSource, bool>
                => source.All<TList, TSource, TPredicate>(predicate, offset, Count);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TSource, int, bool> predicate)
                => source.AllAt<TList, TSource, FunctionWrapper<TSource, int, bool>>(new FunctionWrapper<TSource, int, bool>(predicate));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AllAt<TPredicate>(TPredicate predicate)
                where TPredicate : struct, IFunction<TSource, int, bool>
                => source.AllAt<TList, TSource, TPredicate>(predicate, offset, Count);
            
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TSource, bool> predicate)
                => source.Any<TList, TSource, FunctionWrapper<TSource, bool>>(new FunctionWrapper<TSource, bool>(predicate));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any<TPredicate>(TPredicate predicate)
                where TPredicate : struct, IFunction<TSource, bool>
                => source.Any<TList, TSource, TPredicate>(predicate, offset, Count);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TSource, int, bool> predicate)
                => source.AnyAt<TList, TSource, FunctionWrapper<TSource, int, bool>>(new FunctionWrapper<TSource, int, bool>(predicate));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AnyAt<TPredicate>(TPredicate predicate)
                where TPredicate : struct, IFunction<TSource, int, bool>
                => source.AnyAt<TList, TSource, TPredicate>(predicate, offset, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value, IEqualityComparer<TSource>? comparer = default)
                => source.Contains(value, comparer, offset, Count);

            #endregion            
            #region Filtering  
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereEnumerable<TList, TSource, FunctionWrapper<TSource, bool>> Where(Func<TSource, bool> predicate)
                => Where<FunctionWrapper<TSource, bool>>(new FunctionWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereEnumerable<TList, TSource, TPredicate> Where<TPredicate>(TPredicate predicate)
                where TPredicate : struct, IFunction<TSource, bool>
                => source.Where<TList, TSource, TPredicate>(predicate, offset, Count);
            
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereAtEnumerable<TList, TSource, FunctionWrapper<TSource, int, bool>> Where(Func<TSource, int, bool> predicate)
                => WhereAt<FunctionWrapper<TSource, int, bool>>(new FunctionWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereAtEnumerable<TList, TSource, TPredicate> WhereAt<TPredicate>(TPredicate predicate)
                where TPredicate : struct, IFunction<TSource, int, bool>
                => source.WhereAt<TList, TSource, TPredicate>(predicate, offset, Count);

            #endregion            
            #region Projection  
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectEnumerable<TList, TSource, TResult, FunctionWrapper<TSource, TResult>> Select<TResult>(Func<TSource, TResult> selector)
                => Select<TResult, FunctionWrapper<TSource, TResult>>(new FunctionWrapper<TSource, TResult>(selector));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectEnumerable<TList, TSource, TResult, TSelector> Select<TResult, TSelector>(TSelector selector)
                where TSelector : struct, IFunction<TSource, TResult>
                => source.Select<TList, TSource, TResult, TSelector>(selector, offset, Count);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectAtEnumerable<TList, TSource, TResult, FunctionWrapper<TSource, int, TResult>> Select<TResult>(Func<TSource, int, TResult> selector)
                => SelectAt<TResult, FunctionWrapper<TSource, int, TResult>>(new FunctionWrapper<TSource, int, TResult>(selector));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectAtEnumerable<TList, TSource, TResult, TSelector> SelectAt<TResult, TSelector>(TSelector selector)
                where TSelector : struct, IFunction<TSource, int, TResult>
                => source.SelectAt<TList, TSource, TResult, TSelector>(selector, offset, Count);

            #endregion            
            #region Element  
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> ElementAt(int index)
                => source.ElementAt<TList, TSource>(index, offset, Count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> First()
                => source.First<TList, TSource>(offset, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> Single()
                => source.Single<TList, TSource>(offset, Count);

            #endregion            
            #region Conversion  
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => source.ToArray<TList, TSource>(offset, Count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public IMemoryOwner<TSource> ToArray(MemoryPool<TSource> pool)
                => source.ToArray<TList, TSource>(offset, Count, pool);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => source.ToList<TList, TSource>(offset, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => source.ToDictionary<TList, TSource, TKey, FunctionWrapper<TSource, TKey>>(new FunctionWrapper<TSource, TKey>(keySelector), comparer, offset, Count);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey, TKeySelector>(TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TSource, TKey>
                => source.ToDictionary<TList, TSource, TKey, TKeySelector>(keySelector, comparer, offset, Count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => source.ToDictionary<TList, TSource, TKey, TElement, FunctionWrapper<TSource, TKey>, FunctionWrapper<TSource, TElement>>(new FunctionWrapper<TSource, TKey>(keySelector), new FunctionWrapper<TSource, TElement>(elementSelector), comparer);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement, TKeySelector, TElementSelector>(TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TSource, TKey>
                where TElementSelector : struct, IFunction<TSource, TElement>
                => source.ToDictionary<TList, TSource, TKey, TElement, TKeySelector, TElementSelector>(keySelector, elementSelector, comparer, offset, Count);
            
            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TList, TSource>(this in SkipTakeEnumerable<TList, TSource> source)
            where TList : IReadOnlyList<TSource>
            => source.Count;
    }
}