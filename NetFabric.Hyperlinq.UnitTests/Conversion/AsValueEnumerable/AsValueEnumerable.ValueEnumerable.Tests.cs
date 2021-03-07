using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsValueEnumerable
{
    public class ValueEnumerableTests
    {
        [Fact]
        public void AsValueEnumerable_Must_ReturnCopy()
        {
            // Arrange
            var source = Array.Empty<int>();
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            var result = wrapped
                .AsValueEnumerable();

            // Assert
            _ = result.Must()
                .BeOfType<ValueEnumerableExtensions.ValueEnumerable<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, Wrap.Enumerator<int>, int, Wrap.ValueEnumerableWrapper<int>.GetEnumeratorFunction, Wrap.ValueEnumerableWrapper<int>.GetEnumeratorFunction>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(source);
        }
    }
}