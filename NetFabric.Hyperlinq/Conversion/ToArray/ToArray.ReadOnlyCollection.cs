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
                if (source is ICollection<TSource> collection)
                {
                    collection.CopyTo(array, 0);
                }
                else
                {
                    using (var enumerator = source.GetEnumerator())
                    {
                        for (var index = 0; enumerator.MoveNext(); index++)
                            array[index] = enumerator.Current;
                    }
                }
            }
            return array;
        }    
    }
}