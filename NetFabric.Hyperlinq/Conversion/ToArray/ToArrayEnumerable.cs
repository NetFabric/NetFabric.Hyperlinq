using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static TSource[] ToArray<TEnumerable, TSource>(this TEnumerable source)
            where TEnumerable : IEnumerable<TSource>
        {
            // use LINQ's implementation...
            return System.Linq.Enumerable.ToArray(source);
        }
    }
}
