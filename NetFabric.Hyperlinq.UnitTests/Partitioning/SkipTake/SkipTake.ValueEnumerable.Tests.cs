using FluentAssertions;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SkipTakeValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.SkipTake), MemberType = typeof(TestData))]
        public void SkipTake_With_ValidData_Should_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = System.Linq.Enumerable.Skip(wrapped, skipCount).Take(takeCount);

            // Act
            var result = ValueEnumerable.SkipTake<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerable<int>.Enumerator, int>(wrapped, skipCount, takeCount);

            // Assert
            result.Should().Equals(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTake_Take), MemberType = typeof(TestData))]
        public void SkipTake_Take_With_ValidData_Should_Succeed(int[] source, int skipCount, int takeCount0, int takeCount1)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = System.Linq.Enumerable.Skip(wrapped, skipCount).Take(takeCount1).Take(takeCount1);

            // Act
            var result = ValueEnumerable.SkipTake<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerable<int>.Enumerator, int>(wrapped, skipCount, takeCount0).Take(takeCount1);

            // Assert
            result.Should().Equals(expected);
        }
    }
}