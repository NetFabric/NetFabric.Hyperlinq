using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SkipTakeValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.SkipTake), MemberType = typeof(TestData))]
        public void SkipTake_With_ValidData_Should_Succeed(IEnumerable<int> source, int skipCount, int takeCount, IReadOnlyCollection<int> expected)
        {
            // Arrange

            // Act
            var result = ValueEnumerable.SkipTake<
                Enumerable.AsValueEnumerableEnumerable<IEnumerable<int>, IEnumerator<int>, int>, 
                Enumerable.AsValueEnumerableEnumerable<IEnumerable<int>, IEnumerator<int>, int>.ValueEnumerator, 
                int>(source.AsValueEnumerable(), skipCount, takeCount);

            // Assert
            result.Should().Generate(expected);

            var index = 0;
            using(var resultEnumerator = result.GetEnumerator())
            using(var expectedEnumerator = expected.GetEnumerator())
            {
                while (true)
                {
                    var isResultCompleted = !resultEnumerator.MoveNext();
                    var isExpectedCompleted = !expectedEnumerator.MoveNext();

                    if (isResultCompleted && isExpectedCompleted)
                        break;

                    if (isResultCompleted ^ isExpectedCompleted)
                        throw new Exception($"foreach enumeration expected complete {isExpectedCompleted} but found {isResultCompleted} at index {index}.");

                    if(!resultEnumerator.Current.Equals(expectedEnumerator.Current))
                        throw new Exception($"foreach enumeration expected value {expectedEnumerator.Current} but found {resultEnumerator.Current} at index {index}.");

                    index++;
                }
            }
        }
    }
}