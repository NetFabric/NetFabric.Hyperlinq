using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static IReadOnlyCollection<TSource> AsReadOnlyCollection<TSource>(this TSource[] source)
            => source;
    }
}