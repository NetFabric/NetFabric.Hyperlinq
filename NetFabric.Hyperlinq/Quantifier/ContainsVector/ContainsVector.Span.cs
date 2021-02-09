using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
#if NET5_0

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsVector<TSource>(this Span<TSource> source, TSource value)
            where TSource : struct
            => ((ReadOnlySpan<TSource>)source).ContainsVector(value);

#endif
    }
}

