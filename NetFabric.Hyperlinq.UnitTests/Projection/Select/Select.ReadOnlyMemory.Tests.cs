using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Projection.Select
{
    public class ReadOnlyMemoryTests
    {
        [Fact]
        public void Select_With_NullSelector_Must_Throw()
        {
            // Arrange
            var source = new int[0];
            var selector = (NullableSelector<int, string>)null;

            // Act
            Action action = () => _ = ArrayExtensions.Select((ReadOnlyMemory<int>)source.AsMemory(), selector);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "selector");
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public void Select_With_ValidData_Must_Succeed(int[] source, NullableSelector<int, string> selector)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.Select(source, selector.AsFunc());

            // Act
            var result = ArrayExtensions.Select((ReadOnlyMemory<int>)source.AsMemory(), selector);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected, testRefStructs: false, testRefReturns: false);
            _ = result.SequenceEqual(expected).Must().BeTrue();
        }
    }
}