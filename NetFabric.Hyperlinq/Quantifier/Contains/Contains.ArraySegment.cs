using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        public static bool Contains<TSource>(this in ArraySegment<TSource> source, TSource value)
            => source.Count switch
            {
                0 => false,
                _ => ((ICollection<TSource>)source).Contains(value)
            };

        public static bool Contains<TSource>(this in ArraySegment<TSource> source, TSource value, IEqualityComparer<TSource>? comparer)
            => source.AsSpan().Contains(value, comparer);
    }
}

