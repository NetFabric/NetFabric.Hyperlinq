using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsAsyncValueEnumerable
{
    public class AsyncValueEnumerableTests
    {
        [Fact]
        public void AsAsyncValueEnumerable_With_ValueType_Must_ReturnCopy()
        {
            // Arrange
            var source = new int[0];
            var wrapped = Wrap.AsAsyncValueEnumerable(source);

            // Act
            var result = AsyncValueEnumerableExtensions
                .AsAsyncValueEnumerable<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped);

            // Assert
            _ = result.Must()
                .BeEqualTo(wrapped);
        }
        
        [Fact]
        public void AsAsyncValueEnumerable_With_ReferenceType_Must_ReturnSame()
        {
            // Arrange
            var source = new int[0];
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source) as IAsyncValueEnumerable<int, Wrap.AsyncEnumerator<int>>;

            // Act
            var result = AsyncValueEnumerableExtensions
                .AsAsyncValueEnumerable<IAsyncValueEnumerable<int, Wrap.AsyncEnumerator<int>>, Wrap.AsyncEnumerator<int>, int>(wrapped);

            // Assert
            _ = result.Must()
                .BeSameAs(wrapped);
        }
    }
}