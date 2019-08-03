using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq.UnitTests
{
    static class ValueEnumerableExtensions
    {
        public static int IndexOfFirstDifferenceWith<TEnumeratorFirst, TFirst, TSecond>(
            this IValueEnumerable<TFirst, TEnumeratorFirst> first, 
            IEnumerable<TSecond> second, 
            Func<TFirst, TSecond, bool> equalityComparison)
            where TEnumeratorFirst : struct, IEnumerator<TFirst>
        {
            using (var firstEnumerator = first.GetEnumerator())
            using (var secondEnumerator = second.GetEnumerator())  
            {
                var index = 0;
                while (true)
                {
                    var isFirstCompleted = !firstEnumerator.MoveNext();
                    var isSecondCompleted = !secondEnumerator.MoveNext();

                    if (isFirstCompleted && isSecondCompleted)
                        return -1;

                    if (isFirstCompleted ^ isSecondCompleted)
                        return index;

                    if (!equalityComparison(firstEnumerator.Current, secondEnumerator.Current))
                        return index;

                    index++;
                }
            }
        }
    }
}