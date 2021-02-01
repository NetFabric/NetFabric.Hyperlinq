using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> ElementAt<TSource>(this TSource[] source, int index)
            => source.AsSpan().ElementAt(index);
    }
}
