using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this ReadOnlyMemory<TSource> source)
            => source.Length != 0;
    }
}

