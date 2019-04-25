using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class RangeTests
    {
        [Theory]
        [InlineData(-1)]
        public void Range_With_NegativeCount_Should_Throw(long count)
        {
            // Arrange

            // Act
            Action action = () => Enumerable.Range(0, count);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentOutOfRangeException>()
                .And
                .ParamName.Should()
                    .Be("count");
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(1, 2)]
        [InlineData(1, -1)]
        public void Indexer_With_IndexOutOfRange_Should_Throw(long count, long index)
        {
            // Arrange

            // Act
            Func<long> action = () => Enumerable.Range(0, count)[index];

            // Assert
            action.Should().ThrowExactly<IndexOutOfRangeException>();
        }
  
        [Theory]
        [MemberData(nameof(TestData.Range), MemberType = typeof(TestData))]
        public void Range_With_ValidData_Should_Succeed(long start, long count, IReadOnlyList<long> expected)
        {
            // Arrange

            // Act
            var result = Enumerable.Range(start, count);

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
  
        [Theory]
        [MemberData(nameof(TestData.RangeSkip), MemberType = typeof(TestData))]
        public void Range_With_Skip_Should_Succeed(long start, long count, long skipCount, IReadOnlyList<long> expected)
        {
            // Arrange

            // Act
            var result = Enumerable.Range(start, count).Skip(skipCount);

            // Assert
            result.AsEnumerable().Should().Equal(expected);
        }
  
        [Theory]
        [MemberData(nameof(TestData.RangeTake), MemberType = typeof(TestData))]
        public void Range_With_Take_Should_Succeed(long start, long count, long takeCount, IReadOnlyList<long> expected)
        {
            // Arrange

            // Act
            var result = Enumerable.Range(start, count).Take(takeCount);

            // Assert
            result.AsEnumerable().Should().Equal(expected);
        }
  
        [Theory]
        [MemberData(nameof(TestData.RangeSkipTake), MemberType = typeof(TestData))]
        public void Range_With_SkipTake_Should_Succeed(long start, long count, long skipCount, long takeCount, IReadOnlyList<long> expected)
        {
            // Arrange

            // Act
            var result = Enumerable.Range(start, count).Skip(skipCount).Take(takeCount);

            // Assert
            result.AsEnumerable().Should().Equal(expected);
        }
    }
}