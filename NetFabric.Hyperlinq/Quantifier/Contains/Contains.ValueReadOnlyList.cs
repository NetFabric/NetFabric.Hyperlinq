using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        public static bool Contains<TEnumerable, TEnumerator, TSource>(this TEnumerable source, TSource value, IEqualityComparer<TSource> comparer = null)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => Contains<TEnumerable, TEnumerator, TSource>(source, value, comparer, 0, source.Count);

        static bool Contains<TEnumerable, TEnumerator, TSource>(this TEnumerable source, TSource value, IEqualityComparer<TSource> comparer, int skipCount, int takeCount)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (takeCount != 0)
            {
                if (comparer is null)
                {
                    for (var index = skipCount; index < takeCount; index++)
                    {
                        if (EqualityComparer<TSource>.Default.Equals(source[index], value))
                            return true;
                    }
                }
                else
                {
                    for (var index = skipCount; index < takeCount; index++)
                    {
                        if (comparer.Equals(source[index], value))
                            return true;
                    }
                }
            }
            return false;
        }
    }
}

