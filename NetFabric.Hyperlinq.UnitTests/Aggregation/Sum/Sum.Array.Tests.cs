using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Aggregation.Sum
{
    public class ArrayTests
    {
        public static TheoryData<int[]> Sum =>
            new TheoryData<int[]>
            {
                { new int[] { 1, 2, 3, 4, 5, 6, 7 } },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8 } },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 } },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 } },
            };


        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        [MemberData(nameof(Sum))]
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