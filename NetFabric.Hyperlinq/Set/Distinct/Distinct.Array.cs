using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
#if SPAN_SUPPORTED

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemoryDistinctEnumerable<TSource> Distinct<TSource>(this TSource[] source, IEqualityComparer<TSource>? comparer = default)
            => Distinct((ReadOnlyMemory<TSource>)source.AsMemory(), comparer);

#else

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DistinctEnumerable<TSource> Distinct<TSource>(
            this TSource[] source, 
            IEqualityComparer<TSource>? comparer = default)
            => new DistinctEnumerable<TSource>(source, comparer, 0, source.Length);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static DistinctEnumerable<TSource> Distinct<TSource>(
            this TSource[] source,
            IEqualityComparer<TSource>? comparer,
            int skipCount, int takeCount)
            => new DistinctEnumerable<TSource>(source, comparer, skipCount, takeCount);

        public readonly partial struct DistinctEnumerable<TSource>
            : IValueEnumerable<TSource, DistinctEnumerable<TSource>.Enumerator>
        {
            readonly TSource[] source;
            readonly IEqualityComparer<TSource>? comparer;
            internal readonly int skipCount;
            internal readonly int takeCount;

            internal DistinctEnumerable(TSource[] source, IEqualityComparer<TSource>? comparer, int skipCount, int takeCount)
            {
                this.source = source;
                this.comparer = comparer;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Length, skipCount, takeCount);
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IEnumerator<TSource>
            {
                readonly TSource[] source;
                Set<TSource>? set;
                readonly int end;
                int index;

                internal Enumerator(in DistinctEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    set = source.Length == 0 ? null : new Set<TSource>(enumerable.comparer);
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                    Current = default!;
                }

                [MaybeNull, AllowNull]
                public TSource Current { get; private set; }
                readonly TSource IEnumerator<TSource>.Current 
                    => Current;
                readonly object? IEnumerator.Current
                    => Current;

                public bool MoveNext()
                {
                    while (++index < end)
                    {
                        if (set!.Add(source[index]))
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
                    => Throw.NotSupportedException();

                public void Dispose() 
                    => set = default;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly Set<TSource> GetSet()
            {
                var set = new Set<TSource>(comparer);
                for (var index = 0; index < source.Length; index++)
                    _ = set.Add(source[index]);
                return set;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly DistinctEnumerable<TSource> Skip(int count)
                => new DistinctEnumerable<TSource>(source, comparer, skipCount + count, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly DistinctEnumerable<TSource> Take(int count)
                => new DistinctEnumerable<TSource>(source, comparer, skipCount, Math.Min(takeCount, count));

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
            public readonly List<TSource> ToList()
                => source.Length == 0
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

                    if (!comparer.Equals(enumerator.Current, otherEnumerator.Current))
                        return false;
                }
            }
        }

#endif
    }
}

