using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        public static int Count<T>(this IReadOnlyCollection<T> source) =>
            source.Count;
    }
}

