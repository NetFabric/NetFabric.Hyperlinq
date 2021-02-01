using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Copy<TSource>(TSource[] source, Span<TSource> destination)
        {
            Debug.Assert(destination.Length >= source.Length);

            source.CopyTo(destination);
        }
    }
}
