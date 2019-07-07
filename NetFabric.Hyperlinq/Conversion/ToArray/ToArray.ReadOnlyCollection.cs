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
                switch (source)
                {
                    case ICollection<TSource> collection:
                        collection.CopyTo(array, 0);
                        break;

                    default:
                        using (var enumerator = (TEnumerator)source.GetEnumerator())
                        {
                            for (var index = 0; enumerator.MoveNext(); index++)
                                array[index] = enumerator.Current;
                        }
                        break;
                }
            }
            return array;
        }    
    }
}