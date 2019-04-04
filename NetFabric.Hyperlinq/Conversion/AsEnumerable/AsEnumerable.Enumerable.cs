using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> AsEnumerable<TEnumerable, TSource>(this TEnumerable source)
            where TEnumerable : IEnumerable<TSource>
            => source;
    }
}