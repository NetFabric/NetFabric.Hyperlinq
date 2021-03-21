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
        static ArraySegmentDistinctEnumerable<TSource> Distinct<TSource>(this in ArraySegment<TSource> source, IEqualityComparer<TSource>? comparer = default)
            => new(source, comparer);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ArraySegmentDistinctEnumerable<TSource>
            : IValueEnumerable<TSource, ArraySegmentDistinctEnumerable<TSource>.Enumerator>
        {
            readonly ArraySegment<TSource> source;
            readonly IEqualityComparer<TSource>? comparer;

            internal ArraySegmentDistinctEnumerable(in ArraySegment<TSource> source, IEqualityComparer<TSource>? comparer)
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
                readonly TSource[]? source;
                Set<TSource> set;
                readonly int end;
                int index;

                internal Enumerator(in ArraySegmentDistinctEnumerable<TSource> enumerable)
                {
                    source = enumerable.source.Array;
                    set = new Set<TSource>(enumerable.comparer);
                    index = enumerable.source.Offset - 1;
                    end = index + enumerable.source.Count;
                }

                public readonly TSource Current 
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
            public readonly ArraySegmentDistinctEnumerable<TSource> AsValueEnumerable()
                => this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly int Count()
                => source switch
                {
                    { Count: 0 } => 0,
                    _ => GetSet().Count
                };

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any()
                => source.Count is not 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly TSource[] ToArray()
                => source switch
                {
                    { Count: 0 } => Array.Empty<TSource>(),
                    _ => GetSet().ToArray()
                };

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueMemoryOwner<TSource> ToArray(ArrayPool<TSource> pool, bool clearOnDispose = default)
                => GetSet().ToArray(pool, clearOnDispose);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly List<TSource> ToList()
                => source switch
                {
                    // ReSharper disable once HeapView.ObjectAllocation.Evident
                    { Count: 0 } => new List<TSource>(),
                    _ => GetSet().ToList()
                };
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this ArraySegmentDistinctEnumerable<int> source)
            => source.Sum<ArraySegmentDistinctEnumerable<int>, ArraySegmentDistinctEnumerable<int>.Enumerator, int, int>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this ArraySegmentDistinctEnumerable<int?> source)
            => source.Sum<ArraySegmentDistinctEnumerable<int?>, ArraySegmentDistinctEnumerable<int?>.Enumerator, int?, int>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this ArraySegmentDistinctEnumerable<long> source)
            => source.Sum<ArraySegmentDistinctEnumerable<long>, ArraySegmentDistinctEnumerable<long>.Enumerator, long, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this ArraySegmentDistinctEnumerable<long?> source)
            => source.Sum<ArraySegmentDistinctEnumerable<long?>, ArraySegmentDistinctEnumerable<long?>.Enumerator, long?, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this ArraySegmentDistinctEnumerable<float> source)
            => source.Sum<ArraySegmentDistinctEnumerable<float>, ArraySegmentDistinctEnumerable<float>.Enumerator, float, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this ArraySegmentDistinctEnumerable<float?> source)
            => source.Sum<ArraySegmentDistinctEnumerable<float?>, ArraySegmentDistinctEnumerable<float?>.Enumerator, float?, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this ArraySegmentDistinctEnumerable<double> source)
            => source.Sum<ArraySegmentDistinctEnumerable<double>, ArraySegmentDistinctEnumerable<double>.Enumerator, double, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this ArraySegmentDistinctEnumerable<double?> source)
            => source.Sum<ArraySegmentDistinctEnumerable<double?>, ArraySegmentDistinctEnumerable<double?>.Enumerator, double?, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this ArraySegmentDistinctEnumerable<decimal> source)
            => source.Sum<ArraySegmentDistinctEnumerable<decimal>, ArraySegmentDistinctEnumerable<decimal>.Enumerator, decimal, decimal>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this ArraySegmentDistinctEnumerable<decimal?> source)
            => source.Sum<ArraySegmentDistinctEnumerable<decimal?>, ArraySegmentDistinctEnumerable<decimal?>.Enumerator, decimal?, decimal>();
    }
}

