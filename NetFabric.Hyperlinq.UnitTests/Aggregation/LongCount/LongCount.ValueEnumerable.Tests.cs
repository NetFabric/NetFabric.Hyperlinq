using FluentAssertions;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class LongCountValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Count), MemberType = typeof(TestData))]
        public void LongCount_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = System.Linq.Enumerable.LongCount(wrapped);

            // Act
            var result = ValueEnumerable.LongCount<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.CountPredicate), MemberType = typeof(TestData))]
        public void LongCountPredicate_With_ValidData_Should_Succeed(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = System.Linq.Enumerable.LongCount(wrapped, predicate);

            // Act
            var result = ValueEnumerable.LongCount<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, predicate);

            // Assert
            result.Should().Be(expected);
        }
    }
}