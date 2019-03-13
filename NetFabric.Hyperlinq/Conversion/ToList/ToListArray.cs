using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static List<TSource> ToList<TSource>(this TSource[] source)
            => new List<TSource>(source);
    }
}
