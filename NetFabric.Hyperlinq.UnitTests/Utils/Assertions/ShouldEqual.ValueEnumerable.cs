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
            var sourceEnumerator = source.GetEnumerator();
            var enumerableOfTypeEnumerator = ((IEnumerable<TSource>)source).GetEnumerator();
            var enumerableEnumerator = ((IEnumerable)source).GetEnumerator();
            var expectedEnumerator = expected.GetEnumerator();
            try
            {
                var index = 0;
                while (true)
                {
                    bool isSourceCompleted = !sourceEnumerator.MoveNext();
                    bool isEnumerableOfTypeCompleted = !enumerableOfTypeEnumerator.MoveNext();
                    bool isEnumerableCompleted = !enumerableEnumerator.MoveNext();
                    bool isExpectedCompleted = !expectedEnumerator.MoveNext();

                    if (isSourceCompleted && isExpectedCompleted && isEnumerableOfTypeCompleted && isExpectedCompleted)
                        break;

                    if (isSourceCompleted ^ isExpectedCompleted)
                        throw new Exception($"Enumerator stopped at length {index}.");

                    if (isEnumerableOfTypeCompleted ^ isExpectedCompleted)
                        throw new Exception($"IEnumerator<T> stopped at length {index}.");

                    if (isEnumerableCompleted ^ isExpectedCompleted)
                        throw new Exception($"IEnumerator stopped at length {index}.");

                    if (!EqualityComparer<TSource>.Default.Equals(sourceEnumerator.Current, expectedEnumerator.Current))
                        throw new Exception($"Enumerator item at index {index} is {sourceEnumerator.Current} but expected {expectedEnumerator.Current}.");

                    if (!EqualityComparer<TSource>.Default.Equals(enumerableOfTypeEnumerator.Current, expectedEnumerator.Current))
                        throw new Exception($"Enumerator item at index {index} is {sourceEnumerator.Current} but expected {expectedEnumerator.Current}.");

                    if (!EqualityComparer<TSource>.Default.Equals((TSource)enumerableEnumerator.Current, expectedEnumerator.Current))
                        throw new Exception($"Enumerator item at index {index} is {sourceEnumerator.Current} but expected {expectedEnumerator.Current}.");

                    index++;
                }
            }
            finally
            {
                if (sourceEnumerator is IDisposable disposable)
                    disposable.Dispose();
                expectedEnumerator.Dispose();
            }
        }
    }
}
