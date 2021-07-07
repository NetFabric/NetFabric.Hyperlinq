using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Quantifier.ContainsVector
{
    public class ReadOnlySpanTests
    {

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ContainsVector_With_NotContains_Must_ReturnFalse(int[] source)
        {
            // Arrange
            const int value = int.MaxValue;
            var wrapped = (ReadOnlySpan<int>)source.AsSpan();

            // Act
            var result = wrapped.AsValueEnumerable()
                .ContainsVector(value);

            // Assert
            _ = result.Must()
                .BeFalse();
        }

        [Theory]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ContainsVector_With_Contains_Must_ReturnTrue(int[] source)
        {
            // Arrange
            var value = source
                .Last();
            var wrapped = (ReadOnlySpan<int>)source.AsSpan();

            // Act
            var result = wrapped.AsValueEnumerable()
                .ContainsVector(value);

            // Assert
            _ = result.Must()
                .BeTrue();
        }

    }
}