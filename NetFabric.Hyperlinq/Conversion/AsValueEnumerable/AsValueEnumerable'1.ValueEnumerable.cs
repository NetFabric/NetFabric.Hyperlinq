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

            public ValueEnumerable<TEnumerator, TSource> AsValueEnumerable()
                => this;

            public IEnumerable<TSource> AsEnumerable()
                => source;

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