using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        public static bool Contains<TEnumerable, TEnumerator, TSource>(this TEnumerable source, TSource value, IEqualityComparer<TSource> comparer = null)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            var count = source.Count();
            if (count == 0) return false;

            if (comparer is null)
            {
                for (var index = 0; index < count; index++)
                {
                    if (EqualityComparer<TSource>.Default.Equals(source[index], value))
                        return true;
                }
            }
            else
            {
                for (var index = 0; index < count; index++)
                {
                    if (comparer.Equals(source[index], value))
                        return true;
                }
            }

            return false;
        }
    }
}

