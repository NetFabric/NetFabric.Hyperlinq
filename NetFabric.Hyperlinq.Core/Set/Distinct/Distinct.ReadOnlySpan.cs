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
        static SpanDistinctEnumerable<TSource> Distinct<TSource>(
            this ReadOnlySpan<TSource> source, 
            IEqualityComparer<TSource>? comparer = default)
            => new(source, comparer);

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
            public Enumerator GetEnumerator() 
                => new(in this);

            [StructLayout(LayoutKind.Auto)]
            public ref struct Enumerator
            {
                readonly ReadOnlySpan<TSource> source;
                Set<TSource> set;
                int index;

                internal Enumerator(in SpanDistinctEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    set = new Set<TSource>(enumerable.comparer);
                    index = -1;
                }

                public ref readonly TSource Current 
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => ref source[index];
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    while (++index < source.Length)
                    {
                        if (set.Add(source[index]))
                            return true;
                    }
                    return false;
                }

                public void Dispose() 
                    => set.Dispose();
            }

            Set<TSource> GetSet() 
            {
                var set = new Set<TSource>(comparer);
                foreach (var t in source)
                    _ = set.Add(t);
                return set;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count()
                => source.Length switch
                {
                    0 => 0,
                    _ => GetSet().Count
                };

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.Length is not 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => source.Length switch
                {
                    0 => Array.Empty<TSource>(),
                    _ => GetSet().ToArray()
                };

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Lease<TSource> ToArray(ArrayPool<TSource> pool, bool clearOnDispose = default)
                => GetSet().ToArray(pool, clearOnDispose);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => source.Length switch
                {
                    // ReSharper disable once HeapView.ObjectAllocation.Evident
                    0 => new List<TSource>(),
                    _ => GetSet().ToList()
                };

            public bool SequenceEqual(IEnumerable<TSource> other, IEqualityComparer<TSource>? comparer = default)
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

