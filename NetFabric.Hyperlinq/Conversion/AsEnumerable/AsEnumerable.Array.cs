using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static IEnumerable<TSource> AsEnumerable<TSource>(this TSource[] source)
            => source;
    }
}