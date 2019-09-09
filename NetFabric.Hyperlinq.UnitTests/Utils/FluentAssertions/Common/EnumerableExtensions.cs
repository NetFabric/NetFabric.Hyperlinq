using System;
using System.Collections;
using System.Collections.Generic;

namespace FluentAssertions.Common
{
    static class EnumerableExtensions
    {
        public static int IndexOfFirstDifferenceWith(this IEnumerable first, IEnumerable second)
        {
            var firstEnumerator = first.GetEnumerator();
            var secondEnumerator = second.GetEnumerator();
            var index = 0;
            checked
            {
                while (true)
                {
                    var isFirstCompleted = !firstEnumerator.MoveNext();
                    var isSecondCompleted = !secondEnumerator.MoveNext();

                    if (isFirstCompleted && isSecondCompleted)
                        return -1;

                    if (isFirstCompleted ^ isSecondCompleted)
                        return index;

                    if (!firstEnumerator.Current.Equals(secondEnumerator.Current))
                        return index;

                    index++;
                }
            }
        }

        public static int IndexOfFirstDifferenceWith<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            using var firstEnumerator = first.GetEnumerator();
            using var secondEnumerator = second.GetEnumerator();
            var index = 0;
            checked
            {
                while (true)
                {
                    var isFirstCompleted = !firstEnumerator.MoveNext();
                    var isSecondCompleted = !secondEnumerator.MoveNext();

                    if (isFirstCompleted && isSecondCompleted)
                        return -1;

                    if (isFirstCompleted ^ isSecondCompleted)
                        return index;

                    if (!EqualityComparer<T>.Default.Equals(firstEnumerator.Current, secondEnumerator.Current))
                        return index;

                    index++;
                }
            }
        }

        public static int IndexOfFirstDifferenceWith<T>(this IReadOnlyList<T> first, IEnumerable<T> second)
        {
            using var secondEnumerator = second.GetEnumerator();
            var index = 0;
            checked
            {
                while (true)
                {
                    var isFirstCompleted = index == first.Count;
                    var isSecondCompleted = !secondEnumerator.MoveNext();

                    if (isFirstCompleted && isSecondCompleted)
                        return -1;

                    if (isFirstCompleted ^ isSecondCompleted)
                        return index;

                    if (!EqualityComparer<T>.Default.Equals(first[index], secondEnumerator.Current))
                        return index;

                    index++;
                }
            }
        }
    }
}
