using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Aggregation.Sum
{
    public class ArrayTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Sum_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var expected = Enumerable
                .Sum(source);

            // Act
            var result = source.AsValueEnumerable()
                .Sum();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        public static TheoryData<int?[]> NullableSum =>
            new TheoryData<int?[]>
            {
                { new int?[] { null } },
                { new int?[] { null, null, null } },
                { new int?[] { null, 2, 3, 4, null } },
                { new int?[] { 1, 2, null, 4, 5 } },
            };

        [Theory]
        [MemberData(nameof(NullableSum))]
        public void Sum_With_Nullable_ValidData_Must_Succeed(int?[] source)
        {
            // Arrange
            var expected = Enumerable
                .Sum(source);

            // Act
            var result = source.AsValueEnumerable()
                .Sum();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected.Value);
        }
    }
}