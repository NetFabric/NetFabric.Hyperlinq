using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class AsReadOnlyCollectionExtensions
    {
        public static IReadOnlyCollection<TSource> AsReadOnlyCollection<TSource>(this IReadOnlyCollection<TSource> source)
            => source;
    }
}
