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

            public ValueEnumerable<TSource> AsValueEnumerable()
                => this;

            public IEnumerable<TSource> AsEnumerable()
                => source;

            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this ValueEnumerable<int> source)
            => source.Sum<ValueEnumerable<int>, ValueEnumerator<int>, int, int>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this ValueEnumerable<int?> source)
            => source.Sum<ValueEnumerable<int?>, ValueEnumerator<int?>, int?, int>();

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