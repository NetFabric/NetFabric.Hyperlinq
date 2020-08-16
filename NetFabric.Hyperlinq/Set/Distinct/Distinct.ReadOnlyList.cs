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
        public static DistinctEnumerable<TList, TSource> Distinct<TList, TSource>(
            this TList source, 
            IEqualityComparer<TSource>? comparer = default)
            where TList : notnull, IReadOnlyList<TSource>
            => new DistinctEnumerable<TList, TSource>(source, comparer, 0, source.Count);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static DistinctEnumerable<TList, TSource> Distinct<TList, TSource>(
            this TList source,
            IEqualityComparer<TSource>? comparer,
            int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            => new DistinctEnumerable<TList, TSource>(source, comparer, offset, count);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct DistinctEnumerable<TList, TSource>
            : IValueEnumerable<TSource, DistinctEnumerable<TList, TSource>.Enumerator>
            where TList : notnull, IReadOnlyList<TSource>
        {
            readonly TList source;
            readonly IEqualityComparer<TSource>? comparer;
            internal readonly int offset;
            internal readonly int count;

            internal DistinctEnumerable(TList source, IEqualityComparer<TSource>? comparer, int offset, int count)
            {
                this.source = source;
                this.comparer = comparer;
                (this.offset, this.count) = Utils.SkipTake(source.Count, offset, count);
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            [StructLayout(LayoutKind.Sequential)]
            public struct Enumerator
                : IEnumerator<TSource>
            {
                int index;
                readonly int end;
                readonly TList source;
                Set<TSource> set;

                internal Enumerator(in DistinctEnumerable<TList, TSource> enumerable)
                {
                    source = enumerable.source;
                    set = new Set<TSource>(enumerable.comparer);
                    index = enumerable.offset - 1;
                    end = index + enumerable.count;
                }

                [MaybeNull]
                public readonly TSource Current 
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => source[index];
                }
                readonly TSource IEnumerator<TSource>.Current
                    => source[index];
                readonly object? IEnumerator.Current 
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
                for (var index = 0; index < source.Count; index++)
                    _ = set.Add(source[index]);
                return set;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly DistinctEnumerable<TList, TSource> Skip(int count)
                => new DistinctEnumerable<TList, TSource>(source, comparer, offset + count, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly DistinctEnumerable<TList, TSource> Take(int count)
                => new DistinctEnumerable<TList, TSource>(source, comparer, offset, Math.Min(count, count));


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
                    ? pool.RentSliced(0)
                    : GetSet().ToArray(pool);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly List<TSource> ToList()
                => source.Count == 0
                    ? new List<TSource>()
                    : GetSet().ToList();

            public readonly bool SequenceEqual(IEnumerable<TSource> other, IEqualityComparer<TSource>? comparer = default)
            {
                comparer ??= EqualityComparer<TSource>.Default;

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

                    if (!comparer.Equals(enumerator.Current!, otherEnumerator.Current))
                        return false;
                }
            }
        }
    }
}

