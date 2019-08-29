using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        [Pure]
        public static TSource[] ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
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
                    var index = 0;
                    foreach (var item in source)
                    {
                        array[index] = item;
                        checked { index++; }
                    }
                }
            }
            return array;
        }
    }
}
