using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DistinctEnumerable<TList, TSource> Distinct<TList, TSource>(
            this TList source, 
            IEqualityComparer<TSource>? comparer = default)
            where TList : IReadOnlyList<TSource>
            => new DistinctEnumerable<TList, TSource>(source, comparer, 0, source.Count);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static DistinctEnumerable<TList, TSource> Distinct<TList, TSource>(
            this TList source,
            IEqualityComparer<TSource>? comparer,
            int skipCount, int takeCount)
            where TList : IReadOnlyList<TSource>
            => new DistinctEnumerable<TList, TSource>(source, comparer, skipCount, takeCount);

        public readonly partial struct DistinctEnumerable<TList, TSource>
            : IValueEnumerable<TSource, DistinctEnumerable<TList, TSource>.Enumerator>
            where TList : IReadOnlyList<TSource>
        {
            readonly TList source;
            readonly IEqualityComparer<TSource>? comparer;
            internal readonly int skipCount;
            internal readonly int takeCount;

            internal DistinctEnumerable(TList source, IEqualityComparer<TSource>? comparer, int skipCount, int takeCount)
            {
                this.source = source;
                this.comparer = comparer;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Count, skipCount, takeCount);
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

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
                    index = enumerable.skipCount - 1;
                    end = index + enumerable.takeCount;
                }

                [MaybeNull]
                public readonly TSource Current 
                    => source[index];
                readonly TSource IEnumerator<TSource>.Current
                    => source[index];
                readonly object? IEnumerator.Current 
                    => source[index];

                public bool MoveNext()
                {
                    while (++index <= end)
                    {
                        if (set.Add(source[index]))
                            return true;
                    }

                    Dispose();
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
                => new DistinctEnumerable<TList, TSource>(source, comparer, skipCount + count, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly DistinctEnumerable<TList, TSource> Take(int count)
                => new DistinctEnumerable<TList, TSource>(source, comparer, skipCount, Math.Min(takeCount, count));


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

