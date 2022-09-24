using NetFabric.Assertive;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Aggregation.Sum
{
    public class AsyncValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.SumDouble), MemberType = typeof(TestData))]
        public async Task SumAsync_With_Double_Must_Succeed(double[] source)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var expected = source
                .Sum();

            // Act
            var result = await wrapped.AsAsyncValueEnumerable()
                .SumAsync()
                .ConfigureAwait(false);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SumNullableDouble), MemberType = typeof(TestData))]
        public async Task SumAsync_With_NullableDouble_Must_Succeed(double?[] source)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var expected = source
                .Sum();

            // Act
            var result = await wrapped.AsAsyncValueEnumerable()
                .SumAsync()
                .ConfigureAwait(false);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected!.Value);
        }
        
        [Theory]
        [MemberData(nameof(TestData.SumDecimal), MemberType = typeof(TestData))]
        public async Task SumAsync_With_Decimal_Must_Succeed(decimal[] source)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var expected = source
                .Sum();

            // Act
            var result = await wrapped.AsAsyncValueEnumerable()
                .SumAsync()
                .ConfigureAwait(false);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SumNullableDecimal), MemberType = typeof(TestData))]
        public async Task SumAsync_With_NullableDecimal_Must_Succeed(decimal?[] source)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var expected = source
                .Sum();

            // Act
            var result = await wrapped.AsAsyncValueEnumerable()
                .SumAsync()
                .ConfigureAwait(false);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected!.Value);
        }
    }
}