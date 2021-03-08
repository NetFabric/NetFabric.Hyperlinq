using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Aggregation.Sum
{
    public class ValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Sum), MemberType = typeof(TestData))]
        public void Sum_With_ValidData_Must_Succeed(double[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = source
                .Sum();

            // Act
            var result = wrapped
                .Sum<Wrap.ValueEnumerableWrapper<double>, Wrap.Enumerator<double>, double, double>();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.NullableSum), MemberType = typeof(TestData))]
        public void Sum_With_Nullable_ValidData_Must_Succeed(double?[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = source
                .Sum();

            // Act
            var result = wrapped
                .Sum<Wrap.ValueEnumerableWrapper<double?>, Wrap.Enumerator<double?>, double?, double>();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected!.Value);
        }
    }
}