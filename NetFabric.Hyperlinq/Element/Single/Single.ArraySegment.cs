using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> Single<TSource>(this in ArraySegment<TSource> source)
            => source.Count switch
            {
                1 => Option.Some(source.Array![source.Offset]),
                _ => Option.None
            };
    }
}
