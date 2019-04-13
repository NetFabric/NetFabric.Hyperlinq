using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SkipValueReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.Skip), MemberType = typeof(TestData))]
        public void Skip_With_ValidData_Should_Succeed(IReadOnlyList<int> source, int count, IReadOnlyList<int> expected)
        {
            // Arrange

            // Act
            var result = ValueReadOnlyList.Skip<
                ReadOnlyList.AsValueEnumerableEnumerable<IReadOnlyList<int>, IEnumerator<int>, int>, 
                ReadOnlyList.AsValueEnumerableEnumerable<IReadOnlyList<int>, IEnumerator<int>, int>.ValueEnumerator, 
                int>(source.AsValueEnumerable(), count);

            // Assert
            result.Should().Generate(expected);

            var index = 0;
            var resultEnumerator = result.GetEnumerator();
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