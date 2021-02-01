using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
// ReSharper disable HeapView.ObjectAllocation.Evident

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> ToList<TSource>(this in ArraySegment<TSource> source)
            // ReSharper disable once HeapView.BoxingAllocation
            => source.Count switch
            {
                0 => new List<TSource>(),
                _ => new(collection: source)
            };
    }
}