using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Quantifier.ContainsVector
{
    public class ReadOnlySpanTests
    {
#if NET5_0

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ContainsVector_With_NotContains_Must_ReturnFalse(int[] source)
        {
            // Arrange
            var value = int.MaxValue;

            // Act
            var result = ((ReadOnlySpan<int>)source.AsSpan())
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
            var value = System.Linq.Enumerable.Last(source);

            // Act
            var result = ((ReadOnlySpan<int>)source.AsSpan())
                .ContainsVector(value);

            // Assert
            _ = result.Must()
                .BeTrue();
        }

#endif
    }
}