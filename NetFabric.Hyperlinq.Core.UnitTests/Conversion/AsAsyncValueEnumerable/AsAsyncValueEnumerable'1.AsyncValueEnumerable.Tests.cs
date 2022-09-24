using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsAsyncValueEnumerable
{
    public partial class AsyncValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsAsyncValueEnumerable1_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);

            // Act
            var result = wrapped
                .AsAsyncValueEnumerable();

            // Assert
            _ = result.Must()
                .BeOfType<AsyncValueEnumerableExtensions.AsyncValueEnumerable<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, Wrap.AsyncEnumerator<int>, int, Wrap.AsyncValueEnumerableWrapper<int>.GetAsyncEnumeratorFunction, Wrap.AsyncValueEnumerableWrapper<int>.GetAsyncEnumeratorFunction>>()
                .BeAsyncEnumerableOf<int>()
                .BeEqualTo(source);
        }
        
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public async Task AsAsyncValueEnumerable1_Sum_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = source
                .Sum();

            // Act
            var result = await wrapped
                .AsAsyncValueEnumerable()
                .SumAsync()
                .ConfigureAwait(false);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}
