using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DistinctEnumerable<TEnumerable, TEnumerator, TSource> Distinct<TEnumerable, TEnumerator, TSource>(
            this TEnumerable source, 
            IEqualityComparer<TSource>? comparer = default)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => new(source, comparer);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct DistinctEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueEnumerable<TSource, DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly IEqualityComparer<TSource>? comparer;

            internal DistinctEnumerable(TEnumerable source, IEqualityComparer<TSource>? comparer)
                => (this.source, this.comparer) = (source, comparer);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator GetEnumerator() 
                => new(in this);

            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);

            IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);

            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator
                : IEnumerator<TSource>
            {
#pragma warning disable IDE0044 // Add readonly modifier
                TEnumerator enumerator;
#pragma warning restore IDE0044 // Add readonly modifier
                readonly IEqualityComparer<TSource>? comparer;
                Set<TSource> set;

                internal Enumerator(in DistinctEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    comparer = enumerable.comparer;
                    set = new Set<TSource>(comparer);
                }

                public readonly TSource Current 
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => enumerator.Current;
                }
                readonly TSource IEnumerator<TSource>.Current 
                    => enumerator.Current;
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => enumerator.Current;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    while (enumerator.MoveNext())
                    {
                        if (set.Add(enumerator.Current))
                            return true;
                    }
                    return false;
                }

                [ExcludeFromCodeCoverage]
                [DoesNotReturn]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public void Dispose()
                {
                    enumerator.Dispose();
                    set.Dispose();
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            Set<TSource> GetSet()
            { 
                using var set = new Set<TSource>(comparer);
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                    _ = set.Add(enumerator.Current);
                return set;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count()
                => GetSet().Count;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.Any<TEnumerable, TEnumerator, TSource>();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => GetSet().ToArray();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Lease<TSource> ToArray(ArrayPool<TSource> pool, bool clearOnDispose = default)
                => GetSet().ToArray(pool, clearOnDispose);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => GetSet().ToList();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerable, TEnumerator>(this DistinctEnumerable<TEnumerable, TEnumerator, int> source)
            where TEnumerable : IValueEnumerable<int, TEnumerator>
            where TEnumerator : struct, IEnumerator<int>
            => source.Sum<DistinctEnumerable<TEnumerable, TEnumerator, int>, DistinctEnumerable<TEnumerable, TEnumerator, int>.Enumerator, int, int>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerable, TEnumerator>(this DistinctEnumerable<TEnumerable, TEnumerator, int?> source)
            where TEnumerable : IValueEnumerable<int?, TEnumerator>
            where TEnumerator : struct, IEnumerator<int?>
            => source.Sum<DistinctEnumerable<TEnumerable, TEnumerator, int?>, DistinctEnumerable<TEnumerable, TEnumerator, int?>.Enumerator, int?, int>();
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TEnumerable, TEnumerator>(this DistinctEnumerable<TEnumerable, TEnumerator, nint> source)
            where TEnumerable : IValueEnumerable<nint, TEnumerator>
            where TEnumerator : struct, IEnumerator<nint>
            => source.Sum<DistinctEnumerable<TEnumerable, TEnumerator, nint>, DistinctEnumerable<TEnumerable, TEnumerator, nint>.Enumerator, nint, nint>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TEnumerable, TEnumerator>(this DistinctEnumerable<TEnumerable, TEnumerator, nint?> source)
            where TEnumerable : IValueEnumerable<nint?, TEnumerator>
            where TEnumerator : struct, IEnumerator<nint?>
            => source.Sum<DistinctEnumerable<TEnumerable, TEnumerator, nint?>, DistinctEnumerable<TEnumerable, TEnumerator, nint?>.Enumerator, nint?, nint>();
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TEnumerable, TEnumerator>(this DistinctEnumerable<TEnumerable, TEnumerator, nuint> source)
            where TEnumerable : IValueEnumerable<nuint, TEnumerator>
            where TEnumerator : struct, IEnumerator<nuint>
            => source.Sum<DistinctEnumerable<TEnumerable, TEnumerator, nuint>, DistinctEnumerable<TEnumerable, TEnumerator, nuint>.Enumerator, nuint, nuint>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TEnumerable, TEnumerator>(this DistinctEnumerable<TEnumerable, TEnumerator, nuint?> source)
            where TEnumerable : IValueEnumerable<nuint?, TEnumerator>
            where TEnumerator : struct, IEnumerator<nuint?>
            => source.Sum<DistinctEnumerable<TEnumerable, TEnumerator, nuint?>, DistinctEnumerable<TEnumerable, TEnumerator, nuint?>.Enumerator, nuint?, nuint>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerable, TEnumerator>(this DistinctEnumerable<TEnumerable, TEnumerator, long> source)
            where TEnumerable : IValueEnumerable<long, TEnumerator>
            where TEnumerator : struct, IEnumerator<long>
            => source.Sum<DistinctEnumerable<TEnumerable, TEnumerator, long>, DistinctEnumerable<TEnumerable, TEnumerator, long>.Enumerator, long, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerable, TEnumerator>(this DistinctEnumerable<TEnumerable, TEnumerator, long?> source)
            where TEnumerable : IValueEnumerable<long?, TEnumerator>
            where TEnumerator : struct, IEnumerator<long?>
            => source.Sum<DistinctEnumerable<TEnumerable, TEnumerator, long?>, DistinctEnumerable<TEnumerable, TEnumerator, long?>.Enumerator, long?, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerable, TEnumerator>(this DistinctEnumerable<TEnumerable, TEnumerator, float> source)
            where TEnumerable : IValueEnumerable<float, TEnumerator>
            where TEnumerator : struct, IEnumerator<float>
            => source.Sum<DistinctEnumerable<TEnumerable, TEnumerator, float>, DistinctEnumerable<TEnumerable, TEnumerator, float>.Enumerator, float, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerable, TEnumerator>(this DistinctEnumerable<TEnumerable, TEnumerator, float?> source)
            where TEnumerable : IValueEnumerable<float?, TEnumerator>
            where TEnumerator : struct, IEnumerator<float?>
            => source.Sum<DistinctEnumerable<TEnumerable, TEnumerator, float?>, DistinctEnumerable<TEnumerable, TEnumerator, float?>.Enumerator, float?, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerable, TEnumerator>(this DistinctEnumerable<TEnumerable, TEnumerator, double> source)
            where TEnumerable : IValueEnumerable<double, TEnumerator>
            where TEnumerator : struct, IEnumerator<double>
            => source.Sum<DistinctEnumerable<TEnumerable, TEnumerator, double>, DistinctEnumerable<TEnumerable, TEnumerator, double>.Enumerator, double, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerable, TEnumerator>(this DistinctEnumerable<TEnumerable, TEnumerator, double?> source)
            where TEnumerable : IValueEnumerable<double?, TEnumerator>
            where TEnumerator : struct, IEnumerator<double?>
            => source.Sum<DistinctEnumerable<TEnumerable, TEnumerator, double?>, DistinctEnumerable<TEnumerable, TEnumerator, double?>.Enumerator, double?, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerable, TEnumerator>(this DistinctEnumerable<TEnumerable, TEnumerator, decimal> source)
            where TEnumerable : IValueEnumerable<decimal, TEnumerator>
            where TEnumerator : struct, IEnumerator<decimal>
            => source.Sum<DistinctEnumerable<TEnumerable, TEnumerator, decimal>, DistinctEnumerable<TEnumerable, TEnumerator, decimal>.Enumerator, decimal, decimal>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerable, TEnumerator>(this DistinctEnumerable<TEnumerable, TEnumerator, decimal?> source)
            where TEnumerable : IValueEnumerable<decimal?, TEnumerator>
            where TEnumerator : struct, IEnumerator<decimal?>
            => source.Sum<DistinctEnumerable<TEnumerable, TEnumerator, decimal?>, DistinctEnumerable<TEnumerable, TEnumerator, decimal?>.Enumerator, decimal?, decimal>();
    }
}

