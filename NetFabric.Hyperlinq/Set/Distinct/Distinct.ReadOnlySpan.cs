using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanDistinctEnumerable<TSource> Distinct<TSource>(
            this ReadOnlySpan<TSource> source, 
            IEqualityComparer<TSource>? comparer = null)
            => new SpanDistinctEnumerable<TSource>(source, comparer);

        [StructLayout(LayoutKind.Auto)]
        public readonly ref struct SpanDistinctEnumerable<TSource>
        {
            readonly ReadOnlySpan<TSource> source;
            readonly IEqualityComparer<TSource>? comparer;

            internal SpanDistinctEnumerable(ReadOnlySpan<TSource> source, IEqualityComparer<TSource>? comparer)
            {
                this.source = source;
                this.comparer = comparer;
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);

            [StructLayout(LayoutKind.Sequential)]
            public ref struct Enumerator
            {
                int index;
                readonly int end;
                readonly ReadOnlySpan<TSource> source;
                Set<TSource> set;

                internal Enumerator(in SpanDistinctEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    set = new Set<TSource>(enumerable.comparer);
                    index = -1;
                    end = index + source.Length;
                }

                public ref readonly TSource Current 
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => ref source[index];
                }

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

                public void Dispose() 
                    => set.Dispose();
            }

            readonly Set<TSource> GetSet() 
            {
                var set = new Set<TSource>(comparer);
                for (var index = 0; index < source.Length; index++)
                    _ = set.Add(source[index]);
                return set;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly int Count()
                => source.Length == 0
                    ? 0
                    : GetSet().Count;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any()
                => source.Length != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly TSource[] ToArray()
                => source.Length == 0
                    ? Array.Empty<TSource>()
                    : GetSet().ToArray();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly IMemoryOwner<TSource> ToArray(MemoryPool<TSource> pool)
                => source.Length == 0
                    ? pool.Rent(0)
                    : GetSet().ToArray(pool);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly List<TSource> ToList()
                => source.Length == 0
                    ? new List<TSource>()
                    : GetSet().ToList();

            public readonly bool SequenceEqual(IEnumerable<TSource> other, IEqualityComparer<TSource>? comparer = null)
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

                    if (!comparer.Equals(enumerator.Current, otherEnumerator.Current))
                        return false;
                }
            }
        }
    }
}

