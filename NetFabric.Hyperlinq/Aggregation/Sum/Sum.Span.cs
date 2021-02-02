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
    }
}

