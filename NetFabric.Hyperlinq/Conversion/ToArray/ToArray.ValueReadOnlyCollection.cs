using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        [Pure]
        public static TSource[] ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var array = new TSource[source.Count];
            if (source.Count != 0)
            {
                switch(source)
                {
                    case ICollection<TSource> collection:
                        collection.CopyTo(array, 0);
                        break;

                    default:
                        {
                            using var enumerator = source.GetEnumerator();
                            checked
                            {
                                for (var index = 0; enumerator.MoveNext(); index++)
                                    array[index] = enumerator.Current;
                            }
                        }
                        break;
                }
            }
            return array;
        }
    }
}
