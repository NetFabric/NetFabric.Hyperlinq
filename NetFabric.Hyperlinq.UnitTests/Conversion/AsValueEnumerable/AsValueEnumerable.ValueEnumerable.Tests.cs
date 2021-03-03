using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsValueEnumerable
{
    public class ValueEnumerableTests
    {
        [Fact]
        public void AsValueEnumerable_With_ValueType_Must_ReturnCopy()
        {
            // Arrange
            var source = Array.Empty<int>();
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            var result = wrapped
                .AsValueEnumerable<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>();

            // Assert
            _ = result.Must()
                .BeEqualTo(wrapped);
        }
        
        [Fact]
        public void AsValueEnumerable_With_ReferenceType_Must_ReturnSame()
        {
            // Arrange
            var source = Array.Empty<int>();
            var wrapped = Wrap
                .AsValueEnumerable(source) as IValueEnumerable<int, Wrap.Enumerator<int>>;

            // Act
            var result = wrapped
                .AsValueEnumerable<IValueEnumerable<int, Wrap.Enumerator<int>>, Wrap.Enumerator<int>, int>();

            // Assert
            _ = result.Must()
                .BeSameAs(wrapped);
        }
    }
}