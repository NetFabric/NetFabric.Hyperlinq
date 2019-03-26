using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class AsEnumerableExtensions
    {
        public static IEnumerable<TSource> AsEnumerable<TSource>(this IEnumerable<TSource> source)
            => source;
    }
}
