using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Aggregation.Sum
{
    public class ArrayTests
    {

        [Theory]
        [MemberData(nameof(TestData.Sum), MemberType = typeof(TestData))]
        public void Sum_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = (ReadOnlySpan<int>)source.AsSpan();
            var expected = source
                .Sum();

            // Act
            var result = wrapped.AsValueEnumerable()
                .Sum();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.NullableSum), MemberType = typeof(TestData))]
        public void Sum_With_Nullable_ValidData_Must_Succeed(int?[] source)
        {
            // Arrange
            var wrapped = (ReadOnlySpan<int?>)source.AsSpan();
            var expected = source
                .Sum();

            // Act
            var result = wrapped.AsValueEnumerable()
                .Sum();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected.Value);
        }
    }
}