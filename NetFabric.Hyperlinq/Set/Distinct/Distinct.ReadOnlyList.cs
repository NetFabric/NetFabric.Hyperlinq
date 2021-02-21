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
        public static DistinctEnumerable<TList, TSource> Distinct<TList, TSource>(this TList source, IEqualityComparer<TSource>? comparer = default)
            where TList : struct, IReadOnlyList<TSource>
            => source.Distinct(comparer, 0, source.Count);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static DistinctEnumerable<TList, TSource> Distinct<TList, TSource>(this TList source, IEqualityComparer<TSource>? comparer, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            => new(source, comparer, offset, count);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct DistinctEnumerable<TList, TSource>
            : IValueEnumerable<TSource, DistinctEnumerable<TList, TSource>.Enumerator>
            where TList : struct, IReadOnlyList<TSource>
        {
            readonly TList source;
            readonly IEqualityComparer<TSource>? comparer;
            readonly int offset;
            readonly int count;

            internal DistinctEnumerable(TList source, IEqualityComparer<TSource>? comparer, int offset, int count)
                => (this.source, this.comparer, this.offset, this.count) = (source, comparer, offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() 
                => new(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);

            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator
                : IEnumerator<TSource>
            {
                readonly TList source;
                Set<TSource> set;
                readonly int end;
                int index;

                internal Enumerator(in DistinctEnumerable<TList, TSource> enumerable)
                {
                    source = enumerable.source;
                    set = new Set<TSource>(enumerable.comparer);
                    index = enumerable.offset - 1;
                    end = index + enumerable.count;
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
                {
                    while (++index <= end)
                    {
                        if (set.Add(source[index]))
                            return true;
                    }
                    return false;
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public void Dispose() 
                    => set.Dispose();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly Set<TSource> GetSet()
            {
                using var set = new Set<TSource>(comparer);
                var end = offset + count;
                for (var index = offset; index < end; index++)
                {
                    var item = source[index];
                    _ = set.Add(item);
                }
                return set;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public DistinctEnumerable<TList, TSource> Skip(int count)
            {
                var (skipCount, takeCount) = Utils.Skip(this.count, count);
                return new DistinctEnumerable<TList, TSource>(source, comparer, offset + skipCount, takeCount);
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public DistinctEnumerable<TList, TSource> Take(int count)
                => new(source, comparer, offset, Utils.Take(this.count, count));

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly int Count()
                => count switch
                {
                    0 => 0,
                    _ => GetSet().Count
                };

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any()
                => count is not 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly TSource[] ToArray()
                => count switch
                {
                    0 => Array.Empty<TSource>(),
                    _ => GetSet().ToArray()
                };

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly IMemoryOwner<TSource> ToArray(MemoryPool<TSource> pool)
                => count switch
                {
                    0 => pool.RentSliced(0),
                    _ => GetSet().ToArray(pool)
                };

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly List<TSource> ToList()
                => count switch
                {
                    // ReSharper disable once HeapView.ObjectAllocation.Evident
                    0 => new List<TSource>(),
                    _ => GetSet().ToList()
                };

            public readonly bool SequenceEqual(IEnumerable<TSource> other, IEqualityComparer<TSource>? comparer = default)
            {
                comparer ??= EqualityComparer<TSource>.Default;

                using var enumerator = GetEnumerator();
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
    }
}

