using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> First<TSource>(this in ArraySegment<TSource> source)
            => source.Count switch
            {
                0 => Option.None,
                _ => Option.Some(source.Array![source.Offset])
            };
    }
}
