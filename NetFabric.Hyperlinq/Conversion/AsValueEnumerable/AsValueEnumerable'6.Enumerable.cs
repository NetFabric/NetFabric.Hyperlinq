using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class EnumerableExtensions
    {
        
        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerable<TEnumerable, TEnumerator, TEnumerator, TSource, FunctionWrapper<TEnumerable, TEnumerator>, FunctionWrapper<TEnumerable, TEnumerator>> AsValueEnumerable<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TEnumerable, TEnumerator> getEnumerator)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : struct, IEnumerator<TSource>
            => AsValueEnumerable<TEnumerable, TEnumerator, TSource, FunctionWrapper<TEnumerable, TEnumerator>>(source, new FunctionWrapper<TEnumerable, TEnumerator>(getEnumerator));

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerable<TEnumerable, TEnumerator, TEnumerator, TSource, TGetEnumerator, TGetEnumerator> AsValueEnumerable<TEnumerable, TEnumerator, TSource, TGetEnumerator>(this TEnumerable source, TGetEnumerator getEnumerator = default)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : struct, IEnumerator<TSource>
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            => new(source, getEnumerator, getEnumerator);
        
        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource, FunctionWrapper<TEnumerable, TEnumerator>, FunctionWrapper<TEnumerable, TEnumerator2>> AsValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource>(this TEnumerable source, Func<TEnumerable, TEnumerator> getEnumerator, Func<TEnumerable, TEnumerator2> getEnumerator2)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : struct, IEnumerator<TSource>
            where TEnumerator2 : struct
            => AsValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource, FunctionWrapper<TEnumerable, TEnumerator>, FunctionWrapper<TEnumerable, TEnumerator2>>(source, new FunctionWrapper<TEnumerable, TEnumerator>(getEnumerator), new FunctionWrapper<TEnumerable, TEnumerator2>(getEnumerator2));

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource, TGetEnumerator, TGetEnumerator2> AsValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource, TGetEnumerator, TGetEnumerator2>(this TEnumerable source, TGetEnumerator getEnumerator = default, TGetEnumerator2 getEnumerator2 = default)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : struct, IEnumerator<TSource>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => new(source, getEnumerator, getEnumerator2);

        [StructLayout(LayoutKind.Auto)]
        public partial struct ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource, TGetEnumerator, TGetEnumerator2>
            : IValueEnumerable<TSource, TEnumerator> 
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : struct, IEnumerator<TSource>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
        {
            readonly TEnumerable source;
            TGetEnumerator getEnumerator;
            TGetEnumerator2 getEnumerator2;

            internal ValueEnumerable(TEnumerable source, TGetEnumerator getEnumerator, TGetEnumerator2 getEnumerator2)
                => (this.source, this.getEnumerator, this.getEnumerator2) = (source, getEnumerator, getEnumerator2);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly TEnumerator2 GetEnumerator() 
                => getEnumerator2.Invoke(source);
            readonly TEnumerator IValueEnumerable<TSource, TEnumerator>.GetEnumerator() 
                => getEnumerator.Invoke(source);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                => source.GetEnumerator();
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => source.GetEnumerator();
            
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource, TGetEnumerator, TGetEnumerator2> AsValueEnumerable()
                => this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly TEnumerable AsEnumerable()
                => source;

            public readonly TSource[] ToArray()
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
                
                using var arrayBuilder = ValueEnumerableExtensions.ToArrayBuilder<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource, TGetEnumerator, TGetEnumerator2>, TEnumerator, TSource>(this, ArrayPool<TSource>.Shared, false);
                return arrayBuilder.ToArray();
            }

            public readonly IMemoryOwner<TSource> ToArray(ArrayPool<TSource> pool, bool clearOnDispose = default)
            {
                // ReSharper disable once HeapView.PossibleBoxingAllocation
                if (source is ICollection<TSource> collection)
                {
                    if (collection.Count is 0)
                        return EmptyMemoryOwner<TSource>.Instance;

                    var result = pool.RentDisposable(collection.Count, clearOnDispose);
                    collection.CopyTo(result.Rented, 0);
                    return result;
                }

                using var arrayBuilder = ValueEnumerableExtensions.ToArrayBuilder<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource, TGetEnumerator, TGetEnumerator2>, TEnumerator, TSource>(this, pool, clearOnDispose);
                return arrayBuilder.ToArray(pool, clearOnDispose);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly List<TSource> ToList()
                => ToArray().AsList();

            #endregion
            
            #region Quantifier

            public bool Contains(TSource value, IEqualityComparer<TSource>? comparer = default)
            {
                // ReSharper disable once HeapView.PossibleBoxingAllocation
                if (comparer.UseDefaultComparer() && source is ICollection<TSource> collection)
                    return collection.Contains(value);

                return this.Contains<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource, TGetEnumerator, TGetEnumerator2>, TEnumerator, TSource>(value, comparer);
            }

            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, int, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IEnumerable<int>
            where TEnumerator : struct, IEnumerator<int>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => source.Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, int, TGetEnumerator, TGetEnumerator2>, TEnumerator, int, int>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, int?, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IEnumerable<int?>
            where TEnumerator : struct, IEnumerator<int?>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => source.Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, int?, TGetEnumerator, TGetEnumerator2>, TEnumerator, int?, int>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, nint, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IEnumerable<nint>
            where TEnumerator : struct, IEnumerator<nint>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => source.Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, nint, TGetEnumerator, TGetEnumerator2>, TEnumerator, nint, nint>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, nint?, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IEnumerable<nint?>
            where TEnumerator : struct, IEnumerator<nint?>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => source.Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, nint?, TGetEnumerator, TGetEnumerator2>, TEnumerator, nint?, nint>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, nuint, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IEnumerable<nuint>
            where TEnumerator : struct, IEnumerator<nuint>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => source.Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, nuint, TGetEnumerator, TGetEnumerator2>, TEnumerator, nuint, nuint>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, nuint?, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IEnumerable<nuint?>
            where TEnumerator : struct, IEnumerator<nuint?>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => source.Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, nuint?, TGetEnumerator, TGetEnumerator2>, TEnumerator, nuint?, nuint>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, long, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IEnumerable<long>
            where TEnumerator : struct, IEnumerator<long>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => source.Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, long, TGetEnumerator, TGetEnumerator2>, TEnumerator, long, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, long?, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IEnumerable<long?>
            where TEnumerator : struct, IEnumerator<long?>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => source.Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, long?, TGetEnumerator, TGetEnumerator2>, TEnumerator, long?, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, float, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IEnumerable<float>
            where TEnumerator : struct, IEnumerator<float>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => source.Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, float, TGetEnumerator, TGetEnumerator2>, TEnumerator, float, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, float?, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IEnumerable<float?>
            where TEnumerator : struct, IEnumerator<float?>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => source.Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, float?, TGetEnumerator, TGetEnumerator2>, TEnumerator, float?, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, double, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IEnumerable<double>
            where TEnumerator : struct, IEnumerator<double>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => source.Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, double, TGetEnumerator, TGetEnumerator2>, TEnumerator, double, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, double?, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IEnumerable<double?>
            where TEnumerator : struct, IEnumerator<double?>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => source.Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, double?, TGetEnumerator, TGetEnumerator2>, TEnumerator, double?, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, decimal, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IEnumerable<decimal>
            where TEnumerator : struct, IEnumerator<decimal>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => source.Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, decimal, TGetEnumerator, TGetEnumerator2>, TEnumerator, decimal, decimal>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerable, TEnumerator, TEnumerator2, TGetEnumerator, TGetEnumerator2>(this ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, decimal?, TGetEnumerator, TGetEnumerator2> source)
            where TEnumerable : IEnumerable<decimal?>
            where TEnumerator : struct, IEnumerator<decimal?>
            where TEnumerator2 : struct
            where TGetEnumerator : struct, IFunction<TEnumerable, TEnumerator>
            where TGetEnumerator2 : struct, IFunction<TEnumerable, TEnumerator2>
            => source.Sum<ValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, decimal?, TGetEnumerator, TGetEnumerator2>, TEnumerator, decimal?, decimal>();
    }
}