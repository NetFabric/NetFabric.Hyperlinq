using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq.UnitTests.Utils
{
    public static class ValueEnumerable
    {
        public static void ShouldEqual<TEnumerable, TEnumerator, TSource>(TEnumerable source, IEnumerable<TSource> expected)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var publicEnumerator = source.GetEnumerator();
            var valueEnumerableEnumerator = ((IValueEnumerable<TSource, TEnumerator>)source).GetEnumerator();
            var enumerableOfTypeEnumerator = ((IEnumerable<TSource>)source).GetEnumerator();
            var enumerableEnumerator = ((IEnumerable)source).GetEnumerator();
            var expectedEnumerator = expected.GetEnumerator();
            try
            {
                var index = 0;
                while (true)
                {
                    var isPublicCompleted = !publicEnumerator.MoveNext();
                    var isValueEnumerableCompleted = !valueEnumerableEnumerator.MoveNext();
                    var isEnumerableOfTypeCompleted = !enumerableOfTypeEnumerator.MoveNext();
                    var isEnumerableCompleted = !enumerableEnumerator.MoveNext();
                    var isExpectedCompleted = !expectedEnumerator.MoveNext();

                    if (isPublicCompleted && isValueEnumerableCompleted && isEnumerableOfTypeCompleted && isEnumerableCompleted && isExpectedCompleted)
                        break;

                    if (isPublicCompleted ^ isExpectedCompleted)
                        throw new Exception($"Public enumerable stopped at length {index}.");

                    if (isValueEnumerableCompleted ^ isExpectedCompleted)
                        throw new Exception($"IValueEnumerable<,> enumerable stopped at length {index}.");

                    if (isEnumerableOfTypeCompleted ^ isExpectedCompleted)
                        throw new Exception($"IEnumerable<> stopped at length {index}.");

                    if (isEnumerableCompleted ^ isExpectedCompleted)
                        throw new Exception($"IEnumerable stopped at length {index}.");

                    if (!EqualityComparer<TSource>.Default.Equals(publicEnumerator.Current, expectedEnumerator.Current))
                        throw new Exception($"Enumerator item at index {index} is {publicEnumerator.Current} but expected {expectedEnumerator.Current}.");

                    if (!EqualityComparer<TSource>.Default.Equals(enumerableOfTypeEnumerator.Current, expectedEnumerator.Current))
                        throw new Exception($"Enumerator item at index {index} is {publicEnumerator.Current} but expected {expectedEnumerator.Current}.");

                    if (!EqualityComparer<TSource>.Default.Equals((TSource)enumerableEnumerator.Current, expectedEnumerator.Current))
                        throw new Exception($"Enumerator item at index {index} is {publicEnumerator.Current} but expected {expectedEnumerator.Current}.");

                    index++;
                }
            }
            finally
            {
                if (publicEnumerator is IDisposable disposable)
                    disposable.Dispose();
                valueEnumerableEnumerator.Dispose();
                enumerableOfTypeEnumerator.Dispose();
                expectedEnumerator.Dispose();
            }
        }
    }
}
