using System;
using System.Collections;
using System.Collections.Generic;

namespace FluentAssertions.Common
{
    internal static class EnumerableExtensions
    {
        /// <summary>
        /// Searches for the first different element in two sequences using specified <paramref name="equalityComparison" />
        /// </summary>
        /// <param name="first">The first sequence to compare.</param>
        /// <param name="enumerableType">The <see cref="Type" /> to call GetEnumerator() from for first sequence.</param>
        /// <param name="second">The second sequence to compare.</param>
        /// <param name="equalityComparison">Method that is used to compare 2 elements with the same index.</param>
        /// <returns>Index at which two sequences have elements that are not equal, or -1 if enumerables are equal</returns>
        public static int IndexOfFirstDifferenceWith(this object first, Type enumerableType, IEnumerable second, Func<object, object, bool> equalityComparison)
        {
            var getEnumerator = enumerableType.GetPublicOrExplicitParameterlessMethod("GetEnumerator");

            var enumeratorType = getEnumerator.ReturnType;
            var current = enumeratorType.GetPublicOrExplicitProperty("Current");
            var moveNext = enumeratorType.GetPublicOrExplicitParameterlessMethod("MoveNext");
            var dispose = enumeratorType.GetPublicOrExplicitParameterlessMethod("Dispose");

#if !NETSTANDARD2_1
            // 'Current' may return by-ref but reflection only supports its invocation on netstandard 2.1
            if (current.PropertyType.IsByRef)
                return -1; // what should we do here?????
#endif

            var firstEnumerator = getEnumerator.Invoke(first, new object[0]);
            var secondEnumerator = second.GetEnumerator();
            try
            {
                checked
                {
                    for (var index = 0; true; index++)
                    {
                        var isFirstCompleted = !(bool)moveNext.Invoke(firstEnumerator, new object[0]);
                        var isSecondCompleted = !secondEnumerator.MoveNext();

                        if (isFirstCompleted && isSecondCompleted)
                        {
                            return -1;
                        }

                        if (isFirstCompleted ^ isSecondCompleted)
                        {
                            return index;
                        }

                        if (!equalityComparison(current.GetValue(firstEnumerator), secondEnumerator.Current))
                        {
                            return index;
                        }
                    }
                }
            }
            finally
            {
                dispose?.Invoke(firstEnumerator, new object[0]);
            }
        }

        /// <summary>
        /// Searches for the first different element in two sequences using specified <paramref name="equalityComparison" />
        /// </summary>
        /// <param name="first">The first sequence to compare.</param>
        /// <param name="second">The second sequence to compare.</param>
        /// <param name="equalityComparison">Method that is used to compare 2 elements with the same index.</param>
        /// <returns>Index at which two sequences have elements that are not equal, or -1 if enumerables are equal</returns>
        public static int IndexOfFirstDifferenceWith(this IEnumerable first, IEnumerable second, Func<object, object, bool> equalityComparison)
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
                    {
                        return -1;
                    }

                    if (isFirstCompleted ^ isSecondCompleted)
                    {
                        return index;
                    }

                    if (!equalityComparison(firstEnumerator.Current, secondEnumerator.Current))
                    {
                        return index;
                    }
                }
            }
        }

        /// <summary>
        /// Searches for the first different element in two sequences using specified <paramref name="equalityComparison" />
        /// </summary>
        /// <typeparam name="TFirst">The type of the elements of the <paramref name="first" /> sequence.</typeparam>
        /// <typeparam name="TSecond">The type of the elements of the <paramref name="second" /> sequence.</typeparam>
        /// <param name="first">The first sequence to compare.</param>
        /// <param name="second">The second sequence to compare.</param>
        /// <param name="equalityComparison">Method that is used to compare 2 elements with the same index.</param>
        /// <returns>Index at which two sequences have elements that are not equal, or -1 if enumerables are equal</returns>
        public static int IndexOfFirstDifferenceWith<TFirst, TSecond>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, bool> equalityComparison)
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
                    {
                        return -1;
                    }

                    if (isFirstCompleted ^ isSecondCompleted)
                    {
                        return index;
                    }

                    if (!equalityComparison(firstEnumerator.Current, secondEnumerator.Current))
                    {
                        return index;
                    }
                }
            }
        }

        /// <summary>
        /// Searches for the first different element in two sequences using specified <paramref name="equalityComparison" />
        /// </summary>
        /// <typeparam name="TFirst">The type of the elements of the <paramref name="first" /> sequence.</typeparam>
        /// <typeparam name="TSecond">The type of the elements of the <paramref name="second" /> sequence.</typeparam>
        /// <param name="first">The first sequence to compare.</param>
        /// <param name="second">The second sequence to compare.</param>
        /// <param name="equalityComparison">Method that is used to compare 2 elements with the same index.</param>
        /// <returns>Index at which two sequences have elements that are not equal, or -1 if enumerables are equal</returns>
        public static int IndexOfFirstDifferenceWith<TFirst, TSecond>(this IReadOnlyList<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, bool> equalityComparison)
        {
            using var secondEnumerator = second.GetEnumerator();
            checked
            {
                for (var index = 0; true; index++)
                {
                    var isFirstCompleted = (index == first.Count);
                    var isSecondCompleted = !secondEnumerator.MoveNext();

                    if (isFirstCompleted && isSecondCompleted)
                    {
                        return -1;
                    }

                    if (isFirstCompleted ^ isSecondCompleted)
                    {
                        return index;
                    }

                    if (!equalityComparison(first[index], secondEnumerator.Current))
                    {
                        return index;
                    }
                }
            }
        }
    }
}
