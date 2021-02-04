using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this Span<int> source)
            => ((ReadOnlySpan<int>)source).Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this Span<int?> source)
            => ((ReadOnlySpan<int?>)source).Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this Span<long> source)
            => ((ReadOnlySpan<long>)source).Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this Span<long?> source)
            => ((ReadOnlySpan<long?>)source).Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this Span<float> source)
            => ((ReadOnlySpan<float>)source).Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this Span<float?> source)
            => ((ReadOnlySpan<float?>)source).Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this Span<double> source)
            => ((ReadOnlySpan<double>)source).Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this Span<double?> source)
            => ((ReadOnlySpan<double?>)source).Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this Span<decimal> source)
            => ((ReadOnlySpan<decimal>)source).Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this Span<decimal?> source)
            => ((ReadOnlySpan<decimal?>)source).Sum();
    }
}

