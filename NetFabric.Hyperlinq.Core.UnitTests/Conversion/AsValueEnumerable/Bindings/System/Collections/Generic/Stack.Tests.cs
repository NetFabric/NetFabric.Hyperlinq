using NetFabric.Assertive;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsValueEnumerable.Bindings.System.Collections.Generic
{
    public class StackTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_Stack_Must_ReturnWrapper(int[] source)
        {
            // Arrange
            var wrapped = new Stack<int>(source);

            // Act
            var result = wrapped.AsValueEnumerable();

            // Assert
            _ = result.Must()
                .BeOfType<ReadOnlyCollectionExtensions.ValueEnumerable<Stack<int>, Stack<int>.Enumerator, Stack<int>.Enumerator, int, StackExtensions.GetEnumerator<int>, StackExtensions.GetEnumerator<int>>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(wrapped);
        }
    }
}
