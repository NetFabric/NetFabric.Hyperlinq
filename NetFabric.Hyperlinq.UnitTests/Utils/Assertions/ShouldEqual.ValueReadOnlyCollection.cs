using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq.UnitTests.Utils
{
    public static class ValueReadOnlyCollection
    {
        public static void ShouldEqual<TEnumerable, TEnumerator, TSource>(TEnumerable source, IEnumerable<TSource> expected)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
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
                    var isSourceCompleted = !sourceEnumerator.MoveNext();
                    var isEnumerableOfTypeCompleted = !enumerableOfTypeEnumerator.MoveNext();
                    var isEnumerableCompleted = !enumerableEnumerator.MoveNext();
                    var isExpectedCompleted = !expectedEnumerator.MoveNext();

                    if (isSourceCompleted && isEnumerableOfTypeCompleted && isEnumerableCompleted && isExpectedCompleted)
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

                if (source.Count != index)
                    throw new Exception($"Count property is {source.Count} but expected {index}.");
            }
            finally
            {
                if (sourceEnumerator is IDisposable disposable)
                    disposable.Dispose();
                enumerableOfTypeEnumerator.Dispose();
                expectedEnumerator.Dispose();
            }
        }
    }
}
