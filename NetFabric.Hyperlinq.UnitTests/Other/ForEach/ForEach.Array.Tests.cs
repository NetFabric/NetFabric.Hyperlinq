using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public partial class ArrayTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ForEach_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var expected = 0;
            MoreLinq.Extensions.ForEachExtension.ForEach(source, item => expected += item);

            // Act
            var result = 0;
            Array.ForEach<int>(source, item => result += item);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ForEachIndex_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var expected = 0;
            MoreLinq.Extensions.ForEachExtension.ForEach(source, (item, index) => expected += item + index);

            // Act
            var result = 0;
            Array.ForEach<int>(source, (item, index) => result += item + index);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}