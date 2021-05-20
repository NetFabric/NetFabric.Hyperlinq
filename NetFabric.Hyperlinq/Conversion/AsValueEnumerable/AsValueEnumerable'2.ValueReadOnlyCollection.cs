using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollectionExtensions
    {

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerable<TEnumerator, TSource> AsValueEnumerable<TEnumerator, TSource>(this IValueReadOnlyCollection<TSource, TEnumerator> source)
            where TEnumerator : struct, IEnumerator<TSource>
            => new(source);

        [GeneratorBindings(source: "source", sourceImplements: "IValueReadOnlyCollection`2,IValueEnumerable`2", enumerableType: "IValueReadOnlyCollection<TSource, TEnumerator>")]
        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ValueEnumerable<TEnumerator, TSource>
            : IValueReadOnlyCollection<TSource, TEnumerator>
            , ICollection<TSource>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly IValueReadOnlyCollection<TSource, TEnumerator> source;

            internal ValueEnumerable(IValueReadOnlyCollection<TSource, TEnumerator> source) 
                => this.source = source;

            public int Count
                => source.Count;

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TEnumerator GetEnumerator() 
                => source.GetEnumerator();
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => source.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => source.GetEnumerator();

            bool ICollection<TSource>.IsReadOnly  
                => true;

            public void CopyTo(Span<TSource> span)
            {
                if (Count is 0)
                    return;
                
                if (span.Length < Count)
                    Throw.ArgumentException(Resource.DestinationNotLongEnough, nameof(span));

                using var enumerator = GetEnumerator();
                checked
                {
                    for (var index = 0; enumerator.MoveNext(); index++)
                        span[index] = enumerator.Current;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void CopyTo(TSource[] array, int arrayIndex)
                => CopyTo(array.AsSpan().Slice(arrayIndex));


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource item)
                => Count is not 0 && source.Contains(item);

            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Add(TSource item) 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Clear() 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            bool ICollection<TSource>.Remove(TSource item) 
                => Throw.NotSupportedException<bool>();
            
            #region Conversion

            public ValueEnumerable<TEnumerator, TSource> AsValueEnumerable()
                => this;

            public IReadOnlyCollection<TSource> AsEnumerable()
                => source;

            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source)
            where TEnumerator : struct, IEnumerator<TSource>
            => source.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerator>(this ValueEnumerable<TEnumerator, int> source)
            where TEnumerator : struct, IEnumerator<int>
            => Sum<ValueEnumerable<TEnumerator, int>, TEnumerator, int, int>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerator>(this ValueEnumerable<TEnumerator, int?> source)
            where TEnumerator : struct, IEnumerator<int?>
            => Sum<ValueEnumerable<TEnumerator, int?>, TEnumerator, int?, int>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerator>(this ValueEnumerable<TEnumerator, long> source)
            where TEnumerator : struct, IEnumerator<long>
            => Sum<ValueEnumerable<TEnumerator, long>, TEnumerator, long, long>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerator>(this ValueEnumerable<TEnumerator, long?> source)
            where TEnumerator : struct, IEnumerator<long?>
            => Sum<ValueEnumerable<TEnumerator, long?>, TEnumerator, long?, long>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerator>(this ValueEnumerable<TEnumerator, float> source)
            where TEnumerator : struct, IEnumerator<float>
            => Sum<ValueEnumerable<TEnumerator, float>, TEnumerator, float, float>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerator>(this ValueEnumerable<TEnumerator, float?> source)
            where TEnumerator : struct, IEnumerator<float?>
            => Sum<ValueEnumerable<TEnumerator, float?>, TEnumerator, float?, float>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerator>(this ValueEnumerable<TEnumerator, double> source)
            where TEnumerator : struct, IEnumerator<double>
            => Sum<ValueEnumerable<TEnumerator, double>, TEnumerator, double, double>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerator>(this ValueEnumerable<TEnumerator, double?> source)
            where TEnumerator : struct, IEnumerator<double?>
            => Sum<ValueEnumerable<TEnumerator, double?>, TEnumerator, double?, double>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerator>(this ValueEnumerable<TEnumerator, decimal> source)
            where TEnumerator : struct, IEnumerator<decimal>
            => Sum<ValueEnumerable<TEnumerator, decimal>, TEnumerator, decimal, decimal>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerator>(this ValueEnumerable<TEnumerator, decimal?> source)
            where TEnumerator : struct, IEnumerator<decimal?>
            => Sum<ValueEnumerable<TEnumerator, decimal?>, TEnumerator, decimal?, decimal>(source);
    }
}