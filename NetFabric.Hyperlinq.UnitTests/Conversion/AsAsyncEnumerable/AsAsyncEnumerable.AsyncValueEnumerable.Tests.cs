using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsAsyncEnumerable
{
    public class AsyncValueEnumerableTests
    {
        [Fact]
        public void AsAsyncEnumerable_With_ValueType_Must_ReturnCopy()
        {
            // Arrange
            var source = new int[0];
            var wrapped = Wrap.AsAsyncValueEnumerable(source);

            // Act
            var result = AsyncValueEnumerableExtensions
                .AsAsyncEnumerable<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped);

            // Assert
            _ = result.Must()
                .BeEqualTo(wrapped);
        }
        
        [Fact]
        public void AsAsyncEnumerable_With_ReferenceType_Must_ReturnSame()
        {
            // Arrange
            var source = new int[0];
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source) as IAsyncValueEnumerable<int, Wrap.AsyncEnumerator<int>>;

            // Act
            var result = AsyncValueEnumerableExtensions
                .AsAsyncEnumerable<IAsyncValueEnumerable<int, Wrap.AsyncEnumerator<int>>, Wrap.AsyncEnumerator<int>, int>(wrapped);

            // Assert
            _ = result.Must()
                .BeSameAs(wrapped);
        }
    }
}