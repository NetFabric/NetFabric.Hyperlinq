using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static List<T> ToList<T>(IEnumerable<T> source)
        {
            var list = new List<T>();
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
                list.Add(enumerator.Current);
            return list;
        }
    }
}