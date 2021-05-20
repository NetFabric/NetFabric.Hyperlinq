using System;
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
        public static TakeEnumerable<TEnumerable, TEnumerator, TSource> Take<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int count)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => new(in source, count);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct TakeEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueEnumerable<TSource, TakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly int count;

            internal TakeEnumerable(in TEnumerable source, int count)
            {
                this.source = source;
                this.count = count;
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() 
                => new(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new Enumerator(in this);

            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator
                : IEnumerator<TSource>
            {
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TEnumerator enumerator; // do not make readonly
                int counter;

                internal Enumerator(in TakeEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    counter = enumerable.count;
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
                    if (counter > 0)
                    {
                        if (enumerator.MoveNext())
                        {
                            counter--;
                            return true;
                        }

                        counter = 0;
                    }
                    return false; 
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public void Dispose() 
                    => enumerator.Dispose();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TakeEnumerable<TEnumerable, TEnumerator, TSource> AsValueEnumerable()
                => this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TakeEnumerable<TEnumerable, TEnumerator, TSource> Take(int count)
                => source.Take<TEnumerable, TEnumerator, TSource>(Math.Min(this.count, count));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerable, TEnumerator>(this TakeEnumerable<TEnumerable, TEnumerator, int> source)
            where TEnumerable : IValueEnumerable<int, TEnumerator>
            where TEnumerator : struct, IEnumerator<int>
            => source.Sum<TakeEnumerable<TEnumerable, TEnumerator, int>, TakeEnumerable<TEnumerable, TEnumerator, int>.Enumerator, int, int>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerable, TEnumerator>(this TakeEnumerable<TEnumerable, TEnumerator, int?> source)
            where TEnumerable : IValueEnumerable<int?, TEnumerator>
            where TEnumerator : struct, IEnumerator<int?>
            => source.Sum<TakeEnumerable<TEnumerable, TEnumerator, int?>, TakeEnumerable<TEnumerable, TEnumerator, int?>.Enumerator, int?, int>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerable, TEnumerator>(this TakeEnumerable<TEnumerable, TEnumerator, long> source)
            where TEnumerable : IValueEnumerable<long, TEnumerator>
            where TEnumerator : struct, IEnumerator<long>
            => source.Sum<TakeEnumerable<TEnumerable, TEnumerator, long>, TakeEnumerable<TEnumerable, TEnumerator, long>.Enumerator, long, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerable, TEnumerator>(this TakeEnumerable<TEnumerable, TEnumerator, long?> source)
            where TEnumerable : IValueEnumerable<long?, TEnumerator>
            where TEnumerator : struct, IEnumerator<long?>
            => source.Sum<TakeEnumerable<TEnumerable, TEnumerator, long?>, TakeEnumerable<TEnumerable, TEnumerator, long?>.Enumerator, long?, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerable, TEnumerator>(this TakeEnumerable<TEnumerable, TEnumerator, float> source)
            where TEnumerable : IValueEnumerable<float, TEnumerator>
            where TEnumerator : struct, IEnumerator<float>
            => source.Sum<TakeEnumerable<TEnumerable, TEnumerator, float>, TakeEnumerable<TEnumerable, TEnumerator, float>.Enumerator, float, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerable, TEnumerator>(this TakeEnumerable<TEnumerable, TEnumerator, float?> source)
            where TEnumerable : IValueEnumerable<float?, TEnumerator>
            where TEnumerator : struct, IEnumerator<float?>
            => source.Sum<TakeEnumerable<TEnumerable, TEnumerator, float?>, TakeEnumerable<TEnumerable, TEnumerator, float?>.Enumerator, float?, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerable, TEnumerator>(this TakeEnumerable<TEnumerable, TEnumerator, double> source)
            where TEnumerable : IValueEnumerable<double, TEnumerator>
            where TEnumerator : struct, IEnumerator<double>
            => source.Sum<TakeEnumerable<TEnumerable, TEnumerator, double>, TakeEnumerable<TEnumerable, TEnumerator, double>.Enumerator, double, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerable, TEnumerator>(this TakeEnumerable<TEnumerable, TEnumerator, double?> source)
            where TEnumerable : IValueEnumerable<double?, TEnumerator>
            where TEnumerator : struct, IEnumerator<double?>
            => source.Sum<TakeEnumerable<TEnumerable, TEnumerator, double?>, TakeEnumerable<TEnumerable, TEnumerator, double?>.Enumerator, double?, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerable, TEnumerator>(this TakeEnumerable<TEnumerable, TEnumerator, decimal> source)
            where TEnumerable : IValueEnumerable<decimal, TEnumerator>
            where TEnumerator : struct, IEnumerator<decimal>
            => source.Sum<TakeEnumerable<TEnumerable, TEnumerator, decimal>, TakeEnumerable<TEnumerable, TEnumerator, decimal>.Enumerator, decimal, decimal>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerable, TEnumerator>(this TakeEnumerable<TEnumerable, TEnumerator, decimal?> source)
            where TEnumerable : IValueEnumerable<decimal?, TEnumerator>
            where TEnumerator : struct, IEnumerator<decimal?>
            => source.Sum<TakeEnumerable<TEnumerable, TEnumerator, decimal?>, TakeEnumerable<TEnumerable, TEnumerator, decimal?>.Enumerator, decimal?, decimal>();
    }
}