using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        public static bool Contains<TEnumerable, TEnumerator, TSource>(this TEnumerable source, TSource value, IEqualityComparer<TSource> comparer = null)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (source.Count != 0)
            {
                if (comparer is null)
                {
                    using (var enumerator = source.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            if (EqualityComparer<TSource>.Default.Equals(enumerator.Current, value))
                                return true;
                        }
                    }
                }
                else
                {
                    using (var enumerator = source.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            if (comparer.Equals(enumerator.Current, value))
                                return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}

