using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Projection.Select
{
    public class SpanTests
    {
        [Fact]
        public void Select_With_NullSelector_Must_Throw()
        {
            // Arrange
            var source = new int[0];
            var selector = (Selector<int, string>)null;

            // Act
            Action action = () => _ = Array.Select(source.AsSpan(), selector);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "selector");
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public void Select_With_ValidData_Must_Succeed(int[] source, Selector<int, string> selector)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.Select(source, selector.AsFunc());

            // Act
            var result = Array.Select(source.AsSpan(), selector);

            // Assert
            var resultEnumerator = result.GetEnumerator();
            using var expectedEnumerator = expected.GetEnumerator();
            while (true)
            {
                var resultEnded = !resultEnumerator.MoveNext();
                var expectedEnded = !expectedEnumerator.MoveNext();

                if (resultEnded != expectedEnded)
                    throw new Exception("Not same size");

                if (resultEnded)
                    break;

                if (resultEnumerator.Current != expectedEnumerator.Current)
                    throw new Exception("Items are not equal");
            }
        }
    }
}