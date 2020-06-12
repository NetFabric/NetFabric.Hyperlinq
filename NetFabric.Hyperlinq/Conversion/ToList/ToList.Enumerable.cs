using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class EnumerableExtensions
    {
        static List<T> ToList<T>(IEnumerable<T> source)
            => new List<T>(source);
    }
}