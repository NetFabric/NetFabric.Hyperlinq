using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static bool Contains<TEnumerable, TSource>(this TEnumerable source, TSource value, IEqualityComparer<TSource> comparer = null)
            where TEnumerable : IReadOnlyList<TSource>
        {
            var sourceCount = source.Count;
            if (sourceCount == 0) return false;

            if (comparer is null)
            {
                for (var index = 0; index < sourceCount; index++)
                {
                    if (EqualityComparer<TSource>.Default.Equals(source[index], value))
                        return true;
                }
            }
            else
            {
                for (var index = 0; index < sourceCount; index++)
                {
                    if (comparer.Equals(source[index], value))
                        return true;
                }
            }

            return false;
        }
    }
}

