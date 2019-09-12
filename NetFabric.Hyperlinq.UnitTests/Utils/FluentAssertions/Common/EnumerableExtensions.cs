using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace FluentAssertions.Common
{
    static class EnumerableExtensions
    {
        public static int IndexOfFirstDifferenceWith(this object first, IEnumerable second)
        {
            var enumerableType = first.GetType();
            var getEnumerator = enumerableType.GetMethodGetEnumerator();

            var enumeratorType = getEnumerator.ReturnType;
            var current = enumeratorType.GetPropertyCurrent();
            var moveNext = enumeratorType.GetMethodMoveNext();
            var dispose = enumeratorType.GetMethodDispose();

#if !NETSTANDARD2_1
            if (current.PropertyType.IsByRef)
                return -1; // ??????
#endif

            var firstEnumerator = getEnumerator.Invoke(first, Array.Empty<object>());
            var secondEnumerator = second.GetEnumerator();
            try
            {
                checked
                {
                    for (var index = 0; true; index++)
                    {
                        var isFirstCompleted = !(bool)moveNext.Invoke(firstEnumerator, Array.Empty<object>());
                        var isSecondCompleted = !secondEnumerator.MoveNext();

                        if (isFirstCompleted && isSecondCompleted)
                            return -1;

                        if (isFirstCompleted ^ isSecondCompleted)
                            return index;

                        if (!current.GetValue(firstEnumerator).Equals(secondEnumerator.Current))
                            return index;
                    }
                }
            }
            finally
            {
                dispose?.Invoke(firstEnumerator, Array.Empty<object>());
            }
        }

        public static int IndexOfFirstDifferenceWith(this IEnumerable first, IEnumerable second)
        {
            var firstEnumerator = first.GetEnumerator();
            var secondEnumerator = second.GetEnumerator();
            checked
            {
                for (var index = 0; true; index++)
                {
                    var isFirstCompleted = !firstEnumerator.MoveNext();
                    var isSecondCompleted = !secondEnumerator.MoveNext();

                    if (isFirstCompleted && isSecondCompleted)
                        return -1;

                    if (isFirstCompleted ^ isSecondCompleted)
                        return index;

                    if (!firstEnumerator.Current.Equals(secondEnumerator.Current))
                        return index;
                }
            }
        }

        public static int IndexOfFirstDifferenceWith<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            using var firstEnumerator = first.GetEnumerator();
            using var secondEnumerator = second.GetEnumerator();
            checked
            {
                for (var index = 0; true; index++)
                {
                    var isFirstCompleted = !firstEnumerator.MoveNext();
                    var isSecondCompleted = !secondEnumerator.MoveNext();

                    if (isFirstCompleted && isSecondCompleted)
                        return -1;

                    if (isFirstCompleted ^ isSecondCompleted)
                        return index;

                    if (!EqualityComparer<T>.Default.Equals(firstEnumerator.Current, secondEnumerator.Current))
                        return index;
                }
            }
        }

        public static int IndexOfFirstDifferenceWith<T>(this IReadOnlyList<T> first, IEnumerable<T> second)
        {
            using var secondEnumerator = second.GetEnumerator();
            checked
            {
                for (var index = 0; true; index++)
                {
                    var isFirstCompleted = index == first.Count;
                    var isSecondCompleted = !secondEnumerator.MoveNext();

                    if (isFirstCompleted && isSecondCompleted)
                        return -1;

                    if (isFirstCompleted ^ isSecondCompleted)
                        return index;

                    if (!EqualityComparer<T>.Default.Equals(first[index], secondEnumerator.Current))
                        return index;
                }
            }
        }
    }
}
