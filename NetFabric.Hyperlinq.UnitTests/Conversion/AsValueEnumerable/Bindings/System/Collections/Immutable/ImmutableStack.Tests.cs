using NetFabric.Assertive;
using System.Collections.Generic;
using System.Collections.Immutable;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsValueEnumerable.Bindings.System.Collections.Immutable
{
    public class ImmutableStackTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_ImmutableStack_Must_ReturnWrapper(int[] source)
        {
            // Arrange
            var wrapped = ImmutableStack.Create(source);

            // Act
            var result = wrapped.AsValueEnumerable();

            // Assert
            _ = result.Must()
                .BeOfType<EnumerableExtensions.ValueEnumerable<ImmutableStack<int>, ValueEnumerator<int>, ImmutableStack<int>.Enumerator, int, ImmutableStackExtensions.GetEnumerator<int>, ImmutableStackExtensions.GetEnumerator2<int>>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(wrapped);
        }
    }
}
