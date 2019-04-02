using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static List<TSource> ToList<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            var list = new List<TSource>();
            using (var enumerator = Dynamic.GetEnumerator<TEnumerable, TEnumerator, TSource>.Invoke(source))
            {
                while (enumerator.MoveNext())
                    list.Add(enumerator.Current);
            }
            return list;
        }
    }
}
