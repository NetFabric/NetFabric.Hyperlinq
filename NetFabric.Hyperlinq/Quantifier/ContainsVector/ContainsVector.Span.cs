using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool ContainsVector<TSource>(this Span<TSource> source, TSource value)
            where TSource : struct
            => source.AsReadOnlySpan().ContainsVector(value);

    }
}

