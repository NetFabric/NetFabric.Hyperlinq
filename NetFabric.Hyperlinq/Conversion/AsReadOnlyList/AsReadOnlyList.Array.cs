using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static IReadOnlyList<TSource> AsReadOnlyList<TSource>(this TSource[] source)
            => source;
    }
}