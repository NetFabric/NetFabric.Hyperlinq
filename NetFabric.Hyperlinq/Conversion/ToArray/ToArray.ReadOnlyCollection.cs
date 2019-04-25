using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        public static TSource[] ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            var array = new TSource[source.Count];
            if (source.Count != 0)
            {
                var index = 0;
                using (var enumerator = source.GetEnumerator())
                {
                    unchecked // always less than source.Count
                    {
                        while (enumerator.MoveNext())
                        {
                            array[index] = enumerator.Current;
                            index++;
                        }
                    }
                }
            }
            return array;
        }    
    }
}