using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsValueEnumerable
{
    public class ValueEnumerableTests
    {
        [Fact]
        public void AsValueEnumerable_With_ValueType_Should_ReturnCopy()
        {
            // Arrange
            var source = new int[0];
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            var result = ValueEnumerable
                .AsValueEnumerable<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped);

            // Assert
            _ = result.Must()
                .BeEqualTo(wrapped);
        }
        
        [Fact]
        public void AsValueEnumerable_With_ReferenceType_Should_ReturnSame()
        {
            // Arrange
            var source = new int[0];
            var wrapped = Wrap
                .AsValueEnumerable(source) as IValueEnumerable<int, Wrap.Enumerator<int>>;

            // Act
            var result = ValueEnumerable
                .AsValueEnumerable<IValueEnumerable<int, Wrap.Enumerator<int>>, Wrap.Enumerator<int>, int>(wrapped);

            // Assert
            _ = result.Must()
                .BeSameAs(wrapped);
        }
    }
}