using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        static List<T> ToList<T>(IEnumerable<T> source)
            => new List<T>(source);
    }
}