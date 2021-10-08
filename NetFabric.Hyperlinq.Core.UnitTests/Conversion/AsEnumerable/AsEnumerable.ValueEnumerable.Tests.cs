using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsEnumerable
{
    public class ValueEnumerableTests
    {
        [Fact]
        public void AsEnumerable_With_ValueType_Must_ReturnCopy()
        {
            // Arrange
            var source = new int[0];
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            var result = ValueEnumerableExtensions
                .AsEnumerable<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>(wrapped);

            // Assert
            _ = result.Must()
                .BeEqualTo(wrapped);
        }
        
        [Fact]
        public void AsEnumerable_With_ReferenceType_Must_ReturnSame()
        {
            // Arrange
            var source = new int[0];
            var wrapped = Wrap
                .AsValueEnumerable(source) as IValueEnumerable<int, Wrap.Enumerator<int>>;

            // Act
            var result = ValueEnumerableExtensions
                .AsEnumerable<IValueEnumerable<int, Wrap.Enumerator<int>>, Wrap.Enumerator<int>, int>(wrapped);

            // Assert
            _ = result.Must()
                .BeSameAs(wrapped);
        }
    }
}