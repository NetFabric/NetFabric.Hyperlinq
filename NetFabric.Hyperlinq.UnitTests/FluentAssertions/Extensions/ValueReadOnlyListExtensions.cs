using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq.UnitTests
{
    static class ValueReadOnlyListExtensions
    {
        public static int IndexOfFirstDifferenceWith<TEnumeratorFirst, TFirst, TSecond>(
            this IValueReadOnlyList<TFirst, TEnumeratorFirst> first, 
            IReadOnlyList<TSecond> second, 
            Func<TFirst, TSecond, bool> equalityComparison)
            where TEnumeratorFirst : struct, IValueEnumerator<TFirst>
        {
            if (first.Count != second.Count)
                return (int)Math.Min(first.Count, second.Count);

            for (var index = 0; index < first.Count; index++)
            {
                if (!equalityComparison(first[index], second[index]))
                    return index;
            }

            return -1;
        }
    }
}