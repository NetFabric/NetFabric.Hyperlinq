using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsValueEnumerable
{
    public class ValueEnumerableTests
    {
        [Fact]
        public void AsValueEnumerable_With_ValueType_Must_ReturnCopy()
        {
            // Arrange
            var source = new int[0];
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            var result = ValueEnumerableExtensions
                .AsValueEnumerable<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>(wrapped);

            // Assert
            _ = result.Must()
                .BeEqualTo(wrapped);
        }
        
        [Fact]
        public void AsValueEnumerable_With_ReferenceType_Must_ReturnSame()
        {
            // Arrange
            var source = new int[0];
            var wrapped = Wrap
                .AsValueEnumerable(source) as IValueEnumerable<int, Wrap.Enumerator<int>>;

            // Act
            var result = ValueEnumerableExtensions
                .AsValueEnumerable<IValueEnumerable<int, Wrap.Enumerator<int>>, Wrap.Enumerator<int>, int>(wrapped);

            // Assert
            _ = result.Must()
                .BeSameAs(wrapped);
        }
    }
}