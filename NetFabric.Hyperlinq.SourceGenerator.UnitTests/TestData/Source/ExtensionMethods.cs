using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static class ExtensionMethods
    {
        public static void ExtensionMethod<TEnumerable, TEnumerator, TSource>(this TEnumerable _)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : struct, IEnumerator<TSource>
        { }
    }

}
