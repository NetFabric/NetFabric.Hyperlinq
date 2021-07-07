using System.Linq;
using NetFabric.Assertive;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsAsyncValueEnumerable
{
    public partial class AsyncValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsAsyncValueEnumerable6_Enumerator_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);

            // Act
            var result = AsyncValueEnumerableExtensions
                .AsAsyncValueEnumerable<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(
                    wrapped,
                    (enumerable, _) => enumerable.GetAsyncEnumerator());

            // Assert
            _ = result.Must()
                .BeAsyncEnumerableOf<int>()
                .BeEqualTo(source);
        }
        
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsAsyncValueEnumerable6_Enumerator2_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);

            // Act
            var result = AsyncValueEnumerableExtensions
                .AsAsyncValueEnumerable<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, AsyncValueEnumerator<int>, int>(
                    wrapped,
                    (enumerable, _) => enumerable.GetAsyncEnumerator(),
                    (enumerable, cancellationToken) =>
                    new AsyncValueEnumerator<int>(
                        ((IAsyncEnumerable<int>)enumerable).GetAsyncEnumerator(cancellationToken)));

            // Assert
            _ = result.Must()
                .BeAsyncEnumerableOf<int>()
                .BeEqualTo(source);
        }
        
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public async Task AsAsyncValueEnumerable6_Sum_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = source
                .Sum();

            // Act
            var result = await AsyncValueEnumerableExtensions
                .AsAsyncValueEnumerable<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, AsyncValueEnumerator<int>, int>(
                    wrapped,
                    (enumerable, _) => enumerable.GetAsyncEnumerator(), 
                    (enumerable, cancellationToken) => new AsyncValueEnumerator<int>(((IAsyncEnumerable<int>)enumerable).GetAsyncEnumerator(cancellationToken)))
                .SumAsync()
                .ConfigureAwait(false);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}