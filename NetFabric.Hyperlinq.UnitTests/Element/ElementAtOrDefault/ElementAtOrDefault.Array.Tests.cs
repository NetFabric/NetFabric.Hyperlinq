using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public partial class ArrayTests
    {
        [Theory]
        [MemberData(nameof(TestData.ElementAtOutOfRange), MemberType = typeof(TestData))]
        public void ElementAtOrDefault_With_OutOfRange_Should_ReturnDefault(int[] source, int index)
        {
            // Arrange

            // Act
            var result = source
                .ElementAtOrDefault<int>(index);

            // Assert
            _ = result.Must()
                .BeEqualTo(default);
        }

        [Theory]
        [MemberData(nameof(TestData.ElementAt), MemberType = typeof(TestData))]
        public void ElementAtOrDefault_With_ValidData_Should_Succeed(int[] source, int index)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.ElementAtOrDefault(source, index);

            // Act
            var result = source
                .ElementAtOrDefault<int>(index);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}