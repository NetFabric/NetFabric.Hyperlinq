using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        [Pure]
        public static bool Contains<TEnumerable, TEnumerator, TSource>(this TEnumerable source, TSource value, IEqualityComparer<TSource> comparer = null)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (comparer is null)
            {
                foreach (var item in source)
                {
                    if (EqualityComparer<TSource>.Default.Equals(item, value))
                        return true;
                }
            }
            else
            {
                foreach (var item in source)
                {
                    if (comparer.Equals(item, value))
                        return true;
                }
            }

            return false;
        }
    }
}
