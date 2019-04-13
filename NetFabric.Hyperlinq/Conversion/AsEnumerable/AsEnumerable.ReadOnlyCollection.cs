using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        public static IReadOnlyCollection<TSource> AsEnumerable<TEnumerable, TSource>(this TEnumerable source)
            where TEnumerable : IReadOnlyCollection<TSource>
            => source;
    }
}