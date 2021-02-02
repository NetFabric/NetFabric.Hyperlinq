using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this ReadOnlyMemory<int> source)
            => source.Span.Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this ReadOnlyMemory<int?> source)
            => source.Span.Sum();
    }
}

