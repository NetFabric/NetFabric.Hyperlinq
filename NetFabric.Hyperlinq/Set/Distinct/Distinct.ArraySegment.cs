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
        public static ArraySegmentDistinctEnumerable<TSource> Distinct<TSource>(this in ArraySegment<TSource> source, IEqualityComparer<TSource>? comparer = default)
            => new(source, comparer);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ArraySegmentDistinctEnumerable<TSource>
            : IValueEnumerable<TSource, ArraySegmentDistinctEnumerable<TSource>.Enumerator>
        {
            readonly ArraySegment<TSource> source;
            readonly IEqualityComparer<TSource>? comparer;

            internal ArraySegmentDistinctEnumerable(in ArraySegment<TSource> source, IEqualityComparer<TSource>? comparer)
            {
                this.source = source;
                this.comparer = comparer;
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator()
                => new(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);

            [StructLayout(LayoutKind.Sequential)]
            public struct Enumerator
                : IEnumerator<TSource>
            {
                int index;
                readonly int end;
                readonly TSource[]? source;
                Set<TSource> set;

                internal Enumerator(in ArraySegmentDistinctEnumerable<TSource> enumerable)
                {
                    source = enumerable.source.Array;
                    set = new Set<TSource>(enumerable.comparer);
                    index = enumerable.source.Offset - 1;
                    end = index + enumerable.source.Count;
                }

                public TSource Current 
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
                    while (++index <= end)
                    {
                        if (set.Add(source![index]))
                            return true;
                    }
                    return false;
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset()
                    => throw new NotSupportedException();

                public void Dispose()
                    => set.Dispose();
            }

            readonly Set<TSource> GetSet()
            {
                var set = new Set<TSource>(comparer);
                foreach (var item in source.AsSpan())
                    _ = set.Add(item);
                return set;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly int Count()
                => source.Count switch
                {
                    0 => 0,
                    _ => GetSet().Count
                };

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any()
                => source.Count is not 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly TSource[] ToArray()
                => source.Count switch
                {
                    0 => Array.Empty<TSource>(),
                    _ => GetSet().ToArray()
                };

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly IMemoryOwner<TSource> ToArray(MemoryPool<TSource> pool)
                => source.Count switch
                {
                    0 => pool.Rent(0),
                    _ => GetSet().ToArray(pool)
                };

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly List<TSource> ToList()
                => source.Count switch
                {
                    // ReSharper disable once HeapView.ObjectAllocation.Evident
                    0 => new List<TSource>(),
                    _ => GetSet().ToList()
                };
        }
    }
}

