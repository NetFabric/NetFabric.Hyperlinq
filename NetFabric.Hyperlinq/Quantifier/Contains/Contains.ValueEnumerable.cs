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
            using var enumerator = source.GetEnumerator();
            if (comparer is null)
            {
                while (enumerator.MoveNext())
                {
                    if (EqualityComparer<TSource>.Default.Equals(enumerator.Current, value))
                        return true;
                }
            }
            else
            {
                while (enumerator.MoveNext())
                {
                    if (comparer.Equals(enumerator.Current, value))
                        return true;
                }
            }

            return false;
        }
    }
}
