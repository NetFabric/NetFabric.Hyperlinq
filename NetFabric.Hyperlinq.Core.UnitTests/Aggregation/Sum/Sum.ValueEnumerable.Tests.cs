using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Aggregation.Sum
{
    public class ValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.SumDouble), MemberType = typeof(TestData))]
        public void Sum_With_Double_Must_Succeed(double[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
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
        [MemberData(nameof(TestData.SumNullableDouble), MemberType = typeof(TestData))]
        public void Sum_With_NullableDouble_Must_Succeed(double?[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = source
                .Sum();

            // Act
            var result = wrapped.AsValueEnumerable()
                .Sum();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected!.Value);
        }
        
        [Theory]
        [MemberData(nameof(TestData.SumDecimal), MemberType = typeof(TestData))]
        public void Sum_With_Decimal_Must_Succeed(decimal[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
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
        [MemberData(nameof(TestData.SumNullableDecimal), MemberType = typeof(TestData))]
        public void Sum_With_NullableDecimal_Must_Succeed(decimal?[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = source
                .Sum();

            // Act
            var result = wrapped.AsValueEnumerable()
                .Sum();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected!.Value);
        }
    }
}