using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static TSource[] ToArray<TEnumerable, TSource>(this TEnumerable source)
            where TEnumerable : IReadOnlyList<TSource>
        {
            var count = source.Count;
            var array = new TSource[count];
            if (source is ICollection<TSource> collection)
            {
                collection.CopyTo(array, 0);
            }
            else
            {
                for (var index = 0; index < count; index++)
                    array[index] = source[index];
            }
            return array;
        }
    }
}
