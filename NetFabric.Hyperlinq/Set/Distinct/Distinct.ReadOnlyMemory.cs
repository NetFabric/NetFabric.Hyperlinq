using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemoryDistinctEnumerable<TSource> Distinct<TSource>(
            this ReadOnlyMemory<TSource> source, 
            IEqualityComparer<TSource>? comparer = null)
            => new MemoryDistinctEnumerable<TSource>(source, comparer);

        public readonly partial struct MemoryDistinctEnumerable<TSource>
            : IValueEnumerable<TSource, MemoryDistinctEnumerable<TSource>.Enumerator>
        {
            readonly ReadOnlyMemory<TSource> source;
            readonly IEqualityComparer<TSource>? comparer;

            internal MemoryDistinctEnumerable(ReadOnlyMemory<TSource> source, IEqualityComparer<TSource>? comparer)
            {
                this.source = source;
                this.comparer = comparer;
            }

            
            public readonly Enumerator GetEnumerator() 
                => new Enumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new Enumerator(in this);

            public struct Enumerator
                : IEnumerator<TSource>
            {
                readonly ReadOnlyMemory<TSource> source;
                Set<TSource>? set;
                int index;

                internal Enumerator(in MemoryDistinctEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    set = source.Length == 0 ? null : new Set<TSource>(enumerable.comparer);
                    index = -1;
                    Current = default!;
                }

                [MaybeNull]
                public TSource Current { get; private set; }
                readonly TSource IEnumerator<TSource>.Current 
                    => Current;
                readonly object? IEnumerator.Current
                    => Current;

                public bool MoveNext()
                {
                    var span = source.Span;
                    while (++index < source.Length)
                    {
                        if (set!.Add(span[index]))
                        {
                            Current = span[index];
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
                    => set = null;
            }

            readonly Set<TSource> GetSet() 
            {
                var set = new Set<TSource>(comparer);
                var span = source.Span;
                for (var index = 0; index < source.Length; index++)
                    _ = set.Add(span[index]);
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
                    ? System.Array.Empty<TSource>()
                    : GetSet().ToArray();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly List<TSource> ToList()
                => source.Length == 0
                    ? new List<TSource>()
                    : GetSet().ToList();

            public bool SequenceEqual(IEnumerable<TSource> other, IEqualityComparer<TSource>? comparer = null)
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

