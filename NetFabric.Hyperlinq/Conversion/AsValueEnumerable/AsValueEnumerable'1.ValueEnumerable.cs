using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerable<TEnumerator, TSource> AsValueEnumerable<TEnumerator, TSource>(this IValueEnumerable<TSource, TEnumerator> source)
            where TEnumerator : struct, IEnumerator<TSource>
            => new(source);

        [GeneratorBindings(source: "source", sourceImplements: "IValueEnumerable`2", enumerableType: "IValueEnumerable<TSource, TEnumerator>")]
        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ValueEnumerable<TEnumerator, TSource>
            : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly IValueEnumerable<TSource, TEnumerator> source;

            internal ValueEnumerable(IValueEnumerable<TSource, TEnumerator> source) 
                => this.source = source;

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TEnumerator GetEnumerator() 
                => source.GetEnumerator();
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => source.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => source.GetEnumerator();
            
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueEnumerable<TEnumerator, TSource> AsValueEnumerable()
                => this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public IEnumerable<TSource> AsEnumerable()
                => source;

            public TSource[] ToArray()
            {
                // ReSharper disable once HeapView.PossibleBoxingAllocation
                if (source is ICollection<TSource> collection)
                {
                    if (collection.Count is 0)
                        return Array.Empty<TSource>();

                    var result = Utils.AllocateUninitializedArray<TSource>(collection.Count);
                    collection.CopyTo(result, 0);
                    return result;
                }
                
                using var arrayBuilder = ToArrayBuilder<IValueEnumerable<TSource, TEnumerator>, TEnumerator, TSource>(source, ArrayPool<TSource>.Shared, false);
                return arrayBuilder.ToArray();
            }

            public Lease<TSource> ToArray(ArrayPool<TSource> pool, bool clearOnDispose = default)
            {
                // ReSharper disable once HeapView.PossibleBoxingAllocation
                if (source is ICollection<TSource> collection)
                {
                    if (collection.Count is 0)
                        return Lease.Empty<TSource>();
                
                    var result = pool.Lease(collection.Count, clearOnDispose);
                    collection.CopyTo(result.Rented, 0);
                    return result;                
                }

                using var arrayBuilder = ToArrayBuilder<IValueEnumerable<TSource, TEnumerator>, TEnumerator, TSource>(source, pool, clearOnDispose);
                return arrayBuilder.ToArray(pool, clearOnDispose);
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => ToArray().AsList();

            #endregion
            
            #region Quantifier

            public bool Contains(TSource value, IEqualityComparer<TSource>? comparer = default)
            {
                if (comparer.UseDefaultComparer() && source is ICollection<TSource> collection)
                    return collection.Contains(value);

                return source.Contains<IValueEnumerable<TSource, TEnumerator>, TEnumerator, TSource>(value, comparer);
            }

            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerator>(this ValueEnumerable<TEnumerator, int> source)
            where TEnumerator : struct, IEnumerator<int>
            => source.Sum<ValueEnumerable<TEnumerator, int>, TEnumerator, int, int>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerator>(this ValueEnumerable<TEnumerator, int?> source)
            where TEnumerator : struct, IEnumerator<int?>
            => source.Sum<ValueEnumerable<TEnumerator, int?>, TEnumerator, int?, int>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TEnumerator>(this ValueEnumerable<TEnumerator, nint> source)
            where TEnumerator : struct, IEnumerator<nint>
            => source.Sum<ValueEnumerable<TEnumerator, nint>, TEnumerator, nint, nint>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TEnumerator>(this ValueEnumerable<TEnumerator, nint?> source)
            where TEnumerator : struct, IEnumerator<nint?>
            => source.Sum<ValueEnumerable<TEnumerator, nint?>, TEnumerator, nint?, nint>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TEnumerator>(this ValueEnumerable<TEnumerator, nuint> source)
            where TEnumerator : struct, IEnumerator<nuint>
            => source.Sum<ValueEnumerable<TEnumerator, nuint>, TEnumerator, nuint, nuint>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TEnumerator>(this ValueEnumerable<TEnumerator, nuint?> source)
            where TEnumerator : struct, IEnumerator<nuint?>
            => source.Sum<ValueEnumerable<TEnumerator, nuint?>, TEnumerator, nuint?, nuint>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerator>(this ValueEnumerable<TEnumerator, long> source)
            where TEnumerator : struct, IEnumerator<long>
            => source.Sum<ValueEnumerable<TEnumerator, long>, TEnumerator, long, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerator>(this ValueEnumerable<TEnumerator, long?> source)
            where TEnumerator : struct, IEnumerator<long?>
            => source.Sum<ValueEnumerable<TEnumerator, long?>, TEnumerator, long?, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerator>(this ValueEnumerable<TEnumerator, float> source)
            where TEnumerator : struct, IEnumerator<float>
            => source.Sum<ValueEnumerable<TEnumerator, float>, TEnumerator, float, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerator>(this ValueEnumerable<TEnumerator, float?> source)
            where TEnumerator : struct, IEnumerator<float?>
            => source.Sum<ValueEnumerable<TEnumerator, float?>, TEnumerator, float?, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerator>(this ValueEnumerable<TEnumerator, double> source)
            where TEnumerator : struct, IEnumerator<double>
            => source.Sum<ValueEnumerable<TEnumerator, double>, TEnumerator, double, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerator>(this ValueEnumerable<TEnumerator, double?> source)
            where TEnumerator : struct, IEnumerator<double?>
            => source.Sum<ValueEnumerable<TEnumerator, double?>, TEnumerator, double?, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerator>(this ValueEnumerable<TEnumerator, decimal> source)
            where TEnumerator : struct, IEnumerator<decimal>
            => source.Sum<ValueEnumerable<TEnumerator, decimal>, TEnumerator, decimal, decimal>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerator>(this ValueEnumerable<TEnumerator, decimal?> source)
            where TEnumerator : struct, IEnumerator<decimal?>
            => source.Sum<ValueEnumerable<TEnumerator, decimal?>, TEnumerator, decimal?, decimal>();
    }
}