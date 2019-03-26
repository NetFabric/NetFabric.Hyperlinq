using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class AsReadOnlyListExtensions
    {
        public static IReadOnlyList<TSource> AsReadOnlyList<TSource>(this IReadOnlyList<TSource> source)
            => source;
    }
}
