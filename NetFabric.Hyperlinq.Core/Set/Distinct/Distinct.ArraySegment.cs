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
        static ArraySegmentDistinctEnumerable<TSource> Distinct<TSource>(this in ArraySegment<TSource> source, IEqualityComparer<TSource>? comparer = default)
            => new(source, comparer);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ArraySegmentDistinctEnumerable<TSource>
            : IValueEnumerable<TSource, ArraySegmentDistinctEnumerable<TSource>.Enumerator>
        {
            readonly ArraySegment<TSource> source;
            readonly IEqualityComparer<TSource>? comparer;

            internal ArraySegmentDistinctEnumerable(in ArraySegment<TSource> source, IEqualityComparer<TSource>? comparer)
                => (this.source, this.comparer) = (source, comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator GetEnumerator()
                => new(in this);

            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);

            IEnumerator IEnumerable.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);

            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator
                : IEnumerator<TSource>
            {
                readonly TSource[]? source;
                Set<TSource> set;
                readonly int end;
                int index;

                internal Enumerator(in ArraySegmentDistinctEnumerable<TSource> enumerable)
                {
                    source = enumerable.source.Array;
                    set = new Set<TSource>(enumerable.comparer);
                    index = enumerable.source.Offset - 1;
                    end = index + enumerable.source.Count;
                }

                public readonly TSource Current 
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => source![index];
                }
                readonly TSource IEnumerator<TSource>.Current
                    => source![index];
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => source![index];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    var index = this.index;
                    while (++index <= end)
                    {
                        if (set.Add(source![index]))
                        {
                            this.index = index; 
                            return true;
                        }
                    }
                    return false;
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset()
                    => throw new NotSupportedException();

                public void Dispose()
                    => set.Dispose();
            }

            Set<TSource> GetSet()
            {
                var set = new Set<TSource>(comparer);
                foreach (var item in source.AsSpan())
                    _ = set.Add(item);
                return set;
            }

            #region Aggregation
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count()
                => source switch
                {
                    { Count: 0 } => 0,
                    _ => GetSet().Count
                };
            
            #endregion
            
            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.Count is not 0;
            
            #endregion
            
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentDistinctEnumerable<TSource> AsValueEnumerable()
                => this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentDistinctEnumerable<TSource> AsEnumerable()
                => this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => source switch
                {
                    { Count: 0 } => Array.Empty<TSource>(),
                    _ => GetSet().ToArray()
                };

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Lease<TSource> ToArray(ArrayPool<TSource> pool, bool clearOnDispose = default)
                => GetSet().ToArray(pool, clearOnDispose);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => source switch
                {
                    // ReSharper disable once HeapView.ObjectAllocation.Evident
                    { Count: 0 } => new List<TSource>(),
                    _ => GetSet().ToList()
                };
            
            #endregion
        }
    }
}

