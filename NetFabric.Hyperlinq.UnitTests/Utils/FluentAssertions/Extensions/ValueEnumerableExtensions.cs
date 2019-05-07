using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq.UnitTests
{
    static class ValueEnumerableExtensions
    {
        public static int IndexOfFirstDifferenceWith<TEnumeratorFirst, TFirst, TSecond>(
            this IValueEnumerable<TFirst, TEnumeratorFirst> first, 
            IEnumerable<TSecond> second)
            where TEnumeratorFirst : struct, IValueEnumerator<TFirst>
        {
            using (var firstEnumerator = first.GetValueEnumerator())
            using (var secondEnumerator = second.GetEnumerator())  
            {
                var index = 0;
                while (true)
                {
                    var isFirstCompleted = !firstEnumerator.TryMoveNext();
                    var isSecondCompleted = !secondEnumerator.MoveNext();

                    if (isFirstCompleted && isSecondCompleted)
                        return -1;

                    if (isFirstCompleted ^ isSecondCompleted)
                        return index;

                    index++;
                }
            }
        }

        public static int IndexOfFirstDifferenceWith<TEnumeratorFirst, TFirst, TSecond>(
            this IValueEnumerable<TFirst, TEnumeratorFirst> first, 
            IEnumerable<TSecond> second, 
            Func<TFirst, TSecond, bool> equalityComparison)
            where TEnumeratorFirst : struct, IValueEnumerator<TFirst>
        {
            using (var firstEnumerator = first.GetValueEnumerator())
            using (var secondEnumerator = second.GetEnumerator())  
            {
                var index = 0;
                while (true)
                {
                    var isFirstCompleted = !firstEnumerator.TryMoveNext(out var firstCurrent);
                    var isSecondCompleted = !secondEnumerator.MoveNext();

                    if (isFirstCompleted && isSecondCompleted)
                        return -1;

                    if (isFirstCompleted ^ isSecondCompleted)
                        return index;

                    if (!equalityComparison(firstCurrent, secondEnumerator.Current))
                        return index;

                    index++;
                }
            }
        }
    }
}