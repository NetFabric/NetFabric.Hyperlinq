using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentDistinctEnumerable<TSource> Distinct<TSource>(this in ArraySegment<TSource> source, IEqualityComparer<TSource>? comparer = default)
            => new ArraySegmentDistinctEnumerable<TSource>(source, comparer);

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
                => new Enumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator()
                => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator()
                => new Enumerator(in this);

            public struct Enumerator
                : IEnumerator<TSource>
            {
                readonly TSource[] source;
                readonly int end;
                Set<TSource> set;
                int index;

                internal Enumerator(in ArraySegmentDistinctEnumerable<TSource> enumerable)
                {
                    source = enumerable.source.Array;
                    set = new Set<TSource>(enumerable.comparer);
                    index = enumerable.source.Offset - 1;
                    end = index + enumerable.source.Count;
                    Current = default!;
                }

                [MaybeNull, AllowNull]
                public TSource Current { get; private set; }
                readonly TSource IEnumerator<TSource>.Current
                    => Current!;
                readonly object? IEnumerator.Current
                    => Current;

                public bool MoveNext()
                {
                    while (++index <= end)
                    {
                        if (set.Add(source[index]))
                        {
                            Current = source[index];
                            return true;
                        }
                    }

                    Dispose();
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
                var array = source.Array;
                if (source.IsWhole())
                {
                    foreach (var item in array)
                        _ = set.Add(item);
                }
                else
                {
                    var end = source.Offset + source.Count - 1;
                    for (var index = source.Offset; index <= end; index++)
                        _ = set.Add(array[index]);
                }
                return set;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly int Count()
                => source.Count == 0
                    ? 0
                    : GetSet().Count;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any()
                => source.Count != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly TSource[] ToArray()
                => source.Count == 0
                    ? Array.Empty<TSource>()
                    : GetSet().ToArray();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly IMemoryOwner<TSource> ToArray(MemoryPool<TSource> pool)
                => source.Count == 0
                    ? pool.Rent(0)
                    : GetSet().ToArray(pool);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly List<TSource> ToList()
                => source.Count == 0
                    ? new List<TSource>()
                    : GetSet().ToList();
        }
    }
}

