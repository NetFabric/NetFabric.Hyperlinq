using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        public static bool Contains<TEnumerable, TEnumerator, TSource>(this TEnumerable source, TSource value, IEqualityComparer<TSource> comparer = null)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (comparer is null)
            {
                using (var enumerator = source.GetValueEnumerator())
                {
                    while (enumerator.TryMoveNext(out var current))
                    {
                        if (EqualityComparer<TSource>.Default.Equals(current, value))
                            return true;
                    }
                }
            }
            else
            {
                using (var enumerator = source.GetValueEnumerator())
                {
                    while (enumerator.TryMoveNext(out var current))
                    {
                        if (comparer.Equals(current, value))
                            return true;
                    }
                }
            }

            return false;
        }
    }
}
