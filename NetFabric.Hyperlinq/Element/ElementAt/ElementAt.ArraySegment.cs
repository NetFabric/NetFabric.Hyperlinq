using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> ElementAt<TSource>(this in ArraySegment<TSource> source, int index)
            => index < 0 || index >= source.Count
                ? Option.None
                : Option.Some(source.Array![index + source.Offset]);
    }
}
