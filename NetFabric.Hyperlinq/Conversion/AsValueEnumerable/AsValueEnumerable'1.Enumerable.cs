using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class EnumerableExtensions
    {

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerable<TSource> AsValueEnumerable<TSource>(this IEnumerable<TSource> source)
            => new(source);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ValueEnumerable<TSource>
            : IValueEnumerable<TSource, ValueEnumerator<TSource>>
        {
            readonly IEnumerable<TSource> source;

            internal ValueEnumerable(IEnumerable<TSource> source) 
                => this.source = source;

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueEnumerator<TSource> GetEnumerator() 
                => new(source.GetEnumerator());
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                => source.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() 
                => source.GetEnumerator();
            
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueEnumerable<TSource> AsValueEnumerable()
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
                
                using var arrayBuilder = ValueEnumerableExtensions.ToArrayBuilder<ValueEnumerable<TSource>, ValueEnumerator<TSource>, TSource>(this, ArrayPool<TSource>.Shared, false);
                return arrayBuilder.ToArray();
            }

            public Lease<TSource> ToArray(ArrayPool<TSource> pool, bool clearOnDispose = default)
            {
                // ReSharper disable once HeapView.PossibleBoxingAllocation
                if (source is ICollection<TSource> collection)
                {
                    if (collection.Count is 0)
                        return Lease<TSource>.Default;
                
                    var result = pool.Lease(collection.Count, clearOnDispose);
                    collection.CopyTo(result.Rented, 0);
                    return result;                
                }

                using var arrayBuilder = ValueEnumerableExtensions.ToArrayBuilder<ValueEnumerable<TSource>, ValueEnumerator<TSource>, TSource>(this, pool, clearOnDispose);
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

                return this.Contains<ValueEnumerable<TSource>, ValueEnumerator<TSource>, TSource>(value, comparer);
            }

            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this ValueEnumerable<int> source)
            => source.Sum<ValueEnumerable<int>, ValueEnumerator<int>, int, int>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this ValueEnumerable<int?> source)
            => source.Sum<ValueEnumerable<int?>, ValueEnumerator<int?>, int?, int>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum(this ValueEnumerable<nint> source)
            => source.Sum<ValueEnumerable<nint>, ValueEnumerator<nint>, nint, nint>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum(this ValueEnumerable<nint?> source)
            => source.Sum<ValueEnumerable<nint?>, ValueEnumerator<nint?>, nint?, nint>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum(this ValueEnumerable<nuint> source)
            => source.Sum<ValueEnumerable<nuint>, ValueEnumerator<nuint>, nuint, nuint>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum(this ValueEnumerable<nuint?> source)
            => source.Sum<ValueEnumerable<nuint?>, ValueEnumerator<nuint?>, nuint?, nuint>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this ValueEnumerable<long> source)
            => source.Sum<ValueEnumerable<long>, ValueEnumerator<long>, long, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this ValueEnumerable<long?> source)
            => source.Sum<ValueEnumerable<long?>, ValueEnumerator<long?>, long?, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this ValueEnumerable<float> source)
            => source.Sum<ValueEnumerable<float>, ValueEnumerator<float>, float, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this ValueEnumerable<float?> source)
            => source.Sum<ValueEnumerable<float?>, ValueEnumerator<float?>, float?, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this ValueEnumerable<double> source)
            => source.Sum<ValueEnumerable<double>, ValueEnumerator<double>, double, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this ValueEnumerable<double?> source)
            => source.Sum<ValueEnumerable<double?>, ValueEnumerator<double?>, double?, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this ValueEnumerable<decimal> source)
            => source.Sum<ValueEnumerable<decimal>, ValueEnumerator<decimal>, decimal, decimal>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this ValueEnumerable<decimal?> source)
            => source.Sum<ValueEnumerable<decimal?>, ValueEnumerator<decimal?>, decimal?, decimal>();
    }
}