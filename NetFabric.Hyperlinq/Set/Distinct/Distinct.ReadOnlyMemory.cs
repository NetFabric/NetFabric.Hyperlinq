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
        static MemoryDistinctEnumerable<TSource> Distinct<TSource>(
            this ReadOnlyMemory<TSource> source, 
            IEqualityComparer<TSource>? comparer = default)
            => new(source, comparer);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct MemoryDistinctEnumerable<TSource>
            : IValueEnumerable<TSource, MemoryDistinctEnumerable<TSource>.Enumerator>
        {
            readonly ReadOnlyMemory<TSource> source;
            readonly IEqualityComparer<TSource>? comparer;

            internal MemoryDistinctEnumerable(ReadOnlyMemory<TSource> source, IEqualityComparer<TSource>? comparer)
                => (this.source, this.comparer) = (source, comparer);
            
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
                readonly ReadOnlyMemory<TSource> source;
                Set<TSource> set;
                int index;

                internal Enumerator(in MemoryDistinctEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    set = new Set<TSource>(enumerable.comparer);
                    index = -1;
                    Current = default!;
                }

                public TSource Current { get; private set; }
                readonly TSource IEnumerator<TSource>.Current 
                    => Current;
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => Current;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    var span = source.Span;
                    while (++index < source.Length)
                    {
                        if (set.Add(span[index]))
                        {
                            Current = span[index];
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

            readonly Set<TSource> GetSet() 
            {
                var set = new Set<TSource>(comparer);
                foreach (var t in source.Span)
                    _ = set.Add(t);
                return set;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly int Count()
                => source switch
                {
                    { Length: 0 } => 0,
                    _ => GetSet().Count
                };

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any()
                => source.Length is not 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly TSource[] ToArray()
                => source switch
                {
                    { Length: 0 } => Array.Empty<TSource>(),
                    _ => GetSet().ToArray()
                };

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly IMemoryOwner<TSource> ToArray(MemoryPool<TSource> pool)
                => source switch
                {
                    { Length: 0 } => pool.Rent(0),
                    _ => GetSet().ToArray(pool)
                };

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly List<TSource> ToList()
                => source switch
                {
                    // ReSharper disable once HeapView.ObjectAllocation.Evident
                    { Length: 0 } => new List<TSource>(),
                    _ => GetSet().ToList()
                };

            public bool SequenceEqual(IEnumerable<TSource> other, IEqualityComparer<TSource>? comparer = default)
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

                    if (!comparer.Equals(enumerator.Current!, otherEnumerator.Current))
                        return false;
                }
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this MemoryDistinctEnumerable<int> source)
            => source.Sum<MemoryDistinctEnumerable<int>, MemoryDistinctEnumerable<int>.Enumerator, int, int>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this MemoryDistinctEnumerable<int?> source)
            => source.Sum<MemoryDistinctEnumerable<int?>, MemoryDistinctEnumerable<int?>.Enumerator, int?, int>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this MemoryDistinctEnumerable<long> source)
            => source.Sum<MemoryDistinctEnumerable<long>, MemoryDistinctEnumerable<long>.Enumerator, long, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this MemoryDistinctEnumerable<long?> source)
            => source.Sum<MemoryDistinctEnumerable<long?>, MemoryDistinctEnumerable<long?>.Enumerator, long?, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this MemoryDistinctEnumerable<float> source)
            => source.Sum<MemoryDistinctEnumerable<float>, MemoryDistinctEnumerable<float>.Enumerator, float, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this MemoryDistinctEnumerable<float?> source)
            => source.Sum<MemoryDistinctEnumerable<float?>, MemoryDistinctEnumerable<float?>.Enumerator, float?, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this MemoryDistinctEnumerable<double> source)
            => source.Sum<MemoryDistinctEnumerable<double>, MemoryDistinctEnumerable<double>.Enumerator, double, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this MemoryDistinctEnumerable<double?> source)
            => source.Sum<MemoryDistinctEnumerable<double?>, MemoryDistinctEnumerable<double?>.Enumerator, double?, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this MemoryDistinctEnumerable<decimal> source)
            => source.Sum<MemoryDistinctEnumerable<decimal>, MemoryDistinctEnumerable<decimal>.Enumerator, decimal, decimal>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this MemoryDistinctEnumerable<decimal?> source)
            => source.Sum<MemoryDistinctEnumerable<decimal?>, MemoryDistinctEnumerable<decimal?>.Enumerator, decimal?, decimal>();
    }
}

