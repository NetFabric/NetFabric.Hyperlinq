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
        public static SkipEnumerable<TEnumerable, TEnumerator, TSource> Skip<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int count)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => new(in source, count);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct SkipEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueEnumerable<TSource, SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly int count;

            internal SkipEnumerable(in TEnumerable source, int count)
            {
                this.source = source;
                this.count = count;
            }

            
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

                internal Enumerator(in SkipEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
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
                    while (counter > 0)
                    {
                        if (!enumerator.MoveNext())
                            return false;

                        counter--;
                    }

                    return enumerator.MoveNext();
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public void Dispose() 
                    => enumerator.Dispose();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipEnumerable<TEnumerable, TEnumerator, TSource> AsValueEnumerable()
                => this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipEnumerable<TEnumerable, TEnumerator, TSource> Skip(int count)
                => source.Skip<TEnumerable, TEnumerator, TSource>(this.count + count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> Take(int count)
                => source.SkipTake<TEnumerable, TEnumerator, TSource>(this.count, count);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerable, TEnumerator>(this SkipEnumerable<TEnumerable, TEnumerator, int> source)
            where TEnumerable : IValueEnumerable<int, TEnumerator>
            where TEnumerator : struct, IEnumerator<int>
            => source.Sum<SkipEnumerable<TEnumerable, TEnumerator, int>, SkipEnumerable<TEnumerable, TEnumerator, int>.Enumerator, int, int>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerable, TEnumerator>(this SkipEnumerable<TEnumerable, TEnumerator, int?> source)
            where TEnumerable : IValueEnumerable<int?, TEnumerator>
            where TEnumerator : struct, IEnumerator<int?>
            => source.Sum<SkipEnumerable<TEnumerable, TEnumerator, int?>, SkipEnumerable<TEnumerable, TEnumerator, int?>.Enumerator, int?, int>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerable, TEnumerator>(this SkipEnumerable<TEnumerable, TEnumerator, long> source)
            where TEnumerable : IValueEnumerable<long, TEnumerator>
            where TEnumerator : struct, IEnumerator<long>
            => source.Sum<SkipEnumerable<TEnumerable, TEnumerator, long>, SkipEnumerable<TEnumerable, TEnumerator, long>.Enumerator, long, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerable, TEnumerator>(this SkipEnumerable<TEnumerable, TEnumerator, long?> source)
            where TEnumerable : IValueEnumerable<long?, TEnumerator>
            where TEnumerator : struct, IEnumerator<long?>
            => source.Sum<SkipEnumerable<TEnumerable, TEnumerator, long?>, SkipEnumerable<TEnumerable, TEnumerator, long?>.Enumerator, long?, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerable, TEnumerator>(this SkipEnumerable<TEnumerable, TEnumerator, float> source)
            where TEnumerable : IValueEnumerable<float, TEnumerator>
            where TEnumerator : struct, IEnumerator<float>
            => source.Sum<SkipEnumerable<TEnumerable, TEnumerator, float>, SkipEnumerable<TEnumerable, TEnumerator, float>.Enumerator, float, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerable, TEnumerator>(this SkipEnumerable<TEnumerable, TEnumerator, float?> source)
            where TEnumerable : IValueEnumerable<float?, TEnumerator>
            where TEnumerator : struct, IEnumerator<float?>
            => source.Sum<SkipEnumerable<TEnumerable, TEnumerator, float?>, SkipEnumerable<TEnumerable, TEnumerator, float?>.Enumerator, float?, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerable, TEnumerator>(this SkipEnumerable<TEnumerable, TEnumerator, double> source)
            where TEnumerable : IValueEnumerable<double, TEnumerator>
            where TEnumerator : struct, IEnumerator<double>
            => source.Sum<SkipEnumerable<TEnumerable, TEnumerator, double>, SkipEnumerable<TEnumerable, TEnumerator, double>.Enumerator, double, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerable, TEnumerator>(this SkipEnumerable<TEnumerable, TEnumerator, double?> source)
            where TEnumerable : IValueEnumerable<double?, TEnumerator>
            where TEnumerator : struct, IEnumerator<double?>
            => source.Sum<SkipEnumerable<TEnumerable, TEnumerator, double?>, SkipEnumerable<TEnumerable, TEnumerator, double?>.Enumerator, double?, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerable, TEnumerator>(this SkipEnumerable<TEnumerable, TEnumerator, decimal> source)
            where TEnumerable : IValueEnumerable<decimal, TEnumerator>
            where TEnumerator : struct, IEnumerator<decimal>
            => source.Sum<SkipEnumerable<TEnumerable, TEnumerator, decimal>, SkipEnumerable<TEnumerable, TEnumerator, decimal>.Enumerator, decimal, decimal>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerable, TEnumerator>(this SkipEnumerable<TEnumerable, TEnumerator, decimal?> source)
            where TEnumerable : IValueEnumerable<decimal?, TEnumerator>
            where TEnumerator : struct, IEnumerator<decimal?>
            => source.Sum<SkipEnumerable<TEnumerable, TEnumerator, decimal?>, SkipEnumerable<TEnumerable, TEnumerator, decimal?>.Enumerator, decimal?, decimal>();
    }
}
